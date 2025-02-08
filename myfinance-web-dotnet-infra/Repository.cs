using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_domain.Entities.Base;
using myfinance_web_dotnet_infra.Interfaces.Base;

namespace myfinance_web_dotnet_infra
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
    {
        protected DbContext _dbContext;
        protected DbSet<TEntity> _dbSetContext;
        protected Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSetContext = dbContext.Set<TEntity>();

        }
        public void Cadastrar(TEntity Entidade)
        {
            if (Entidade.Id == null)
            {
                _dbSetContext.Add(Entidade);
            }
            else
            {
                _dbSetContext.Attach(Entidade);
                _dbContext.Entry(Entidade).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();
        }

        public TEntity Consultar(int id)
        {
            return _dbSetContext.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Excluir(int id)
        {
            var entidade = new TEntity() { Id = id };
            _dbContext.Attach(entidade);
            _dbContext.Remove(entidade);
            _dbContext.SaveChanges();
        }

        public List<TEntity> ListarRegistros()
        {
            return _dbSetContext.ToList();
        }
    }
}

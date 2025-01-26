using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_domain.Entities;

namespace myfinance_web_dotnet_infra
{
    public class MyFinanceDbContext : DbContext
    {
        public DbSet<PlanoConta> PlanoConta { get; set; }

        public DbSet<Transacao> Transacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sqlPassword = Environment.GetEnvironmentVariable("SA_PASSWORD");
            optionsBuilder.UseSqlServer($@"Server=myfinance-sqlserver,1433;Database=myfinance;User Id=sa;Password={sqlPassword};TrustServerCertificate=True;");
        }
    }
}

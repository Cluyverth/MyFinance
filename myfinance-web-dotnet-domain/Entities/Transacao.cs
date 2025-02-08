﻿using myfinance_web_dotnet_domain.Entities.Base;

namespace myfinance_web_dotnet_domain.Entities
{
    public class Transacao : EntityBase
    {
        public string Historico { get; set; }
        public DateTimeOffset Data { get; set; }
        public decimal Valor { get; set; }
        public int PlanoContaId { get; set; }
        public PlanoConta PlanoConta { get; set; }
    }
}

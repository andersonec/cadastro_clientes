using System;
using System.Collections.Generic;

namespace cadastroClientes.Infra.Data.Entities
{
    public class Cliente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime data_nascimento { get; set; } = new DateTime();
        public string cpf { get; set; }
        public string rg { get; set; }
        public string facebook { get; set; }
        public string linkedin { get; set; }
        public string twitter { get; set; }
        public string instagram { get; set; }
    }
}

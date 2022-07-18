using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroClientes.Infra.Data.Entities
{
    public class Telefone
    {
        public int id { get; set; }
        public string identificacao { get; set; }
        public string telefone { get; set; }
    }
}

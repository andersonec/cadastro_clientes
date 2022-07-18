using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroClientes.Domain.EntitiesDTO
{
    public class EnderecoDTO
    {
        public int id { get; set; }
        public string logradouro { get; set; }
        public string tipo_logradouro { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroClientes.Infra.Data.Entities.Relations
{
    public class cliente_endereco
    {
        public int id { get; set; }
        public int id_cliente { get; set; }
        public int id_endereco { get; set; }
    }
}

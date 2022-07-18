using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroClientes.Infra.Data.Entities
{
    public class ListagemClientes
    {
        public int quantidadeClientes { get; set; }
        public int quantidadePaginas { get; set; }
        public List<Cliente> listaClientes { get; set; } = new List<Cliente>();
    }
}

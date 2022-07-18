using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroClientes.Domain.EntitiesDTO
{
    public class ListagemClientesDTO
    {
        public int quantidadeClientes { get; set; }
        public int quantidadePaginas { get; set; }
        public List<ClienteDTO> listaClientes { get; set; } = new List<ClienteDTO>();
    }
}

using cadastroClientes.Domain.EntitiesDTO;
using cadastroClientes.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroClientes.Infra.CrossCutting.Adapter.Mapper.IMapper
{
    public interface IClienteMapper
    {
        ClienteDTO ClienteToDTO(Cliente cliente);
        List<ClienteDTO> ListClienteToDTO(List<Cliente> clientes);
        ClienteDetalhesDTO ClienteToDetalhesDTO(Cliente cliente);
        Cliente DTOToCliente(ClienteDetalhesDTO cliente);
        ListagemClientesDTO ListClienteToDTO(ListagemClientes clientes);
    }
}

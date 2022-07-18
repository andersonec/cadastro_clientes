using cadastroClientes.Domain.EntitiesDTO;
using cadastroClientes.Infra.CrossCutting.Adapter.Mapper.IMapper;
using cadastroClientes.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroClientes.Infra.CrossCutting.Adapter.Mapper.Mapper
{
    public class ClienteMapper : IClienteMapper
    {
        public ClienteDTO ClienteToDTO(Cliente cliente)
        {
            return new ClienteDTO
            {
                id = cliente.id,
                data_nascimento = cliente.data_nascimento,
                nome = cliente.nome,
                cpf = cliente.cpf,
            };
        }

        public List<ClienteDTO> ListClienteToDTO(List<Cliente> clientes)
        {
            List<ClienteDTO> list = new List<ClienteDTO>();

            foreach (Cliente cliente in clientes)
            {
                var clienteDTO = new ClienteDTO
                {
                    id = cliente.id,
                    data_nascimento = cliente.data_nascimento,
                    nome = cliente.nome,
                    cpf = cliente.cpf,
                };

                list.Add(clienteDTO);
            }

            return list;
        }

        public ClienteDetalhesDTO ClienteToDetalhesDTO(Cliente cliente)
        {
            return new ClienteDetalhesDTO
            {
                id = cliente.id,
                nome = cliente.nome,
                data_nascimento = cliente.data_nascimento,
                cpf = cliente.cpf,
                rg = cliente.rg,
                facebook = cliente.facebook,
                instagram = cliente.instagram,
                linkedin = cliente.linkedin,
                twitter = cliente.twitter,
            };
        }

        public Cliente DTOToCliente(ClienteDetalhesDTO cliente)
        {
            return new Cliente
            {
                id = cliente.id,
                nome = cliente.nome,
                data_nascimento = cliente.data_nascimento,
                cpf = cliente.cpf,
                rg = cliente.rg,
                facebook = cliente.facebook,
                instagram = cliente.instagram,
                linkedin = cliente.linkedin,
                twitter = cliente.twitter,
            };
        }

        public ListagemClientesDTO ListClienteToDTO(ListagemClientes clientes)
        {
            return new ListagemClientesDTO
            {
                quantidadeClientes = clientes.quantidadeClientes,
                quantidadePaginas = clientes.quantidadePaginas,
                listaClientes = ListClienteToDTO(clientes.listaClientes)
            };
        }
    }
}

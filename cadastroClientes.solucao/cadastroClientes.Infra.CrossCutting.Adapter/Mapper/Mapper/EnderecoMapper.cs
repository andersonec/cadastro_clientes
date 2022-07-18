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
    public class EnderecoMapper : IEnderecoMapper
    {
        public EnderecoDTO EnderecoToDTO(Endereco endereco)
        {
            return new EnderecoDTO
            {
                id = endereco.id,
                logradouro = endereco.logradouro,
                tipo_logradouro = endereco.tipo_logradouro,
                bairro = endereco.bairro,
                cidade = endereco.cidade,
                estado = endereco.estado,
            };
        }

        public List<EnderecoDTO> ListEnderecoToDTO(List<Endereco> enderecos)
        {
            var list = new List<EnderecoDTO>();

            foreach (var endereco in enderecos)
            {
                var enderecoDTO = new EnderecoDTO
                {
                    id = endereco.id,
                    logradouro = endereco.logradouro,
                    tipo_logradouro = endereco.tipo_logradouro,
                    bairro = endereco.bairro,
                    cidade = endereco.cidade,
                    estado = endereco.estado,
                };

                list.Add(enderecoDTO);
            }

            return list;
        }

        public Endereco DTOToEndereco(EnderecoDTO endereco)
        {
            return new Endereco
            {
                id = endereco.id,
                logradouro = endereco.logradouro,
                tipo_logradouro = endereco.tipo_logradouro,
                bairro = endereco.bairro,
                cidade = endereco.cidade,
                estado = endereco.estado,
            };
        }
    }
}

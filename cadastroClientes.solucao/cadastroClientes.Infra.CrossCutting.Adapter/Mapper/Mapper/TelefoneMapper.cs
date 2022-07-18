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
    public class TelefoneMapper : ITelefoneMapper
    {
        public TelefoneDTO TelefoneToDTO(Telefone telefone)
        {
            return new TelefoneDTO
            {
                id = telefone.id,
                telefone = telefone.telefone,
                identificacao = telefone.identificacao,
            };
        }

        public List<TelefoneDTO> ListTelefoneToDTO(List<Telefone> telefones)
        {
            List<TelefoneDTO> list = new List<TelefoneDTO>();
            foreach(Telefone telefone in telefones)
            {
                var telefoneDTO = new TelefoneDTO
                {
                    id = telefone.id,
                    telefone = telefone.telefone,
                    identificacao = telefone.identificacao,
                };

                list.Add(telefoneDTO);
            }

            return list;
        }

        public Telefone DTOToTelefone(TelefoneDTO telefone)
        {
            return new Telefone
            {
                id = telefone.id,
                telefone = telefone.telefone,
                identificacao = telefone.identificacao,
            };
        }
    }
}

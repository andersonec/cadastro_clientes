using cadastroClientes.Domain.EntitiesDTO;
using cadastroClientes.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroClientes.Infra.CrossCutting.Adapter.Mapper.IMapper
{
    public interface ITelefoneMapper
    {
        TelefoneDTO TelefoneToDTO(Telefone telefone);
        List<TelefoneDTO> ListTelefoneToDTO(List<Telefone> telefones);
        Telefone DTOToTelefone(TelefoneDTO telefone);
    }
}

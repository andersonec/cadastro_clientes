using cadastroClientes.Domain.EntitiesDTO;
using cadastroClientes.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroClientes.Infra.CrossCutting.Adapter.Mapper.IMapper
{
    public interface IEnderecoMapper
    {
        EnderecoDTO EnderecoToDTO(Endereco endereco);
        List<EnderecoDTO> ListEnderecoToDTO(List<Endereco> enderecos);
        Endereco DTOToEndereco(EnderecoDTO endereco);
    }
}

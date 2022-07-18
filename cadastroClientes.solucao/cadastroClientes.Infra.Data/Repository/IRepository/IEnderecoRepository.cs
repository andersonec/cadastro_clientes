using cadastroClientes.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroClientes.Infra.Data.Repository.IRepository
{
    public interface IEnderecoRepository
    {
        int CadastrarEndereco(Endereco endereco, int idCliente);
        int AtualizarEndereco(Endereco endereco);
        List<Endereco> ListarEnderecosCliente(int id_cliente);
    }
}

using cadastroClientes.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroClientes.Infra.Data.Repository.IRepository
{
    public interface ITelefoneRepository
    {
        int CadastrarTelefone(Telefone telefone, int idCliente);
        int AtualizarTelefone(Telefone telefone);
        List<Telefone> ListarTelefonesCliente(int id_cliente);
    }
}

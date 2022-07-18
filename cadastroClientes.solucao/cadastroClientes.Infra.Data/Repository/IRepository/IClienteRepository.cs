using cadastroClientes.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroClientes.Infra.Data.Repository.IRepository
{
    public interface IClienteRepository
    {
        int CadastrarDadosCliente(Cliente cliente);
        int AtualizarDadosCliente(Cliente cliente);
        ListagemClientes ListarClientes(int pagina, int quantidade, string ordenaPor, string ordem);
        Cliente ConsultarCliente(string parametro);
    }
}

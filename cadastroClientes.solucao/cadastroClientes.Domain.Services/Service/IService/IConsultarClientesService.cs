using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroClientes.Domain.Services.Service.IService
{
    public interface IConsultarClientesService
    {
        Object ListarClientes(int pagina, int quantidade, string ordenaPor, string ordem);
        Object ConsultarCliente(string parametro);
    }
}

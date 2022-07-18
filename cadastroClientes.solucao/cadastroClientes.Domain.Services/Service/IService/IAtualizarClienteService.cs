using cadastroClientes.Domain.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroClientes.Domain.Services.Service.IService
{
    public interface IAtualizarClienteService
    {
        ServiceResult AtualizarCliente(ClienteDetalhesDTO cliente);
    }
}

using cadastroClientes.Domain.EntitiesDTO;
using cadastroClientes.Domain.Services;
using cadastroClientes.Domain.Services.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastroClientes.Service.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ICadastrarClienteService _cadastrarClienteService;
        private readonly IConsultarClientesService _consultarClientesService;
        private readonly IAtualizarClienteService _atualizarClienteService;
        public ClienteController(ICadastrarClienteService cadastrarClienteService, IConsultarClientesService consultarClientesService, IAtualizarClienteService atualizarClienteService)
        {
            _cadastrarClienteService = cadastrarClienteService;
            _consultarClientesService = consultarClientesService;
            _atualizarClienteService = atualizarClienteService;
        }

        [HttpPost("cadastrarCliente")]
        public ActionResult<ServiceResult> CadastrarCliente(ClienteDetalhesDTO cliente)
        {
            var cadastro = _cadastrarClienteService.CadastrarCliente(cliente);

            if (cadastro == null)
                return NotFound("Erro na chamada do serviço.");

            if (cadastro.codigoErro != 0)
                return BadRequest(cadastro);

            return Ok(cadastro);
        }

        [HttpGet("listarClientes")]
        public ActionResult ListarClientes(int pagina, int quantidade, string ordenaPor, string ordem)
        {
            var cliente = _consultarClientesService.ListarClientes(pagina, quantidade, ordenaPor, ordem);

            if (cliente == null)
                return NotFound("Erro na chamada do serviço.");

            return Ok(cliente);
        }

        [HttpGet("consultarCliente")]
        public ActionResult ConsultarCliente(string parametro)
        {
            var cliente = _consultarClientesService.ConsultarCliente(parametro);

            if (cliente == null)
                return NotFound("Erro na chamada do serviço.");

            return Ok(cliente);
        }

        [HttpPost("atualizarCliente")]
        public ActionResult<ServiceResult> AtualizarCliente(ClienteDetalhesDTO cliente)
        {
            var cadastro = _atualizarClienteService.AtualizarCliente(cliente);

            if (cadastro == null)
                return NotFound("Erro na chamada do serviço.");

            if (cadastro.codigoErro != 0)
                return BadRequest(cadastro);

            return Ok(cadastro);
        }
    }
}

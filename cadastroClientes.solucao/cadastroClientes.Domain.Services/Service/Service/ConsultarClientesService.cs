using cadastroClientes.Domain.EntitiesDTO;
using cadastroClientes.Domain.Services.Service.IService;
using cadastroClientes.Infra.CrossCutting.Adapter.Mapper.IMapper;
using cadastroClientes.Infra.CrossCutting.Validations.Validation;
using cadastroClientes.Infra.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroClientes.Domain.Services.Service.Service
{
    public class ConsultarClientesService : IConsultarClientesService
    {
        private readonly IClienteMapper _clienteMapper;
        private readonly IClienteRepository _clienteRepository;
        private readonly ITelefoneMapper _telefoneMapper;
        private readonly ITelefoneRepository _telefoneRepository;
        private readonly IEnderecoMapper _enderecoMapper;
        private readonly IEnderecoRepository _enderecoRepository;

        public ConsultarClientesService(IClienteMapper clienteMapper, IClienteRepository clienteRepository,
                                       ITelefoneMapper telefoneMapper, ITelefoneRepository telefoneRepository,
                                       IEnderecoMapper enderecoMapper, IEnderecoRepository enderecoRepository)
        {
            _clienteMapper = clienteMapper;
            _clienteRepository = clienteRepository;
            _telefoneMapper = telefoneMapper;
            _telefoneRepository = telefoneRepository;
            _enderecoMapper = enderecoMapper;
            _enderecoRepository = enderecoRepository;
        }

        public Object ListarClientes(int pagina, int quantidade, string ordenaPor, string ordem)
        {
            var clientes = _clienteRepository.ListarClientes(pagina, quantidade, ordenaPor, ordem);

            if (clientes == null)
            {
                return new ServiceResult
                {
                    codigoErro = 1,
                    mensagem = "Erro ao consultar clientes."
                };
            }
            else if (clientes.listaClientes.Count() == 0)
            {
                return new ServiceResult
                {
                    codigoErro = 1,
                    mensagem = "Não existem clientes na base."
                };
            }
            else
            {
                return _clienteMapper.ListClienteToDTO(clientes);
            }
        }

        public Object ConsultarCliente(string parametro)
        {
            if (parametro.Length == 11)
            {
                if (NameValidation.IsValidName(parametro).valido == false)
                {
                    var cpfValido = CPFValidation.IsValidCpf(parametro);
                    if (cpfValido.valido == false)
                        return new ServiceResult
                        {
                            codigoErro = 1,
                            mensagem = cpfValido.mensagem,
                        };
                }
            }

            var cliente = _clienteRepository.ConsultarCliente(parametro);

            if (cliente == null)
            {
                return new ServiceResult
                {
                    codigoErro = 1,
                    mensagem = "Erro ao consultar cliente."
                };
            }
            else
            {
                var clienteDto = _clienteMapper.ClienteToDetalhesDTO(cliente);

                var telefones = _telefoneRepository.ListarTelefonesCliente(cliente.id);
                clienteDto.listaTelefones = _telefoneMapper.ListTelefoneToDTO(telefones);

                var enderecos = _enderecoRepository.ListarEnderecosCliente(cliente.id);
                clienteDto.listaEnderecos = _enderecoMapper.ListEnderecoToDTO(enderecos);

                return clienteDto;
            }
        }
    }
}

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
    public class CadastrarClienteService : ICadastrarClienteService
    {
        private readonly IClienteMapper _clienteMapper;
        private readonly IClienteRepository _clienteRepository;
        private readonly ITelefoneMapper _telefoneMapper;
        private readonly ITelefoneRepository _telefoneRepository;
        private readonly IEnderecoMapper _enderecoMapper;
        private readonly IEnderecoRepository _enderecoRepository;

        public CadastrarClienteService(IClienteMapper clienteMapper, IClienteRepository clienteRepository,
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

        public ServiceResult CadastrarCliente(ClienteDetalhesDTO cliente)
        {
            var validaCpf = CPFValidation.IsValidCpf(cliente.cpf);
            if (validaCpf.valido == false)
                return new ServiceResult
                {
                    codigoErro = 1,
                    mensagem = validaCpf.mensagem
                };

            var validaNome = NameValidation.IsValidName(cliente.nome);
            if (validaNome.valido == false)
                return new ServiceResult
                {
                    codigoErro = 1,
                    mensagem = validaNome.mensagem
                };

            var clienteExiste = _clienteRepository.ConsultarCliente(cliente.nome);
            if (clienteExiste != null)
                return new ServiceResult
                {
                    codigoErro= 1,
                    mensagem = "Já existe um cliente com este nome."
                };

            clienteExiste = _clienteRepository.ConsultarCliente(cliente.cpf);
            if (clienteExiste != null)
                return new ServiceResult
                {
                    codigoErro = 1,
                    mensagem = "Já existe um cliente com este cpf."
                };

            var clienteIn = _clienteMapper.DTOToCliente(cliente);
            var resultCadastro = _clienteRepository.CadastrarDadosCliente(clienteIn);

            if (resultCadastro == 0)
                return new ServiceResult
                {
                    codigoErro = 1,
                    mensagem = "Erro ao cadastrar cliente."
                };

            foreach (var telefone in cliente.listaTelefones)
            {
                var telefoneIn = _telefoneMapper.DTOToTelefone(telefone);
                var resultTelefone = _telefoneRepository.CadastrarTelefone(telefoneIn, resultCadastro);

                if (resultTelefone == 0)
                    return new ServiceResult
                    {
                        codigoErro = 1,
                        mensagem = "Erro ao cadastrar telefone."
                    };
            }
            foreach (var endereco in cliente.listaEnderecos)
            {
                var enderecoIn = _enderecoMapper.DTOToEndereco(endereco);
                var resultEndereco = _enderecoRepository.CadastrarEndereco(enderecoIn, resultCadastro);

                if (resultEndereco == 0)
                    return new ServiceResult
                    {
                        codigoErro = 1,
                        mensagem = "Erro ao cadastrar endereço."
                    };
            }

            return new ServiceResult
            {
                codigoErro = 0,
                mensagem = "Cliente cadastrado com sucesso."
            };
        }
    }
}

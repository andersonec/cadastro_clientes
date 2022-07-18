using Autofac;
using cadastroClientes.Domain.Services.Service.IService;
using cadastroClientes.Domain.Services.Service.Service;
using cadastroClientes.Infra.CrossCutting.Adapter.Mapper.IMapper;
using cadastroClientes.Infra.CrossCutting.Adapter.Mapper.Mapper;
using cadastroClientes.Infra.Data.Repository.IRepository;
using cadastroClientes.Infra.Data.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroClientes.Infra.CrossCutting.IoC
{
    public class DependencyInjection
    {
        public static void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CadastrarClienteService>().As<ICadastrarClienteService>();
            builder.RegisterType<ConsultarClientesService>().As<IConsultarClientesService>();
            builder.RegisterType<AtualizarClienteService>().As<IAtualizarClienteService>();

            builder.RegisterType<ClienteMapper>().As<IClienteMapper>();
            builder.RegisterType<EnderecoMapper>().As<IEnderecoMapper>();
            builder.RegisterType<TelefoneMapper>().As<ITelefoneMapper>();

            builder.RegisterType<ClienteRepository>().As<IClienteRepository>();
            builder.RegisterType<EnderecoRepository>().As<IEnderecoRepository>();
            builder.RegisterType<TelefoneRepository>().As<ITelefoneRepository>();
        }
    }
}

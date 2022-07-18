# API de Cadastro de Clientes

<h2>Aplicação desenvolvida na linguagem C#.</h2>
<p>Backend (Biblioteca de classes) e API Web desenvolvidos com .NET 5.0.</p>
<p>Desenvolvida no Microsoft Visual Studio 2022.</p>

<h2>Informações iniciais:</h2>

<h3>Banco de Dados:</h3>
<p>No arquivo: 'script_database.sql' está contido o script de criação do banco de dados feito para esta aplicação.</p>
<p>O banco de dados foi desenvolvido utilizando o SQL Server 2014 Management Studio.</p>

<h3>Dependências do projeto:</h3>
<p>Microsoft.Data.SqlClient 4.1.0</p>
<p>Autofac 6.4.0</p>
<p>Autofac.Extensions.DependencyInjection 8.0.0</p>
<p>Swashbuckle.AspNetCore 5.6.3</p>

<h2>Estrutura do projeto:</h2>

<h3>Camada 01 - Services:</h3>
<p>A camada mais alta da aplicação, ela disponibiliza os serviços para usuários externos.</p>

<h3>Camada 02 - Domain:</h3>
<p>Camada de comunicação entre a camada de dados e a camada de serviços.</p>
<p>É responsável pelos serviços da aplicação e manipulação das entidades de transferência de dados.</p>

<h3>Camada 03 - Infra:</h3>
<p>Camada mais baixa da aplicação, responsável por conter a comunicação com o banco de dados e manipulação de entidades do banco.</p>
<p>Possui duas subcamadas:</p>

<h4>Data:</h4>
<p>Camada responsável pela configuração e manipulação de recursos e entidades do banco.</p>

<h4>CrossCutting:</h4>
<p>Responsável pelas manipulações e validações de comunicação entre a camada de dados e a camada de domínio.</p>
<p>Também possui métodos de mapeamento entre entidades de banco e entidades de transferência de dados.</p>
<p>Realiza a configuração e injeção de dependências do projeto.</p>

<h2>Informações adicionais:</h2>
<p>Foram utilizados conceitos de DDD (Domain-Driven Design) e SOLID Pattern.</p>
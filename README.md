# API de Cadastro de Clientes

<h2>Aplicação desenvolvida na linguagem C#.</h2>
Backend (Biblioteca de classes) e API Web desenvolvidos com .NET 5.0.
Desenvolvida no Microsoft Visual Studio 2022.

<h2> Estrutura do projeto: </h2>

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
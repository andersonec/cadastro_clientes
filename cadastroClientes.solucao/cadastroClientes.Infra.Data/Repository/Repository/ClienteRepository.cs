using cadastroClientes.Infra.Data.DbConfig;
using cadastroClientes.Infra.Data.Entities;
using cadastroClientes.Infra.Data.Repository.IRepository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroClientes.Infra.Data.Repository.Repository
{
    public class ClienteRepository : ConexaoSql, IClienteRepository
    {
        //_connectionString = Configuration.GetSection("ConnectionStrings:ConexaoProducao").Value;
        //_jwtSecret = Configuration["Jwt:Key"];
        //string sqlStr = @"Data Source=DESKTOP-82DB0FS\SQLEXPRESS;Initial Catalog=CadastroClientes;User Id=DESKTOP-82DB0FS\ander; Password=;TrustServerCertificate=True;";
        string sqlStr = @"Data Source=DESKTOP-82DB0FS\SQLEXPRESS;Initial Catalog=CadastroClientes;Integrated Security=True;TrustServerCertificate=True;";

        public int CadastrarDadosCliente(Cliente cliente)
        {
            try
            {
                sqlCommand = new SqlCommand();
                sqlConnection = new SqlConnection();
                OpenConnection(sqlStr);

                sqlCommand = new SqlCommand("INSERT INTO tb_cliente (nome, data_nascimento, cpf, rg, facebook, linkedin, twitter, instagram) " +
                                          "VALUES (@nome, @data_nascimento, @cpf, @rg, @facebook, @linkedin, @twitter, @instagram) " +
                                          "SELECT id FROM tb_cliente WHERE id = SCOPE_IDENTITY()", sqlConnection);

                sqlCommand.Parameters.AddWithValue("nome", cliente.nome);
                sqlCommand.Parameters.AddWithValue("data_nascimento", cliente.data_nascimento);
                sqlCommand.Parameters.AddWithValue("cpf", cliente.cpf);
                sqlCommand.Parameters.AddWithValue("rg", cliente.rg);
                sqlCommand.Parameters.AddWithValue("facebook", cliente.facebook);
                sqlCommand.Parameters.AddWithValue("linkedin", cliente.linkedin);
                sqlCommand.Parameters.AddWithValue("twitter", cliente.twitter);
                sqlCommand.Parameters.AddWithValue("instagram", cliente.instagram);

                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["id"]);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar cadastrar cliente, tente novamento mais tarde! " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public int AtualizarDadosCliente(Cliente cliente)
        {
            try
            {
                sqlCommand = new SqlCommand();
                sqlConnection = new SqlConnection();
                OpenConnection(sqlStr);

                sqlCommand = new SqlCommand("UPDATE tb_cliente SET nome = @nome, " +
                                                                   "data_nascimento = @data_nascimento, " +
                                                                   "cpf = @cpf, " +
                                                                   "rg = @rg, " +
                                                                   "facebook = @facebook, " +
                                                                   "linkedin = @linkedin, " +
                                                                   "twitter = @twitter, " +
                                                                   "instagram = @instagram " +
                                            "WHERE id = @id", sqlConnection);

                sqlCommand.Parameters.AddWithValue("@id", cliente.id);
                sqlCommand.Parameters.AddWithValue("@nome", cliente.nome);
                sqlCommand.Parameters.AddWithValue("@data_nascimento", cliente.data_nascimento);
                sqlCommand.Parameters.AddWithValue("@cpf", cliente.cpf);
                sqlCommand.Parameters.AddWithValue("@rg", cliente.rg);
                sqlCommand.Parameters.AddWithValue("@facebook", cliente.facebook);
                sqlCommand.Parameters.AddWithValue("@linkedin", cliente.linkedin);
                sqlCommand.Parameters.AddWithValue("@twitter", cliente.twitter);
                sqlCommand.Parameters.AddWithValue("@instagram", cliente.instagram);

                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar atualizar dados do cliente, tente novamento mais tarde! " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public ListagemClientes ListarClientes(int pagina, int quantidade, string ordenaPor, string ordem)
        {
            ListagemClientes listaClientes = new ListagemClientes();
            try
            {
                sqlConnection = new SqlConnection();
                OpenConnection(sqlStr);
                sqlCommand = new SqlCommand("SELECT COUNT(*) AS Total FROM tb_cliente", sqlConnection);

                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    listaClientes.quantidadeClientes = Convert.ToInt32(sqlDataReader["Total"]);
                    listaClientes.quantidadePaginas = listaClientes.quantidadeClientes / quantidade;
                    if ((listaClientes.quantidadeClientes % quantidade) != 0)
                    {
                        listaClientes.quantidadePaginas += 1;
                    }
                }
                CloseConnection();

                OpenConnection(sqlStr);
                sqlCommand = new SqlCommand("SELECT * FROM(SELECT ROW_NUMBER() OVER(ORDER BY id DESC) AS Linha, " +
                                            "*FROM tb_cliente) AS tbl " +
                                            "WHERE Linha BETWEEN((@pagina - 1) * @quantidade + 1) AND(@pagina * @quantidade) " +
                                            "ORDER BY " +
                                                "CASE WHEN @ordenaPor LIKE 'nome' AND @ordem LIKE 'DESC' THEN nome END DESC " +
                                                ",CASE WHEN @ordenaPor LIKE 'nome' AND @ordem LIKE 'ASC' THEN nome END ASC " +
                                                ",CASE WHEN @ordenaPor LIKE 'data' AND @ordem LIKE 'DESC' THEN data_nascimento END DESC " +
                                                ",CASE WHEN @ordenaPor LIKE 'data' AND @ordem LIKE 'ASC' THEN data_nascimento END ASC " +
                                                ",CASE WHEN @ordenaPor LIKE 'id' AND @ordem LIKE 'DESC' THEN id END DESC " +
                                                ",CASE WHEN @ordenaPor LIKE 'id' AND @ordem LIKE 'ASC' THEN id END ASC", sqlConnection);

                sqlCommand.Parameters.AddWithValue("@pagina", pagina);
                sqlCommand.Parameters.AddWithValue("@quantidade", quantidade);
                sqlCommand.Parameters.AddWithValue("@ordenaPor", ordenaPor);
                sqlCommand.Parameters.AddWithValue("@ordem", ordem);

                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var cliente = new Cliente
                    {
                        id = Convert.ToInt32(sqlDataReader["id"]),
                        nome = Convert.ToString(sqlDataReader["nome"]),
                        data_nascimento = Convert.ToDateTime(sqlDataReader["data_nascimento"]),
                        cpf = Convert.ToString(sqlDataReader["cpf"]),
                        rg = Convert.ToString(sqlDataReader["rg"]),
                        facebook = Convert.ToString(sqlDataReader["facebook"]),
                        linkedin = Convert.ToString(sqlDataReader["linkedin"]),
                        twitter = Convert.ToString(sqlDataReader["twitter"]),
                        instagram = Convert.ToString(sqlDataReader["instagram"]),
                    };

                    listaClientes.listaClientes.Add(cliente);
                }

                return listaClientes;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar Clientes: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    
        public Cliente ConsultarCliente(string parametro)
        {
            try
            {
                sqlConnection = new SqlConnection();
                OpenConnection(sqlStr);

                string sql = "SELECT * FROM tb_cliente WHERE nome LIKE @parametro";
                if (parametro.Length == 11)
                    sql = "SELECT * FROM tb_cliente WHERE cpf LIKE @parametro";

                sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlCommand.Parameters.AddWithValue("parametro", parametro);

                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    return new Cliente
                    {
                        id = Convert.ToInt32(sqlDataReader["id"]),
                        nome = Convert.ToString(sqlDataReader["nome"]),
                        data_nascimento = Convert.ToDateTime(sqlDataReader["data_nascimento"]),
                        cpf = Convert.ToString(sqlDataReader["cpf"]),
                        rg = Convert.ToString(sqlDataReader["rg"]),
                        facebook = Convert.ToString(sqlDataReader["facebook"]),
                        linkedin = Convert.ToString(sqlDataReader["linkedin"]),
                        twitter = Convert.ToString(sqlDataReader["twitter"]),
                        instagram = Convert.ToString(sqlDataReader["instagram"]),
                    };
                }

                return null;
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao consultar Cliente: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}

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
    public class EnderecoRepository : ConexaoSql, IEnderecoRepository
    {
        //_connectionString = Configuration.GetSection("ConnectionStrings:ConexaoProducao").Value;
        //_jwtSecret = Configuration["Jwt:Key"];
        string sqlStr = @"Data Source=DESKTOP-82DB0FS\SQLEXPRESS;Initial Catalog=CadastroClientes;Integrated Security=True;TrustServerCertificate=True;";
        public int CadastrarEndereco(Endereco endereco, int idCliente)
        {
            try
            {
                sqlCommand = new SqlCommand();
                sqlConnection = new SqlConnection();
                OpenConnection(sqlStr);

                sqlCommand = new SqlCommand("INSERT INTO tb_endereco (logradouro, tipo_logradouro, bairro, cidade, estado) " +
                                          "VALUES (@logradouro, @tipo_logradouro, @bairro, @cidade, @estado) " +
                                          "SELECT id FROM tb_endereco WHERE id = SCOPE_IDENTITY()", sqlConnection);

                sqlCommand.Parameters.AddWithValue("@logradouro", endereco.logradouro);
                sqlCommand.Parameters.AddWithValue("@tipo_logradouro", endereco.tipo_logradouro);
                sqlCommand.Parameters.AddWithValue("@bairro", endereco.bairro);
                sqlCommand.Parameters.AddWithValue("@cidade", endereco.cidade);
                sqlCommand.Parameters.AddWithValue("@estado", endereco.estado);

                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    int id_endereco = Convert.ToInt32(sqlDataReader["id"]);

                    CloseConnection();

                    OpenConnection(sqlStr);

                    sqlCommand = new SqlCommand("INSERT INTO cliente_para_endereco (id_cliente, id_endereco) " +
                                              "VALUES (@id_cliente, @id_endereco) ", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("id_endereco", id_endereco);
                    sqlCommand.Parameters.AddWithValue("id_cliente", idCliente);

                    if (sqlCommand.ExecuteNonQuery() > 0)
                        return 1;

                    return 0;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar adicionar endereco do cliente, tente novamento mais tarde! " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public int AtualizarEndereco(Endereco endereco)
        {
            try
            {
                sqlCommand = new SqlCommand();
                sqlConnection = new SqlConnection();
                OpenConnection(sqlStr);

                sqlCommand = new SqlCommand("UPDATE tb_endereco SET logradouro = @logradouro, " +
                                                                   "tipo_logradouro = @tipo_logradouro, " +
                                                                   "bairro = @bairro, " +
                                                                   "cidade = @cidade, " +
                                                                   "estado = @estado " +
                                            "WHERE id = @id", sqlConnection);

                sqlCommand.Parameters.AddWithValue("@id", endereco.id);
                sqlCommand.Parameters.AddWithValue("@logradouro", endereco.logradouro);
                sqlCommand.Parameters.AddWithValue("@tipo_logradouro", endereco.tipo_logradouro);
                sqlCommand.Parameters.AddWithValue("@bairro", endereco.bairro);
                sqlCommand.Parameters.AddWithValue("@cidade", endereco.cidade);
                sqlCommand.Parameters.AddWithValue("@estado", endereco.estado);

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
                throw new Exception("Erro ao tentar atualizar endereco do cliente, tente novamento mais tarde! " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<Endereco> ListarEnderecosCliente(int id_cliente)
        {
            List<Endereco> listaEnderecos = new List<Endereco>();
            try
            {
                sqlConnection = new SqlConnection();
                OpenConnection(sqlStr);
                sqlCommand = new SqlCommand("SELECT * FROM tb_endereco AS ed " +
                                            "INNER JOIN cliente_para_endereco AS ec " +
                                            "ON ec.id_cliente = @id_cliente " +
                                            "AND ed.id = ec.id_endereco", sqlConnection);

                sqlCommand.Parameters.AddWithValue("@id_cliente", id_cliente);

                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var endereco = new Endereco
                    {
                        id = Convert.ToInt32(sqlDataReader["id"]),
                        logradouro = Convert.ToString(sqlDataReader["logradouro"]),
                        tipo_logradouro = Convert.ToString(sqlDataReader["tipo_logradouro"]),
                        bairro = Convert.ToString(sqlDataReader["bairro"]),
                        cidade = Convert.ToString(sqlDataReader["cidade"]),
                        estado = Convert.ToString(sqlDataReader["estado"]),
                    };

                    listaEnderecos.Add(endereco);
                }
                return listaEnderecos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar Enderecos: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}

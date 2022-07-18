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
    public class TelefoneRepository : ConexaoSql, ITelefoneRepository
    {
        //_connectionString = Configuration.GetSection("ConnectionStrings:ConexaoProducao").Value;
        //_jwtSecret = Configuration["Jwt:Key"];
        string sqlStr = @"Data Source=DESKTOP-82DB0FS\SQLEXPRESS;Initial Catalog=CadastroClientes;Integrated Security=True;TrustServerCertificate=True;";
        public int CadastrarTelefone(Telefone telefone, int idCliente)
        {
            try
            {
                sqlCommand = new SqlCommand();
                sqlConnection = new SqlConnection();
                OpenConnection(sqlStr);

                sqlCommand = new SqlCommand("INSERT INTO tb_telefone (identificacao, telefone) " +
                                          "VALUES (@identificacao, @telefone) " +
                                          "SELECT id FROM tb_telefone WHERE id = SCOPE_IDENTITY()", sqlConnection);

                sqlCommand.Parameters.AddWithValue("@identificacao", telefone.identificacao);
                sqlCommand.Parameters.AddWithValue("@telefone", telefone.telefone);

                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    int id_telefone = Convert.ToInt32(sqlDataReader["id"]);

                    CloseConnection();

                    OpenConnection(sqlStr);

                    sqlCommand = new SqlCommand("INSERT INTO cliente_para_telefone (id_cliente, id_telefone) " +
                                              "VALUES (@id_cliente, @id_telefone) ", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("id_telefone", id_telefone);
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
                throw new Exception("Erro ao tentar adicionar telefone do cliente, tente novamento mais tarde! " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public int AtualizarTelefone(Telefone telefone)
        {
            try
            {
                sqlCommand = new SqlCommand();
                sqlConnection = new SqlConnection();
                OpenConnection(sqlStr);

                sqlCommand = new SqlCommand("UPDATE tb_telefone SET identificacao = @identificacao, " +
                                                                   "telefone = @telefone " +
                                            "WHERE id = @id", sqlConnection);

                sqlCommand.Parameters.AddWithValue("@id", telefone.id);
                sqlCommand.Parameters.AddWithValue("@identificacao", telefone.identificacao);
                sqlCommand.Parameters.AddWithValue("@telefone", telefone.telefone);

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
                throw new Exception("Erro ao tentar atualizar telefone do cliente, tente novamento mais tarde! " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<Telefone> ListarTelefonesCliente(int id_cliente)
        {
            List<Telefone> listaTelefones = new List<Telefone>();
            try
            {
                sqlConnection = new SqlConnection();
                OpenConnection(sqlStr);
                sqlCommand = new SqlCommand("SELECT * FROM tb_telefone AS tel " +
                                            "INNER JOIN cliente_para_telefone AS tc " +
                                            "ON tc.id_cliente = @id_cliente " +
                                            "AND tel.id = tc.id_telefone", sqlConnection);

                sqlCommand.Parameters.AddWithValue("@id_cliente", id_cliente);

                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var telefone = new Telefone
                    {
                        id = Convert.ToInt32(sqlDataReader["id"]),
                        identificacao = Convert.ToString(sqlDataReader["identificacao"]),
                        telefone = Convert.ToString(sqlDataReader["telefone"]),
                    };

                    listaTelefones.Add(telefone);
                }
                return listaTelefones;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar Telefones: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}

using EstouComSede.Domain.Entities;
using EstouComSede.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EstouComSede.Repository.Concrete
{
    public class RevisaoRepository : IRevisaoRepository
    {
        private const string CON = "Data Source=localhost;Initial Catalog=estoucomsede;Integrated Security=SSPI;";

        public RetornoRevisao Approve(int id)
        {
            try
            {
                using (var con = new SqlConnection())
                {
                    con.ConnectionString = CON;
                    con.Open();
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "UPDATE TB_REVISAO SET REV_STATUS = @REV_STATUS WHERE REV_ID = @REV_ID";
                        cmd.Parameters.AddWithValue("@REV_STATUS", "Aprovado");
                        cmd.Parameters.AddWithValue("@REV_ID", id);
                        var count = cmd.ExecuteNonQuery();

                        if (count > 0)
                        {
                            return new RetornoRevisao
                            {
                                Codigo = 0,
                                Mensagem = "Status da solicitação alterado com sucesso."
                            };
                        }
                        return new RetornoRevisao
                        {
                            Codigo = -1,
                            Mensagem = "Não foi possível alterar o status da solicitação."
                        };
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<Revisao> GetAll()
        {
            try
            {
                using (var con = new SqlConnection())
                {
                    con.ConnectionString = CON;
                    con.Open();
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "SELECT REV_ID, REV_NOME, REV_BAIRRO, REV_CIDADE, REV_ESTADO, REV_DATA_SOLICITACAO, REV_OBS, REV_STATUS FROM TB_REVISAO";
                        var reader = cmd.ExecuteReader();
                        List<Revisao> solicitacoes = new List<Revisao>();

                        while (reader.Read())
                        {
                            var solicitacao = new Revisao
                            {
                                Id = Convert.ToInt64(reader["REV_ID"]),
                                Nome = reader["REV_NOME"].ToString(),
                                Bairro = reader["REV_BAIRRO"].ToString(),
                                Cidade = reader["REV_CIDADE"].ToString(),
                                Estado = reader["REV_ESTADO"].ToString(),
                                DataSolicitacao = Convert.ToDateTime(reader["REV_DATA_SOLICITACAO"]),
                                Observacao = reader["REV_OBS"].ToString(),
                                Status = reader["REV_STATUS"].ToString()
                            };

                            solicitacoes.Add(solicitacao);
                        }
                        return solicitacoes;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public RetornoRevisao Insert(Revisao solicitacao)
        {
            try
            {
                using (var con = new SqlConnection())
                {
                    con.ConnectionString = CON;
                    con.Open();
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "INSERT INTO TB_REVISAO (REV_NOME, REV_BAIRRO, REV_CIDADE, REV_ESTADO, REV_DATA_SOLICITACAO, REV_OBS, REV_STATUS) VALUES (@REV_NOME, @REV_BAIRRO, @REV_CIDADE, @REV_ESTADO, @REV_DATA_SOLICITACAO, @REV_OBS, @REV_STATUS)";
                        cmd.Parameters.AddWithValue("@REV_NOME", solicitacao.Nome);
                        cmd.Parameters.AddWithValue("@REV_BAIRRO", solicitacao.Bairro);
                        cmd.Parameters.AddWithValue("@REV_CIDADE", solicitacao.Cidade);
                        cmd.Parameters.AddWithValue("@REV_ESTADO", solicitacao.Estado);
                        cmd.Parameters.AddWithValue("@REV_DATA_SOLICITACAO", DateTime.Now);
                        cmd.Parameters.AddWithValue("@REV_OBS", solicitacao.Observacao);
                        cmd.Parameters.AddWithValue("@REV_STATUS", "Pendente");
                        var count = cmd.ExecuteNonQuery();

                        if (count > 0)
                        {
                            return new RetornoRevisao
                            {
                                Codigo = 0,
                                Mensagem = "Solicitação de revisão cadastrada com sucesso."
                            };
                        }
                        return new RetornoRevisao
                        {
                            Codigo = -1,
                            Mensagem = "Não foi possível cadastrar a sua solicitação."
                        };
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public RetornoRevisao Reprove(int id)
        {
            try
            {
                using (var con = new SqlConnection())
                {
                    con.ConnectionString = CON;
                    con.Open();
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "UPDATE TB_REVISAO SET REV_STATUS = @REV_STATUS WHERE REV_ID = @REV_ID";
                        cmd.Parameters.AddWithValue("@REV_STATUS", "Recusado");
                        cmd.Parameters.AddWithValue("@REV_ID", id);
                        var count = cmd.ExecuteNonQuery();

                        if (count > 0)
                        {
                            return new RetornoRevisao
                            {
                                Codigo = 0,
                                Mensagem = "Status da solicitação alterado com sucesso."
                            };
                        }
                        return new RetornoRevisao
                        {
                            Codigo = -1,
                            Mensagem = "Não foi possível alterar o status da solicitação."
                        };
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
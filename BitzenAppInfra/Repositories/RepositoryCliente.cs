using BitzenAppInfra.Interfaces;
using Dapper;
using ProvaAppDomain.Entities;
using ProvaAppDomain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProvaAppInfra.Repositories
{
    public class RepositoryCliente : IRepositoryCliente
    {
        private readonly IDbConnectionString _dbConnectionString;

        public RepositoryCliente(IDbConnectionString dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
            DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public int Adicionar(Cliente entity)
        {
            using (var connection = _dbConnectionString.Connection())
            {
                connection.Open();


                try
                {
                    string sql = @"INSERT INTO
                            ger_cliente
                            (
                                c_nome,
                                d_nascimento,
                                c_sexo,
                                c_cep,
                                c_endereco,
                                n_numero,
                                c_complemento,
                                c_estado,
                                c_cidade,
                                c_bairro
                            )
                        VALUES
                            (
                                @CNome,
                                @DNascimento,
                                @CSexo,
                                @CCep,
                                @CEndereco,
                                @NNumero,
                                @CComplemento,
                                @CEstado,
                                @CCidade,
                                @CBairro
                            )";
                    return connection.Execute(sql, entity);
                }
                catch (Exception ex)
                {
                   return  0;
                }

            }
        }

        public int Atualizar(Cliente entity)
        {
            using (var connection = _dbConnectionString.Connection())
            {
                connection.Open();

                string sql = @"UPDATE 
                                ger_cliente
                            SET
                                c_nome = @CNome,
                                d_nascimento = @DNascimento,
                                c_sexo = @CSexo,
                                c_cep = @CCep,
                                c_endereco = @CEndereco,
                                n_numero = @NNumero,
                                c_complemento = @CComplemento,
                                c_estado = @CEstado,
                                c_cidade = @CCidade,
                                c_bairro = @CBairro
                            WHERE 
                                n_cod_cliente = @NCodCliente;";

                return connection.Execute(sql, entity);
               
            }
        }

        public Cliente ObterPorId(int id)
        {
            using (var connection = _dbConnectionString.Connection())
            {
                connection.Open();

                var sql = @"SELECT 
	                           *
                        FROM 
                            ger_cliente 
                        WHERE 
                            n_cod_cliente = @id";

               return connection.Query<Cliente>(sql, new { id = id }).FirstOrDefault();
              

            }
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            using (var connection = _dbConnectionString.Connection())
            {
                string sql = @"
                                SELECT 
                                   * 
                                FROM
	                                ger_cliente
                               Order by c_nome 
                    ";


                connection.Open();
                return connection.Query<Cliente>(sql);
            }
        }

        public int Remover(int id)
        {
            using (var connection = _dbConnectionString.Connection())
            {
                connection.Open();

                string sql = @"DELETE 
                                    FROM
                                ger_cliente
                            WHERE 
                                n_cod_cliente = @id;";

                return connection.Execute(sql, new { id = id });

            }
        }
        public void Dispose()
        {
            _dbConnectionString.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

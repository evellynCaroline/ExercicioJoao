using MySql.Data.MySqlClient;
using ApiTarefasNet80.Database;

namespace ApiTarefasNet80.Models
{
    public class CategoriaDAO
    {
        private static ConnectionMysql _conn;

        public CategoriaDAO()
        {
            _conn = new ConnectionMysql();
        }

        public int Insert(Categorias item)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "INSERT INTO categorias (id_cat, nome_cat) VALUES ( @nome)";

                query.Parameters.AddWithValue("@nome", item.Nome);
                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente");
                }

                return (int)query.LastInsertedId;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

        public List<Categorias> List()
        {
            try
            {
                List<Categorias> list = new List<Categorias>();
                // List<Tarefa> list = [];

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM categorias";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Categorias()
                    {
                        Id = reader.GetInt32("id_cat"),
                        Nome = reader.GetString("nome_cat"),
                      
                    });
                }

                return list;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

        public Categorias? GetById(int id)
        {
            try
            {
                Categorias _categorias = new Categorias();
                // Tarefa _tarefa = new();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM categorias WHERE id_cat = @_id";

                query.Parameters.AddWithValue("@_id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }

                while (reader.Read())
                {
                    _categorias.Id = reader.GetInt32("id_cat");
                    _categorias.Nome = reader.GetString("nome_cat");
                  
                }

                return _categorias;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }
        //PAREI DAQUI
        /*
        public void Update(Categorias item)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "UPDATE categorias SET nome_cat = @_nome, feito_tar = @_feito WHERE id_tar = @_id";

                query.Parameters.AddWithValue("@_descricao", item.Descricao);
                query.Parameters.AddWithValue("@_feito", item.Feito);
                query.Parameters.AddWithValue("@_id", item.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi atualizado. Verifique e tente novamente");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

        public void Delete(int id)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "DELETE FROM tarefas WHERE id_tar = @_id";

                query.Parameters.AddWithValue("@_id", id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi excluído. Verifique e tente novamente");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }*/

    }
}

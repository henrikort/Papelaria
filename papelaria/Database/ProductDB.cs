
using Npgsql;
using papelaria.Models;

namespace Papelaria.Database
{
    public class CargoDB
    {
        public bool Add(Cargo cargo)
        {
            bool result = false;

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"INSERT INTO cargos (nome, salario, descricao) VALUES (@nome, @salario, @descricao);";
                    cmd.Parameters.AddWithValue("@nome", cargo.Nome);
                    cmd.Parameters.AddWithValue("@salario", cargo.Salario);
                    cmd.Parameters.AddWithValue("@descricao", cargo.Descricao);

                    AccessDB db = new AccessDB();
                    using (cmd.Connection = db.OpenConnection())
                    {
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
               
            }
            return result;
        }

        public Cargo Get(int id)
        {
            Cargo cargo = new Cargo();
            AccessDB db = new AccessDB();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM cargos WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", id);

                    using (cmd.Connection = db.OpenConnection())
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cargo.Id = Convert.ToInt32(reader["id"]);
                            cargo.Nome = reader["nome"].ToString();
                            cargo.Salario = Convert.ToDecimal(reader["salario"]);
                            cargo.Descricao = reader["descricao"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return cargo;
        }

        public List<Cargo> GetAll()
        {
            List<Cargo> cargos = new List<Cargo>();
            AccessDB db = new AccessDB();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM cargos;";

                    using (cmd.Connection = db.OpenConnection())
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cargo cargo = new Cargo
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nome = reader["nome"].ToString(),
                                Salario = Convert.ToDecimal(reader["salario"]),
                                Descricao = reader["descricao"].ToString()
                            };
                            cargos.Add(cargo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return cargos;
        }

        public bool Update(Cargo cargo)
        {
            bool result = false;
            AccessDB db = new AccessDB();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"UPDATE cargos SET nome = @nome, salario = @salario, descricao = @descricao WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", cargo.Id);
                    cmd.Parameters.AddWithValue("@nome", cargo.Nome);
                    cmd.Parameters.AddWithValue("@salario", cargo.Salario);
                    cmd.Parameters.AddWithValue("@descricao", cargo.Descricao);

                    using (cmd.Connection = db.OpenConnection())
                    {
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            AccessDB db = new AccessDB();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"DELETE FROM cargos WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", id);

                    using (cmd.Connection = db.OpenConnection())
                    {
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return result;
        }
    }
}

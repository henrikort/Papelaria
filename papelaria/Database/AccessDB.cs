using Npgsql;
using papelaria.Global;


namespace Papelaria.Database
{
    public class AccessDB
    {
        public NpgsqlConnection OpenConnection()
        {
            string connectionString = $"Server={Config.dbHost};User Id={Config.dbUser};Database={Config.dbName};Port={Config.dbPort};Password={Config.dbPass};";
            NpgsqlConnection con = new NpgsqlConnection(connectionString);
            con.Open();
            return con;
        }
    }
}

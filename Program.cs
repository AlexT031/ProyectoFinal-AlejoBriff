using System.Data;
using System.Data.SqlClient;
class Program
{
    static void Main(String[] args)
    {
        SqlConnectionStringBuilder connectionStringBuilder = new();
        connectionStringBuilder.DataSource = "DESKTOP-50OP213";
        connectionStringBuilder.InitialCatalog = "SistemaGestion";
        connectionStringBuilder.IntegratedSecurity = true;
        var cs = connectionStringBuilder.ConnectionString;

        //Traer Usuario
        Console.WriteLine("////////Traer Usuario///////////\n");
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT *  FROM Usuario WHERE Nombre = 'Tobias'";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0} / {1} / {2} / {3} / {4}\n", reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
            }
            reader.Close();
        }
        //Traer Producto
        Console.WriteLine("////////Traer Producto///////////\n");

        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT *  FROM Producto WHERE IdUsuario = 1";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0} / {1} / {2} / {3}\n", reader.GetString(1), reader.GetDecimal(2), reader.GetDecimal(3), reader.GetInt32(4));
            }
            reader.Close();
        }
        //Traer Productos Vendidos
        Console.WriteLine("////////Traer Producto Vendidos///////////\n");

        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select * from Producto SELECT * FROM ProductoVendido A join Producto B on B.Id = A.IdProducto";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0} / {1} / {2} / {3} / {4}\n ", reader.GetString(1), reader.GetDecimal(2), reader.GetDecimal(3), reader.GetInt32(4), reader.GetInt64(5));
            }
            reader.Close();
        }
        //Inicio de sesión
        Console.WriteLine("////////Inicio de sesión///////////\n");
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select * FROM Usuario Where NombreUsuario = 'tcasazza' AND Contraseña = 'SoyTobiasCasazza'";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0} / {1} / {2} / {3} / {4}\n", reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
            }
            reader.Close();
        }
    }
}

  
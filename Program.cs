using System.Data.SqlClient;

namespace csharp_db_connection // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string stringaDiConnesione = "Data Source=localhost;Initial Catalog=biblioteca;Integrated Security=True;Pooling=False";
            
            using (SqlConnection conn = new SqlConnection(stringaDiConnesione))
            {
                conn.Open();

                using (SqlCommand insert = new SqlCommand(@"insert into Clienti (Id, nome, cognome, codice_cliente)
                    values(1, 'il nome della persona','il cognome della persona', 2817263)", conn))
                {
                    var NumRows = insert.ExecuteNonQuery();
                    Console.WriteLine(NumRows);
                }

                using (SqlCommand query = new SqlCommand("select * from Clienti", conn))
                {
                    SqlDataReader reader = query.ExecuteReader();
                    Console.WriteLine(reader.FieldCount);
                    while (reader.Read())
                    {
                        for(int i = 0; i < reader.FieldCount; i++)
                        Console.WriteLine("{0}", reader[i]);
                        Console.WriteLine();
                    }
                    conn.Close();
                }
            }
        }
    }
}

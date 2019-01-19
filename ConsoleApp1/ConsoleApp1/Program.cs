using Oracle.ManagedDataAccess.Client;
using System;

namespace ConsoleApp1
{
    class Program
    {
        private static readonly string connectinString = "Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.99.100)(PORT = 1521)))(CONNECT_DATA = (SID = xe)));Persist Security Info=True;User ID=Teste;Password=123456;Pooling=True;Connection Timeout=60;";

        static void Main(string[] args)
        {
            using (var conn = new OracleConnection(connectinString))
            {
                using(var cmd = conn.CreateCommand())
                {
                    conn.Open();

                    cmd.CommandText = "select * from pessoa";

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine("===========================");
                        Console.WriteLine($"Id:{reader["Id"]}");
                        Console.WriteLine($"Nome: {reader["Nome"]}");
                    }

                    Console.WriteLine("===========================");

                    reader.Dispose();                    
                }
            }

            Console.ReadKey();
        }
    }
}

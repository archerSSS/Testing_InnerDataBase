using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseExp
{
    class Program
    {
        static SqlConnection connection;

        static void Main(string[] args)
        {//Integrated Security=SSPI
            //User Instance=true
            connection = new SqlConnection(@"data source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDBFilename=|DataDirectory|Database1.mdf");
            
            connection.Open();


            SqlCommand com = new SqlCommand("INSERT INTO [Table] (Id, [Name], [Surname]) VALUES(3, 'Trevor', 'Markson')");
            com.Connection = connection;
            com.ExecuteNonQuery();
            connection.Close();

            connection.Open();
            SqlCommand com2 = new SqlCommand("SELECT * FROM [Table]");
            com2.Connection = connection;
            SqlDataReader reader = com2.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string n = reader.GetString(1);
                    string s = reader.GetString(2);
                }
            }
            connection.Close();
        }
    }
}

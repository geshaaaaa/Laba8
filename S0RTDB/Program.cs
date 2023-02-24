using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using DBSort;
using System.Text.RegularExpressions;
using System;

namespace DBSort
{
    class Program
    {

        static void Main()
        {

            string connectionString = @"Data Source=GENA;Initial Catalog=SchoolСlass;Integrated Security=True";
            string sqlExpression = "SELECT * FROM Groups";
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand comd = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = comd.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));
                    List<SortGroup> groups = new List<SortGroup>();
                    while (reader.Read())
                    {
                        SortGroup group = new SortGroup();
                        group.Id = reader.GetInt32(0);
                        group.Name = reader.GetString(1);
                        group.Grade = reader.GetInt32(2);
                        groups.Add(group);
                        Console.WriteLine("{0} \t{1} \t{2}", reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                    }

                    var sortedstuudents = groups.OrderBy(g => g.Grade);
                    Console.WriteLine("Оцінки за зростанням:");
                    foreach (var student in sortedstuudents)
                    {
                        Console.WriteLine("{0} \t{1} \t{2}", student.Id, student.Name, student.Grade);
                    }


                }

                Console.Read();
            }


        }



    }
}

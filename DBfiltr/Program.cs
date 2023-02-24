using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using DBlearning;
namespace DBlearning
{
    class Program
    {
        
        static void Main()
        {

            string connectionString = @"Data Source=GENA;Initial Catalog=SchoolСlass;Integrated Security=True";
            string sqlExpression = "SELECT * FROM Groups";
            Func<Group, bool> gradeFilter = s => s.Grade >= 3.5;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand comd = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = comd.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));
                    List<Group> groups = new List<Group>();
                    while (reader.Read())
                    {
                        Group group = new Group();
                        group.Id = reader.GetInt32(0);
                        group.Name = reader.GetString(1);
                        group.Grade = reader.GetInt32(2);
                        groups.Add(group);
                        Console.WriteLine("{0} \t{1} \t{2}", reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                    }

                    var studentsfiltergrade = groups.Where(gradeFilter);
                    Console.WriteLine("Студенти з оцінкою >= 3.5:");
                    foreach (var student in studentsfiltergrade)
                    {
                        Console.WriteLine("{0} \t{1} \t{2}", student.Id, student.Name, student.Grade);
                    }

                                       
                }

                Console.Read();
            }


        }



    }
}
    


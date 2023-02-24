using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace DBlearning
{
    public class MyStudents : DbContext
    {
        public MyStudents() : base("DbConnect")
        {

        }
        public DbSet<Group> Groups { get; set; }




    }
}



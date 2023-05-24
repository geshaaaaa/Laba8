using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace GropDB
{
    class Program
    {
        delegate int Lenghtofstring(string a);
        static void Main(string[] args)
        {
            Lenghtofstring lenghtofstring = a => a.Length;

            List<string> list = new List<string>()
            {
                "Hello",
                "How are u doing?",
                "My name is..."

            };
            Console.WriteLine($"1st word:{list[0]} 2nd word: {list[1]},3rd word:{list[2]}");
            foreach (string s in list)
            {
                int number = lenghtofstring(s);
                Console.WriteLine(number);
            }







        }
    }
}
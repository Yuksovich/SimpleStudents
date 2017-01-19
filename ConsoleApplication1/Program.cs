using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)

        {
             var context = new UniversityContext();
             var student = new Student() {FirstName = "John", LastName = "Doe"};
             context.Students.Add(student);
             context.SaveChanges();
        }
    }
}
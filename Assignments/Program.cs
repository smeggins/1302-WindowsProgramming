using System;
using Assignments.Assignment1;

namespace Assignments
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World bb!");

            string[] classes = new string[] {"math", "science"};

            Administrator admin = new Administrator("jim", "jam", "admin@email.com", "(123)456-7445", new Address("222nd", "vancouver", "BC", "v2x-555"), "123admin", "9am-5pm");
            Instructor instructor = new Instructor("jane", "john", "instruct@email.com", "(123)456-1234", new Address("222nd", "vancouver", "BC", "v2x-555"), "123teach", classes);
            Student student = new Student("Tom", "Tron", "student@email.com", "(123)456-6534", new Address("222nd", "vancouver", "BC", "v2x-555"), "123student");

            

        }
    }
}

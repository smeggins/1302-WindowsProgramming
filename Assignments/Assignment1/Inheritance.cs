using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.Assignment1
{
    public class Test
    {
        public static void runTest()
        {
            string[] classes = new string[] { "math", "science" };

            Administrator admin = new Administrator("jim", "jam", "admin@email.com", "(123)456-7445", new Address("222nd", "vancouver", "BC", "v2x-555"), "123admin", "9am-5pm");
            Instructor instructor = new Instructor("jane", "john", "instruct@email.com", "(123)456-1234", new Address("222nd", "vancouver", "BC", "v2x-555"), "123teach", classes);
            Student student = new Student("Tom", "Tron", "student@email.com", "(123)456-6534", new Address("222nd", "vancouver", "BC", "v2x-555"), "123student");

            Console.WriteLine("info from student");
            Console.WriteLine("name = " + student.fName + " " + student.lName);
            Console.WriteLine("studentID = " + student.studentID);

            Console.WriteLine("\ninfo from admin");
            Console.WriteLine("name = " + admin.fName + " " + admin.lName);
            Console.WriteLine("employeeID = " + admin.employeeID);
            Console.WriteLine("officeHours = " + admin.officeHours);

            Console.WriteLine("\ninfo from instructor");
            Console.WriteLine("name = " + instructor.fName + " " + instructor.lName);
            Console.WriteLine("employeeID = " + instructor.employeeID);
            Console.Write("classes = ");

            foreach (var item in instructor.teaching)
            {
                Console.Write(item + ", ");
            }
        }
    }

    public class Address
    {
        public string street;
        public string city;
        public string state;
        public string zipCode;

        public Address(string _street, string _city, string _state, string _zipcode)
        {
            street = _street;
            city = _city;
            state = _state;
            zipCode = _zipcode;
        }
    }

    public class Person
    {
        public string fName;
        public string lName;
        public string email;
        public string phone;
        public Address address;

        public Person (string _fName, string _lName, string _email, string _phone, Address _address)
        {
            fName = _fName;
            lName = _lName;
            email = _email;
            phone = _phone;
            address = _address;
        }
    }

    public class Student : Person
    {
        public string studentID;

        public Student(string _fName, string _lName, string _email, string _phone, Address _address, string _studentID) : base(_fName, _lName, _email, _phone, _address)
        {
            studentID = _studentID;
        }
    }

    public class Instructor : Employee
    {
        public string[] teaching;

        public Instructor(string _fName, string _lName, string _email, string _phone, Address _address, string _employeeID, string[] _teaching) : base(_fName, _lName, _email, _phone, _address, _employeeID)
        {
            teaching = _teaching;
        }
    }

    public class Administrator : Employee
    {
        public string officeHours;
        public Administrator(string _fName, string _lName, string _email, string _phone, Address _address, string _employeeID, string _officeHours) : base(_fName, _lName, _email, _phone, _address, _employeeID)
        {
            officeHours = _officeHours;
        }
    }

    public class Employee : Person
    {
        public string employeeID;

        public Employee(string _fName, string _lName, string _email, string _phone, Address _address, string _employeeID) : base(_fName, _lName, _email, _phone, _address)
        {
            employeeID = _employeeID;
        }
    }
}

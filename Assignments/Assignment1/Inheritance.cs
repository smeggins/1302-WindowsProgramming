using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.Assignment1
{
    class Address
    {
        string street;
        string city;
        string state;
        string zipCode;

        public Address(string _street, string _city, string _state, string _zipcode)
        {
            street = _street;
            city = _city;
            state = _state;
            zipCode = _zipcode;
        }
    }

    class Person
    {
        string fName;
        string lName;
        string email;
        string phone;
        Address address;

        public Person (string _fName, string _lName, string _email, string _phone, Address _address)
        {
            fName = _fName;
            lName = _lName;
            email = _email;
            phone = _phone;
            address = _address;
        }
    }

    class Student : Person
    {
        string studentID;

        public Student(string _fName, string _lName, string _email, string _phone, Address _address, string _studentID) : base(_fName, _lName, _email, _phone, _address)
        {
            studentID = _studentID;
        }
    }

    class Instructor : Employee
    {
        string[] teaching;

        public Instructor(string _fName, string _lName, string _email, string _phone, Address _address, string _employeeID, string[] _teaching) : base(_fName, _lName, _email, _phone, _address, _employeeID)
        {
            teaching = _teaching;
        }
    }

    class Administrator : Employee
    {
        string officeHours;
        public Administrator(string _fName, string _lName, string _email, string _phone, Address _address, string _employeeID, string _officeHours) : base(_fName, _lName, _email, _phone, _address, _employeeID)
        {
            officeHours = _officeHours;
        }
    }

    class Employee : Person
    {
        string employeeID;

        public Employee(string _fName, string _lName, string _email, string _phone, Address _address, string _employeeID) : base(_fName, _lName, _email, _phone, _address)
        {
            employeeID = _employeeID;
        }
    }
}

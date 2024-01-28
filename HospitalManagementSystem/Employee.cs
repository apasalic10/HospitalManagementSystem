using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateTime = System.DateTime;

namespace HospitalManagementSystem
{
    public abstract class Employee : IPerson
    {
        private DateTime _DateOfBirth;
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth
        {
            get => _DateOfBirth;
            set
            {
                if (CalculateAge(value) < 18)
                {
                    throw new ArgumentException("Cannot set age to less than 18!");
                }

                _DateOfBirth = value;
            }
        }

        public int  EmployeeCardNumber { get; set; }

        protected Employee( string firstName, string lastName, DateTime dateOfBirth, int employeeCardNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            EmployeeCardNumber = employeeCardNumber;
        }

        public abstract string GetInformationOfPerson();

        public static int CalculateAge(DateTime birthDate)
        {
            return DateTime.Now.Year - birthDate.Year;
        }

    }
}

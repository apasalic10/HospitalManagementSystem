using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem
{
    public class Nurse : Employee
    {
        public string Department { get; set; }

        public Nurse(string firstName, string lastName, DateTime birthDate, int employyeCardNumber, string department) : base(firstName, lastName, birthDate, employyeCardNumber)
        {
            Department = department;
        }
        public override string GetInformationOfPerson()
        {
            return "FirstName: " + FirstName + "\n" + "LastName: " + LastName + "\n" + "Date of birth: " + DateOfBirth +
                   "\n" + "Employee card number: " + EmployeeCardNumber + "\n" + "Department: " + Department;
        }
    }
}

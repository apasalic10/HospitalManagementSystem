namespace HospitalManagementSystem
{
    public class Nurse : Employee
    {
        public string Department { get; set; }

        public Nurse(string firstName, string lastName, DateTime birthDate, int employeeCardNumber, string department) : base(firstName, lastName, birthDate, employeeCardNumber)
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

namespace HospitalManagementSystem
{
    public class Doctor : Employee
    {
        public string Specialization { get; set; }

        public Doctor(string firstName, string lastName, DateTime birthDate, int employeeCardNumber, string specialization) : base(firstName,lastName,birthDate,employeeCardNumber)
        {
            Specialization = specialization;
        }

        public Doctor(){}

        public override string GetInformationOfPerson()
        {
            return "FirstName: " + FirstName + "\n" + "LastName: " + LastName + "\n" + "Date of birth: " + DateOfBirth +
                   "\n" + "Employee card number: " + EmployeeCardNumber + "\n" + "Specialization: " + Specialization + "\n";
        }
    }
}

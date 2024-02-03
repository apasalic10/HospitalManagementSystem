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
                if (Hospital.CalculateAge(value) < 18)
                {
                    throw new ArgumentException("Cannot set age to less than 18!");
                }

                _DateOfBirth = value;
            }
        }

        private string _Username;
        private string _Password;

        public string Username
        {
            get
            {
                return _Username;
            }
            set
            {
                if (!Hospital.IsUsernameUnique(value))
                {
                    throw new InvalidDataException("Username already exist!");
                }

                _Username = value;
            }
        }
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = Hospital.HashPassword(value);
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

        public Employee(){}

    }
}

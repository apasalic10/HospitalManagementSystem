using System.Xml.Serialization;

namespace HospitalManagementSystem
{
    public class Patient : IPerson
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
                    throw new InvalidDataException("Cannot set age to less than 18!");
                }

                _DateOfBirth = value;
            }
        }

        private string _Username;
        private string _Password;

        public string Username {
            get
            {
                return _Username;
            }
            set
            {
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
                _Password = value;
            }
        }

        public string GetInformationOfPerson()
        {
            return "FirstName: " + FirstName + "\n" + "LastName: " + LastName + "\n" + "Date of birth: " + DateOfBirth;
        }

        public Patient()
        {

        }

        public Patient(DateTime dateOfBirth, string firstName, string lastName, string username, string password)
        {
            DateOfBirth = dateOfBirth;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
        }
    }
}

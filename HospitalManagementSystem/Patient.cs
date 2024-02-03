using System.Xml.Serialization;

namespace HospitalManagementSystem
{
    public class Patient : IPerson
    {
        private DateTime _DateOfBirth;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Prescription> PrescriptionList { get; }

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

        public void addPrescription(Prescription prescription)
        {
            PrescriptionList.Add(prescription);
        }

        public string GetInformationOfPerson()
        {
            return "FirstName: " + FirstName + "\n" + "LastName: " + LastName + "\n" + "Date of birth: " + DateOfBirth;
        }

        public Patient(){}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (Employee.CalculateAge(value) < 18)
                {
                    throw new InvalidDataException("Cannot set age to less than 18!");
                }

                _DateOfBirth = value;
            }
        }

        public void addPrescription(Prescription prescription)
        {
            PrescriptionList.Add(prescription);
        }

        public string GetInformationOfPerson()
        {
            throw new NotImplementedException();
        }
    }
}

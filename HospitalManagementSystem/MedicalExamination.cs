using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem
{
    public class MedicalAppointment
    {
        private DateTime _ExaminationDate;
        private Patient _Patient;
        private Doctor _Doctor;

        public DateTime ExaminationDate
        {
            get => _ExaminationDate;
            set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException("Invalid date!");
                }

                _ExaminationDate = value;
            }
        }

        public Patient Patient
        {
            get => _Patient;
            set => _Patient = value;
        }

        public Doctor Doctor
        {
            get => _Doctor;
            set => _Doctor = value;
        }

        public MedicalAppointment(DateTime appointmentDate, Patient patient, Doctor doctor)
        {
            ExaminationDate = appointmentDate;
            Patient = patient;
            Doctor = doctor;
        }
    }
}

namespace HospitalManagementSystem
{
    public class MedicalAppointment
    {
        private DateTime _AppointmentDate;
        private Patient _Patient;
        private Doctor _Doctor;

        public DateTime AppointmentDate
        {
            get => _AppointmentDate;
            set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException("Invalid date!");
                }

                _AppointmentDate = value;
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
            AppointmentDate = appointmentDate;
            Patient = patient;
            Doctor = doctor;
        }
    }
}

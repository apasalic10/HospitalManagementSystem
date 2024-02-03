using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Text;

namespace HospitalManagementSystem
{
    public class Hospital
    {
        private List<Doctor>? doctors = ReturnSaveDoctors();
        private List<Patient>? patients = ReturnSavePatients();
        private List<MedicalAppointment>? appointments = ReturnSaveAppointments();

        public void AddDoctor(Doctor doctor)
        {
            doctors.Add(doctor);

            UpdateFile("Doctor");
        }

        public void RemoveDoctor(Doctor doctor)
        {
            doctors.Remove(doctor);
            UpdateFile("Doctor");
        }

        public void AddPatient(Patient patient)
        {
            patients.Add(patient);

            UpdateFile("Patient");
        }

        public void RemovePatient(Patient patient)
        {
            patients.Remove(patient);
            UpdateFile("Patient");
        }

        public void ScheduleAppointment(DateTime date, Patient patient, Doctor doctor)
        {
            appointments.Add(new MedicalAppointment(date,patient,doctor));

            UpdateFile("Appointment");
        }

        public void CancelAppointment(MedicalAppointment appointment)
        {
            appointments.Remove(appointment);
            UpdateFile("Appointment");
        }

        public List<MedicalAppointment> GetAppointmentsOfPatient(Patient patient)
        {
            List<MedicalAppointment> patientAppointments = new List<MedicalAppointment>();

            foreach (MedicalAppointment appointment  in appointments)
            {
                patientAppointments.Add(appointment);
            }

            return patientAppointments;
        }


        private void UpdateFile(string type)
        {
            if (type.Equals("Doctor"))
            {
                string relativePath = "../../../Data/" + type + ".xml";

                using (FileStream stream = File.OpenWrite(relativePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Doctor>));

                    serializer.Serialize(stream, doctors);
                }
            }
            else if (type.Equals("Patient"))
            {
                string relativePath = "../../../Data/" + type + ".xml";

                using (FileStream stream = File.OpenWrite(relativePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Patient>));

                    serializer.Serialize(stream, patients);
                }
            }
            else
            {
                string relativePath = "../../../Data/" + type + ".xml";

                using (FileStream stream = File.OpenWrite(relativePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<MedicalAppointment>));

                    serializer.Serialize(stream, appointments);
                }
            }
        }

        public List<Prescription>? GetPrescriptionsOfPatient(Patient patient)
        {
            List<Prescription>? prescriptionList = new List<Prescription>();

            string relativePath = "../../../Data/Prescriptions.xml";

            using (FileStream stream = File.OpenWrite(relativePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Prescription>));

                prescriptionList = (List<Prescription>)(serializer.Deserialize(stream))!;
            }

            return prescriptionList;
        }

        public Patient? GetPatient(Predicate<Patient> patient)
        {
            var patients = ReturnSavePatients();
            return patients.Find(patient);
        }

        public List<Patient> GetPatients()
        {
            return ReturnSavePatients();
        }

        public List<Doctor> GetADoctors()
        {
            return ReturnSaveDoctors();
        }

        public Doctor? GetDoctor(Predicate<Doctor> doctor)
        {
            var doctors = ReturnSaveDoctors();
            return doctors.Find(doctor);
        }

        public static bool IsUsernameUnique(string username)
        {
            var patientList = ReturnSavePatients();

            foreach (var patient in patientList)
            {
                if (patient.Username.Equals(username))
                {
                    return false;
                }
            }

            return true;
        }

        public static int CalculateAge(DateTime birthDate)
        {
            return DateTime.Now.Year - birthDate.Year;
        }

        public static string HashPassword(string password)
        {
            var sha = SHA256.Create();

            var asByteArray = Encoding.Default.GetBytes(password);
            var hashedPassword = sha.ComputeHash(asByteArray);

            return Convert.ToBase64String(hashedPassword);
        }

        public Patient? LogInPatient(string username, string password)
        {
            var patientList = ReturnSavePatients();

            foreach (var patient in patientList)
            {
                if (patient.Username.Equals(username) && patient.Password.Equals(password))
                {
                    return patient;
                }
            }

            return null;
        }

        public Doctor? LogInDoctor(string username, string password)
        {
            var doctorList = ReturnSaveDoctors();

            foreach (var doctor in doctorList)
            {
                if (doctor.Username.Equals(username) && doctor.Password.Equals(password))
                {
                    return doctor;
                }
            }

            return null;
        }

        private static List<Patient>? ReturnSavePatients()
        {
            List<Patient>? patientList = new List<Patient>();

            string relativePath = "../../../Data/Patients.xml";

            using (FileStream stream = File.OpenWrite(relativePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Patient>));

                patientList = (List<Patient>)(serializer.Deserialize(stream))!;
            }

            return patientList;
        }

        private static List<Doctor>? ReturnSaveDoctors()
        {
            List<Doctor>? doctorList = new List<Doctor>();

            string relativePath = "../../../Data/Patients.xml";

            using (FileStream stream = File.OpenWrite(relativePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Doctor>));

                doctorList = (List<Doctor>)(serializer.Deserialize(stream))!;
            }

            return doctorList;
        }

        private static List<MedicalAppointment>? ReturnSaveAppointments()
        {
            List<MedicalAppointment>? appointmentList = new List<MedicalAppointment>();

            string relativePath = "../../../Data/Appointments.xml";

            using (FileStream stream = File.OpenWrite(relativePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<MedicalAppointment>));

                appointmentList = (List<MedicalAppointment>)(serializer.Deserialize(stream))!;
            }

            return appointmentList;
        }
    }
}

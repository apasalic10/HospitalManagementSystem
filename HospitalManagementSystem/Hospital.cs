using System.Globalization;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Numerics;

namespace HospitalManagementSystem
{
    public class Hospital
    {
        private List<Doctor> doctors = ReturnSaveDoctors();
        private List<Patient>? patients = ReturnSavePatients();
        private List<MedicalAppointment>? appointments = ReturnSaveAppointments();

        public void AddDoctor(Doctor doctor)
        {
            doctors.Add(doctor);

            UpdateFile("Doctors");
        }

        public void RemoveDoctor(Doctor doctor)
        {
            doctors.Remove(doctor);
            UpdateFile("Doctors");
        }

        public void AddPatient(Patient patient)
        {
            patients.Add(patient);

            UpdateFile("Patients");
        }

        public void RemovePatient(Patient patient)
        {
            patients.Remove(patient);
            UpdateFile("Patients");
        }

        public void ScheduleAppointment(DateTime date, Patient patient)
        {
            appointments.Add(new MedicalAppointment(date,patient,doctors[0]));

            UpdateFile("Appointments");
        }

        public void CancelAppointment(MedicalAppointment appointment)
        {
            appointments.Remove(appointment);
            UpdateFile("Appointments");
        }

        public List<MedicalAppointment> GetAppointmentsOfPatient(Patient patient)
        {
            return ReturnSaveAppointments()
                .Where(appointment => appointment.Patient.Username.Equals(patient.Username))
                .ToList();
        }

        public List<MedicalAppointment> GetAppointmentsOfDoctor(Doctor doctor)
        {
            return ReturnSaveAppointments()
                .Where(appointment => appointment.Doctor.Username.Equals(doctor.Username))
                .ToList();
        }

        private void UpdateFile(string type)
        {
            if (type.Equals("Doctors"))
            {
                string relativePath = "../../../Data/" + type + ".xml";

                using (FileStream stream = File.OpenWrite(relativePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Doctor>));

                    serializer.Serialize(stream, doctors);
                }
            }
            else if (type.Equals("Patients"))
            {
                string relativePath = "../../../Data/" + type + ".xml";

                using (FileStream stream = File.OpenWrite(relativePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Patient>));

                    serializer.Serialize(stream, patients);
                }
            }
            else if(type.Equals("Appointments"))
            {
                string relativePath = "../../../Data/" + type + ".xml";

                using (FileStream stream = File.OpenWrite(relativePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<MedicalAppointment>));

                    serializer.Serialize(stream, appointments);
                }
            }
        }

        public Patient? GetPatientByName(string firstName, string lastName)
        {
            var patients = ReturnSavePatients();
            foreach (var patient in patients)
            {
                if (patient.FirstName.Equals(firstName) && patient.LastName.Equals(lastName))
                {
                    return patient;
                }
            }

            return null;
        }

        public List<Patient> GetPatients()
        {
            return ReturnSavePatients();
        }

        public List<Doctor> GetDoctors()
        {
            return ReturnSaveDoctors();
        }

        public Doctor? GetDoctor(Predicate<Doctor> doctor)
        {
            var doctors = ReturnSaveDoctors();
            return doctors.Find(doctor);
        }

        public static int CalculateAge(DateTime birthDate)
        {
            return DateTime.Now.Year - birthDate.Year;
        }

        public Patient? LogInPatient(string username, string password)
        {
            var patientList = ReturnSavePatients();

            foreach (var patient in patientList)
            {
                if (patient.Username.Equals(username) && password.Equals(patient.Password))
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
                if (doctor.Username.Equals(username) && password.Equals(doctor.Password))
                {
                    return doctor;
                }
            }

            return null;
        }

        public static List<Patient>? ReturnSavePatients()
        {
            List<Patient>? patientList = new List<Patient>();

            string relativePath = "../../../Data/Patients.xml";

            using (FileStream stream = File.OpenRead(relativePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Patient>));

                try
                {
                    patientList = (List<Patient>)(serializer.Deserialize(stream))!;
                }
                catch (InvalidDataException)
                {
                    patientList = new List<Patient>();
                }
            }

            return patientList;
        }

        public static List<Doctor>? ReturnSaveDoctors()
        {
            List<Doctor>? doctorList = new List<Doctor>();

            string relativePath = "../../../Data/Doctors.xml";

            try
            {
                using (FileStream stream = File.Open(relativePath, FileMode.OpenOrCreate))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Doctor>));
                    doctorList = (List<Doctor>)(serializer.Deserialize(stream))!;
                }
            }
            catch (InvalidDataException)
            {
                doctorList = new List<Doctor>();
            }

            return doctorList;
        }


        public static List<MedicalAppointment>? ReturnSaveAppointments()
        {
            List<MedicalAppointment>? appointmentList = new List<MedicalAppointment>();

            string relativePath = "../../../Data/Appointments.xml";

            using (FileStream stream = File.OpenRead(relativePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<MedicalAppointment>));

                try
                {
                    appointmentList = (List<MedicalAppointment>)(serializer.Deserialize(stream))!;
                }
                catch (InvalidDataException)
                {
                    appointmentList = new List<MedicalAppointment>();
                }
                
            }

            return appointmentList;
        }
    }
}

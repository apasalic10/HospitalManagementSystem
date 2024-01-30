using System.Xml.Serialization;

namespace HospitalManagementSystem
{
    public class Hospital
    {
        private List<Doctor> doctors = new List<Doctor>();
        private List<Patient> patients = new List<Patient>();
        private List<MedicalAppointment> appointments = new List<MedicalAppointment>();

        public List<Doctor> Doctors => doctors;
        public List<Patient> Patients => patients;
        public List<MedicalAppointment> Appointments => appointments;

        public void AddDoctor(Doctor doctor)
        {
            doctors.Add(doctor);

            SaveToFile("Doctor");
        }

        public void RemoveDoctor(Doctor doctor)
        {
            doctors.Remove(doctor);
        }

        public void AddPatient(Patient patient)
        {
            patients.Add(patient);

            SaveToFile("Patient");
        }

        public void RemovePatient(Patient patient)
        {
            patients.Remove(patient);
        }

        public void ScheduleAppointment(DateTime date, Patient patient, Doctor doctor)
        {
            appointments.Add(new MedicalAppointment(date,patient,doctor));

            SaveToFile("Appointment");
        }

        public void CancelAppointment(MedicalAppointment appointment)
        {
            appointments.Remove(appointment);
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


        private void SaveToFile(string type)
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
                XmlSerializer serializer = new XmlSerializer(typeof(List<MedicalAppointment>));

                prescriptionList = (List<Prescription>)(serializer.Deserialize(stream))!;
            }

            return prescriptionList;
        }

        public Patient? GetPatient(Predicate<Patient> patient)
        {
            return patients.Find(patient);
        }

        public List<Patient> GetPatients()
        {
            return patients;
        }

        public List<Doctor> GetADoctors()
        {
            return doctors;
        }

        public Doctor? GetDoctor(Predicate<Doctor> doctor)
        {
            return doctors.Find(doctor);
        }
    }
}

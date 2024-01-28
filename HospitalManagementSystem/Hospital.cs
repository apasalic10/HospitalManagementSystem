using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem
{
    public class Hospital
    {
        private List<Doctor> doctors;
        private List<Patient> patients;
        private List<MedicalAppointment> appointments;

        public List<Doctor> Doctors { get {  return doctors; } }
        public List<Patient> Patients { get { return patients; } }
        public List<MedicalAppointment> Appointments { get {  return appointments; } }

        public void AddDoctor(Doctor doctor)
        {
            doctors.Add(doctor);
        }

        public void RemoveDoctor(Doctor doctor)
        {
            doctors.Remove(doctor);
        }

        public void AddPatient(Patient patient)
        {
            patients.Add(patient);
        }

        public void RemovePatient(Patient patient)
        {
            patients.Remove(patient);
        }

        public void ScheduleAppointment(DateTime date, Patient patient, Doctor doctor)
        {
            appointments.Add(new MedicalAppointment(date,patient,doctor));
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
    }
}

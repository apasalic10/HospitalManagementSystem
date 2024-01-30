namespace HospitalManagementSystem
{
    public class Prescription
    {
        private Patient _Patient;
        private Doctor _Doctor;
        private string _MedicalDiagnosis;

        public Prescription(Patient patient, Doctor doctor, string medicalDiagnosis)
        {
            Patient = patient;
            Doctor = doctor;
            MedicalDiagnosis = medicalDiagnosis;
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

        public string MedicalDiagnosis
        {
            get => _MedicalDiagnosis;
            set => _MedicalDiagnosis = value;
        }


    }
}

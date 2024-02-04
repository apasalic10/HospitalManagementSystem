using System.Threading.Channels;
using HospitalManagementSystem;


Hospital hospital = new Hospital();
Console.WriteLine("Welcome to the Hospitals app!");

while (true)
{
    Console.WriteLine("Select an option: \n1 - Patient \n2 - Doctor \n3 - Close");
    string? userChoice = Console.ReadLine();

    if(userChoice.Equals("1"))
    {
        HandlePatientOptions(hospital);
    }
    else if (userChoice == "2")
    {
        HandleDoctorOptions(hospital);
    }
    else if (userChoice.Equals("3"))
    {
        break;
    }
    else
    {
        Console.WriteLine("You have selected a non-existent option. Please re-enter!");
    }
}


static void HandlePatientOptions(Hospital hospital)
{
    while (true)
    {
        Console.WriteLine("Select an option: \n1 - Login \n2 - Sign up \n3 - Roll back");
        string? choice = Console.ReadLine();

        if (choice.Equals("1"))
        {
            HandlePatientLogin(hospital);
        }
        else if (choice.Equals("2"))
        {
            HandlePatientSignup(hospital);
        }
        else if (choice.Equals("3"))
        {
            break;
        }
        else
        {
            Console.WriteLine("You have selected a non-existent option. Please re-enter!");
        }

    }
}

static void HandleDoctorOptions(Hospital hospital)
{
    while (true)
    {
        Console.WriteLine("Select an option: \n1 - Login \n2 - Roll back");
        string? choice = Console.ReadLine();

        if (choice.Equals("1"))
        {
            HandleDoctorLogin(hospital);
        }
        else if (choice.Equals("2"))
        {
            break;
        }
        else
        {
            Console.WriteLine("You have selected a non-existent option. Please re-enter!");
        }
    }
}

static void HandleDoctorLogin(Hospital hospital)
{
    while (true)
    {
        Console.WriteLine("Username: ");
        string? username = Console.ReadLine();
        Console.WriteLine("Password: ");
        string? password = Console.ReadLine();

        Doctor doctor = hospital.LogInDoctor(username, password);

        if (doctor != null)
        {
            Console.WriteLine("You are successfully logged in!");
            HandleWhenDoctorIsLogged(hospital, doctor);
            break;
        }
        else
        {
            Console.WriteLine("Incorrect data. Please re-enter!");
        }
    }
}

static void HandleWhenDoctorIsLogged(Hospital hospital, Doctor doctor)
{
    while (true)
    {
        Console.WriteLine("Select an option: \n1 - View patients \n2 - View appointments \n3 - Log out");
        string? choice = Console.ReadLine();

        if (choice.Equals("1"))
        {
            var patientList = hospital.GetPatients();

            Console.WriteLine("Patients: \n");
            foreach (var patient in patientList)
            {
                Console.WriteLine(patient.GetInformationOfPerson() + "\n");
            }
        }
        else if (choice.Equals("2"))
        {
            var appointmentList = hospital.GetAppointmentsOfDoctor(doctor);

            Console.WriteLine("Appointments: \n");
            foreach (var appointment in appointmentList)
            {
                appointment.PrintMedicalAppointment();
            }
        }
        else if (choice.Equals("3"))
        {
            Console.WriteLine("You are successfully logged out!");
            break;
        }
        else
        {
            Console.WriteLine("You have selected a non-existent option. Please re-enter!");
        }
    }
}

static void HandlePatientLogin(Hospital hospital)
{
    while (true)
    {
        Console.WriteLine("Username: ");
        string? username = Console.ReadLine();
        Console.WriteLine("Password: ");
        string? password = Console.ReadLine();

        Patient patient = hospital.LogInPatient(username, password);

        if (patient != null)
        {
            Console.WriteLine("You are successfully logged in!");
            HandleWhenPatientIsLogged(hospital,patient);
            break;
        }
        else
        {
            Console.WriteLine("Incorrect data. Please re-enter!");
        }
    }
}

static void HandlePatientSignup(Hospital hospital)
{
    while (true)
    {
        Console.WriteLine("First name: ");
        string? firstName = Console.ReadLine();
        Console.WriteLine("Last name: ");
        string? lastName = Console.ReadLine();
        Console.WriteLine("Day of birth: ");
        int day = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Month of birth: ");
        int month = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Year of birth: ");
        int year = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Username: ");
        string? username = Console.ReadLine();
        Console.WriteLine("Password: ");
        string? password = Console.ReadLine();

        try
        {
            var dateOfBirth = new DateTime(year, month, day);
            Patient newPatient = new Patient(dateOfBirth, firstName, lastName, username, password);
            hospital.AddPatient(newPatient);
            Console.WriteLine("You have successfully registered!");
            break;
        }
        catch (InvalidDataException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Please re-enter!");
        }
        catch
        {
            Console.WriteLine("Incorrect data. Please re-enter!");
        }
    }
}

static void HandleWhenPatientIsLogged(Hospital hospital, Patient patient)
{
    while (true)
    {
        Console.WriteLine("Select an option: \n1 - Schedule an appointment for today \n2 - View appointments \n3 - Log out");
        string? choice = Console.ReadLine();

        if (choice.Equals("1"))
        {
            hospital.ScheduleAppointment(DateTime.Now.AddHours(5), patient);
        }
        else if (choice.Equals("2"))
        {
            var appointmentList = hospital.GetAppointmentsOfPatient(patient);

            Console.WriteLine("Appointments: \n");
            foreach (var appointment in appointmentList)
            {
                appointment.PrintMedicalAppointment();
            }
        }
        else if (choice.Equals("3"))
        {
            Console.WriteLine("You are successfully logged out!");
            break;
        }
        else
        {
            Console.WriteLine("You have selected a non-existent option. Please re-enter!");
        }
    }
}



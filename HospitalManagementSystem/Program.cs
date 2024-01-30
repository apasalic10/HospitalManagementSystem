// See https://aka.ms/new-console-template for more information

using HospitalManagementSystem;

Console.WriteLine("Hello, World!");

Doctor doctor = new Doctor("Almedin", "Pasalic", new DateTime(2002, 8, 31), 1, "Hirurg");

Hospital hosital = new Hospital();

hosital.AddDoctor(doctor);

Doctor doctor1 = new Doctor("Almedin", "Pasalic", new DateTime(2002, 8, 31), 1, "Kardiolog");

hosital.AddDoctor(doctor1);


namespace HospitalManagementSystem
{
    public interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime DateOfBirth { get; set; }
        string Username { get; set; }
        string Password { get; set; }

        string GetInformationOfPerson();
    }
}

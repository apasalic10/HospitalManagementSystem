namespace HospitalManagementSystem
{
    public interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime DateOfBirth { get; set; }

        string GetInformationOfPerson();
    }
}

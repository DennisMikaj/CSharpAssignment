namespace GetAndRead.Shared.Interfaces
{
    public interface ICustomer
    {
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string Adress { get; set; }

    }
}

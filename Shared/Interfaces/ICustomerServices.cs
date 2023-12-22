using GetAndRead.Shared.Interfaces;
using GetAndRead.Shared.Models;

namespace Shared.Interfaces
{
    public interface ICustomerServices
    {
        bool AddCustomerToList(Customer customer);
        void DeleteContactByEmail(string email);
        IEnumerable<Customer> GetCustomersFromList();
    }
}
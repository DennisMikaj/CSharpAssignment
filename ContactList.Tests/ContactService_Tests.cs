using GetAndRead.Shared.Models;
using GetAndRead.Shared.Interfaces;
using Xunit;
using Shared.Interfaces;
using GetAndRead.Shared.Services;

namespace ContactList.Tests
{
    public class ContactService_Tests
    {
        [Fact]

        public void AddToListShould_AddNewCustomerToList_ThenReturnTrue()
        {
            // Arrange
            Customer customer = new Customer { Email = "Email@domain.com", FirstName = "Dennis", LastName = "Mikaj", PhoneNumber = "070-123 123 12", Adress = "Bästervägen 1" };
            ICustomerServices customerServices = new CustomerServices();

            //Act
            bool result = customerServices.AddCustomerToList(customer);

            //Assert
            Assert.True(result);
        }
    }
}

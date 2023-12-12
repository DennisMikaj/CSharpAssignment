using GetAndRead.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace GetAndRead.Services;

internal class CustomerServices
{
    private readonly FileService _fileService = new FileService(@"C:\Solutions\GetAndRead\content.json");
    private List<Customer> _customerList = new List<Customer>();
    
    public void AddCustomerToList(Customer customer)
    {
        try
        {
            if (!_customerList.Any(x => x.Email == customer.Email))
        {
            
                _customerList.Add(customer);
                _fileService.SaveContentToFile(JsonConvert.SerializeObject(_customerList));
        }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        
    }

    public IEnumerable<Customer> GetCustomersFromList()
    {
        try
        {
            var content = _fileService.GetContentFromFile();
           if (!string.IsNullOrEmpty(content))
            {
                _customerList = JsonConvert.DeserializeObject<List<Customer>>(content)!;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return _customerList;

    }
}

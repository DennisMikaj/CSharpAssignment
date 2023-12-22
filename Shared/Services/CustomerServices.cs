using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GetAndRead.Services;
using GetAndRead.Shared.Models;
using Newtonsoft.Json;
using Shared.Interfaces;

namespace GetAndRead.Shared.Services;

public class CustomerServices : ICustomerServices
{
    private readonly FileService _fileService = new FileService(@"C:\Solutions\GetAndRead\content.json");
    private List<Customer> _customerList = new List<Customer>();

    public bool AddCustomerToList(Customer customer)
    {
        try
        {
            if (!_customerList.Any(x => x.Email == customer.Email))
            {

                _customerList.Add(customer);
                _fileService.SaveContentToFile(JsonConvert.SerializeObject(_customerList));
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;

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

    public void DeleteContactByEmail(string email)
    {
        var contactToRemove = _customerList.FirstOrDefault(c => c.Email == email);

        if (contactToRemove != null)
        {
            _customerList.Remove(contactToRemove);
            SaveCustomerListToFile();
            Console.WriteLine($"Kontakt med e-post {email} har tagits bort.");
        }
        else
        {
            Console.WriteLine($"Ingen kontakt med e-post {email} hittades.");
        }
    }

    private void SaveCustomerListToFile()
    {
        try
        {
            _fileService.SaveContentToFile(JsonConvert.SerializeObject(_customerList));
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"{ex.Message}");
        }
    }
}

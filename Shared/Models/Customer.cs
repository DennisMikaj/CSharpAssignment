using GetAndRead.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetAndRead.Shared.Models
{

    public class Customer : ICustomer
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Adress { get; set; } = null!;
    }
}

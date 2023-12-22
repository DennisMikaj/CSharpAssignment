using GetAndRead.Shared.Services;
using GetAndRead.Shared.Models;


namespace GetAndRead.Services
{
    internal class MenuService
    {

        private readonly CustomerServices _customerService;

        public MenuService(CustomerServices customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }
        public void DisplayMenu()

        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("### MENU ###");
                Console.WriteLine("### 1. Visa Listan ###");
                Console.WriteLine("### 2. Lägg till i listan ###");
                Console.WriteLine("### 3. Ta bort en kontakt med hjälp av e-post ###");
                Console.WriteLine("### 0. Avsluta ###");

                var UserOption = Console.ReadLine();

                switch (UserOption)
                {
                    //Kod för att visa hela listan med kontakter
                    case "1":
                        Console.Clear();
                        Console.WriteLine("### Visa detaljer för en kontakt ###");
                        var list = _customerService.GetCustomersFromList();
                        int i = 0;
                        foreach (var contact in list)
                        {
                            i++;
                            Console.WriteLine($"{i}. Namn: {contact.FirstName} {contact.LastName}.<{contact.Email}>");
                        }
                        Console.Write("Ange numret för kontakten du vill se detaljer för: ");
                        if (int.TryParse(Console.ReadLine(), out int contactNumber) && contactNumber > 0)
                        {
                            var contactList = _customerService.GetCustomersFromList().ToList();

                            if (contactNumber <= contactList.Count)
                            {
                                var selectedContact = contactList[contactNumber - 1];
                                Console.WriteLine($"Detaljer för kontakten:");
                                Console.WriteLine($"Namn: {selectedContact.FirstName} {selectedContact.LastName}");
                                Console.WriteLine($"Email: {selectedContact.Email}");
                                Console.WriteLine($"Telefonnummer: {selectedContact.PhoneNumber}");
                                Console.WriteLine($"Adress: {selectedContact.Adress}");
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt nummer. Försök igen.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt nummer. Försök igen.");
                        }
                        Console.ReadKey();
                        break;

                        //Kod för att lägga till en kontakt
                    case "2":
                        Console.Clear();
                        Console.WriteLine("### Lägg till en kontakt.");
                        Console.Write("Förnamn: ");
                        string newContactFirstName = Console.ReadLine()!;
                        Console.Write("Efternamn: ");
                        string newContactLastName = Console.ReadLine()!;
                        Console.Write("Email: ");
                        string newContactEmail = Console.ReadLine()!;
                        Console.Write("Telefonnummer: ");
                        string newContactPhone = Console.ReadLine()!;
                        Console.Write("Adress: ");
                        string newContactAdress = Console.ReadLine()!;
                        _customerService.AddCustomerToList(new GetAndRead.Shared.Models.Customer
                        {
                            FirstName = $"{newContactFirstName}",
                            LastName = $"{newContactLastName}",
                            Email = $"{newContactEmail}",
                            PhoneNumber = $"{newContactPhone}",
                            Adress = $"{newContactAdress}",
                        });
                        Console.WriteLine($"{newContactFirstName} {newContactLastName} <{newContactEmail}> Telefonnummer: {newContactPhone} från {newContactAdress} Har lagts till i listan!");
                        Console.ReadKey(); 
                        break;

                        //Kod för att Ta bort en kontakt
                    case "3":
                        Console.Clear();
                        Console.WriteLine("### Ta bort en kontakt med hjälp av e-post ###");
                        Console.Write("Ange e-post för kontakten du vill ta bort: ");
                        string emailToDelete = Console.ReadLine()!;
                        _customerService.DeleteContactByEmail(emailToDelete);
                        Console.ReadKey();
                        break;

                        //Stänger av programmet
                    case "0": 
                        Console.Clear();
                        Console.WriteLine("Tack för idag.");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                        
                        //om valet inte är 0 - 3, ogiltigt svar.
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        
    }

    
}



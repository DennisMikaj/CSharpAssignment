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
                Console.WriteLine("### 0. Avsluta ###");

                var UserOption = Console.ReadLine();
                //var customerService = new CustomerServices();

                switch (UserOption)
                {

                    case "1":

                        Console.Clear();
                        var list = _customerService.GetCustomersFromList();
                        foreach (var contact in list)
                        {
                            int i = 0; i++;
                            Console.WriteLine(
                            $"{i}. Namn: {contact.FirstName} {contact.LastName} <{contact.Email}> Telefonnummer: {contact.PhoneNumber}. Adress: {contact.Adress}");
                        }

                        Console.ReadKey();
                        Console.WriteLine();
                        break;

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
                        _customerService.AddCustomerToList(new GetAndRead.Models.Customer
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

                    case "0": 
                        Console.Clear();
                        Console.WriteLine("Tack för idag.");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                }
            }
        }

    }
}



using System;

namespace ConsoleApplication
{
    class Customer
    {
        public string Name;
        public int TeaBags;
        public bool IsReseller;

        public double CalculateTotalCost()
        {
            if (CoffeeBags < 6)
                return CoffeeBags * 36;
            else if (CoffeeBags < 17)
                return CoffeeBags * 34.5;
            else
                return CoffeeBags * 32.7;
        }

        public double CalculateDiscount()
        {
            if (IsReseller)
                return CalculateTotalCost() * 0.20;
            else
                return 0;
        }

        public double AmountPayable()
        {
            return CalculateTotalCost() - CalculateDiscount();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            char choice;

            do
            {
                Customer customer = new Customer();

                Console.Write("Enter New Customer Name: ");
                customer.Name = Console.ReadLine();

                Console.Write("Enter Number Of Tea Bags (1-200): ");
                customer.CoffeeBags = Int32.Parse(Console.ReadLine());

                while (customer.CoffeeBags < 1 || customer.CoffeeBags > 200)
                {
                    Console.WriteLine("Value Must Be Between 1 And 200!");
                    Console.Write("Re-Enter Number Of Coffee Bags (1-200): ");
                    customer.CoffeeBags = Int32.Parse(Console.ReadLine());
                }

                Console.Write("Is Customer A Reseller? (y/Y For Yes): ");
                choice = Console.ReadLine().ToLower()[0];
                customer.IsReseller = (choice == 'y');

                Console.WriteLine();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("------------------- BILL -------------------");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine($"Customer Name: {customer.Name}");
                Console.WriteLine($"Number Of Coffee Bags: {customer.CoffeeBags}");
                Console.WriteLine($"Total Cost Of Bags: {customer.CalculateTotalCost():C}");
                Console.WriteLine($"Discount: {customer.CalculateDiscount():C}");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine($"Amount Payable: {customer.AmountPayable():C}");
                Console.WriteLine("--------------------------------------------");

                Console.Write("Input Y/y To Continue Or Any Other Key To Exit: ");
                choice = Console.ReadLine().ToLower()[0];
                Console.WriteLine();

            } while (choice == 'y');
        }
    }
}

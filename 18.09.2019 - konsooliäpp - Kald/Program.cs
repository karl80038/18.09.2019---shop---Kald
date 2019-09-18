using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _18._09._2019___konsooliäpp___Kald
{
    class Program
    {
        static void Main(string[] args)
        {
            //Let's prepare a shopping cart to our customer (create a new list containing predefined items in it)
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Write("18.09.2019 - Console Application - Kald\n");
            Console.Write("(c) 2019 Karl-Erik Kald. All Rights Reserved.\n");


            List<Food> Groceries = new List<Food>

            {

                new Food ("Banana", 1.2),

                new Food ("Milk", 0.98),

                new Food ("Can of Beans", 1.15),


            };

            //Let's ask the customer to enter his/her first and then the last name

            Console.WriteLine("\nThank you for choosing us. Please enter your first name: ");

            string firstName = Console.ReadLine();

            Console.WriteLine($"\nCould you also provide us your lastname the same way you did with your firstname: ");

            string lastName = Console.ReadLine();

            while (firstName == "" | lastName == "")
            {
                if (firstName == "")
                {
                    Console.WriteLine("\nYou did not enter your first name. Please enter it now: ");
                    firstName = Console.ReadLine();
                }
                else if (lastName == "")
                {
                    Console.WriteLine("\nYou did not enter your last name. Please enter it now:");
                    lastName = Console.ReadLine();
                }
            }
            Customer customer = new Customer(firstName, lastName);
            Console.WriteLine($"\nHi, {firstName}! ");
            Console.WriteLine($"\nWelcome to the store, {customer} ");

            customer.PersonalCart = new Cart();
            ConsoleKey CKEY = ConsoleKey.F;
            //Store(Groceries, customer);

            while (true)
            {
                Store(Groceries, customer);


                while (true)
                {
                    if (customer.PersonalCart.Amount.Count > 0)
                    {
                        Console.WriteLine($"\nYou have currently {customer.PersonalCart.Amount.Count} items in your cart. Is that all?");
                    }
                    else
                    {
                        Console.WriteLine($"\nYou have currently no items in your cart. Leave without purchasing anything?");
                    }
                    CKEY = Console.ReadKey().Key;
                    if (CKEY == ConsoleKey.Y | CKEY == ConsoleKey.N)
                    {
                        break;
                    }
                }

                if (CKEY == ConsoleKey.Y)
                {
                    break;
                }
            }
            double total = customer.PersonalCart.Total;
            if (customer.PersonalCart.Amount.Count > 0)
            {
                Console.WriteLine("\nThank you for the purchase! Here's the summary of items you purchased. At the end you'll find the total cost. ");
                foreach (Food f in customer.PersonalCart.Items)
                {
                    Console.WriteLine($"- Item Name: - Price - \n- {f.Name}  - {f.Price} -");
                }
                Console.WriteLine($"TOTAL: {total}\nPlease visit us again");
            }
            else
            {
                Console.WriteLine("\nYou purchased nothing.\nPlease visit us again!");
            }
            Console.ReadKey();

        }











        private static void Store(List<Food> Groceries, Customer customer)
        {
            Console.WriteLine("What would you like to buy? ");

           
            string food = Console.ReadLine();
            if (food != "")
            {
            char[] a = food.ToCharArray();

            a[0] = char.ToUpper(a[0]);

            int ct = a.Count();

            for (int i = 1; i < ct; i++)
            {
                a[i] = char.ToLower(a[i]);
            }

            food = new string(a);
            }


            if (food == "")
            {
                food = "Unspecified";
            }
            int Amount = 0;

            //Let's check whether the item's name our customer entered actually exists on our list.

            Food chosenFood = Groceries.FirstOrDefault(x => x.Name == food);

            if (chosenFood == null)

            {

                Console.WriteLine($"We are sorry, but currently we do not carry that item ({food}) in our store");


                Console.WriteLine("\nWe currently stock the following items:");

                foreach (Food f in Groceries)
                {
                    Console.WriteLine($"Item's name: {f.Name} Item's price: {f.Price};");
                }



            }

            else

            {

                Console.WriteLine("And how much: ");
                bool Successful;
                string AmounttobeConverted = Console.ReadLine();

                Successful = int.TryParse(AmounttobeConverted, out Amount);


                //The program will ask the customer to input a value in loop until the value entered is in a correct format (needs to be an integer) and is larger than zero(0).

                while (!Successful | Amount == 0)
                {

                    Console.WriteLine("The amount you entered is not in a valid format. The amount can only be a number and it must be higher than 0. ");
                    Console.WriteLine("Amount: ");
                    AmounttobeConverted = Console.ReadLine();

                    Successful = int.TryParse(AmounttobeConverted, out Amount);

                }
                customer.PersonalCart.AddToCart(chosenFood, Amount);

                //Notify the customer that the item was successfully added to the cart

                Console.WriteLine($"The item ({food}) was successfully added to your cart.");
            }

        }
    }
}


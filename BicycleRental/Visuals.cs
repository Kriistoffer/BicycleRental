using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental
{
    class Visuals
    {
        DataHandling HandleData = new DataHandling();

        /*De olika huvudmenyalternativen som används utav metoden DisplayMainMenu.*/
        string[] MainMenuOptions = {
            "Welcome to my bicycle rental place!",
            "",
            "[1]Show all bicycles.",
            "[2]Add a new bicycle.",
            "[3]Edit the price of a bicycle.",
            "[4]Remove a bicycle.",
            "[5]Display a specific bicycle.",
            "[0]Exit the rental shop.",
            "",
            "",
            "Please, pick an option:"};

        /*En väldigt simpel metod för att skapa en variant till huvudmeny, och går till rätt alternativ m.h.a. en if-sats.*/
        public void DisplayMainMenu()
        {
            Console.Clear();
            for (int i = 0; i < MainMenuOptions.Length; i++)
            {
                Console.WriteLine(MainMenuOptions[i]);
            }

            string UserInputMainMenu = Console.ReadLine();

            if (UserInputMainMenu == "1")
            {
                ShowAllBicycles();
            }
            else if (UserInputMainMenu == "2")
            {
                AddBicycle();
            }
            else if (UserInputMainMenu == "3")
            {
                EditBicyclePrice();
            }
            else if (UserInputMainMenu == "4")
            {
                RemoveBicycle();
            }
            else if (UserInputMainMenu == "5")
            {
                ShowSpecificBicycle();
            }
            else if (UserInputMainMenu == "0")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("\n\nPlease, enter a valid option (Number 1, 2, 3, 4, 5, or 0). Press a key to enter your correct option again.");
                Console.ReadKey();
                DisplayMainMenu();
            }

        }

        /*En metod för att visa alla cyklar. Användaren har sedan möjligheten att återvända till huvudmenyn genom menyalternativ 0.*/

        public void ShowAllBicycles()
        {
            HandleData.DisplayAllBicycles();
            Console.WriteLine("\n\nPress [0] to return to the main menu.");

            string UserInputDisplayAllBicycles = Console.ReadLine();

            if (UserInputDisplayAllBicycles == "0")
            {
                DisplayMainMenu();
            }
            else
            {
                Console.WriteLine("\n\nPlease, enter a valid option (Number 0). Press a key to enter your correct option again.");
                Console.ReadLine();
                HandleData.DisplayAllBicycles();
            }
        }

        /*En metod som lägger till en ny cykel m.h.a. input utav användare (admin). En lång rad med prompts som efterfrågar
         nödvändig information för att kunna skapa ett nytt cykelobjekt som sedan ska sparas i databasen. Informationen skickas
         vidare till en metod som faktiskt sparar informationen i databasen.*/

        public void AddBicycle()
        {
            Console.Clear();
            Console.WriteLine("Enter the frame number:");
            string addFrameNumber = Console.ReadLine();

            Console.WriteLine("Enter the bicycle type: (Vanlig cykel, Elcykel, Enhjuling)");
            string addBicycleType = Console.ReadLine();

            Console.WriteLine("Enter the bicycle category:");
            string addBicycleCategory = Console.ReadLine();

            Console.WriteLine("Enter the recommended user:");
            string addRecommendedUser = Console.ReadLine();

            Console.WriteLine("Enter the bicycle make:");
            string addBicycleMake = Console.ReadLine();

            Console.WriteLine("Enter the bicycle model:");
            string addBicycleModel = Console.ReadLine();

            Console.WriteLine("Enter the bicycle color:");
            string addBicycleColor = Console.ReadLine();

            Console.WriteLine("Enter the frame size:");
            string addFrameSize = Console.ReadLine();

            Console.WriteLine("Enter the wheel size:");
            string addWheelSize = Console.ReadLine();

            Console.WriteLine("Enter the number of gears:");
            byte addGears = Convert.ToByte(Console.ReadLine());

            Console.WriteLine("Enter brake back:");
            string addBrakeBack = Console.ReadLine();

            Console.WriteLine("Enter brake front:");
            string addBrakeFront = Console.ReadLine();

            Console.WriteLine("Enter the price:");
            int addPrice = Convert.ToInt32(Console.ReadLine());

            HandleData.AddBicycleToDatabase(addFrameNumber, addBicycleType, addBicycleCategory, addRecommendedUser, addBicycleMake, addBicycleModel, addBicycleColor, addFrameSize, addWheelSize, addGears, addBrakeBack, addBrakeFront, addPrice);
            DisplayMainMenu();

        }

        /*Metod för att redigera priset på en cykel, ber om ramnummer för att hitta korrekt cykel.*/

        public void EditBicyclePrice()
        {
            Console.Clear();
            Console.WriteLine("Enter the frame number of the bicycle you want to edit the price of.");
            string UserInputFramenumber = Console.ReadLine();

            Console.WriteLine("Enter the new price of the bicycle in SEK.");
            int UserInputPriceEdit = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Are you sure you want to change the price of " + UserInputFramenumber + " to " + UserInputPriceEdit + " SEK? (Yes or No)");
            string UserConfirmation = Console.ReadLine();

            if (UserConfirmation == "Yes")
            {
                //Skickar ramnummer på cykeln som ska ändras, samt det nya priset till metoden som ändrar i databasen.
                HandleData.EditBicycleToDatabase(UserInputFramenumber, UserInputPriceEdit);
                DisplayMainMenu();
            }
            else if (UserConfirmation == "No")
            {
                DisplayMainMenu();
            }
            /*Egentligen så ska man hantera "fel" input här, men just nu skickas man bara tillbaka till huvudmenyn om man ger
             ett inkorrekt input. Hanteras i mån av tid. TODO.*/
            DisplayMainMenu();
        }

        /*Ber användare (realistiskt: en admin) om ramnummer för att kunna radera en cykel ur databasen.*/

        public void RemoveBicycle()
        {
            Console.Clear();
            Console.WriteLine("Enter the frame number of the bicycle you want to remove.");
            string UserInputFramenumber = Console.ReadLine();

            Console.WriteLine("Are you sure you want to remove bicycle " + UserInputFramenumber + "?");
            string UserConfirmation = Console.ReadLine();

            if (UserConfirmation == "Yes")
            {
                //Skickar strängen UserInputFramenumber till metoden som raderar cykeln ur databasen.
                HandleData.RemoveBicycleFromDatabase(UserInputFramenumber);
                DisplayMainMenu();
            }
            else if (UserConfirmation == "No")
            {
                Console.WriteLine("Bicycle " + UserInputFramenumber + " will not be removed. Press a key to return to the main menu.");
                Console.ReadKey();
                DisplayMainMenu();
            }
            else
            {
                Console.WriteLine("Something went wrong. Press a key to return to the main menu.");
                Console.ReadKey();
                DisplayMainMenu();
            }
        }

        /*Ber användaren om ett ramnummer för att kunna visa upp all data för en specifik cykel.*/

        public void ShowSpecificBicycle()
        {
            Console.Clear();
            Console.WriteLine("Enter the frame number of the bicycle you want to view: ");
            string UserInputShowSpecificBicycle = Console.ReadLine();

            HandleData.DisplaySpecificBicycle(UserInputShowSpecificBicycle);
            DisplayMainMenu();
        }
    }
}

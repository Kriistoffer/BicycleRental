using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental
{
    class DataHandling
    {
        /*Följande metod hämtar och visar alla cyklar som finns i den "generella" cykeltabellen, men den visar däremot inte
         all data för varje cykel, utan visar endast en viss utvald sådan. Realistiskt så borde den självklart visa en aning mer
         data, men p.g.a. inte en riktig applikation så skippas det nu för att inte kluttra ner konsollen onödigt mycket och
         försvåra läsningen. Men pricipiellt så hade man visat resten utav datan på samma sätt som metoden redan gör.*/

        public void DisplayAllBicycles()
        {
            Console.Clear();

            using (var context = new bicycle_rental2DBEntities())
            {
                var indexQuery = from b in context.Bicycles
                                 orderby b.make
                                 select b;

                Console.WriteLine("All of our current bicycles: ");

                foreach (var item in indexQuery)
                {
                    Console.WriteLine("Frame number: " + item.frame_number + ". Make: " + item.make + ". Model: " + item.model + ". Bicycle category: " + item.bicycle_type);
                }
            }
        }

        /*Följande metod tar emot ett ramnummer som användaren har fyllt i m.h.a. en annan metod, söker upp matchande cykel i
         den "generella" cykeltabellen för att sedan presentera ALL data på just den cykeln.
        
         Denna metoden borde nog egentligen inte ha printat informationen, utan bara hämtat objekt/objektinformationen och
         skickat vidare den till en mer relevant metod. Åtgärdas i mån av tid. TODO.*/

        public void DisplaySpecificBicycle(string frame_number)
        {
            Console.Clear();

            using (var context = new bicycle_rental2DBEntities())
            {
                Bicycle bicycle = context.Bicycles.FirstOrDefault(b => b.frame_number == frame_number);
                Console.WriteLine("DISPLAYING BICYCLE: " + bicycle.make + " " + bicycle.model);
                Console.WriteLine("\n\nBicycle type: " + bicycle.bicycle_type);
                Console.WriteLine("Bicycle category: " + bicycle.bicycle_category);
                Console.WriteLine("Recommended user: " + bicycle.recommended_user);
                Console.WriteLine("Color: " + bicycle.color);
                Console.WriteLine("Frame size: " + bicycle.frame_size);
                Console.WriteLine("Wheel size: " + bicycle.wheel_size);
                Console.WriteLine("Gears: " + bicycle.gears);
                Console.WriteLine("Brakes back: " + bicycle.brake_back);
                Console.WriteLine("Brakes front: " + bicycle.brake_front);
                Console.WriteLine("Price: " + bicycle.price);

                /*Hämtar extra information om cykeln som visas är en elcykel. Info hämtas m.h.a. ramnummer och finnes i
                 subtabellen över elcyklar.*/

                if (bicycle.bicycle_type == "Elcykel")
                {
                    Console.WriteLine("\nBATTERY INFORMATION:");
                    Electric_bicycle displayElectric = context.Electric_bicycle.FirstOrDefault(b => b.frame_number == frame_number);
                    Console.WriteLine("\nBattery capacity: " + displayElectric.battery_capacity + " Wh.");
                    Console.WriteLine("Average charge time: " + displayElectric.battery_avg_charge_time + " hours.");
                    Console.WriteLine("Average distance per full charge: " + displayElectric.battery_avg_distance + " km.");
                    Console.WriteLine("Motor power: " + displayElectric.motor_power + " W.");
                }

                Console.WriteLine("\n\n\n\nPress a key to return to the main menu.");
                Console.ReadKey();
            }
        }

        /*Följande metod tar emot indata (som kommer ifrån en användare och en annan metod) och ger den till ett nytt cykelobjekt.*/

        public void AddBicycleToDatabase(string frame_number, string type, string category, string user, string make, string model, string color, string frame_size, string wheel_size, byte gears, string brake_back, string brake_front, int price)
        {
            using (var context = new bicycle_rental2DBEntities())
            {
                Bicycle newBicycle = new Bicycle
                {
                    frame_number = frame_number,
                    bicycle_type = type,
                    bicycle_category = category,
                    recommended_user = user,
                    make = make,
                    model = model,
                    color = color,
                    frame_size = frame_size,
                    wheel_size = wheel_size,
                    gears = gears, 
                    brake_back = brake_back,
                    brake_front = brake_front,
                    price = price
                };
                context.Bicycles.Add(newBicycle);

                /*Följande if-sats kollar vilken cykeltyp som ska läggas till och uppdaterar korrekt subtabell för cyklar.
                Tillgängliga subtabeller för cyklar är vanliga cyklar, elcyklar, och enhjulingar.
                Om det är en elcykel som läggs till kommer några extraprompts relaterat till batteriet på elcykeln.
                När cykeln placeras i en korrekt subtabell så utförs en SaveChange.*/

                if (type == "Vanlig cykel")
                {
                    context.Regular_bicycle.Add(new Regular_bicycle { frame_number = frame_number });
                    context.SaveChanges();
                }
                else if (type == "Elcykel")
                {
                    Console.WriteLine("Enter the battery capacity (in Wh).");
                    string UserInputBatteryCapacity = Console.ReadLine();

                    Console.WriteLine("Enter the average charge time (in hours).");
                    string UserInputAvgChrgTime = Console.ReadLine();

                    Console.WriteLine("Enter the average distance (in km).");
                    string UserInputAvgDistance = Console.ReadLine();

                    Console.WriteLine("Enter the motor power (in W).");
                    string UserInputPower = Console.ReadLine();

                    context.Electric_bicycle.Add(new Electric_bicycle { frame_number = frame_number,
                    battery_capacity = UserInputBatteryCapacity,
                    battery_avg_charge_time = UserInputAvgChrgTime,
                    battery_avg_distance = UserInputAvgDistance,
                    motor_power = UserInputPower});

                    context.SaveChanges();
                }
                else if (type == "Enhjuling")
                {
                    context.Unicycles.Add(new Unicycle { frame_number = frame_number });
                    context.SaveChanges();
                }
            }
        }

        /*Följande metod redigerar en existerande cykels pris i databasen. Användaren har blivit tillfrågad efter
         ramnummer och det nya priset, som sedan matas in i denna metod. Metoden letar upp korrekt cykel i den
        "generella" cykeltabellen m.h.a. ramnummret och korrigerar dess pris innan en SaveChange genomförs.*/

        /*TODO:
         
         Får ej transaction.Commit och transaction.Rollback att fungera som önskat. WORK IN PROGRESS.
         Målet är att försöka få en form utav felhantering som sedan kan implementeras på fler metoder där input
         behöver säkerställas.
        
         ARBETE PÅGÅR.*/

        public void EditBicycleToDatabase(string frame_number, int price)
        {
            using (var context = new bicycle_rental2DBEntities())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Bicycle editBicycle = context.Bicycles.FirstOrDefault(b => b.frame_number == frame_number);
                        editBicycle.price = price;
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error occured.");
                        Console.ReadKey(); 
                    }
                }
            }
        }

        /*Följande metod raderar en cykel ur "generella" cykeltabellen SAMT den korrekta subtabellen m.h.a. ramnummret 
         som kommer ifrån en användare.*/

        public void RemoveBicycleFromDatabase(string frame_number)
        {
            using (var context = new bicycle_rental2DBEntities())
            {
                Bicycle removeBicycle = context.Bicycles.FirstOrDefault(c => c.frame_number == frame_number);
                context.Bicycles.Remove(removeBicycle);

                if (removeBicycle.bicycle_type == "Vanlig cykel")
                {
                    Regular_bicycle removeRegular = context.Regular_bicycle.FirstOrDefault(b => b.frame_number == frame_number);
                    context.Regular_bicycle.Remove(removeRegular);
                    context.SaveChanges();
                }
                else if (removeBicycle.bicycle_type == "Elcykel")
                {
                    Electric_bicycle removeElectric = context.Electric_bicycle.FirstOrDefault(b => b.frame_number == frame_number);
                    context.Electric_bicycle.Remove(removeElectric);
                    context.SaveChanges();
                }
                else if (removeBicycle.bicycle_type == "Enhjuling")
                {
                    Unicycle removeUnicycle = context.Unicycles.FirstOrDefault(b => b.frame_number == frame_number);
                    context.Unicycles.Remove(removeUnicycle);
                    context.SaveChanges();
                }
            }
        }

        /*Endast en metod som hämtar alla cyklar där priset är lika med eller mindre än det som användaren har fyllt i.
         Ingen superimponerande metod i sig, men är användbar att modifiera/använda för att söka efter data som matchar
         användarens önskemål.*/

        public void DataQuery(int UserInput)
        {
            Console.Clear();
            using (var context = new bicycle_rental2DBEntities())
            {
                var dataQuery = from b in context.Bicycles
                                where b.price <= UserInput
                                select b;

                Console.WriteLine("All bicycles for " + UserInput + " SEK or less:");
                Console.WriteLine("");


                foreach (var item in dataQuery)
                {
                    Console.WriteLine(item.model);
                }

                Console.WriteLine("\n\nPress a key to return to the main menu.");
                Console.ReadKey();
            }
        }
    }
}

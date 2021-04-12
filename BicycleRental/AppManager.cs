using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental
{
    class AppManager
    {
        public void RunProgram()
        {
            Console.Title = "BicycleRental!";
            Visuals myMenu = new Visuals();
            myMenu.DisplayMainMenu();
        }
    }
}

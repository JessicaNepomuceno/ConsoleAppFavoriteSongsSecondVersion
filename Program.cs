using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppFavoriteSongsSecondVersion.ContentContext;
using ConsoleAppFavoriteSongsSecondVersion.CRUDContext;

namespace ConsoleAppFavoriteSongsSecondVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            var favoriteSongs = new List<Music>();
            var crudContext = new CRUD();
            var showMenu = true;

            while (showMenu)
            {
                //ShowLogo();
                //ShowMessagesWelcome();
                string selectedOptionsMenu = crudContext.ShowMenuOptions();
                switch (selectedOptionsMenu)
                {
                    case "1":
                        Console.WriteLine($"You selected the option {selectedOptionsMenu}!");
                        Thread.Sleep(3000);
                        Console.Clear();
                        //ShowLogo();
                        showMenu = crudContext.CreateFavoriteSong(favoriteSongs);
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine($"You selected the option {selectedOptionsMenu}!");
                        Thread.Sleep(3000);
                        Console.Clear();
                        //ShowLogo();
                        crudContext.ListFavoriteSong(favoriteSongs);
                        Console.WriteLine("Press Enter to Return to menu.");
                        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        Console.Clear();
                        showMenu = true;
                        break;
                    case "3":
                        Console.WriteLine($"You selected the option {selectedOptionsMenu}!");
                        Thread.Sleep(3000);
                        Console.Clear();
                        //ShowLogo();
                        showMenu = crudContext.UpdateFavoriteSong(favoriteSongs);
                        Console.Clear();
                        break;
                    case "4":
                        Console.WriteLine($"You selected the option {selectedOptionsMenu}!");
                        Thread.Sleep(3000);
                        Console.Clear();
                        //ShowLogo();
                        showMenu = crudContext.DeleteFavoriteSong(favoriteSongs);
                        Console.Clear();
                        break;
                    case "0":
                        Console.WriteLine("THE PROGRAM WILL BE EXIT, WAIT...");
                        // Delay that permit the user to read the exit message
                        Thread.Sleep(3000);
                        showMenu = false;
                        break;
                    default:
                        Console.WriteLine("WARNING! --> YOU TYPE A INVALID OPTION, PLEASE TRY IT AGAIN.");
                        // Delay that permit the user to read the warning message
                        Thread.Sleep(3000);
                        Console.Clear();
                        showMenu = true;
                        break;
                }
            }
        }
    }
}

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
            
            var teste = crudContext.CreateFavoriteSong(favoriteSongs);
            Thread.Sleep(3000);
            var teste2 = crudContext.CreateFavoriteSong(favoriteSongs);
            Console.WriteLine("");
            Thread.Sleep(3000);
            crudContext.ListFavoriteSong(favoriteSongs);
            Thread.Sleep(3000);

            //while (showMenu)
            //{
            //    ShowLogo();
            //    ShowMessagesWelcome();
            //    string selectedOptionsMenu = ShowMenuOptions();
            //    switch (selectedOptionsMenu)
            //    {
            //        case "1":
            //            Console.WriteLine($"You selected the option {selectedOptionsMenu}!");
            //            Thread.Sleep(3000);
            //            Console.Clear();
            //            ShowLogo();
            //            showMenu = CreateFavoriteSong();
            //            Thread.Sleep(4000);
            //            Console.Clear();
            //            break;
            //        case "2":
            //            Console.WriteLine($"You selected the option {selectedOptionsMenu}!");
            //            Thread.Sleep(3000);
            //            Console.Clear();
            //            ShowLogo();
            //            ListFavoriteSong();
            //            Console.Clear();
            //            showMenu = true;
            //            break;
            //        case "3":
            //            Console.WriteLine($"You selected the option {selectedOptionsMenu}!");
            //            Thread.Sleep(3000);
            //            Console.Clear();
            //            ShowLogo();
            //            showMenu = UpdateFavoriteSong();
            //            Console.Clear();
            //            break;
            //        case "4":
            //            Console.WriteLine($"You selected the option {selectedOptionsMenu}!");
            //            Thread.Sleep(3000);
            //            Console.Clear();
            //            ShowLogo();
            //            showMenu = DeleteFavoriteSong();
            //            Console.Clear();
            //            break;
            //        case "0":
            //            Console.WriteLine("THE PROGRAM WILL BE EXIT, WAIT...");
            //            // Delay that permit the user to read the exit message
            //            Thread.Sleep(3000);
            //            showMenu = false;
            //            break;
            //        default:
            //            Console.WriteLine("WARNING! --> YOU TYPE A INVALID OPTION, PLEASE TRY IT AGAIN.");
            //            // Delay that permit the user to read the warning message
            //            Thread.Sleep(3000);
            //            Console.Clear();
            //            showMenu = true;
            //            break;
            //    }
            //}
        }
    }
}

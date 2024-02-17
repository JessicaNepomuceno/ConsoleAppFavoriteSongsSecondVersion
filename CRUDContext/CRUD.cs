using ConsoleAppFavoriteSongsSecondVersion.ContentContext;
using ConsoleAppFavoriteSongsSecondVersion.Context.Enums;
using ConsoleAppFavoriteSongsSecondVersion.NotificationContext;
using ConsoleAppFavoriteSongsSecondVersion.SharedContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFavoriteSongsSecondVersion.CRUDContext
{
    public class CRUD : Base
    {
        public CRUD() { }

        /// <summary>
        /// Function - Register a favorite song
        /// </summary>
        public bool CreateFavoriteSong(List<Music> favoriteSongs)
        {
            bool concluded = false;
            bool repeatAgree = true;

            var favoriteSong = SetFavoriteSong();           

            return SetAgree(repeatAgree, concluded, favoriteSongs, favoriteSong.Band.BandName(), favoriteSong.MusicName(), favoriteSong.MusicNote, (int)favoriteSong.Genre, favoriteSong.Band.Members.ToList());
        }

        /// <summary>
        /// Function - List a favorite song
        /// </summary>
        public void ListFavoriteSong(List<Music> favoriteSongs)
        {
            if (favoriteSongs.Any())
            {
                var contador = 1;
                Console.WriteLine("Your favorite songs registered are listed below.");
                Console.WriteLine("");

                foreach (var item in favoriteSongs)
                {
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine($"Favorite song number: {contador}");
                    item.NumIndex = contador;
                    Console.WriteLine("");
                    ShowInformationInputSong(item.Band.BandName(), item.MusicName(), item.MusicNote, (int)item.Genre, item.Band.Members.ToList());
                    contador++;
                }                  

                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("You dont have favorite songs registered. Please, return to menu and select the first option to register a song!");
                Console.WriteLine("");
            }                        
        }

        /// <summary>
        /// Function - Update a favorite song
        /// </summary>
        public bool UpdateFavoriteSong(List<Music> favoriteSongs)
        {
            bool repeatAgree = true;
            bool concluded = false;

            if (favoriteSongs.Any())
            {
                ListFavoriteSong(favoriteSongs);
                Console.WriteLine("To UPDATE a favorite song, enter the information requested below.");

                Console.WriteLine("");
                Console.Write("Type the favorite song number that you want to UPDATE: ");                
                var numberFavoriteSong = (int.TryParse(Console.ReadLine()!, out int num) ? num : 0);

                Console.WriteLine("");  
                Console.WriteLine("This is the favorite song you entered:");
                Console.WriteLine("");

                var updateSong = favoriteSongs.Where(x => x.NumIndex == numberFavoriteSong).Select(y => y).FirstOrDefault();
                ShowInformationInputSong(updateSong.Band.BandName(), updateSong.MusicName(), updateSong.MusicNote, (int)updateSong.Genre, updateSong.Band.Members.ToList());
                concluded = SetAgree(repeatAgree, concluded, updateSong);
            }
            else
            {
                Console.WriteLine("You dont have favorite songs registered.");
                Console.WriteLine("Please, return to menu and select the first option to register a song!");
                concluded = true;
            }

            Console.WriteLine("");
            Console.WriteLine("Press Enter to Return to menu.");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }

            return concluded;
        }

        ///// <summary>
        ///// Function - Delete a favorite song
        ///// </summary>
        //public bool DeleteFavoriteSong(List<Music> favoriteSongs)
        //{
        //    bool concluded = false;
        //    if (artist != null && artist.Any())
        //    {
        //        Console.WriteLine("To DELETE a favorite song, enter the information requested below.");
        //        Console.WriteLine("");

        //        Console.Write("Type the NAME OF THE ARTIST that you want to DELETE: ");
        //        var name = Console.ReadLine()!;
        //        Console.WriteLine("");

        //        Console.Write("Type the NAME OF THE SONG that you want to DELETE: ");
        //        var nameSong = Console.ReadLine()!;
        //        Console.WriteLine("");

        //        Console.WriteLine("This is the information you entered:");
        //        Console.WriteLine("");

        //        Console.WriteLine($"The name of the artist: {name}");
        //        Console.WriteLine($"The name of the song: {nameSong}");
        //        Console.WriteLine("");

        //        bool repeatAgree = true;
        //        while (repeatAgree)
        //        {
        //            Console.Write("Do you agree? Type Y for yes or N for no: ");
        //            var agree = Console.ReadLine()!.ToUpper();

        //            switch (agree)
        //            {
        //                case "Y":
        //                    var searchArtist = artist.FirstOrDefault(x => x.Name == name && x.NameSong == nameSong);
        //                    if (searchArtist != null)
        //                    {
        //                        var removed = artist.Remove(artist.FirstOrDefault(x => x.Name == name && x.NameSong == nameSong));
        //                        if (removed)
        //                        {
        //                            Console.WriteLine("Your favorite song has been DELETED!");
        //                            Console.WriteLine("");

        //                            Console.WriteLine($"The name of the artist deleted: {searchArtist.Name} - The name of the song deleted: {searchArtist.NameSong} - The note (From 0 to 10) deleted: {searchArtist.Note}");
        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine("Your favorite song has not been DELETED.");
        //                            Console.WriteLine("Try it again!");
        //                        }

        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("Your favorite song has not been DELETED.");
        //                        Console.WriteLine("Because the name of the artist or the name of the song was not found. Try it again!");

        //                    }
        //                    concluded = true;
        //                    repeatAgree = false;
        //                    break;
        //                case "N":
        //                    Console.WriteLine("Your favorite song has not been DELETED!");
        //                    concluded = true;
        //                    repeatAgree = false;
        //                    break;
        //                default:
        //                    Console.WriteLine("WARNING! --> YOU TYPE A INVALID OPTION, PLEASE TRY IT AGAIN.");
        //                    // Delay that permit the user to read the warning message
        //                    Thread.Sleep(3000);
        //                    repeatAgree = true;
        //                    Console.WriteLine("");
        //                    break;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("You dont have favorite songs registered.");
        //        Console.WriteLine("Please, return to menu and select the first option to register a song!");
        //        concluded = true;
        //    }

        //    Console.WriteLine("");
        //    Console.WriteLine("Press Enter to Return to menu.");
        //    while (Console.ReadKey().Key != ConsoleKey.Enter) { }

        //    return concluded;
        //}



    }
}

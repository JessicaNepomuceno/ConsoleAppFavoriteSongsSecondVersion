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

            Console.WriteLine("To register a favorite song, enter the information requested below.");
            Console.WriteLine("");
            Console.Write("Type the name of the artist/band: ");
            var nameArtistBand = Console.ReadLine()!;
            
            Console.WriteLine("");
            Console.Write("Type the name of the music: ");
            var nameMusic = Console.ReadLine()!;
            
            Console.WriteLine("");
            Console.Write("Type the note (From 0 to 10) of how much you like this music: ");
            var musicNote = (int.TryParse(Console.ReadLine()!, out int numNote) ? numNote : 0);
            
            Console.WriteLine("");
            Console.Write("Type the number of music genre: ");
            Console.WriteLine("");
            Console.Write("\n"+ ShowGenre());
            Console.WriteLine("");
            Console.Write("number: ");            
            var genre = (int.TryParse(Console.ReadLine()!, out int numGenre) ? numGenre : 0);
            
            Console.WriteLine("");
            Console.Write("Type the name of members: ");
            Console.WriteLine("");
            var members = SetMembers();

            Console.WriteLine("");
            Console.WriteLine("This is the information you entered:");
            Console.WriteLine("");
            ShowInformationInputSong(nameArtistBand, nameMusic, musicNote, genre, members);

            bool repeatAgree = true;

            return SetAgree(repeatAgree, concluded, favoriteSongs, nameArtistBand, nameMusic, musicNote, genre, members);
        }

        /// <summary>
        /// Function - List a favorite song
        /// </summary>
        public void ListFavoriteSong(List<Music> favoriteSongs)
        {
            if (favoriteSongs.Any())
            {
                Console.WriteLine("Your favorite songs registered are listed below.");
                Console.WriteLine("");

                foreach (var item in favoriteSongs)
                    ShowInformationInputSong(item.Band.BandName(), item.MusicName(), item.MusicNote, (int)item.Genre, item.Band.Members.ToList());

                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("You dont have favorite songs registered. Please, return to menu and select the first option to register a song!");
                Console.WriteLine("");
            }

            Console.WriteLine("Press Enter to Return to menu.");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }

        ///// <summary>
        ///// Function - Update a favorite song
        ///// </summary>
        //public bool UpdateFavoriteSong(List<Music> favoriteSongs)
        //{
        //    bool concluded = false;
        //    if (artist != null && artist.Any())
        //    {
        //        Console.WriteLine("To UPDATE a favorite song, enter the information requested below.");
        //        Console.WriteLine("");

        //        Console.Write("Type the NAME OF THE ARTIST that you want to UPDATE: ");
        //        var name = Console.ReadLine()!;
        //        Console.WriteLine("");

        //        Console.Write("Type the NAME OF THE SONG that you want to UPDATE: ");
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
        //                    Console.WriteLine("");
        //                    Console.WriteLine("To UPDATE, enter the information requested below.");
        //                    Console.WriteLine("");

        //                    Console.Write("Type the NEW name of the artist: ");
        //                    var newName = Console.ReadLine()!;
        //                    Console.WriteLine("");

        //                    Console.Write("Type the NEW name of the song: ");
        //                    var newNameSong = Console.ReadLine()!;
        //                    Console.WriteLine("");

        //                    Console.Write("Type the NEW note (From 0 to 10): ");
        //                    var newNote = (decimal.TryParse(Console.ReadLine()!, out decimal number) ? number : 0);
        //                    Console.WriteLine("");

        //                    var searchArtist = artist.FirstOrDefault(x => x.Name == name && x.NameSong == nameSong);
        //                    if (searchArtist != null)
        //                    {
        //                        searchArtist.Name = newName;
        //                        searchArtist.NameSong = newNameSong;
        //                        searchArtist.Note = newNote;

        //                        Console.WriteLine("Your favorite song has been UPDATE!");
        //                        Console.WriteLine("");

        //                        Console.WriteLine($"The NEW name of the artist: {searchArtist.Name} - The NEW name of the song: {searchArtist.NameSong} - The NEW note (From 0 to 10): {searchArtist.Note}");
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("Your favorite song has not been UPDATED.");
        //                        Console.WriteLine("Because the name of the artist or the name of the song was not found. Try it again!");

        //                    }
        //                    concluded = true;
        //                    repeatAgree = false;
        //                    break;
        //                case "N":
        //                    Console.WriteLine("Your favorite song has not been UPDATE!");
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

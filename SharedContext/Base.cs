﻿using ConsoleAppFavoriteSongsSecondVersion.ContentContext;
using ConsoleAppFavoriteSongsSecondVersion.Context.Enums;
using ConsoleAppFavoriteSongsSecondVersion.NotificationContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFavoriteSongsSecondVersion.SharedContext
{
    public class Base : Notifiable
    {
        public static string ShowGenre()
        {
            string genreOptions = string.Empty;
            foreach (var genre in Enum.GetValues(typeof(EGenre)))
            {
                genreOptions += $"{(int)genre} - {genre} \n";
            }
            return genreOptions;
        }
        public static List<Members> SetMembers()
        {
            var members = new List<Members>();
            Console.WriteLine("");
            Console.WriteLine("Type ESC to complete, if you have already registered all members");
            Console.WriteLine("Or type Enter to continue registering");

            do
            {
                Console.Write($" \n Name: ");
                members.Add(new Members(Console.ReadLine()!));
                Console.WriteLine("");
                Console.WriteLine("Type ESC to exit or ENTER to continuous...");

            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine("");

            return members;
        }
        public static void ShowInformationInputSong(string nameArtistBand, string nameMusic, int musicNote, int genre, List<Members> members)
        {
            Console.WriteLine($"The name of the artist: {nameArtistBand}");
            Console.WriteLine($"The name of the song: {nameMusic}");
            Console.WriteLine($"The note (From 0 to 10): {musicNote}");
            Console.WriteLine($"The music genre: {(EGenre)genre}");
            Console.WriteLine($"The members name: {string.Join(" / ", members.Select(x => x.MemberName()))}");
            Console.WriteLine("");
        }                
        public void SetAgree(bool repeatAgree, Music song)
        {
            while (repeatAgree)
            {
                Console.Write("Do you agree? Type Y for yes or N for no: ");
                var agree = Console.ReadLine()!.ToUpper();

                switch (agree)
                {
                    case "Y":
                        var changeSong = SetFavoriteSong();
                        song.ChangeName(changeSong.MusicName());
                        song.ChangeGenre((int)changeSong.Genre);
                        song.ChangeMusicNote(changeSong.MusicNote);
                        song.Band.ChangeName(changeSong.Band.BandName());

                        song.Band.Members.Clear();
                        foreach (var item in changeSong.Band.Members)
                            song.Band.Members.Add(item);
                        
                        repeatAgree = false;
                        Console.WriteLine("Your favorite song has been UPDATED! Returning to the menu...");
                        break;
                    case "N":
                        Console.WriteLine("Your favorite song has not been UPDATED!");                       
                        repeatAgree = false;
                        break;
                    default:
                        if (!Notifications.Any(x => x.Property.Contains("agree")))
                            AddNotification(new Notification("agree", "WARNING! --> YOU TYPE A INVALID OPTION, PLEASE TRY IT AGAIN."));
                        Console.WriteLine(ShowNotifications());
                        // Delay that permit the user to read the warning message
                        Thread.Sleep(3000);
                        repeatAgree = true;
                        Console.WriteLine("");
                        break;
                }
            }            
        }
        public void SetAgree(bool repeatAgree, Music song, List<Music> favoriteSongs)
        {
            while (repeatAgree)
            {
                Console.Write("Do you agree? Type Y for yes or N for no: ");
                var agree = Console.ReadLine()!.ToUpper();

                switch (agree)
                {
                    case "Y":
                        favoriteSongs.Remove(song);
                        repeatAgree = false;
                        Console.WriteLine("Your favorite song has been DELETED! Returning to the menu...");
                        break;
                    case "N":
                        Console.WriteLine("Your favorite song has not been DELETED!");
                        repeatAgree = false;
                        break;
                    default:
                        if (!Notifications.Any(x => x.Property.Contains("agree")))
                            AddNotification(new Notification("agree", "WARNING! --> YOU TYPE A INVALID OPTION, PLEASE TRY IT AGAIN."));
                        Console.WriteLine(ShowNotifications());
                        // Delay that permit the user to read the warning message
                        Thread.Sleep(3000);
                        repeatAgree = true;
                        Console.WriteLine("");
                        break;
                }
            }            
        }
        public void SetAgree(bool repeatAgree, List<Music> favoriteSongs, string nameArtistBand, string nameMusic, int musicNote, int genre, List<Members> members)
        {
            while (repeatAgree)
            {
                Console.Write("Do you agree? Type Y for yes or N for no: ");
                var agree = Console.ReadLine()!.ToUpper();

                switch (agree)
                {
                    case "Y":
                        Console.WriteLine("");
                        Console.WriteLine("The information has been saved! Returning to the menu...");
                        favoriteSongs.Add(new Music(nameMusic, nameArtistBand, members, genre, musicNote));                        
                        repeatAgree = false;

                        break;
                    case "N":
                        Console.WriteLine("");
                        Console.WriteLine("The information has not been saved! Returning to the menu...");
                        repeatAgree = false;

                        break;
                    default:
                        Console.WriteLine("");

                        if (!Notifications.Any(x => x.Property.Contains("agree")))
                            AddNotification(new Notification("agree", "WARNING! --> YOU TYPE A INVALID OPTION, PLEASE TRY IT AGAIN."));

                        Console.WriteLine(ShowNotifications());
                        Thread.Sleep(3000);
                        repeatAgree = true;

                        Console.WriteLine("");

                        break;
                }
            }
        }
        public static Music SetFavoriteSong()
        {
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
            Console.Write("\n" + ShowGenre());
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

            return new Music(nameMusic, nameArtistBand, members, genre, musicNote);
        }
        public static Music ChoiceFavoriteSong(List<Music> favoriteSongs, bool isUpdate)
        {            
            Console.WriteLine($"To {(isUpdate ? "UPDATE" : "DELETE")} a favorite song, enter the information requested below.");

            Console.WriteLine("");
            Console.Write($"Type the favorite song number that you want to {(isUpdate ? "UPDATE" : "DELETE")}: ");
            var numberFavoriteSong = (int.TryParse(Console.ReadLine()!, out int num) ? num : 0);

            if (!favoriteSongs.Select(x => x.NumIndex).Contains(numberFavoriteSong))
                throw new Exception("This favorite song number does not exist");

            Console.WriteLine("");
            Console.WriteLine("This is the favorite song you entered:");
            Console.WriteLine("");
            
            return favoriteSongs.Where(x => x.NumIndex == numberFavoriteSong).Select(y => y).FirstOrDefault();
        }
        public string ShowMenuOptions()
        {
            string numberOptionsMenu;

            Console.WriteLine("");
            Console.WriteLine("OPTIONS MENU");
            Console.WriteLine("");
            //CRUD (Create, Read, Update, Delete)
            Console.WriteLine("Type 1 - Register a favorite song.");
            Console.WriteLine("Type 2 - List your favorite songs.");
            Console.WriteLine("Type 3 - Update a favorite song.");
            Console.WriteLine("Type 4 - Delete a favorite song.");
            Console.WriteLine("Type 0 - Exit.");
            Console.WriteLine("");
            Console.Write("Type the number to select the option: ");
            numberOptionsMenu = Console.ReadLine()!;
            Console.WriteLine("");

            return numberOptionsMenu;
        }

    }
}

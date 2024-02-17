using ConsoleAppFavoriteSongsSecondVersion.ContentContext;
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
        public bool SetAgree(bool repeatAgree, bool concluded, Music updateSong)
        {
            while (repeatAgree)
            {
                Console.Write("Do you agree? Type Y for yes or N for no: ");
                var agree = Console.ReadLine()!.ToUpper();

                switch (agree)
                {
                    case "Y":
                        var changeSong = SetFavoriteSong();
                        updateSong.ChangeName(changeSong.MusicName());
                        updateSong.ChangeGenre((int)changeSong.Genre);
                        updateSong.ChangeMusicNote(changeSong.MusicNote);
                        updateSong.Band.ChangeName(changeSong.Band.BandName());

                        updateSong.Band.Members.Clear();
                        foreach (var item in changeSong.Band.Members)
                            updateSong.Band.Members.Add(item);

                        concluded = true;
                        repeatAgree = false;
                        break;
                    case "N":
                        Console.WriteLine("Your favorite song has not been UPDATE!");
                        concluded = true;
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

            return concluded;
        }
        public bool SetAgree(bool repeatAgree, bool concluded, List<Music> favoriteSongs, string nameArtistBand, string nameMusic, int musicNote, int genre, List<Members> members)
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
                        concluded = true;
                        repeatAgree = false;

                        break;
                    case "N":
                        Console.WriteLine("");
                        Console.WriteLine("The information has not been saved! Returning to the menu...");
                        concluded = true;
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

            return concluded;
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
    }
}

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
        public void CreateFavoriteSong(List<Music> favoriteSongs)
        {
            bool repeatAgree = true;
            var favoriteSong = SetFavoriteSong();           

            SetAgree(repeatAgree, favoriteSongs, favoriteSong.Band.BandName(), favoriteSong.MusicName(), favoriteSong.MusicNote, (int)favoriteSong.Genre, favoriteSong.Band.Members.ToList());
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
        public void UpdateFavoriteSong(List<Music> favoriteSongs)
        {
            bool repeatAgree = true;
            
            try
            {
                if (favoriteSongs.Any())
                {
                    ListFavoriteSong(favoriteSongs);
                    var updateSong = ChoiceFavoriteSong(favoriteSongs, true);
                    ShowInformationInputSong(updateSong.Band.BandName(), updateSong.MusicName(), updateSong.MusicNote, (int)updateSong.Genre, updateSong.Band.Members.ToList());
                    SetAgree(repeatAgree, updateSong);
                }
                else
                {
                    Console.WriteLine("You dont have favorite songs registered.");
                    Console.WriteLine("Please, return to menu and select the first option to register a song!");                   
                }

                Console.WriteLine("");
                Console.WriteLine("Press Enter to Return to menu.");
                                
            }
            catch (Exception ex)
            {
                Console.WriteLine("");
                Console.WriteLine($"{ex.Message}");

            }

            while (Console.ReadKey().Key != ConsoleKey.Enter) { };
        }

        /// <summary>
        /// Function - Delete a favorite song
        /// </summary>
        public void DeleteFavoriteSong(List<Music> favoriteSongs)
        {
            bool repeatAgree = true;
            
            try
            {
                if (favoriteSongs.Any())
                {
                    ListFavoriteSong(favoriteSongs);
                    var deletSong = ChoiceFavoriteSong(favoriteSongs, false);
                    ShowInformationInputSong(deletSong.Band.BandName(), deletSong.MusicName(), deletSong.MusicNote, (int)deletSong.Genre, deletSong.Band.Members.ToList());
                    SetAgree(repeatAgree, deletSong, favoriteSongs);
                }
                else
                {
                    Console.WriteLine("You dont have favorite songs registered.");
                    Console.WriteLine("Please, return to menu and select the first option to register a song!");                    
                }

                Console.WriteLine("");
                Console.WriteLine("Press Enter to Return to menu.");               
            }
            catch (Exception ex)
            {
                Console.WriteLine("");
                Console.WriteLine($"{ex.Message}");
            }

            while (Console.ReadKey().Key != ConsoleKey.Enter) { };
        }
    }
}

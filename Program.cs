using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppFavoriteSongsSecondVersion.ContentContext;

namespace ConsoleAppFavoriteSongsSecondVersion
{
    class Program 
    {
        static void Main(string[] args)
        {
            var membrosBanda = new List<Members>();
            membrosBanda.Add(new Members("Menbro01"));
            membrosBanda.Add(new Members("Menbro02"));
            membrosBanda.Add(new Members("Menbro03"));

            var musicaPrimeira = new Music("NomeDaMusica", "NomeDaBanda", membrosBanda, 1, 10);

            var band = new Band("NomeDaBanda", membrosBanda);

            Console.WriteLine($"Nome da banda 02: Id: {band.BandId()} - Nome: {band.BandName()}");
            Console.WriteLine($"{string.Join(" \n", band.Members.Select(x => $" Membros - Id: {x.MenberId()} - Nome: {x.MemberName()}"))}");

            Console.WriteLine($"Nome da banda: {musicaPrimeira.Band.BandName()}");
            Console.WriteLine($"Nome da música: {musicaPrimeira.MusicName()}");
            Console.WriteLine($"Id da música: {musicaPrimeira.MusicId()}");

            foreach (var membro in membrosBanda)
            {                
                Console.WriteLine($"Menbro da banda: {membro.MemberName()}");                
            }

            Console.WriteLine($"Nota da banda: {musicaPrimeira.MusicNote} e Genero da música: {musicaPrimeira.Genre}");    
        }
    }
}

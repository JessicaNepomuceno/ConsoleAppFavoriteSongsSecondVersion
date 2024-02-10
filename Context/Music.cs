using ConsoleAppFavoriteSongsSecondVersion.Context.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFavoriteSongsSecondVersion.Context
{
    internal class Music : Identifier
    {
        public Band Band { get; set; }
        public EGenre Genre { get; set; }
    }
}

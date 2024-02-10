using ConsoleAppFavoriteSongsSecondVersion.Context.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFavoriteSongsSecondVersion.Context
{
    public class Music : Identifier
    {
        public Music(string musicName, string bandName, List<Members> membersName, int gender, short musicNote)
            :base(musicName)
        {            
            Band = new Band(bandName, membersName);
            Genre = (EGenre)gender;
            MusicNote = musicNote;
        }

        public Band Band { get; private set; }
        public EGenre Genre { get; private set; }
        public short MusicNote { get; private set; }
    }
}

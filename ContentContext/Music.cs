using ConsoleAppFavoriteSongsSecondVersion.Context.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFavoriteSongsSecondVersion.ContentContext
{
    public class Music : Identifier
    {
        public Music(string musicName, string bandName, List<Members> membersName, int gender, int musicNote) : base(musicName)
        {            
            Band = new Band(bandName, membersName);
            Genre = (EGenre)gender;
            MusicNote = musicNote;
        }

        public Band Band { get; private set; }
        public EGenre Genre { get; private set; }
        public int MusicNote { get; private set; }

        public string MusicName() { return Name; }
        public string MusicId() { return Id.ToString(); }
        public override void ChangeName(string newName) { base.ChangeName(newName); }
        public void ChangeGenre(int newGenre) { this.Genre = (EGenre)newGenre; }
        public void ChangeMusicNote(short newMusicNote) { this.MusicNote = newMusicNote; }        
    }
}

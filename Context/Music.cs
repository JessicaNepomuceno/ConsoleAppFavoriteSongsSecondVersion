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

        public string MusicName() { return Name; }
        public string MusicId() { return Id.ToString(); }

        public override void ChangeName(string newName) { base.ChangeName(newName); }

        public void ChangeBand(string newBandName, List<Members> newMenbersName) { this.Band = new Band(newBandName, newMenbersName); }
        
        public void ChangeAllBandMenbers(List<Members> newMenbers)
        {
            this.Band.Members.Clear();
            foreach (var newMenber in newMenbers) { this.Band.Members.Add(newMenber); }            
        }

        public void ChangeBandMenber(string newMenberName, Guid oldMenberId)
        {
            this.Band.Members.Where(x => x.MenberId() == oldMenberId).Select(y => y).FirstOrDefault()?.ChangeName(newMenberName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFavoriteSongsSecondVersion.ContentContext
{
    public class Band : Identifier
    {
        public Band(string bandName, List<Members> membersName) : base(bandName) { Members = membersName; }        

        public IList<Members> Members { get; private set; }

        public string BandName() {return Name;}
        public string BandId() { return Id.ToString(); }
        public override void ChangeName(string newName) { base.ChangeName(newName); }        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFavoriteSongsSecondVersion.Context
{
    public class Band : Identifier
    {
        public Band(string bandName, List<Members> membersName)
            : base(bandName)
        {            
            Members = membersName;
        }

        public IList<Members> Members { get; private set; }
    }
}

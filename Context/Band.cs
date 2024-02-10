using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFavoriteSongsSecondVersion.Context
{
    public class Band : Identifier
    {
        public Band()
        {
            Members = new List<Members>();
        }

        public IList<Members> Members { get; set; }
    }
}

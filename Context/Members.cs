using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFavoriteSongsSecondVersion.Context
{
    public class Members : Identifier
    {
        public Members(string memberName)
            : base(memberName) { }       

        public string MemberName() { return Name; }
        public Guid MenberId() { return Id; }

        public override void ChangeName(string newName)
        {
            base.ChangeName(newName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFavoriteSongsSecondVersion.ContentContext
{
    public abstract class Identifier
    {
        public Identifier(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        protected Guid Id { get; private set; }
        protected string Name { get; private set; }

        public virtual void ChangeName(string newName) { Name = newName; }
    }
}

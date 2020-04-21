using DnDSpellsCompendium.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSpellsCompendium
{
	public class DnDClass
	{
		public Class Name { get; set; }
		public int ClassLevel { get; set; }
		public Spellbook Spells { get; set; }


        public DnDClass(Class name, int classLevel)
		{
            Name = name;
            ClassLevel = classLevel;
        }

        public override string ToString()
        {
            return "Name: " + Name.ToString() + "\n" + "Class Level: " + ClassLevel.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSpellsCompendium
{
	public class Character
	{
        

        public string Name { get; set; }
		public int TotalLevel { get; set; }
		public List<DnDClass> Classes { get; set; }

        public Character(string name, int totalLevel, List<DnDClass> classes)
        {
            Name = name;
            TotalLevel = totalLevel;
            Classes = classes;
        }


        public override string ToString()
        {
            string toString =  "Name: " + Name + "\n" + "Total Level: " + TotalLevel.ToString() + "\n" + "Classes: " + "\n";

            Classes.ForEach(dndClass => toString += $"\t {dndClass.ToString()}\n");

            return toString;

        }

    }
}

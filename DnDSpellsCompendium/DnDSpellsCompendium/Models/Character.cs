using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSpellsCompendium
{
	class Character
	{
		public string Name { get; set; }
		public int TotalLevel { get; set; }
		public List<DnDClass> Classes { get; set; }

	}
}

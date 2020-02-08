using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSpellsCompendium
{
	class Spellbook : BaseModel
	{
		public List<Spell> LearnedSpells { get; set; }
		public List<Spell> PreparedSpells { get; set; }
		
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSpellsCompendium.ViewModels
{
    public class SpellListItemViewModel : BaseViewModel
    {
        public bool IsSelected { get; set; }
        public Spell SpellItem { get; set; }

        public SpellListItemViewModel(Spell spell)
        {
            SpellItem = spell;
            IsSelected = false;
        }
    }
}

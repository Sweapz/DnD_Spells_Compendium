using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSpellsCompendium.Events
{
    public static class CharacterSavedEvent
    {
        public static EventHandler SavedEvent = delegate { };

        public static void RaiseSavedEvent()
        {
            SavedEvent(null, EventArgs.Empty);
        }
    }
}

using DnDSpellsCompendium.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DnDSpellsCompendium.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public List<Spell> Spells { get; set; }
        public MainViewModel()
        {
            Spells = LoadJson();
        }

        public List<Spell> LoadJson()
        {
            string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\spell_data.json");

            return JsonSpellDecoder.GetSpellsFromJsonFile(path);
        }
    }
}

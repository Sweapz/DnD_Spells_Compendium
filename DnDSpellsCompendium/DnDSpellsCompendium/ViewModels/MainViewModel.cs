using DnDSpellsCompendium.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DnDSpellsCompendium.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<SpellListItemViewModel> Spells { get; set; }
        public ObservableCollection<Spell> TrueSpells { get; set; }
        public Spell CurrentActiveSpell { get; set; }
        public MainViewModel()
        {
            TrueSpells = LoadJson();
            Spells = ConvertSpellToSpellItemViewModel(LoadJson());
            CurrentActiveSpell = Spells[0].SpellItem;
        }

        private ObservableCollection<SpellListItemViewModel> ConvertSpellToSpellItemViewModel(ObservableCollection<Spell> spells)
        {
            var spellListItemViewModels = new ObservableCollection<SpellListItemViewModel>();

            foreach (var spell in spells)
            {
                spellListItemViewModels.Add(new SpellListItemViewModel(spell));
            }
            spellListItemViewModels[0].IsSelected = true;
            return spellListItemViewModels;
        }

        public ObservableCollection<Spell> LoadJson()
        {
            string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\spell_data.json");

            return JsonSpellDecoder.GetSpellsFromJsonFile(path);
        }

        public void OnItemSelectedHandler(object sender, MouseButtonEventHandler e)
        {
            Console.WriteLine("Aids");
        }

        private void ExecuteChooseNewSpellCommand(Spell spell)
        {
            CurrentActiveSpell = spell;
        }
    }
}

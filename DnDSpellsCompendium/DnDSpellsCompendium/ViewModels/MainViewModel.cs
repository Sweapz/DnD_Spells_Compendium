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
        public RelayCommand<Spell> ChooseNewSpellCommand
        {
            get;
            private set;
        }
        public ObservableCollection<Spell> Spells { get; set; }
        public Spell CurrentActiveSpell { get; set; }
        public MainViewModel()
        {
            Spells = LoadJson();
            CurrentActiveSpell = Spells[0];

            ChooseNewSpellCommand = new RelayCommand<Spell>(x => ExecuteChooseNewSpellCommand(x));
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

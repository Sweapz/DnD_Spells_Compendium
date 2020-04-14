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
        private ObservableCollection<Spell> _allSpells;
        private ObservableCollection<Spell> _spells;

        public ObservableCollection<Spell> Spells
        {
            get { return _spells; }
            set
            {
                _spells = value;
                ActiveSpell = _spells.First();
            }
        }


        public Spell ActiveSpell { get; set; }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (value != _searchText)
                {
                    _searchText = value;
                    Spells = new ObservableCollection<Spell>(_allSpells.Where(x => x.Name.ToLower().Contains(_searchText.ToLower())));
                }
            }
        }
        public MainViewModel()
        {
            _allSpells = LoadJson();
            Spells = new ObservableCollection<Spell>(_allSpells);
            
        }

        public ObservableCollection<Spell> LoadJson()
        {
            string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\spell_data.json");

            return JsonSpellDecoder.GetSpellsFromJsonFile(path);
        }
    }
}

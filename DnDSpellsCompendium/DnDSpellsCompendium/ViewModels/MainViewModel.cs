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

        public ObservableCollection<string> Classes { get; set; }
        public ObservableCollection<string> Levels { get; set; } = new ObservableCollection<string>
        {
            "Spell Level", "Cantrip", "1st level",
            "2nd level", "3rd level", "4th level",
            "5th level", "6th level", "7th level",
            "8th level", "9th level"
        };

        public ObservableCollection<Spell> Spells
        {
            get { return _spells; }
            set
            {
                _spells = value;
                ActiveSpell = _spells.Count == 0 ? null : _spells.First();
            }
        }
        private string _classValue;
        public string ClassValue
        {
            get { return _classValue; }
            set
            {
                _classValue = value;

                Spells = FilterSpells();
            }
        }

        private string _spellLevel;

        public string SpellLevel
        {
            get { return _spellLevel; }
            set
            {
                _spellLevel = value;
                Spells = FilterSpells();
            }
        }

        public Spell ActiveSpell { get; set; }

        private string _searchText = "";
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (value != _searchText)
                {
                    _searchText = value;
                    Spells = FilterSpells();
                }
            }
        }
        public MainViewModel()
        {
            _allSpells = LoadJson();
            Spells = new ObservableCollection<Spell>(_allSpells);

            Classes = new ObservableCollection<string>();
            Classes.Add("Classes");

            foreach (var item in Enum.GetValues(typeof(Class)))
            {
                Classes.Add(item.ToString());
            }
            
        }

        public ObservableCollection<Spell> LoadJson()
        {
            string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\spell_data.json");

            return JsonSpellDecoder.GetSpellsFromJsonFile(path);
        }

        private ObservableCollection<Spell> FilterSpells()
        {
            IEnumerable<Spell> tempSpells;
            //Func<string, Type, string, Func<string>, IEnumerable<Spell>, IEnumerable<Spell>> find = 
            //    (
            //        (defaultValue, t, property, cmp, inputList) => 
            //        inputList.Where(x => ((t)x.GetType().GetProperty(property).GetMethod(cmp).Invoke())



            // Search parameter
            tempSpells = _allSpells.Where(x => x.Name.ToLower().Contains(_searchText.ToLower()));

            // Class filter
            tempSpells = ClassValue != "Classes" ? tempSpells.Where(x => x.Classes.Contains((Class)Enum.Parse(typeof(Class), _classValue))) : tempSpells;
            tempSpells = ClassValue != "Classes" ? tempSpells.Where(x => (bool)typeof(List<Class>).GetMethod("Contains").Invoke((List<Class>)x.GetType().GetProperty("Classes").GetValue(x), new[] { Enum.Parse(typeof(Class), _classValue) })) : tempSpells;


            // Level filter
            tempSpells = SpellLevel != "Spell Level" ? tempSpells.Where(x => x.Level.Equals(SpellLevel)) : tempSpells;



            return new ObservableCollection<Spell>(tempSpells);
                    
        }
    }
}

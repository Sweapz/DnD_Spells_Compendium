using DnDSpellsCompendium.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DnDSpellsCompendium.ViewModels
{
    class SpellBookViewModel : BaseViewModel
	{
        #region Filtering

        #region CheckBoxConcentration
        private bool _concentrationCheckBoxNo = false;

        public bool ConcentrationCheckBoxNo
        {
            get { return _concentrationCheckBoxNo; }
            set
            {
                _concentrationCheckBoxNo = value;
                if (value)
                {
                    ConcentrationCheckBoxAll = false;
                    ConcentrationCheckBoxYes = false;
                    Spells = FilterSpells();
                }
            }
        }

        private bool _concentrationCheckBoxYes = false;

        public bool ConcentrationCheckBoxYes
        {
            get { return _concentrationCheckBoxYes; }
            set
            {
                _concentrationCheckBoxYes = value;
                if (value)
                {
                    ConcentrationCheckBoxAll = false;
                    ConcentrationCheckBoxNo = false;
                    Spells = FilterSpells();
                }
            }
        }

        private bool _concentrationCheckBoxAll = true;

        public bool ConcentrationCheckBoxAll
        {
            get { return _concentrationCheckBoxAll; }
            set
            {
                _concentrationCheckBoxAll = value;
                if (value)
                {
                    ConcentrationCheckBoxNo = false;
                    ConcentrationCheckBoxYes = false;
                    Spells = FilterSpells();
                }
            }
        }

        #endregion
        public ObservableCollection<string> Classes { get; set; }
        public ObservableCollection<string> Schools { get; set; }

        public ObservableCollection<string> CastingTimes { get; set; } = new ObservableCollection<string>
        {
            "Casting Time", "Action", "Bonus Action",
            "Reaction", "Minute", "Hour"
        };
        public ObservableCollection<string> Levels { get; set; } = new ObservableCollection<string>
        {
            "Spell Level", "Cantrip", "1st level",
            "2nd level", "3rd level", "4th level",
            "5th level", "6th level", "7th level",
            "8th level", "9th level"
        };



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

        private string _schoolValue;

        public string SchoolValue
        {
            get { return _schoolValue; }
            set
            {
                _schoolValue = value;
                Spells = FilterSpells();

            }
        }

        private string _castingValue;

        public string CastingValue
        {
            get { return _castingValue; }
            set
            {
                _castingValue = value;
                Spells = FilterSpells();
            }
        }


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

        #endregion

        public Spell ActiveSpell { get; set; }

		private ObservableCollection<Spell> _allSpells;
		private ObservableCollection<Spell> _spells;

		public ObservableCollection<Spell> Spells
		{
			get { return _spells; }
			set
			{
				_spells = value;
				ActiveSpell = _spells.Count == 0 ? null : _spells.First();
			}
		}

		public SpellBookViewModel()
		{
			_allSpells = LoadJson();
			Spells = new ObservableCollection<Spell>(_allSpells);

			Schools = new ObservableCollection<string>
				{
					"Schools"
				};

			Classes = new ObservableCollection<string>
				{
					"Classes"
				};

			foreach (var item in Enum.GetValues(typeof(Class)))
			{
				Classes.Add(item.ToString());
			}

			foreach (var item in Enum.GetValues(typeof(SpellSchool)))
			{
				Schools.Add(item.ToString());
			}

			//ConcentrationCheckBox = new CheckBoxStatus(true, false, false);
		}

		public ObservableCollection<Spell> LoadJson()
		{
			string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\spell_data.json");

			return JsonSpellDecoder.GetSpellsFromJsonFile(path);
		}

		private ObservableCollection<Spell> FilterSpells()
		{
			IEnumerable<Spell> tempSpells;

			// Search parameter
			tempSpells = _allSpells.Where(x => x.Name.ToLower().Contains(_searchText.ToLower()));

			// Class filter
			tempSpells = ClassValue == "Classes" || ClassValue == null ? tempSpells : tempSpells.Where(spell => spell.Classes.Contains((Class)Enum.Parse(typeof(Class), ClassValue)));

			// Level filter
			tempSpells = SpellLevel == "Spell Level" || SpellLevel == null ? tempSpells : tempSpells.Where(spell => spell.Level.Equals(SpellLevel));

			tempSpells = SchoolValue == "Schools" || SchoolValue == null ? tempSpells : tempSpells.Where(spell => spell.School.Equals((SpellSchool)Enum.Parse(typeof(SpellSchool), SchoolValue)));

			tempSpells = CastingValue == "Casting Time" || CastingValue == null ? tempSpells : tempSpells.Where(spell => spell.CastTime.Contains(CastingValue));

			if (ConcentrationCheckBoxYes)
			{
				tempSpells = tempSpells.Where(spell => spell.Duration.Contains("Concentration"));
			}
			else if (ConcentrationCheckBoxNo)
			{
				tempSpells = tempSpells.Where(spell => !spell.Duration.Contains("Concentration"));

			}
			return new ObservableCollection<Spell>(tempSpells);

		}
	}
}

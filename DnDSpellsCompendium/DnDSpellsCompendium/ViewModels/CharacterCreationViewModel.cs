using DnDSpellsCompendium.Events;
using DnDSpellsCompendium.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace DnDSpellsCompendium.ViewModels
{
    public class CharacterCreationViewModel : BaseViewModel
    {

        public ICommand RemoveClassCommand => new RelayCommand<DnDClass>(s => RemoveClass(s));
        public ICommand SaveCharacterCommand => new RelayCommand(SaveCharacter);
        public ObservableCollection<DnDClass> ClassesList { get; set; }
        public ObservableCollection<string> Classes { get; set; }



        public string Name { get; set; }
        public ObservableCollection<string> Levels { get; set; }

        private readonly string _selectedClass = "Class";

        public string SelectedClass
        {
            get => _selectedClass;
            set
            {
                if (value != "Class" && !ClassesList.Any(x => x.Name.ToString() == value))
                {
                    ClassesList.Add(new DnDClass((Class)Enum.Parse(typeof(Class), value), 0));   
                }
            }
        }


        public CharacterCreationViewModel()
        {
            Classes = new ObservableCollection<string>
            {
                "Class"
            };

            foreach (var item in Enum.GetValues(typeof(Class)))
            {
                Classes.Add(item.ToString());
            }

            ClassesList = new ObservableCollection<DnDClass> ();

            Levels = new ObservableCollection<string>
            {
                "Levels"
            };

            for (int i = 0; i <= 30; i++)
            {
                string levelString;
                switch (i)
                {
                    case 1:
                    case 21:
                        levelString = i.ToString() + "st level";
                        break;
                    case 2:
                    case 22:
                        levelString = i.ToString() + "nd level";
                        break;
                    case 3:
                    case 23:
                        levelString = i.ToString() + "rd level";
                        break;
                    default:
                        levelString = i.ToString() + "th level";
                        break;
                }

                Levels.Add(levelString);
            }
            
        }

        private void RemoveClass(DnDClass value)
        {
            ClassesList.Remove(value);
        }


        private void SaveCharacter()
        {
            int level = 0;

            if (ClassesList.Any(c => c.ClassLevel == 0) || Name == "")
            {
                return;
            }

            ClassesList.ToList().ForEach(x => level += x.ClassLevel);

            Character character = new Character(Name, level, ClassesList.ToList());

            string output = JsonConvert.SerializeObject(character);


            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\character_list.json");

            StreamWriter stream = new StreamWriter(path, true);
            stream.WriteLine(output);
            stream.Close();

            CharacterSavedEvent.RaiseSavedEvent();
        }

        

    }
}

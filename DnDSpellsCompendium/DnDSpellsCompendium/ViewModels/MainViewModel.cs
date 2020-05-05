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
using System.Windows.Controls;
using System.Windows.Input;

namespace DnDSpellsCompendium.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Commands
        public ICommand OpenTopBarCommand => new RelayCommand(() => { TopBarVisibility = !TopBarVisibility; });
        public ICommand NavigateToSpellBook => new RelayCommand(ChangeToSpellBookViewModel);
        public ICommand NavigateToCharacterCreation => new RelayCommand(ChangeToCharacterCreationViewModel);

        public ICommand CreateCharacterCommand => new RelayCommand(CreateCharacter);
        public ICommand CancelCreationCommand => new RelayCommand(CancelCreation);
        public ICommand RemoveCharacterCommand => new RelayCommand(RemoveCharacter);

        #endregion

        public BaseViewModel CurrentViewModel { get; set; }

        private ObservableCollection<Character> _characters;

        public ObservableCollection<Character> Characters
        {
            get { return _characters; }
            set { _characters = value; }
        }

        private Character _selectedCharacter;

        public Character SelectedCharacter
        {
            get { return _selectedCharacter; }
            set
            {
                _selectedCharacter = value;
            }
        }
        private int _selectedCharacterIndex;
        public int SelectedCharacterIndex
        {
            set
            {
                _selectedCharacterIndex = (Characters.Count - 1) - value;
            }
        }
        public bool TopBarVisibility { get; set; } = false;
        public bool CharacterCreationVisibility { get; set; } = false;


        public MainViewModel()
        {
            CurrentViewModel = new SpellBookViewModel();
            Characters = LoadCharacters();
            CharacterSavedEvent.SavedEvent += RefreshCharacters;
        }

        private void RefreshCharacters(object sender, EventArgs e)
        {
            CharacterCreationVisibility = false;
            Characters = LoadCharacters();
        }

        private ObservableCollection<Character> LoadCharacters()
        {
            var characters = new ObservableCollection<Character>();

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\character_list.json");
            StreamReader reader = new StreamReader(path);
            string line;
            while((line = reader.ReadLine()) != null)
            {
                characters.Add(JsonConvert.DeserializeObject<Character>(line));
            }


            return new ObservableCollection<Character>(characters.Reverse());
        }

        private void CreateCharacter()
        {
            CharacterCreationVisibility = true;
        }

        private void ChangeToSpellBookViewModel()
        {
            CurrentViewModel = new SpellBookViewModel();
        }

        private void ChangeToCharacterCreationViewModel()
        {
            CurrentViewModel = new CharacterCreationViewModel();
        }

        private void CancelCreation()
        {
            CharacterCreationVisibility = false;
        }

        private void RemoveCharacter()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\character_list.json");
            var lines = new List<string>();
            int currentIndex = 0;
            StreamReader reader = new StreamReader(path);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
                
            }

            reader.Close();

            StreamWriter writer = new StreamWriter(path, false);


            foreach (var item in lines)
            {
                if (currentIndex == _selectedCharacterIndex)
                {
                    writer.Write("");
                }
                else
                {
                    writer.WriteLine(item);
                }
                currentIndex++;
            }
            writer.Close();
            Characters = LoadCharacters();
        }


    }
}

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
        public BaseViewModel CurrentViewModel { get; set; }


        public ICommand NavigateToSpellBook => new RelayCommand(ChangeToSpellBookViewModel);
        public ICommand NavigateToCharacterCreation => new RelayCommand(ChangeToCharacterCreationViewModel);
        public MainViewModel()
        {
            CurrentViewModel = new MenuViewModel();
        }


        private void ChangeToSpellBookViewModel()
        {
            CurrentViewModel = new SpellBookViewModel();
        }

        private void ChangeToCharacterCreationViewModel()
        {
            CurrentViewModel = new CharacterCreationViewModel();
        }
    }
}

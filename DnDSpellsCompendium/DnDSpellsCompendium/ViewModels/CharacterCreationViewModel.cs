using DnDSpellsCompendium.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DnDSpellsCompendium.ViewModels
{
    public class CharacterCreationViewModel : BaseViewModel
    {
        public ICommand AddClassCommand => new RelayCommand(AddClass);

        

        public ObservableCollection<ObservableCollection<string>> ClassesList { get; set; }
        public ObservableCollection<string> Classes { get; set; }

        public CharacterCreationViewModel()
        {
            Classes = new ObservableCollection<string>
                {
                    "Classes"
                };

            foreach (var item in Enum.GetValues(typeof(Class)))
            {
                Classes.Add(item.ToString());
            }

            ClassesList = new ObservableCollection<ObservableCollection<string>> ();
        }

        private void AddClass()
        {
            Console.WriteLine("dd");
            ClassesList.Add(new ObservableCollection<string> (Classes));
        }
    }
}

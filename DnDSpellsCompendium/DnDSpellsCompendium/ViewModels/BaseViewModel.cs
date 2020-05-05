using PropertyChanged;
using System.ComponentModel;

namespace DnDSpellsCompendium
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        [SuppressPropertyChangedWarnings]
        public void OnProperyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
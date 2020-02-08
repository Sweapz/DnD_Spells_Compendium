using PropertyChanged;
using System.ComponentModel;


namespace DnDSpellsCompendium.ViewModels
{
	[AddINotifyPropertyChangedInterface]
	public class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
	}
}

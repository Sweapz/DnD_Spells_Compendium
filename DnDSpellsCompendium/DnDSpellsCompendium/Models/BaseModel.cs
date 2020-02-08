using PropertyChanged;
using System.ComponentModel;

namespace DnDSpellsCompendium.Models
{
	[AddINotifyPropertyChangedInterface]
	public class BaseModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
	}
}
using PropertyChanged;
using System.ComponentModel;

namespace DnDSpellsCompendium
{
	[AddINotifyPropertyChangedInterface]
	public class BaseModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

		public void OnProperyChanged(string name)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(name));
		}
	}
}
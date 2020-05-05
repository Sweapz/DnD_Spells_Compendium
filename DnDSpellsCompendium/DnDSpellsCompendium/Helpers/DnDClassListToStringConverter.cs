using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DnDSpellsCompendium.Helpers
{
    [ValueConversion(typeof(List<Class>), typeof(string))]
    public class DnDClassListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(string))
                throw new InvalidOperationException("The target must be a String");

            var newList = new List<string>();

            ((List<DnDClass>)value).ForEach(x => newList.Add(ConvertDnDClassToString(x)));

            return String.Join("/", newList);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private string ConvertDnDClassToString(DnDClass element)
        {
            return element.Name + " - " + element.ClassLevel;
        }
    }
}

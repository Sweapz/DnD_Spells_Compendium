using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DnDSpellsCompendium.Helpers
{
    [ValueConversion(typeof(string), typeof(int))]
    public class StringToIntConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

             throw new InvalidOperationException("The target must be a String");

            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int level = 0;
            string levelString = "";
            var temp = ((string)value).TakeWhile(x => int.TryParse(x.ToString(), out int k));

            temp.ToList().ForEach(c => levelString += c.ToString());

            if (levelString != "")
            {
                level = int.Parse(levelString);
            }

            return level;
        }
    }
}

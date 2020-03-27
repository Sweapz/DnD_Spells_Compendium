using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DnDSpellsCompendium
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
            List<Spell> spells = new List<Spell>();

            LoadJson();

			InitializeComponent();

		}

        public void LoadJson()
        {
            string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\spell_data.json");
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                List<Spell> spells = JsonConvert.DeserializeObject<List<Spell>>(json);
                Console.WriteLine(spells);
            }
        }
    }
}

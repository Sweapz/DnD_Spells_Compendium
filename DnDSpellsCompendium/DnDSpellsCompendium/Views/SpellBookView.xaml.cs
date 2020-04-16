using DnDSpellsCompendium.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DnDSpellsCompendium
{
    /// <summary>
    /// Interaction logic for SpellBookWindow.xaml
    /// </summary>
    public partial class SpellBookView : UserControl
    {
        public SpellBookView()
        {
            this.DataContext = new SpellBookViewModel();
            InitializeComponent();
        }
    }
}

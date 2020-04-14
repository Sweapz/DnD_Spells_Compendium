﻿using DnDSpellsCompendium.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DnDSpellsCompendium.Controls
{
    /// <summary>
    /// Interaction logic for SpellListControl.xaml
    /// </summary>
    public partial class SpellListControl : UserControl
    {
        public SpellListControl()
        {
            InitializeComponent();

            
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var mainViewModel = (sender as TextBox).DataContext as MainViewModel;
                mainViewModel.SearchText = (sender as TextBox).Text;
            }
        }
    }
}

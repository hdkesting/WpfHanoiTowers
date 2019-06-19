// <copyright file="Configuration.xaml.cs" company="Hans Kesting">
// Copyright (c) Hans Kesting. All rights reserved.
// </copyright>

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

namespace WpfHanoiTowers.Pages
{
    /// <summary>
    /// Interaction logic for Configuration.xaml.
    /// </summary>
    public partial class Configuration : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            this.InitializeComponent();

            var nod = Properties.Settings.Default.NumberOfDisks.ToString();
            this.DiskAmount.SelectedValue = this.DiskAmount.Items.OfType<ComboBoxItem>().FirstOrDefault(cbi => (string)cbi.Tag == nod);
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.NumberOfDisks = int.Parse(((ComboBoxItem)this.DiskAmount.SelectedValue).Tag.ToString());
            Properties.Settings.Default.Save();

            this.NavigationService.Navigate(new Game(Properties.Settings.Default.NumberOfDisks));
        }
    }
}

// <copyright file="Configuration.xaml.cs" company="Hans Kesting">
// Copyright (c) Hans Kesting. All rights reserved.
// </copyright>

using System.Windows;
using System.Windows.Controls;

namespace WpfHanoiTowers.Pages
{
    /// <summary>
    /// Interaction logic for Configuration.xaml.
    /// </summary>
    public partial class Configuration : Page
    {
        private ViewModels.ConfigurationViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            this.InitializeComponent();

            this.DataContext = this.viewModel = new ViewModels.ConfigurationViewModel();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Game(this.viewModel.Amount));
        }
    }
}

// <copyright file="Game.xaml.cs" company="Hans Kesting">
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
using WpfHanoiTowers.Controls;

namespace WpfHanoiTowers.Pages
{
    /// <summary>
    /// Interaction logic for Game.xaml.
    /// </summary>
    public partial class Game : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Game" /> class.
        /// </summary>
        /// <param name="numberOfDisks">The number of disks.</param>
        public Game(int numberOfDisks)
        {
            this.InitializeComponent();

            this.MainGrid.Children.Add(new HanoiTowers(numberOfDisks));
            // TODO maximize?
        }
    }
}

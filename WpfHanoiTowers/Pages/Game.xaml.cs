// <copyright file="Game.xaml.cs" company="Hans Kesting">
// Copyright (c) Hans Kesting. All rights reserved.
// </copyright>

using System;
using System.Windows.Controls;
using WpfHanoiTowers.Controls;
using WpfHanoiTowers.ViewModels;

namespace WpfHanoiTowers.Pages
{
    /// <summary>
    /// Interaction logic for Game.xaml.
    /// </summary>
    public partial class Game : Page
    {
        private GameStatus status;

        /// <summary>
        /// Initializes a new instance of the <see cref="Game" /> class.
        /// </summary>
        /// <param name="numberOfDisks">The number of disks.</param>
        public Game(int numberOfDisks)
        {
            this.InitializeComponent();

            var ctrl = new HanoiTowers(numberOfDisks);
            this.MainGrid.Children.Add(ctrl);
            ctrl.ValidMoveMade += this.Towers_ValidMoveMade;

            this.DataContext = this.status = new GameStatus();
        }

        private void Towers_ValidMoveMade(object sender, EventArgs e)
        {
            this.status.MovesMade++;
        }
    }
}

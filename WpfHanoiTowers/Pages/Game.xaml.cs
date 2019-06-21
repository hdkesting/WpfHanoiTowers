// <copyright file="Game.xaml.cs" company="Hans Kesting">
// Copyright (c) Hans Kesting. All rights reserved.
// </copyright>

using System;
using System.Windows;
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
        private readonly bool randomize;
        private GameStatus status;

        /// <summary>
        /// Initializes a new instance of the <see cref="Game" /> class.
        /// </summary>
        /// <param name="numberOfDisks">The number of disks.</param>
        /// <param name="randomize">if set to <c>true</c>, randomize the stacks.</param>
        public Game(int numberOfDisks, bool randomize = false)
        {
            this.InitializeComponent();

            var ctrl = new HanoiTowers(numberOfDisks);
            if (randomize)
            {
                ctrl.Randomize();
            }

            this.MainGrid.Children.Add(ctrl);
            ctrl.ValidMoveMade += this.Towers_ValidMoveMade;
            ctrl.FullStackCreated += this.Towers_FullStackCreated;

            this.DataContext = this.status = new GameStatus(numberOfDisks);
            this.randomize = randomize;
        }

        private void Towers_FullStackCreated(object sender, EventArgs e)
        {
            if (this.randomize)
            {
                MessageBox.Show($"Untangled the columns in {this.status.MovesMade} moves.");
            }
            else
            {
                MessageBox.Show($"Moved the full stack in {this.status.MovesMade} moves, efficiency {this.status.Efficiency * 100:#}%");
            }

            this.NavigationService.GoBack();
        }

        private void Towers_ValidMoveMade(object sender, EventArgs e)
        {
            this.status.MovesMade++;
        }
    }
}

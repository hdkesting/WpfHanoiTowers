// <copyright file="GameStatus.cs" company="Hans Kesting">
// Copyright (c) Hans Kesting. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfHanoiTowers.ViewModels
{
    /// <summary>
    /// View Model for game status.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class GameStatus : INotifyPropertyChanged
    {
        private int movesMade;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameStatus"/> class.
        /// </summary>
        /// <param name="numberOfDisks">The number of disks.</param>
        public GameStatus(int numberOfDisks)
        {
            this.NumberOfDisks = numberOfDisks;
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the number of moves made.
        /// </summary>
        /// <value>
        /// The moves made.
        /// </value>
        public int MovesMade
        {
            get => this.movesMade;
            set => this.SetField(ref this.movesMade, value);
        }

        /// <summary>
        /// Gets the number of disks.
        /// </summary>
        /// <value>
        /// The number of disks.
        /// </value>
        public int NumberOfDisks { get; }

        /// <summary>
        /// Gets the optimal count of moves.
        /// </summary>
        /// <value>
        /// The optimal move count.
        /// </value>
        public int OptimalMoveCount => (int)Math.Pow(2, this.NumberOfDisks) - 1;

        /// <summary>
        /// Gets the efficiency (only valid for completed game).
        /// </summary>
        /// <value>
        /// The efficiency.
        /// </value>
        public double Efficiency => (double)this.OptimalMoveCount / (double)this.MovesMade;

        /// <summary>
        /// Sets the field to the value and calls <see cref="OnPropertyChanged"/> when needed.
        /// </summary>
        /// <typeparam name="T">The type of field and value.</typeparam>
        /// <param name="field">The field to set.</param>
        /// <param name="value">The value to set to.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns><c>true</c> when the value was changed.</returns>
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Called when a property's value changed.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        protected void OnPropertyChanged(string propertyName) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

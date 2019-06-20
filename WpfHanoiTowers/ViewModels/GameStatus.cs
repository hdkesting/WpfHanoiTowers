// <copyright file="GameStatus.cs" company="Hans Kesting">
// Copyright (c) Hans Kesting. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfHanoiTowers.ViewModels
{
    public class GameStatus : INotifyPropertyChanged
    {
        private int movesMade;

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

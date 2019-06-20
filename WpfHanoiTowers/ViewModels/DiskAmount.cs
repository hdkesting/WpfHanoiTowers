// <copyright file="DiskAmount.cs" company="Hans Kesting">
// Copyright (c) Hans Kesting. All rights reserved.
// </copyright>

namespace WpfHanoiTowers.ViewModels
{
    /// <summary>
    /// Amount of disks.
    /// </summary>
    public class DiskAmount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiskAmount" /> class.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="name">The name.</param>
        public DiskAmount(int amount, string name)
        {
            this.Amount = amount;
            this.Name = name;
        }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public int Amount { get; }

        /// <summary>
        /// Gets the text version of the <see cref="Amount"/>.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; }
    }
}

// <copyright file="ConfigurationViewModel.cs" company="Hans Kesting">
// Copyright (c) Hans Kesting. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHanoiTowers.ViewModels
{
    /// <summary>
    /// View Model for the Configuration page.
    /// </summary>
    public class ConfigurationViewModel
    {
        /// <summary>
        /// Gets the possible disk amounts.
        /// </summary>
        /// <value>
        /// The disk amounts.
        /// </value>
        public List<DiskAmount> DiskAmounts { get; } = new List<DiskAmount>
            {
                new DiskAmount(3, "Three"),
                new DiskAmount(4, "Four"),
                new DiskAmount(5, "Five"),
                new DiskAmount(6, "Six"),
                new DiskAmount(7, "Seven"),
                new DiskAmount(8, "Eight"),
                new DiskAmount(9, "Nine"),
            };

        /// <summary>
        /// Gets or sets the selected amount of disks.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public int Amount
        {
            get
            {
                var n = Properties.Settings.Default.NumberOfDisks;
                if (n < 3)
                {
                    this.Amount = 3;
                    return 3;
                }

                return n;
            }

            set
            {
                Properties.Settings.Default.NumberOfDisks = value;
                Properties.Settings.Default.Save();
            }
        }
    }
}

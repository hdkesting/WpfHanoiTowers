// <copyright file="Column.cs" company="Hans Kesting">
// Copyright (c) Hans Kesting. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace WpfHanoiTowers.Controls
{
    /// <summary>
    /// A column to place <see cref="Disk"/>s on.
    /// </summary>
    /// <seealso cref="HelixToolkit.Wpf.PipeVisual3D" />
    public class Column : PipeVisual3D
    {
        private readonly List<Disk> disks = new List<Disk>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Column"/> class.
        /// </summary>
        /// <param name="xPosition">The x position.</param>
        /// <param name="yPosition">The y position.</param>
        /// <param name="height">The height.</param>
        /// <param name="color">The color.</param>
        public Column(double xPosition, double yPosition, double height, Color color)
        {
            this.Point1 = new Point3D(xPosition, yPosition, 0.0);
            this.Point2 = new Point3D(xPosition, yPosition, height);
            this.Material = new DiffuseMaterial(new SolidColorBrush(color));
            this.InnerDiameter = 0.0;
            this.Diameter = 1;
        }

        /// <summary>
        /// Gets the disks.
        /// </summary>
        /// <value>
        /// The disks.
        /// </value>
        public IEnumerable<Disk> Disks => this.disks;

        /// <summary>
        /// Pushes the disk onto this column, if it fits.
        /// </summary>
        /// <param name="disk">The disk.</param>
        /// <returns><c>true</c> if it was successful.</returns>
        public bool PushDisk(Disk disk)
        {
            if (!this.disks.Any() || this.disks.Last().Size > disk.Size)
            {
                disk.Position = new Point3D(this.Point1.X, this.Point1.Y, Disk.Thickness * this.disks.Count);
                this.disks.Add(disk);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Pops the disk from this column.
        /// </summary>
        /// <returns><c>null</c> when there was no disk.</returns>
        public Disk PopDisk()
        {
            if (this.disks.Any())
            {
                var d = this.disks.Last();
                this.disks.Remove(d);

                this.HoverDisk(d);
                return d;
            }

            return null;
        }

        /// <summary>
        /// Hovers the disk over this column.
        /// </summary>
        /// <param name="disk">The disk.</param>
        public void HoverDisk(Disk disk)
        {
            disk.Position = new Point3D(this.Point2.X, this.Point2.Y, this.Point2.Z + Disk.Thickness);
        }
    }
}

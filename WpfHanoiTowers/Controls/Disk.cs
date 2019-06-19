// <copyright file="Disk.cs" company="Hans Kesting">
// Copyright (c) Hans Kesting. All rights reserved.
// </copyright>

using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace WpfHanoiTowers.Controls
{
    /// <summary>
    /// A single disk to place on a column.
    /// </summary>
    /// <seealso cref="HelixToolkit.Wpf.PipeVisual3D" />
    public class Disk : PipeVisual3D
    {
        /// <summary>
        /// The thickness (height) of the disk.
        /// </summary>
        public const double Thickness = 1.0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Disk"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public Disk(int size)
        {
            this.Size = size;

            this.InnerDiameter = 1.5;
            this.Diameter = size + 1.5;

            this.Material = new DiffuseMaterial(new SolidColorBrush(this.GetDiskColor(size % 2 == 1)));
        }

        /// <summary>
        /// Gets the size of the disk.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public int Size { get; }

        /// <summary>
        /// Gets or sets the position of the disk.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public Point3D Position
        {
            get
            {
                return this.Point1;
            }

            set
            {
                this.Point1 = value;
                this.Point2 = new Point3D(value.X, value.Y, value.Z + Thickness);
            }
        }

        private Color GetDiskColor(bool even)
        {
            return AddTransparency(even ? Colors.Gold : Colors.Silver, 200);

            Color AddTransparency(Color baseColor, byte alpha)
            {
                return Color.FromArgb(alpha, baseColor.R, baseColor.G, baseColor.B);
            }
        }
    }
}

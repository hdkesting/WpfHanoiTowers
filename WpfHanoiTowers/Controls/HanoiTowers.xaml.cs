// <copyright file="HanoiTowers.xaml.cs" company="Hans Kesting">
// Copyright (c) Hans Kesting. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfHanoiTowers.Controls
{
    /// <summary>
    /// Interaction logic for HanoiTowers.xaml.
    /// </summary>
    public partial class HanoiTowers : UserControl
    {
        private readonly List<Column> columns = new List<Column>();

        private Column startColumn;
        private Disk liftedDisk;

        /// <summary>
        /// Initializes a new instance of the <see cref="HanoiTowers"/> class.
        /// </summary>
        /// <param name="diskCount">The disk count.</param>
        public HanoiTowers(int diskCount)
        {
            this.InitializeComponent();

            this.CreateColumns(diskCount);
            this.CreateInitialDisks(diskCount);

            this.myViewport.ZoomExtents(500);
        }

        private void CreateInitialDisks(int diskCount)
        {
            var col = this.columns[1];

            // lowest disk has size "diskCount" at Z=0, highest disk has size "1"
            for (int d = diskCount; d > 0; d--)
            {
                var disk = new Disk(d);
                col.PushDisk(disk);
                this.myViewport.Children.Add(disk);
            }
        }

        private void CreateColumns(int diskCount)
        {
            this.columns.Add(new Column(xPosition: -diskCount * 1.2, yPosition: -diskCount / 2, height: diskCount + 1, Colors.Red));
            this.columns.Add(new Column(0.0, diskCount / 2, diskCount + 1, Colors.Green));
            this.columns.Add(new Column(diskCount * 1.2, -diskCount / 2, diskCount + 1, Colors.Blue));

            foreach (var col in this.columns)
            {
                this.myViewport.Children.Add(col);
            }
        }

        private void MyViewport_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Point location = e.GetPosition(this.myViewport);

            var column = this.GetColumn(location);

            if (column != null)
            {
                this.startColumn = column;
                this.liftedDisk = this.startColumn.PopDisk();
            }
        }

        private void MyViewport_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Point location = e.GetPosition(this.myViewport);

            if (this.liftedDisk != null)
            {
                var column = this.GetColumn(location);

                if (column != null)
                {
                    if (!column.PushDisk(this.liftedDisk))
                    {
                        this.startColumn.PushDisk(this.liftedDisk);
                    }
                }
                else
                {
                    // put back
                    this.startColumn.PushDisk(this.liftedDisk);
                }
            }

            this.liftedDisk = null;
            this.startColumn = null;
        }

        private void MyViewport_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (this.liftedDisk != null)
            {
                Point location = e.GetPosition(this.myViewport);
                var column = this.GetColumn(location);

                if (column != null)
                {
                    column.HoverDisk(this.liftedDisk);
                }
            }
        }

        private Column GetColumn(Point location)
        {
            HitTestResult result = VisualTreeHelper.HitTest(this.myViewport, location);

            switch (result?.VisualHit)
            {
                case Column col:
                    return col;

                case Disk dsk:
                    foreach (var c in this.columns)
                    {
                        if (c.Point1.X == dsk.Point1.X && c.Point1.Y == dsk.Point1.Y)
                        {
                            return c;
                        }
                    }

                    break;
            }

            return null;
        }
    }
}

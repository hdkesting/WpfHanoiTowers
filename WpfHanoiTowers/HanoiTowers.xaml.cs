﻿using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using WpfHanoiTowers.Controls;

namespace WpfHanoiTowers
{
    /// <summary>
    /// Interaction logic for HanoiTowers.xaml
    /// </summary>
    public partial class HanoiTowers : UserControl
    {
        private readonly List<Column> columns = new List<Column>();
        private readonly List<Disk> disks = new List<Disk>();

        public HanoiTowers(int diskCount)
        {
            InitializeComponent();

            this.CreateColumns();
            this.CreateInitialDisks(diskCount);
        }

        private void CreateInitialDisks(int diskCount)
        {
            var pos = columns[0].Point1;

            // lowest disk has size "diskCount" at Z=0, highest "1"
            for (int d = 0; d< diskCount; d++)
            {
                var disk = new Disk(diskCount - d) { Position = new System.Windows.Media.Media3D.Point3D(pos.X, pos.Y, pos.Z + d) };
                this.disks.Add(disk);
                this.myViewport.Children.Add(disk);
            }
        }

        private void CreateColumns()
        {
            this.columns.Add(new Column(-1.0, -1.0, 5, Colors.Red));
            this.columns.Add(new Column(3.0, 0.0, 5, Colors.Green));
            this.columns.Add(new Column(0.0, 3.0, 5, Colors.Blue));

            foreach (var col in this.columns)
            {
                this.myViewport.Children.Add(col);
            }
        }
    }
}

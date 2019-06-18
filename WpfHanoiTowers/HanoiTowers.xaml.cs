using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
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

        private Column startColumn;
        private Disk liftedDisk;

        public HanoiTowers(int diskCount)
        {
            InitializeComponent();

            this.CreateColumns(diskCount);
            this.CreateInitialDisks(diskCount);
        }

        private void CreateInitialDisks(int diskCount)
        {
            var col = columns[1];

            // lowest disk has size "diskCount" at Z=0, highest "1"
            for (int d = 0; d< diskCount; d++)
            {
                var disk = new Disk(diskCount - d);
                col.PushDisk(disk);
                this.myViewport.Children.Add(disk);
            }
        }

        private void CreateColumns(int diskCount)
        {
            this.columns.Add(new Column(xPosition:-diskCount * 1.2, yPosition:-diskCount/2, height:diskCount+1, Colors.Red));
            this.columns.Add(new Column(0.0, diskCount/2, diskCount+1, Colors.Green));
            this.columns.Add(new Column(diskCount * 1.2, -diskCount/2, diskCount+1, Colors.Blue));

            foreach (var col in this.columns)
            {
                this.myViewport.Children.Add(col);
            }
        }

        private void MyViewport_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Point location = e.GetPosition(myViewport);

            var column = GetColumn(location);

            if (column != null)
            {
                startColumn = column;
                liftedDisk = startColumn.PopDisk();
            }
        }

        private void MyViewport_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Point location = e.GetPosition(myViewport);

            if (liftedDisk != null)
            {
                var column = GetColumn(location);

                if (column != null)
                {
                    if (!column.PushDisk(liftedDisk))
                    {
                        startColumn.PushDisk(liftedDisk);
                    }
                }
                else
                {
                    // put back
                    startColumn.PushDisk(liftedDisk);
                }
            }
            liftedDisk = null;
            startColumn = null;
        }

        private void MyViewport_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (liftedDisk != null)
            {
                Point location = e.GetPosition(myViewport);
                var column = GetColumn(location);

                if (column != null)
                {
                    column.HoverDisk(liftedDisk);
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
                    foreach(var c in columns)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace WpfHanoiTowers.Controls
{
    public class Column: PipeVisual3D
    {
        private readonly List<Disk> disks = new List<Disk>();

        public Column(double xPosition, double yPosition, double height, Color color)
        {
            this.Point1 = new Point3D(xPosition, yPosition, 0.0);
            this.Point2 = new Point3D(xPosition, yPosition, height);
            this.Material = new DiffuseMaterial(new SolidColorBrush(color));
            this.InnerDiameter = 0.0;
            this.Diameter = 1;
        }

        public IEnumerable<Disk> Disks => disks;

        public bool PushDisk(Disk disk)
        {
            if (!disks.Any() || disks.Last().Size > disk.Size)
            {
                disk.Position = new Point3D(this.Point1.X, this.Point1.Y, Disk.Thickness * disks.Count);
                disks.Add(disk);
                return true;
            }

            return false;
        }

        public Disk PopDisk()
        {
            if (disks.Any())
            {
                var d = disks.Last();
                disks.Remove(d);

                HoverDisk(d);
                return d;
            }

            return null;
        }

        public void HoverDisk(Disk disk)
        {
            disk.Position = new Point3D(this.Point2.X, this.Point2.Y, Point2.Z + Disk.Thickness);
        }
    }
}

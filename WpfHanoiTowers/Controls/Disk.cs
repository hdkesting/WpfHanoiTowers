using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace WpfHanoiTowers.Controls
{
    public class Disk : PipeVisual3D
    {
        public Disk(int size)
        {
            this.InnerDiameter = 1.5;
            this.Diameter = size + 1.5;

            this.Material = new DiffuseMaterial(new SolidColorBrush(size % 2 == 1 ? Colors.Gold : Colors.Silver));
        }

        public Point3D Position
        {
            get { return this.Point1; }
            set
            {
                this.Point1 = value;
                this.Point2 = new Point3D(value.X, value.Y, value.Z + 1);
            }
        }
    }
}

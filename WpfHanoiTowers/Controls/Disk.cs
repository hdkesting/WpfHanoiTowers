using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace WpfHanoiTowers.Controls
{
    public class Disk : PipeVisual3D
    {
        public const double Thickness = 1.0;

        public Disk(int size)
        {
            this.Size = size;

            this.InnerDiameter = 1.5;
            this.Diameter = size + 1.5;

            this.Material = new DiffuseMaterial(new SolidColorBrush(GetDiskColor(size % 2 == 1)));
        }

        public int Size { get; }

        public Point3D Position
        {
            get { return this.Point1; }
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

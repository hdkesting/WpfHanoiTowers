using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace WpfHanoiTowers.Controls
{
    public class Column: PipeVisual3D
    {
        public Column(double xPosition, double yPosition, double height, Color color)
        {
            this.Point1 = new Point3D(xPosition, yPosition, 0.0);
            this.Point2 = new Point3D(xPosition, yPosition, height);
            this.Material = new DiffuseMaterial(new SolidColorBrush(color));
            this.InnerDiameter = 0.0;
            this.Diameter = 1;
        }
    }
}

using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace TestWPF1
{
    public class MyPolygon : IMyPolygon
    {
        private Polygon polygon;

        public MyPolygon() {
            this.polygon = new Polygon();
        }

        public void setPolygon(object _polygon) {
            this.polygon = (Polygon)_polygon;
        }

        public Polygon getPolygon() {
            return this.polygon;
        }

        public MyPolygon createPolygon() {
            return new MyPolygon();
        }

        public MyStylusPointCollection getPolygonPoints() {
            MyStylusPointCollection points = new MyStylusPointCollection();
            foreach (Point aPoint in polygon.Points)
            {
                points.Add(new StylusPoint(aPoint.X, aPoint.Y));
            }
            return points;
        }

        public void setPolygonPoints(IMyStroke _stroke){
            foreach (StylusPoint aStylusPoint in _stroke.getStroke().StylusPoints) {
                polygon.Points.Add(aStylusPoint.ToPoint());
            }
        }
    }
}

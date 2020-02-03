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

        public Polygon createPolygonFromStrokeCollection(MyStrokeCollection _myStrokeCollection) {
            for (int i = 0; i < _myStrokeCollection.Count; i++) {
                for (int j = 0; j < _myStrokeCollection[i].StylusPoints.Count; j++)
                {
                    polygon.Points.Add(_myStrokeCollection[i].StylusPoints[j].ToPoint());
                }
            }
            return polygon;
        }

        public void setPolygonPointsFromStroke(IMyStroke _stroke){
            foreach (StylusPoint aStylusPoint in _stroke.getStroke().StylusPoints) {
                polygon.Points.Add(aStylusPoint.ToPoint());
            }
        }
    }
}

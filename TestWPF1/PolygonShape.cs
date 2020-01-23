using System;
using System.Windows.Shapes;
using System.Windows.Input;

using System.Windows;
using System.Windows.Ink;

namespace TestWPF1
{
    public class PolygonShape
    {
        private Polygon polygon;
        private String colorFill;
        private StylusPointCollection points;
        public PolygonShape() {
           
        }
        public PolygonShape(Polygon polygon, string colorFill)
        {
            this.polygon = polygon;
            this.colorFill = colorFill;
        }
        public void setPolygon(Polygon _polygon) {
            this.polygon = _polygon;
        }

        public Polygon getPolygon() {
            return this.polygon;
        }

        public void setColorFill(String _colorFill) {
            this.colorFill = _colorFill;
        }

        public string getColorFill() {
            return colorFill;
        }

        public StylusPointCollection getPoints() {
            points = new StylusPointCollection();
            foreach (Point aPoint in polygon.Points) {
                points.Add(new StylusPoint(aPoint.X, aPoint.Y));
            }
            return points;
        }

        public void setPoints(Point _points, Stroke newStroke) {
            foreach (StylusPoint aStylusPoint in newStroke.StylusPoints)
            {
                polygon.Points.Add(aStylusPoint.ToPoint());
            }
        }
    }
}

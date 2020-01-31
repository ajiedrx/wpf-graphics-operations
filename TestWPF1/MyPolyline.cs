using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TestWPF1
{
    public class MyPolyline : IMyPolyline
    {
        private Polyline polyline;
        public MyPolyline() {
            this.polyline = new Polyline();
        }

        public void setPolyline(object _polyline) { 
            this.polyline = (Polyline)_polyline;
        }

        public Polyline getPolyline() {
            return this.polyline;
        }

        public MyPolyline createMyPolyline() {
            return new MyPolyline();
        }

        public MyStylusPointCollection getPolylinePoints() {
            MyStylusPointCollection points = new MyStylusPointCollection();
            foreach (Point aPoint in polyline.Points)
            {
                points.Add(new StylusPoint(aPoint.X, aPoint.Y));
            }
            return points;
        }

        public void setPolylinePoints(IMyStroke _stroke) {
            foreach (StylusPoint aStylusPoint in _stroke.getStroke().StylusPoints)
            {
                polyline.Points.Add(aStylusPoint.ToPoint());
            }
        }

        public MyPolyline makePolylineWithPoints(IMyPoint _firstPoint, IMyPoint _endPoint, SolidColorBrush _brushes)
        {
            MyPolyline newPolyline = new MyPolyline();
            newPolyline.getPolyline().Points.Add(_firstPoint.getPoint());
            newPolyline.getPolyline().Points.Add(_endPoint.getPoint());
            newPolyline.getPolyline().Stroke = _brushes;
            return newPolyline;
        }
    }
}

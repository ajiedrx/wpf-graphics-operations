using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TestWPF1
{
    public class PolylineShape : IPolylineShape
    {
        public void duplicateLine(MouseEventArgs _obj, InkCanvas _InkCanvas){
            MyPolyline originalPolyline = new MyPolyline();
            originalPolyline.setPolyline((Polyline)_obj.OriginalSource);
            MyDrawingAttributes drawingAttribute = new MyDrawingAttributes() {
                Color = Colors.Black
            };
            MyStroke newStroke = new MyStroke(createMyStylusPointCollection(originalPolyline), drawingAttribute);
            _InkCanvas.Strokes.Add(newStroke);
            originalPolyline = createNewPolylineFromStroke(newStroke);
            _InkCanvas.Strokes.Remove(newStroke);
            _InkCanvas.Children.Add(originalPolyline.getPolyline());
        }

        public MyPolyline createNewPolylineFromStroke(MyStroke _newStroke)
        {
            MyPolyline _originalPolyline = new MyPolyline();
            _originalPolyline.getPolyline().Stroke = MyBrushes.Black;
            foreach (StylusPoint aStylusPoint in _newStroke.StylusPoints)
            {
                _originalPolyline.getPolyline().Points.Add(aStylusPoint.ToPoint());
            }
            return _originalPolyline;
        }

        public MyStylusPointCollection createMyStylusPointCollection(MyPolyline _originalPolyline)
        {
            MyStylusPointCollection points = new MyStylusPointCollection();
            foreach (Point aPoint in _originalPolyline.getPolyline().Points)
            {
                points.Add(new StylusPoint(aPoint.X, aPoint.Y));
            }
            return points;
        }

        public void printPolyline(InkCanvas _InkCanvas, Point _firstPoint, Point _endPoint)
        {
            MyPolyline polyline = new MyPolyline();
            polyline.getPolyline().Points.Add(_firstPoint);
            polyline.getPolyline().Points.Add(_endPoint);
            polyline.getPolyline().Stroke = Brushes.Black;
            _InkCanvas.Children.Add(polyline.getPolyline());
        }
    }
}

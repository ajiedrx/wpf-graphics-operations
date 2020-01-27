using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Ink;

namespace TestWPF1
{
    public class PolylineShape
    {
        public void duplicateLine(MouseEventArgs _obj, InkCanvas _InkCanvas){
            MyPolyline tempLine = new MyPolyline();
            tempLine.setPolyline((Polyline)_obj.OriginalSource);
            MyDrawingAttributes drawingAttribute = new MyDrawingAttributes()
            {
                Color = Colors.Black
            };
            MyStylusPointCollection points = new MyStylusPointCollection();
            foreach (Point aPoint in tempLine.getPolyline().Points)
            {
                points.Add(new StylusPoint(aPoint.X, aPoint.Y));
            }
            MyStroke newStroke = new MyStroke(points, drawingAttribute);
            _InkCanvas.Strokes.Add(newStroke);
            tempLine = new MyPolyline();
            tempLine.getPolyline().Stroke = Brushes.Black;
            foreach (StylusPoint aStylusPoint in newStroke.StylusPoints)
            {
                tempLine.getPolyline().Points.Add(aStylusPoint.ToPoint());
            }
            _InkCanvas.Strokes.Remove(newStroke);
            _InkCanvas.Children.Add(tempLine.getPolyline());
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

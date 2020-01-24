using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Ink;

namespace TestWPF1
{
    public class PolygonShape
    {
        private Polygon polygon;
        private String colorFill;
        public PolygonShape() {
           
        }

        public void duplicatePolygon(MouseEventArgs _obj, InkCanvas _InkCanvas)
        {
            Polygon originalPolygon = (Polygon)_obj.OriginalSource;
            MyDrawingAttributes drawingAttribute = new MyDrawingAttributes()
            {
                Color = Colors.Black
            };
            MyStylusPointCollection points = new MyStylusPointCollection();
            foreach (Point aPoint in originalPolygon.Points)
            {
                points.Add(new StylusPoint(aPoint.X, aPoint.Y));
            }
            MyStroke newStroke = new MyStroke(points, drawingAttribute);
            _InkCanvas.Strokes.Add(newStroke);
            Polygon tempPolygon = originalPolygon;
            originalPolygon = new Polygon();
            originalPolygon.Stroke = Brushes.Black;
            foreach (StylusPoint aStylusPoint in newStroke.StylusPoints)
            {
                originalPolygon.Points.Add(aStylusPoint.ToPoint());
            }
            BrushConverter brushConverter = new BrushConverter();
            Brush brush = (Brush)brushConverter.ConvertFromString(tempPolygon.Fill.ToString());
            originalPolygon.Fill = brush;
            _InkCanvas.Strokes.Remove(newStroke);
            _InkCanvas.Children.Add(originalPolygon);
        }

        public void replaceSelectedStroke(InkCanvas _InkCanvas)
        {
            MyStrokeCollection strokeCollection = new MyStrokeCollection(_InkCanvas.GetSelectedStrokes());
            printPolygon(strokeCollection, _InkCanvas);
            foreach (Stroke aStroke in strokeCollection)
            {
                _InkCanvas.Strokes.Remove(aStroke);
            }
        }

        public void printPolygon(MyStrokeCollection _strokeCollection, InkCanvas _InkCanvas)
        {
            MyStrokeCollection strokeCollections = new MyStrokeCollection(_strokeCollection);
            for (int i = 0; i < strokeCollections.Count; i++)
            {
                for (int j = 0; j < strokeCollections[i].StylusPoints.Count; j++)
                {
                    polygon.Points.Add(strokeCollections[i].StylusPoints[j].ToPoint());
                }
            }
            _InkCanvas.Children.Add(polygon);
        }

        public void setPolygon(Polygon _polygon) {
            polygon = _polygon;
        }

        public Polygon getPolygon() {
            return polygon;
        }

        public void setColorFill(String _colorFill) {
            this.colorFill = _colorFill;
        }

        public string getColorFill() {
            return colorFill;
        }
    }
}

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
        private MyPolygon myPolygon;
        private ColorHandler colorHandler;
        public PolygonShape() {

        }

        public void duplicatePolygon(MouseEventArgs _obj, InkCanvas _InkCanvas) {
            MyPolygon originalPolygon = new MyPolygon();
            originalPolygon.setPolygon((Polygon)_obj.OriginalSource);
            MyDrawingAttributes drawingAttribute = new MyDrawingAttributes()
            {
                Color = Colors.Black
            };
            MyStylusPointCollection points = new MyStylusPointCollection();
            foreach (Point aPoint in originalPolygon.getPolygon().Points)
            {
                points.Add(new StylusPoint(aPoint.X, aPoint.Y));
            }
            MyStroke newStroke = new MyStroke(points, drawingAttribute);
            _InkCanvas.Strokes.Add(newStroke);
            MyPolygon tempPolygon = originalPolygon;
            originalPolygon = new MyPolygon();
            originalPolygon.getPolygon().Stroke = Brushes.Black;
             
            foreach (StylusPoint aStylusPoint in newStroke.StylusPoints)
            {
                originalPolygon.getPolygon().Points.Add(aStylusPoint.ToPoint());
            }
            BrushConverter brushConverter = new BrushConverter();
            Brush brush = (Brush)brushConverter.ConvertFromString(tempPolygon.getPolygon().Fill.ToString());
            originalPolygon.getPolygon().Fill = brush;
            _InkCanvas.Strokes.Remove(newStroke);
            _InkCanvas.Children.Add(originalPolygon.getPolygon());
        }

        public void replaceSelectedStroke(InkCanvas _InkCanvas) {
            MyStrokeCollection strokeCollection = new MyStrokeCollection(_InkCanvas.GetSelectedStrokes());
            printPolygon(strokeCollection, _InkCanvas);
            foreach (Stroke aStroke in strokeCollection)
            {
                _InkCanvas.Strokes.Remove(aStroke);
            }
        }

        public void changePolygonColor(MouseEventArgs _obj, InkCanvas _InkCanvas) {
            MyPolygon originalPolygon = new MyPolygon();
            originalPolygon.setPolygon((Polygon)_obj.OriginalSource);
            _InkCanvas.Children.Remove(originalPolygon.getPolygon());
            MyDrawingAttributes drawingAttribute = new MyDrawingAttributes() {
                Color = Colors.Black
            };
            MyStylusPointCollection points = new MyStylusPointCollection();
            foreach (Point aPoint in originalPolygon.getPolygon().Points)
            {
                points.Add(new StylusPoint(aPoint.X, aPoint.Y));
            }
            MyStroke newStroke = new MyStroke(points, drawingAttribute);
            _InkCanvas.Strokes.Add(newStroke);
            originalPolygon = new MyPolygon();
            originalPolygon.getPolygon().Stroke = Brushes.Black;
            foreach (StylusPoint aStylusPoint in newStroke.StylusPoints)
            {
                originalPolygon.getPolygon().Points.Add(aStylusPoint.ToPoint());
            }
            BrushConverter brushConverter = new BrushConverter();
            Brush brush = (Brush)brushConverter.ConvertFromString(colorHandler.getColorFill());
            originalPolygon.getPolygon().Fill = brush;
            _InkCanvas.Strokes.Remove(newStroke);
            _InkCanvas.Children.Add(originalPolygon.getPolygon());
        }

        public void printPolygon(MyStrokeCollection _strokeCollection, InkCanvas _InkCanvas) {
            MyStrokeCollection strokeCollections = new MyStrokeCollection(_strokeCollection);
            for (int i = 0; i < strokeCollections.Count; i++) {
                for (int j = 0; j < strokeCollections[i].StylusPoints.Count; j++) {
                    myPolygon.getPolygon().Points.Add(strokeCollections[i].StylusPoints[j].ToPoint());
                }
            }
            _InkCanvas.Children.Add(myPolygon.getPolygon());
        }

        public void setMyPolygon(MyPolygon _myPolygon) {
            myPolygon = _myPolygon;
        }

        public MyPolygon getMyPolygon() {
            return myPolygon;
        }

        public void setColorHandler(ColorHandler _colorHandler) {
            this.colorHandler = _colorHandler;
        }
    }
}

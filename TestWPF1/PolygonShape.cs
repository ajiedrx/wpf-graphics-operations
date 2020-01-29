using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Ink;

namespace TestWPF1
{
    public class PolygonShape : IPolygonShape
    {
        private MyPolygon myPolygon;
        private IColorHandler colorHandler;
        public PolygonShape() { }

        public void duplicatePolygon(MouseEventArgs _obj, InkCanvas _InkCanvas) {
            MyPolygon originalPolygon = new MyPolygon();
            originalPolygon.setPolygon((Polygon)_obj.OriginalSource);
            replicatePolygon(_obj, _InkCanvas, originalPolygon.getPolygon().Fill.ToString());
        }

        public void changePolygonColor(MouseEventArgs _obj, InkCanvas _InkCanvas)
        {
            _InkCanvas.Children.Remove((Polygon)_obj.OriginalSource);
            replicatePolygon(_obj, _InkCanvas, colorHandler.getColorFill());
        }

        public void replicatePolygon(MouseEventArgs _obj, InkCanvas _InkCanvas, string _color) {
            MyPolygon originalPolygon = new MyPolygon();
            originalPolygon.setPolygon((Polygon)_obj.OriginalSource);
            MyDrawingAttributes drawingAttribute = new MyDrawingAttributes() {
                Color = Colors.Black
            };
            MyStroke newStroke = new MyStroke(createMyStylusPointCollection(originalPolygon), drawingAttribute);
            _InkCanvas.Strokes.Add(newStroke);
            originalPolygon = createNewPolygonFromStroke(newStroke, _color);
            _InkCanvas.Strokes.Remove(newStroke);
            _InkCanvas.Children.Add(originalPolygon.getPolygon());
        }

        public MyStylusPointCollection createMyStylusPointCollection(MyPolygon _originalPolygon) {
            MyStylusPointCollection points = new MyStylusPointCollection();
            foreach (Point aPoint in _originalPolygon.getPolygon().Points)
            {
                points.Add(new StylusPoint(aPoint.X, aPoint.Y));
            }
            return points;
        }

        public MyPolygon createNewPolygonFromStroke(MyStroke _newStroke, string _color) {
            MyPolygon _originalPolygon = new MyPolygon();
            _originalPolygon.getPolygon().Stroke = MyBrushes.Black;
            foreach (StylusPoint aStylusPoint in _newStroke.StylusPoints) {
                _originalPolygon.getPolygon().Points.Add(aStylusPoint.ToPoint());
            }
            MyBrushConverter myBrushConverter = new MyBrushConverter();
            _originalPolygon.getPolygon().Fill = myBrushConverter.getConvertedBrush(_color);
            return _originalPolygon;
        }

        public void replaceSelectedStroke(InkCanvas _InkCanvas) {
            MyStrokeCollection strokeCollection = new MyStrokeCollection(_InkCanvas.GetSelectedStrokes());
            printPolygon(strokeCollection, _InkCanvas);
            _InkCanvas.Strokes.Remove(_InkCanvas.GetSelectedStrokes());
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

        public void setColorHandler(IColorHandler _colorHandler) {
            this.colorHandler = _colorHandler;
        }
    }
}

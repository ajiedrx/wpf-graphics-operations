using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TestWPF1
{
    public class PolygonShape : IPolygonShape
    {
        private IMyPolygon myPolygon;
        private IColorHandler colorHandler;
        private IMyStroke myStroke;
        private IMyStrokeCollection myStrokeCollection;
        private IMyDrawingAttributes myDrawingAttributes;
        public PolygonShape() { }

        public void duplicatePolygon(MouseEventArgs _obj, InkCanvas _InkCanvas) {
            IMyPolygon originalPolygon = myPolygon.createPolygon();
            originalPolygon.setPolygon(_obj.OriginalSource);
            replicatePolygon(_obj, _InkCanvas, originalPolygon.getPolygon().Fill.ToString());
        }

        public void setMyStroke(IMyStroke _myStroke) {
            this.myStroke = _myStroke;
        }
        public void setMyStrokeCollection(IMyStrokeCollection _myStrokeCollection)
        {
            this.myStrokeCollection = _myStrokeCollection;
        }
        public void setMyDrawingAttributes(IMyDrawingAttributes _myDrawingAttributes)
        {
            this.myDrawingAttributes = _myDrawingAttributes;
        }

        public void changePolygonColor(MouseEventArgs _obj, InkCanvas _InkCanvas)
        {
            IMyPolygon originalPolygon = myPolygon.createPolygon();
            originalPolygon.setPolygon(_obj.OriginalSource);
            _InkCanvas.Children.Remove(originalPolygon.getPolygon());
            replicatePolygon(_obj, _InkCanvas, colorHandler.getColorFill());
        }

        public void replicatePolygon(MouseEventArgs _obj, InkCanvas _InkCanvas, string _color) {
            IMyPolygon originalPolygon = myPolygon.createPolygon();
            originalPolygon.setPolygon(_obj.OriginalSource);
            myStroke.createStroke(originalPolygon.getPolygonPoints(), myDrawingAttributes.createMyDrawingAttributes(Colors.Black));
            _InkCanvas.Strokes.Add(myStroke.getStroke());
            originalPolygon = createNewPolygonFromStroke(myStroke, _color);
            _InkCanvas.Strokes.Remove(myStroke.getStroke());
            originalPolygon.getPolygon().Stroke = Brushes.Black;
            _InkCanvas.Children.Add(originalPolygon.getPolygon());
        }

        public IMyPolygon createNewPolygonFromStroke(IMyStroke _newStroke, string _color) {
            IMyPolygon newPolygon = myPolygon.createPolygon();
            newPolygon.getPolygon().Stroke = MyBrushes.Black;
            newPolygon.setPolygonPoints(_newStroke);
            newPolygon.getPolygon().Fill = colorHandler.getMyBrushConverter().getConvertedBrush(_color);
            return newPolygon;
        }

        public void replaceSelectedStroke(InkCanvas _InkCanvas) {
            printPolygon(myStrokeCollection.createStrokeCollection(_InkCanvas.GetSelectedStrokes()), _InkCanvas);
            _InkCanvas.Strokes.Remove(_InkCanvas.GetSelectedStrokes());
        }

        public void printPolygon(MyStrokeCollection _strokeCollection, InkCanvas _InkCanvas) {
            for (int i = 0; i < _strokeCollection.Count; i++) {
                for (int j = 0; j < _strokeCollection[i].StylusPoints.Count; j++) {
                    myPolygon.getPolygon().Points.Add(_strokeCollection[i].StylusPoints[j].ToPoint());
                }
            }
            _InkCanvas.Children.Add(myPolygon.getPolygon());
        }

        public void setMyPolygon(IMyPolygon _myPolygon) {
            myPolygon = _myPolygon;
        }

        public IMyPolygon getMyPolygon() {
            return myPolygon;
        }

        public void setColorHandler(IColorHandler _colorHandler) {
            this.colorHandler = _colorHandler;
        }
    }
}

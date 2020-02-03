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
        private IMyBrushConverter myBrushConverter;
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
            myStroke.addStrokeOnCanvas(_InkCanvas, myStroke.getStroke());
            originalPolygon = createNewPolygonFromStroke(myStroke, _color);
            myStroke.removeStrokeOnCanvas(_InkCanvas, myStroke.getStroke());
            originalPolygon.getPolygon().Stroke = MyBrushes.Black;
            _InkCanvas.Children.Add(originalPolygon.getPolygon());
        }

        public IMyPolygon createNewPolygonFromStroke(IMyStroke _newStroke, string _color) {
            IMyPolygon newPolygon = myPolygon.createPolygon();
            newPolygon.getPolygon().Stroke = MyBrushes.Black;
            newPolygon.setPolygonPointsFromStroke(_newStroke);
            newPolygon.getPolygon().Fill = myBrushConverter.getConvertedBrush(_color);
            return newPolygon;
        }

        public void replaceSelectedStroke(InkCanvas _InkCanvas) {
            printPolygon(myStrokeCollection.createStrokeCollection(_InkCanvas.GetSelectedStrokes()), _InkCanvas);
            _InkCanvas.Strokes.Remove(_InkCanvas.GetSelectedStrokes());
        }

        public void printPolygon(MyStrokeCollection _strokeCollection, InkCanvas _InkCanvas) {
            _InkCanvas.Children.Add(myPolygon.createPolygonFromStrokeCollection(_strokeCollection));
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

        public void setMyBrushConverter(IMyBrushConverter _myBrushConverter) {
            this.myBrushConverter = _myBrushConverter;
        }
    }
}

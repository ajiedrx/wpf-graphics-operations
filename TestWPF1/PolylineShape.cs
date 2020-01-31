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
        private IMyPolyline myPolyline;
        private IMyStroke myStroke;
        private IMyDrawingAttributes myDrawingAttributes;
        public void setMyStroke(IMyStroke _myStroke)
        {
            this.myStroke = _myStroke;
        }
        public void setMyDrawingAttributes(IMyDrawingAttributes _myDrawingAttributes)
        {
            this.myDrawingAttributes = _myDrawingAttributes;
        }
        public void duplicateLine(MouseEventArgs _obj, InkCanvas _InkCanvas){
            IMyPolyline originalPolyline = myPolyline.createMyPolyline();
            originalPolyline.setPolyline(_obj.OriginalSource);
            myStroke.createStroke(originalPolyline.getPolylinePoints(), myDrawingAttributes.createMyDrawingAttributes(Colors.Black));
            _InkCanvas.Strokes.Add(myStroke.getStroke());
            originalPolyline = createNewPolylineFromStroke(myStroke);
            _InkCanvas.Strokes.Remove(myStroke.getStroke());
            originalPolyline.getPolyline().Stroke = Brushes.Black;
            _InkCanvas.Children.Add(originalPolyline.getPolyline());
        }

        public IMyPolyline createNewPolylineFromStroke(IMyStroke _newStroke)
        {
            IMyPolyline _originalPolyline = myPolyline.createMyPolyline();
            _originalPolyline.getPolyline().Stroke = MyBrushes.Black;
            _originalPolyline.setPolylinePoints(_newStroke);
            return _originalPolyline;
        }

        public void printPolyline(InkCanvas _InkCanvas, IMyPoint _firstPoint, IMyPoint _endPoint)
        {
            IMyPolyline newPolyline = myPolyline.makePolylineWithPoints(_firstPoint, _endPoint, Brushes.Black);
            _InkCanvas.Children.Add(newPolyline.getPolyline());
        }

        public void setMyPolyline(IMyPolyline _myPolyline)
        {
            this.myPolyline = _myPolyline;
        }

        public IMyPolyline getMyPolyline()
        {
            return this.myPolyline;
        }
    }
}

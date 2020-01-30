using System.Windows.Controls;
using System.Windows.Input;

namespace TestWPF1
{
    public interface IPolylineShape
    {
        void duplicateLine(MouseEventArgs _obj, InkCanvas _InkCanvas);
        void printPolyline(InkCanvas _InkCanvas, MyPoint _firstPoint, MyPoint _endPoint);
        void setMyStroke(IMyStroke _myStroke);
        void setMyStrokeCollection(IMyStrokeCollection _myStrokeCollection);
        void setMyDrawingAttributes(IMyDrawingAttributes _myDrawingAttributes);
        void setMyPolyline (IMyPolyline _myPolyline);

        IMyPolyline getMyPolyline();

    }
}

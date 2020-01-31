using System.Windows.Controls;
using System.Windows.Input;

namespace TestWPF1
{
    public interface IPolylineShape
    {
        void duplicateLine(MouseEventArgs _obj, InkCanvas _InkCanvas);
        void printPolyline(InkCanvas _InkCanvas, IMyPoint _firstPoint, IMyPoint _endPoint);
        void setMyStroke(IMyStroke _myStroke);
        void setMyDrawingAttributes(IMyDrawingAttributes _myDrawingAttributes);
        void setMyPolyline (IMyPolyline _myPolyline);

        IMyPolyline getMyPolyline();

    }
}

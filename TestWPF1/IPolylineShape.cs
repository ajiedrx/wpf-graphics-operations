using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestWPF1
{
    public interface IPolylineShape
    {
        void duplicateLine(MouseEventArgs _obj, InkCanvas _InkCanvas);
        void printPolyline(InkCanvas _InkCanvas, Point _firstPoint, Point _endPoint);
    }
}

using System.Windows.Controls;
using System.Windows.Input;

namespace TestWPF1
{
    public interface IPolygonShape
    {
        void duplicatePolygon(MouseEventArgs _obj, InkCanvas _InkCanvas);
        void setMyPolygon(IMyPolygon _myPolygon);

        IMyPolygon getMyPolygon();

        void setColorHandler(IColorHandler _colorHandler);
        void changePolygonColor(MouseEventArgs _obj, InkCanvas _InkCanvas);
        void replaceSelectedStroke(InkCanvas _InkCanvas);
        void setMyBrushConverter(IMyBrushConverter _myBrushConverter);
        void setMyStroke(IMyStroke _myStroke);
        void setMyStrokeCollection(IMyStrokeCollection _myStrokeCollection);
        void setMyDrawingAttributes(IMyDrawingAttributes _myDrawingAttributes);
    }
}

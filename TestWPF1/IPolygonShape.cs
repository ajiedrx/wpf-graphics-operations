using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestWPF1
{
    public interface IPolygonShape
    {
        void duplicatePolygon(MouseEventArgs _obj, InkCanvas _InkCanvas);
        void setMyPolygon(MyPolygon _myPolygon);

        MyPolygon getMyPolygon();

        void setColorHandler(IColorHandler _colorHandler);
        void changePolygonColor(MouseEventArgs _obj, InkCanvas _InkCanvas);
        void replaceSelectedStroke(InkCanvas _InkCanvas);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Ink;

namespace TestWPF1
{
    public interface IMyStroke
    {
        void createMyStroke(MyStylusPointCollection _stylusPointCollection, MyDrawingAttributes _myDrawingAttributes);
        Stroke createStroke(MyStylusPointCollection _stylusPointCollection, MyDrawingAttributes _myDrawingAttributes);
        void removeStrokesOnCanvas(InkCanvas _InkCanvas, IMyStroke _stroke);
        Stroke getStroke();
        void setStroke(Stroke _stroke);
        void addStrokesOnCanvas(InkCanvas _InkCanvas, IMyStroke _stroke);
    }
}

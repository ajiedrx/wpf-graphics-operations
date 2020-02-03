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
        Stroke createStroke(MyStylusPointCollection _stylusPointCollection, MyDrawingAttributes _myDrawingAttributes);
        void removeStrokeOnCanvas(InkCanvas _InkCanvas, Stroke _stroke);
        Stroke getStroke();
        void setStroke(Stroke _stroke);
        void addStrokeOnCanvas(InkCanvas _InkCanvas, Stroke _stroke);
    }
}

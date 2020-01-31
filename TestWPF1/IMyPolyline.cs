using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TestWPF1
{
    public interface IMyPolyline
    {
        void setPolyline(object _polyline);
        Polyline getPolyline();
        MyPolyline createMyPolyline();
        MyPolyline makePolylineWithPoints(IMyPoint _firstPoint, IMyPoint _endPoint, SolidColorBrush _brushes);
        MyStylusPointCollection getPolylinePoints();

        void setPolylinePoints(IMyStroke _stroke);
    }
}

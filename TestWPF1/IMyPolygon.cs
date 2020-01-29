using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace TestWPF1
{
    public interface IMyPolygon
    {
        void setPolygon(object _polygon);

        Polygon getPolygon();

        MyPolygon createPolygon();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF1
{
    public interface ICanvasObjectHandler
    {
        PolylineShape getPolylineShape();

        PolygonShape getPolygonShape();
    }
}

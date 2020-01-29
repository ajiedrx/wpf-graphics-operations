using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF1
{
    public interface ICanvasObjectHandler
    {
        IPolylineShape getPolylineShape();

        IPolygonShape getPolygonShape();

        void setPolygonShape(IPolygonShape _polygonShape);
        void setPolylineShape(IPolylineShape _polylineShape);
    }
}

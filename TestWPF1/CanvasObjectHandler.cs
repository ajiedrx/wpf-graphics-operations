using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace TestWPF1
{
    public class CanvasObjectHandler : ICanvasObjectHandler
    {
        private IPolylineShape polylineShape;
        private IPolygonShape polygonShape;
        public CanvasObjectHandler() {
        
        }

        public void setPolygonShape(IPolygonShape _polygonShape) {
            this.polygonShape = _polygonShape;
        }
        public void setPolylineShape(IPolylineShape _polylineShape)
        {
            this.polylineShape = _polylineShape;
        }
        public IPolylineShape getPolylineShape() {
            return this.polylineShape;
        }

        public IPolygonShape getPolygonShape() {
            return this.polygonShape;
        }
    }
}

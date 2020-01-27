using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace TestWPF1
{
    public class CanvasObjectHandler
    {
        private PolylineShape polylineShape;
        private PolygonShape polygonShape;
        public CanvasObjectHandler() {
            this.polylineShape = new PolylineShape();
            this.polygonShape = new PolygonShape();
        }

        public PolylineShape getPolylineShape() {
            return this.polylineShape;
        }

        public PolygonShape getPolygonShape()
        {
            return this.polygonShape;
        }
    }
}

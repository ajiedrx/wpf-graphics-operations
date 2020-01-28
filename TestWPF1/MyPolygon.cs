using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace TestWPF1
{
    public class MyPolygon
    {
        private Polygon polygon;

        public MyPolygon() {
            this.polygon = new Polygon();
        }

        public void setPolygon(Polygon _polygon) {
            this.polygon = _polygon;
        }

        public Polygon getPolygon() {
            return this.polygon;
        }

        public MyPolygon createPolygon() {
            return new MyPolygon();
        }
    }
}

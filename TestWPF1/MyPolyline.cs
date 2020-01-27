using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace TestWPF1
{
    class MyPolyline
    {
        private Polyline polyline;
        public static Polyline thisIsPolyline;

        public MyPolyline()
        {
            this.polyline = new Polyline();
        }

        public void setPolyline(Polyline _polyline)
        {
            this.polyline = _polyline;
        }

        public Polyline getPolyline()
        {
            return this.polyline;
        }

    }
}

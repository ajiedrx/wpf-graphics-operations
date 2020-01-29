using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestWPF1
{
    public class MyPoint
    {
        private Point point;

        public MyPoint() {
            this.point = new Point();
        }

        public Point getPoint() {
            return this.point;
        }

        public void setPoint(Point _point) {
            this.point = _point;
        }
    }
}

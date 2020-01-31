using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestWPF1
{
    public interface IMyPoint
    {
        Point getPoint();

        void setPoint(Point _point);

        MyPoint createMyPoint();
    }
}

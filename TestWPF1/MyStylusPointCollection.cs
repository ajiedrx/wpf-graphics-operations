using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TestWPF1
{
    public class MyStylusPointCollection : StylusPointCollection
    {
        public MyStylusPointCollection()
        {
        }

        public MyStylusPointCollection(int initialCapacity) : base(initialCapacity)
        {
        }

        public MyStylusPointCollection(StylusPointDescription stylusPointDescription) : base(stylusPointDescription)
        {
        }

        public MyStylusPointCollection(IEnumerable<StylusPoint> stylusPoints) : base(stylusPoints)
        {
        }

        public MyStylusPointCollection(IEnumerable<Point> points) : base(points)
        {
        }

        public MyStylusPointCollection(StylusPointDescription stylusPointDescription, int initialCapacity) : base(stylusPointDescription, initialCapacity)
        {
        }
    }
}

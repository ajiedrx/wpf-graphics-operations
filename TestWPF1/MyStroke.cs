using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;

namespace TestWPF1
{
    class MyStroke : Stroke
    {
        public MyStroke(StylusPointCollection stylusPoints) : base(stylusPoints)
        {

        }

        public MyStroke(StylusPointCollection stylusPoints, DrawingAttributes drawingAttributes) : base(stylusPoints, drawingAttributes)
        {

        }
    }
}

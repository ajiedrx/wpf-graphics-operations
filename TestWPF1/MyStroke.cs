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
        public MyStroke(MyStylusPointCollection stylusPoints) : base(stylusPoints)
        {

        }

        public MyStroke(MyStylusPointCollection stylusPoints, MyDrawingAttributes drawingAttributes) : base(stylusPoints, drawingAttributes)
        {

        }
    }
}

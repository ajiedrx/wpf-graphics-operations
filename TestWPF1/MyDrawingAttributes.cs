using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;
using System.Windows.Media;

namespace TestWPF1
{
    public class MyDrawingAttributes : DrawingAttributes
    {
        public MyDrawingAttributes()
        {

        }
        public DrawingAttributes createDrawingAttributes() {
            return new DrawingAttributes();
        }
    }
}

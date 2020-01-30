using System.Windows.Ink;
using System.Windows.Media;

namespace TestWPF1
{
    public class MyDrawingAttributes : DrawingAttributes, IMyDrawingAttributes
    {
        public MyDrawingAttributes()
        {

        }
        public DrawingAttributes createDrawingAttributes() {
            return new DrawingAttributes();
        }

        public MyDrawingAttributes createMyDrawingAttributes(Color _color)
        {
            return new MyDrawingAttributes()
            {
                Color = _color
            };
        }
    }
}

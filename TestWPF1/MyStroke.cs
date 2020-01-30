using System.Windows.Controls;
using System.Windows.Ink;

namespace TestWPF1
{
    public class MyStroke : IMyStroke
    {
        private Stroke stroke;
        public MyStroke() {
         
        }

        public MyStroke(MyStylusPointCollection _stylusPointCollection, MyDrawingAttributes _myDrawingAttributes) {
            this.stroke = new Stroke(_stylusPointCollection, _myDrawingAttributes);
        }

        public void addStrokesOnCanvas(InkCanvas _InkCanvas, IMyStroke _stroke)
        {
            throw new System.NotImplementedException();
        }

        public void createMyStroke(MyStylusPointCollection _stylusPointCollection, MyDrawingAttributes _myDrawingAttributes)
        {
            throw new System.NotImplementedException();
        }

        public Stroke createStroke(MyStylusPointCollection _stylusPointCollection, MyDrawingAttributes _myDrawingAttributes)
        {
            this.stroke = new Stroke(_stylusPointCollection, _myDrawingAttributes);
            return this.stroke;
        }

        public Stroke getStroke() {
            return this.stroke;
        }

        public void removeStrokesOnCanvas(InkCanvas _InkCanvas, IMyStroke _stroke)
        {
            throw new System.NotImplementedException();
        }

        public void setStroke(Stroke _stroke) {
            this.stroke = _stroke;
        }
    }
}

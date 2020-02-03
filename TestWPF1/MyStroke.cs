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

        public void addStrokeOnCanvas(InkCanvas _InkCanvas, Stroke _stroke)
        {
            _InkCanvas.Strokes.Add(_stroke);
        }

        public Stroke createStroke(MyStylusPointCollection _stylusPointCollection, MyDrawingAttributes _myDrawingAttributes)
        {
            this.stroke = new Stroke(_stylusPointCollection, _myDrawingAttributes);
            return this.stroke;
        }

        public Stroke getStroke() {
            return this.stroke;
        }

        public void removeStrokeOnCanvas(InkCanvas _InkCanvas, Stroke _stroke)
        {
            _InkCanvas.Strokes.Remove(_stroke);
        }

        public void setStroke(Stroke _stroke) {
            this.stroke = _stroke;
        }
    }
}

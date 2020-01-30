using System.Windows.Media;

namespace TestWPF1
{
    public class MyBrushConverter : IMyBrushConverter
    {
        private BrushConverter brushConverter;

        public MyBrushConverter() {
            this.brushConverter = new BrushConverter();
        }

        public BrushConverter getBrushConverter() {
            return this.brushConverter;
        }

        public void setBrushConverter(BrushConverter _brushConverter) {
            this.brushConverter = _brushConverter;
        }

        public Brush getConvertedBrush(string _color) {
            return (Brush)getBrushConverter().ConvertFromString(_color);
        }
    }
}

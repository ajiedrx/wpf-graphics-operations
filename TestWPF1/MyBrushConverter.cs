using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TestWPF1
{
    class MyBrushConverter
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

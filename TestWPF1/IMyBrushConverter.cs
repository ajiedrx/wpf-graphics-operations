using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TestWPF1
{
    public interface IMyBrushConverter
    {
        BrushConverter getBrushConverter();

        void setBrushConverter(BrushConverter _brushConverter);

        Brush getConvertedBrush(string _color);
    }
}

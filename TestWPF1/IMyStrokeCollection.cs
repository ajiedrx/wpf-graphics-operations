using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;

namespace TestWPF1
{
    public interface IMyStrokeCollection
    {
        MyStrokeCollection createStrokeCollection(StrokeCollection _strokeCollection);
    }
}

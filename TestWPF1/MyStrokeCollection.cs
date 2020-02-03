using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Ink;
namespace TestWPF1
{
    public class MyStrokeCollection : StrokeCollection, IMyStrokeCollection
    {
        public MyStrokeCollection() {
        }

        public MyStrokeCollection(IEnumerable<Stroke> strokes) : base(strokes) {
        }

        public MyStrokeCollection createStrokeCollection(StrokeCollection _strokeCollection) {
            return new MyStrokeCollection(_strokeCollection);
        }
    }
}

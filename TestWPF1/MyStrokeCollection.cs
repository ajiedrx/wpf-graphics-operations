using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Ink;
namespace TestWPF1
{
    public class MyStrokeCollection : StrokeCollection, IMyStrokeCollection
    {
        public MyStrokeCollection()
        {
        }

        public MyStrokeCollection(IEnumerable<Stroke> strokes) : base(strokes)
        {
        }

        public MyStrokeCollection(Stream stream) : base(stream)
        {
        }

        public override StrokeCollection Clone()
        {
            return base.Clone();
        }

        public MyStrokeCollection createStrokeCollection(StrokeCollection _strokeCollection)
        {
            return new MyStrokeCollection(_strokeCollection);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void Save(Stream stream, bool compress)
        {
            base.Save(stream, compress);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
        }

        protected override void OnPropertyDataChanged(PropertyDataChangedEventArgs e)
        {
            base.OnPropertyDataChanged(e);
        }

        protected override void OnStrokesChanged(StrokeCollectionChangedEventArgs e)
        {
            base.OnStrokesChanged(e);
        }
    }
}

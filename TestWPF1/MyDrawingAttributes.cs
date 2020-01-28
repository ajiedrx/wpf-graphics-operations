using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;

namespace TestWPF1
{
    public class MyDrawingAttributes : DrawingAttributes
    {
        public MyDrawingAttributes()
        {
        }

        public override DrawingAttributes Clone()
        {
            return base.Clone();
        }

        public override bool Equals(object o)
        {
            return base.Equals(o);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override void OnAttributeChanged(PropertyDataChangedEventArgs e)
        {
            base.OnAttributeChanged(e);
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
        }

        protected override void OnPropertyDataChanged(PropertyDataChangedEventArgs e)
        {
            base.OnPropertyDataChanged(e);
        }
    }
}

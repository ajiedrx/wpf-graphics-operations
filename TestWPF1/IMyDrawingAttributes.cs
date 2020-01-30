using System.Windows.Media;

namespace TestWPF1
{
    public interface IMyDrawingAttributes
    {
        MyDrawingAttributes createMyDrawingAttributes(Color _color);
    }
}

using System.Windows.Controls;

namespace TestWPF1
{
    public interface IColorHandler
    {
         void onColorPick(InkCanvas _InkCanvas, Xceed.Wpf.Toolkit.ColorPicker _colorPicker);
         string getColorFill();
         void checkOnColorPick(InkCanvas _InkCanvas, Xceed.Wpf.Toolkit.ColorPicker _colorPicker);
         IMyBrushConverter getMyBrushConverter();

        void setMyBrushConverter(IMyBrushConverter _myBrushConverter);
        void setMyPolygon(IMyPolygon _myPolygon);
    }
}

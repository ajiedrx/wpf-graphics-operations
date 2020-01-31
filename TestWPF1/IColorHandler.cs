using System.Windows.Controls;

namespace TestWPF1
{
    public interface IColorHandler
    {
         void onColorPick(InkCanvas _InkCanvas, Xceed.Wpf.Toolkit.ColorPicker _colorPicker);
         string getColorFill();
        void setCanvasObjectHandler(ICanvasObjectHandler _canvasObjectHandler);
        void setGraphicsOperations(IGraphicsOperations _graphicsOperations);
        void checkOnColorPick(InkCanvas _InkCanvas, Xceed.Wpf.Toolkit.ColorPicker _colorPicker);
        void setMyBrushConverter(IMyBrushConverter _myBrushConverter);
        void setMyPolygon(IMyPolygon _myPolygon);
    }
}

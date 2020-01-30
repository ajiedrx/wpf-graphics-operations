using System.Windows.Controls;
using System.Windows.Input;

namespace TestWPF1
{
    public interface IGraphicsOperations
    {
        void setCanvasObjectHandler(ICanvasObjectHandler _canvasObjectHandler);

        void toggleDuplicateButton();

        void toggleChangeColorButton();

        void selectState(InkCanvas _InkCanvas, InkCanvasEditingMode _InkCanvasEditingMode, StateEnum _state);

        void copySelection(InkCanvas _InkCanvas);

        void pasteFromClipboard(InkCanvas _InkCanvas);

        void onColorPick_cp(InkCanvas _InkCanvas, Xceed.Wpf.Toolkit.ColorPicker _colorPicker);

        void onInkCanvasMouseDown(MouseEventArgs _e, MainWindow _mainWindow, InkCanvas _InkCanvas);

        void getMouseUpInfo(InkCanvas _InkCanvas, MouseButtonEventArgs _e, MainWindow _mainWindow);

        bool getDuplicateButtonCheck();

        bool getChangeColorButtonCheck();
    }
}

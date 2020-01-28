using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestWPF1
{
    interface IGraphicsOperations
    {
        void setCanvasObjectHandler(ICanvasObjectHandler _canvasObjectHandler);

        void toggleDuplicateButton();

        void toggleChangeColorButton();

        void selectState(InkCanvas _InkCanvas, InkCanvasEditingMode _InkCanvasEditingMode, string _state);

        void copySelection(InkCanvas _InkCanvas);

        void pasteFromClipboard(InkCanvas _InkCanvas);

        void onColorPick_cp(InkCanvas _InkCanvas, Xceed.Wpf.Toolkit.ColorPicker _colorPicker);

        void onInkCanvasMouseDown(MouseEventArgs _e, MainWindow _mainWindow, InkCanvas _InkCanvas);

        void getMouseUpInfo(InkCanvas _InkCanvas, MouseButtonEventArgs _e, MainWindow _mainWindow);
    }
}

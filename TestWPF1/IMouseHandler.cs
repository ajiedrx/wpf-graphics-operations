using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestWPF1
{
    public interface IMouseHandler
    {
        IMyPoint getMyPoint();
        IMyPoint getPointOnMouseDown(MouseEventArgs _e, MainWindow _mainWindow);
        void setMouseDownAction(MouseEventArgs _e, MainWindow _mainWindow, InkCanvas _InkCanvas);
        void setMyPoint(IMyPoint _myPoint);
        void setCanvasObjectHandler(ICanvasObjectHandler _canvasObjectHandler);
        IMyPoint getMyPointOnMouseUp(MouseButtonEventArgs _e, MainWindow _mainWindow);
    }
}

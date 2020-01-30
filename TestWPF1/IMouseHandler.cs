using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestWPF1
{
    public interface IMouseHandler
    {
        void setMyPoint(MyPoint _point);
        MyPoint getMyPoint();
        void setPointOnMouseDown(MouseEventArgs _e, MainWindow _mainWindow);
        void setMouseDownAction(MouseEventArgs _e, MainWindow _mainWindow, InkCanvas _InkCanvas);
        
    }
}

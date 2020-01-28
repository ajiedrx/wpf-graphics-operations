using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestWPF1
{
    public interface IMouseHandler
    {
        void setPoint(Point _point);
        Point getPoint();
        void getFirstMousePoint(MouseEventArgs _e, MainWindow _mainWindow);
        void getMouseDownInfo(MouseEventArgs _e, MainWindow _mainWindow, InkCanvas _InkCanvas);
        
    }
}

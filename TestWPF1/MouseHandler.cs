using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestWPF1
{
    public class MouseHandler : IMouseHandler
    {
        ICanvasObjectHandler canvasObjectHandler;
        private MyPoint myPoint;

        public MouseHandler(ICanvasObjectHandler _canvasObjectHandler) {
            this.canvasObjectHandler = _canvasObjectHandler;
            this.myPoint = new MyPoint();
        }
        public void setMyPoint(MyPoint _point) {
            myPoint = _point;
        }
        public MyPoint getMyPoint() {
            return myPoint;
        }
        public void setPointOnMouseDown(MouseEventArgs _e, MainWindow _mainWindow) {
            myPoint.setPoint(_e.GetPosition(_mainWindow));
        }
        public void setPointOnMouseUp() { 
        
        }
        public void setMouseDownAction(MouseEventArgs _e, MainWindow _mainWindow, InkCanvas _InkCanvas) {
            setPointOnMouseDown(_e, _mainWindow);
            canvasObjectHandler.canvasObjectAction(_e, _mainWindow, _InkCanvas);
        }

        public void getFirstMousePoint(MouseEventArgs _e, MainWindow _mainWindow)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestWPF1
{
    public class MouseHandler : IMouseHandler
    {
        ICanvasObjectHandler canvasObjectHandler;
        private IMyPoint myPoint;

        public MouseHandler() { }

        public void setCanvasObjectHandler(ICanvasObjectHandler _canvasObjectHandler) {
            this.canvasObjectHandler = _canvasObjectHandler;
        }
        public IMyPoint getMyPoint() {
            return myPoint;
        }
        public IMyPoint getPointOnMouseDown(MouseEventArgs _e, MainWindow _mainWindow) {
            myPoint.setPoint(_e.GetPosition(_mainWindow));
            return this.myPoint;
        }
        public void setMouseDownAction(MouseEventArgs _e, MainWindow _mainWindow, InkCanvas _InkCanvas) {
            getPointOnMouseDown(_e, _mainWindow);
            canvasObjectHandler.canvasObjectAction(_e, _mainWindow, _InkCanvas);
        }

        public void getFirstMousePoint(MouseEventArgs _e, MainWindow _mainWindow) {
            throw new NotImplementedException();
        }

        public void setMyPoint(IMyPoint _myPoint) {
            this.myPoint = _myPoint;
        }

        public IMyPoint getMyPointOnMouseUp(MouseButtonEventArgs _e, MainWindow _mainWindow) {
            IMyPoint endPoint = myPoint.createMyPoint();
            endPoint.setPoint(_e.GetPosition(_mainWindow));
            return endPoint;
        }
    }
}

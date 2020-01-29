using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace TestWPF1
{
    public class MouseHandler : IMouseHandler
    {
        private readonly string POLYGON = "System.Windows.Shapes.Polygon";
        private readonly string POLYLINE = "System.Windows.Shapes.Polyline";
        ICanvasObjectHandler canvasObjectHandler;
        private Point point;

        public MouseHandler(ICanvasObjectHandler _canvasObjectHandler) {
            this.canvasObjectHandler = _canvasObjectHandler;      
        }
        public void setPoint(Point _point) {
            point = _point;
        }
        public Point getPoint() {
            return point;
        }
        public void getFirstMousePoint(MouseEventArgs _e, MainWindow _mainWindow) {
            setPoint(_e.GetPosition(_mainWindow));
        }
        public void getMouseDownInfo(MouseEventArgs _e, MainWindow _mainWindow, InkCanvas _InkCanvas) {
            getFirstMousePoint(_e, _mainWindow);
            if (_e.OriginalSource.ToString().Equals(POLYLINE) && GraphicsOperations.getDuplicateButtonCheck()){
                canvasObjectHandler.getPolylineShape().duplicateLine(_e, _InkCanvas);
            }
            else if (_e.OriginalSource.ToString().Equals(POLYGON) && GraphicsOperations.getDuplicateButtonCheck()){
                canvasObjectHandler.getPolygonShape().duplicatePolygon(_e, _InkCanvas);
            }
            else if (_e.OriginalSource.ToString().Equals(POLYGON) && GraphicsOperations.getChangeColorButtonCheck())
            {
                canvasObjectHandler.getPolygonShape().changePolygonColor(_e, _InkCanvas);
            }
        }
    }
}

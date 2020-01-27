using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace TestWPF1
{
    class MouseHandler
    {
        GraphicsOperations graphicsOperations;
        private static Point point;

        public MouseHandler(GraphicsOperations _graphicsOperations) {
            this.graphicsOperations = _graphicsOperations;            
        }
        public static void setPoint(Point _point)
        {
            point = _point;
        }
        public static Point getPoint()
        {
            return point;
        }
        public void getFirstMousePoint(MouseEventArgs _e, MainWindow _mainWindow)
        {
            setPoint(_e.GetPosition(_mainWindow));
        }
        public void getMouseDownInfo(MouseEventArgs _e, MainWindow _mainWindow, InkCanvas _InkCanvas)
        {
            getFirstMousePoint(_e, _mainWindow);
            if (_e.OriginalSource is Polyline && GraphicsOperations.getDuplicateButtonCheck()){
                graphicsOperations.getCanvasObjectHandler().getPolylineShape().duplicateLine(_e, _InkCanvas);
            }
            else if (_e.OriginalSource is Polygon && GraphicsOperations.getDuplicateButtonCheck()){
                graphicsOperations.getCanvasObjectHandler().getPolygonShape().duplicatePolygon(_e, _InkCanvas);
            }
        }
    }
}

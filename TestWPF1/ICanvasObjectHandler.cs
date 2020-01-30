using System.Windows.Controls;
using System.Windows.Input;

namespace TestWPF1
{
    public interface ICanvasObjectHandler
    {
        IPolylineShape getPolylineShape();

        IPolygonShape getPolygonShape();

        void setPolygonShape(IPolygonShape _polygonShape);
        void setPolylineShape(IPolylineShape _polylineShape);
        void canvasObjectAction(MouseEventArgs _e, MainWindow _mainWindow, InkCanvas _InkCanvas);
        void setGraphicsOperations(IGraphicsOperations _graphicsOperations);
    }
}

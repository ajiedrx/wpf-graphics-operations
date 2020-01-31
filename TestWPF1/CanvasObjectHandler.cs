using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;


namespace TestWPF1
{
    public class CanvasObjectHandler : ICanvasObjectHandler
    {
        private IPolylineShape polylineShape;
        private IPolygonShape polygonShape;
        private IGraphicsOperations graphicsOperations;
        private readonly string POLYGON     = "System.Windows.Shapes.Polygon";
        private readonly string POLYLINE    = "System.Windows.Shapes.Polyline";
        public CanvasObjectHandler() { }
        
        public void setPolygonShape(IPolygonShape _polygonShape) {
            this.polygonShape = _polygonShape;
        }
        public void setGraphicsOperations(IGraphicsOperations _graphicsOperations) {
            this.graphicsOperations = _graphicsOperations;
        }
        public void setPolylineShape(IPolylineShape _polylineShape)
        {
            this.polylineShape = _polylineShape;
        }
        public IPolylineShape getPolylineShape() {
            return this.polylineShape;
        }
        public IPolygonShape getPolygonShape() {
            return this.polygonShape;
        }
        public void canvasObjectAction(MouseEventArgs _e, MainWindow _mainWindow, InkCanvas _InkCanvas) {
            if (_e.OriginalSource.ToString().Equals(POLYLINE) && graphicsOperations.getDuplicateButtonCheck()) {
                polylineShape.duplicateLine(_e, _InkCanvas);
            }
            else if (_e.OriginalSource.ToString().Equals(POLYGON) && graphicsOperations.getDuplicateButtonCheck()) {
                polygonShape.duplicatePolygon(_e, _InkCanvas);
            }
            else if (_e.OriginalSource.ToString().Equals(POLYGON) && graphicsOperations.getChangeColorButtonCheck()) {
                polygonShape.changePolygonColor(_e, _InkCanvas);
            }
        }
    }
}

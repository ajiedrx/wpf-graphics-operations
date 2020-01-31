using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestWPF1
{
    public class GraphicsOperations : IGraphicsOperations
    {
        private IColorHandler colorHandler;
        private IMouseHandler mouseHandler;
        private ICanvasObjectHandler canvasObjectHandler;
        private bool duplicateButtonCheck = false;
        private bool changeColorButtonCheck = false;

        #region state-setter-getter

        public static StateEnum state;
        public static void setState(StateEnum _state) {
            state = _state;
        }
        public static StateEnum getState() {
            return state;
        }
        #endregion

        public GraphicsOperations() {
            setState(StateEnum.DRAW);
            initializeModule();
        }

        private void initializeModule() {
            initializeCanvasObjectHandler();
            setCanvasObjectHandler(canvasObjectHandler);
            initializeColorHandler();
            initializeMouseHandler();
        }

        public void initializeColorHandler() {
            colorHandler = new ColorHandler();
            colorHandler.setCanvasObjectHandler(canvasObjectHandler);
            colorHandler.setGraphicsOperations(this);
            colorHandler.setMyBrushConverter(new MyBrushConverter());
            colorHandler.setMyPolygon(new MyPolygon());
            canvasObjectHandler.getPolygonShape().setColorHandler(colorHandler);
        }

        public void initializeMouseHandler() {
            this.mouseHandler = new MouseHandler();
            this.mouseHandler.setCanvasObjectHandler(canvasObjectHandler);
            this.mouseHandler.setMyPoint(new MyPoint());
        }

        public void initializeCanvasObjectHandler()
        {
            this.canvasObjectHandler = new CanvasObjectHandler();
            MyDrawingAttributes myDrawingAttributes = new MyDrawingAttributes();
            MyStrokeCollection myStrokeCollection = new MyStrokeCollection();
            MyStroke myStroke = new MyStroke();
            this.canvasObjectHandler.setPolygonShape(new PolygonShape());
            this.canvasObjectHandler.setPolylineShape(new PolylineShape());
            this.canvasObjectHandler.setGraphicsOperations(this);
            setShapeComponents(myDrawingAttributes, myStrokeCollection, myStroke);
        }

        public void setCanvasObjectHandler(ICanvasObjectHandler _canvasObjectHandler) {
            canvasObjectHandler = _canvasObjectHandler;
        }

        public void setShapeComponents(MyDrawingAttributes _myDrawingAttributes, MyStrokeCollection _myStrokeCollection, MyStroke _myStroke) {
            this.canvasObjectHandler.getPolygonShape().setMyDrawingAttributes(_myDrawingAttributes);
            this.canvasObjectHandler.getPolygonShape().setMyStrokeCollection(_myStrokeCollection);
            this.canvasObjectHandler.getPolygonShape().setMyStroke(_myStroke);
            this.canvasObjectHandler.getPolygonShape().setMyBrushConverter(new MyBrushConverter());
            this.canvasObjectHandler.getPolylineShape().setMyDrawingAttributes(_myDrawingAttributes);
            this.canvasObjectHandler.getPolylineShape().setMyStroke(_myStroke);
        }
        public void setMouseHandler(IMouseHandler _mouseHandler)
        {
            mouseHandler = _mouseHandler;
        }

        public void setColorHandler(IColorHandler _colorHandler) {
            colorHandler = _colorHandler;
        }

        public void toggleDuplicateButton() {
            duplicateButtonCheck = !duplicateButtonCheck;
            changeColorButtonCheck = false;
        }

        public void toggleChangeColorButton() {
            changeColorButtonCheck = !changeColorButtonCheck;
            duplicateButtonCheck = false;
        }

        public void selectState(InkCanvas _InkCanvas, InkCanvasEditingMode _InkCanvasEditingMode, StateEnum _state) {
            if (duplicateButtonCheck){
                duplicateButtonCheck = false;
            }
            _InkCanvas.EditingMode = _InkCanvasEditingMode;
            setState(_state);
        }

        public void copySelection(InkCanvas _InkCanvas) {
            _InkCanvas.CopySelection();
        }

        public void pasteFromClipboard(InkCanvas _InkCanvas) {
            if (_InkCanvas.CanPaste())
            {
                _InkCanvas.Paste(
                    new Point(0, 0));
            }
        }

        public void onColorPick_cp(InkCanvas _InkCanvas, Xceed.Wpf.Toolkit.ColorPicker _colorPicker) {
            colorHandler.checkOnColorPick(_InkCanvas, _colorPicker);
        }

        public void onInkCanvasMouseDown(MouseEventArgs _e, MainWindow _mainWindow, InkCanvas _InkCanvas) {
            mouseHandler.setMouseDownAction(_e, _mainWindow, _InkCanvas);
        }

        public void onInkCanvasMouseUp(InkCanvas _InkCanvas, MouseButtonEventArgs _e, MainWindow _mainWindow){
            if (getState() == StateEnum.DRAW_LINE)
            {
                this.canvasObjectHandler.getPolylineShape().setMyPolyline(new MyPolyline());
                MyPoint firstPoint = (MyPoint)mouseHandler.getMyPoint();
                MyPoint endPoint = (MyPoint)mouseHandler.getMyPointOnMouseUp(_e, _mainWindow);
                canvasObjectHandler.getPolylineShape().printPolyline(_InkCanvas, firstPoint, endPoint);
            }
        }

        public bool getDuplicateButtonCheck() {
            return duplicateButtonCheck;
        }
        public bool getChangeColorButtonCheck() {
            return changeColorButtonCheck;
        }
    }
}

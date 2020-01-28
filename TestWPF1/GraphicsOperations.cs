using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Ink;

namespace TestWPF1
{
    public class GraphicsOperations : IGraphicsOperations
    {
        private IColorHandler colorHandler;
        private IMouseHandler mouseHandler;
        private ICanvasObjectHandler canvasObjectHandler;
        private static bool duplicateButtonCheck = false;
        private static bool changeColorButtonCheck = false;

        #region state-setter-getter

        public static string state;
        public static void setState(String _state)
        {
            state = _state;
        }
        public static string getState()
        {
            return state;
        }
        #endregion

        public GraphicsOperations(){
            setState(StateEnum.DRAW);
            initializeModule();
        }

        private void initializeModule()
        {
            this.canvasObjectHandler = new CanvasObjectHandler();
            setCanvasObjectHandler(canvasObjectHandler);
            this.colorHandler = new ColorHandler(canvasObjectHandler);
            this.canvasObjectHandler.getPolygonShape().setColorHandler(colorHandler);
            this.mouseHandler = new MouseHandler(canvasObjectHandler);
        }

        public void setCanvasObjectHandler(ICanvasObjectHandler _canvasObjectHandler){
            canvasObjectHandler = _canvasObjectHandler;
        }

        public void toggleDuplicateButton(){
            duplicateButtonCheck = !duplicateButtonCheck;
        }

        public void toggleChangeColorButton(){
            changeColorButtonCheck = !changeColorButtonCheck;
        }

        public void selectState(InkCanvas _InkCanvas, InkCanvasEditingMode _InkCanvasEditingMode, string _state){
            if (duplicateButtonCheck){
                duplicateButtonCheck = false;
            }
            _InkCanvas.EditingMode = _InkCanvasEditingMode;
            setState(_state);
        }

        public void copySelection(InkCanvas _InkCanvas){
            _InkCanvas.CopySelection();
        }

        public void pasteFromClipboard(InkCanvas _InkCanvas){
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
            mouseHandler.getMouseDownInfo(_e, _mainWindow, _InkCanvas);
        }

        public void getMouseUpInfo(InkCanvas _InkCanvas, MouseButtonEventArgs _e, MainWindow _mainWindow){
            if (getState() == StateEnum.DRAW_LINE)
            {
                Point firstPoint = new Point(mouseHandler.getPoint().X, mouseHandler.getPoint().Y);
                Point endPoint = _e.GetPosition(_mainWindow);
                canvasObjectHandler.getPolylineShape().printPolyline(_InkCanvas, firstPoint, endPoint);
            }
        }

        public static bool getDuplicateButtonCheck() {
            return duplicateButtonCheck;
        }
        public static bool getChangeColorButtonCheck() {
            return changeColorButtonCheck;
        }
    }
}

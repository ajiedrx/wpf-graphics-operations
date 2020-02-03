﻿using System.Windows.Controls;

namespace TestWPF1
{
    public class ColorHandler : IColorHandler
    {
        private const string DEFAULT_COLOR_FILL = "#FFFFFF";
        private const string DEFAULT_COLOR_ATTR = "#000000";
        private string colorFill = DEFAULT_COLOR_FILL;
        private string colorAttr = DEFAULT_COLOR_ATTR;
        private ICanvasObjectHandler canvasObjectHandler;
        private IGraphicsOperations graphicsOperations;
        private IMyPolygon myPolygon;
        private IMyBrushConverter myBrushConverter;

        public ColorHandler() {
        }
        public void setCanvasObjectHandler(ICanvasObjectHandler _canvasObjectHandler) {
            this.canvasObjectHandler = _canvasObjectHandler;
        }
        public void setGraphicsOperations(IGraphicsOperations _graphicsOperations) {
            this.graphicsOperations = _graphicsOperations;
        }
        public void setMyBrushConverter(IMyBrushConverter _myBrushConverter) {
            this.myBrushConverter = _myBrushConverter;
        }
        public void setMyPolygon(IMyPolygon _myPolygon)
        {
            this.myPolygon = _myPolygon;
        }
        public void fillPolygon() {
            IMyPolygon newPolygon = myPolygon.createPolygon();
            newPolygon.getPolygon().Stroke = MyBrushes.Black; 
            newPolygon.getPolygon().StrokeThickness = 1;
            newPolygon.getPolygon().Fill = myBrushConverter.getConvertedBrush(getColorFill());
            canvasObjectHandler.getPolygonShape().setMyPolygon(newPolygon);
        }

        public void checkOnColorPick(InkCanvas _InkCanvas, Xceed.Wpf.Toolkit.ColorPicker _colorPicker) {
            if (!graphicsOperations.getChangeColorButtonCheck()) {
                onColorPick(_InkCanvas, _colorPicker);
                canvasObjectHandler.getPolygonShape().replaceSelectedStroke(_InkCanvas);
            }
            else {
                onColorPick(_InkCanvas, _colorPicker);
            }
        }

        public void onColorPick(InkCanvas _InkCanvas, Xceed.Wpf.Toolkit.ColorPicker _colorPicker) {
            if (_colorPicker.SelectedColor.HasValue) {
                if (!graphicsOperations.getChangeColorButtonCheck()) {
                    setColorFill(_colorPicker.SelectedColor.ToString());
                    fillThenReplace(_InkCanvas);
                }
                else{
                    setColorFill(_colorPicker.SelectedColor.ToString());
                }
            }
        }

        public void fillThenReplace(InkCanvas _InkCanvas) {
            fillPolygon();
            _InkCanvas.Children.Remove(canvasObjectHandler.getPolygonShape().getMyPolygon().getPolygon());
        }
        public string getColorFill() {
            return colorFill;
        }
        public void setColorFill (string _colorFill) {
            colorFill = _colorFill;
        }
    }
}

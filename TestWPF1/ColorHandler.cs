using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Ink;

namespace TestWPF1
{
    public class ColorHandler
    {
        private const string DEFAULT_COLOR_FILL = "#FFFFFF";
        private const string DEFAULT_COLOR_ATTR = "#000000";
        private string colorFill = DEFAULT_COLOR_FILL;
        private string colorAttr = DEFAULT_COLOR_ATTR;
        private GraphicsOperations graphicsOperations;

        public ColorHandler() { }
        public ColorHandler(GraphicsOperations _graphicsOperations) {
            this.graphicsOperations = _graphicsOperations;
        }
        public void fillPolygon() {
            BrushConverter brushConverter = new BrushConverter();
            Brush brush = (Brush)brushConverter.ConvertFromString(getColorFill());
            MyPolygon myPolygon = new MyPolygon();
            myPolygon.getPolygon().Stroke = Brushes.Black; 
            myPolygon.getPolygon().StrokeThickness = 1;
            myPolygon.getPolygon().Fill = brush;
            graphicsOperations.getCanvasObjectHandler().getPolygonShape().setMyPolygon(myPolygon);
        }

        public void onColorPick(InkCanvas _InkCanvas, Xceed.Wpf.Toolkit.ColorPicker _colorPicker) {
            if (_colorPicker.SelectedColor.HasValue) {
                if (!GraphicsOperations.getChangeColorButtonCheck()) {
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
            _InkCanvas.Children.Remove(graphicsOperations.getCanvasObjectHandler().getPolygonShape().getMyPolygon().getPolygon());
        }
        public string getColorAttr() {
            return colorAttr;
        }
        public void setColorAttr(string _colorAttr) {
            colorAttr = _colorAttr;
        }
        public string getColorFill() {
            return colorFill;
        }
        public void setColorFill (string _colorFill) {
            colorFill = _colorFill;
        }
    }
}

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Ink;

namespace TestWPF1
{
    class Color
    {
        private const string DEFAULT_COLOR_FILL = "#FFFFFF";
        private const string DEFAULT_COLOR_ATTR = "#000000";
        private string colorFill = DEFAULT_COLOR_FILL;
        private string colorAttr = DEFAULT_COLOR_ATTR;

        public Color() { }
        public void fillPolygon(InkCanvas _InkCanvas, Polygon _polygon) {
            BrushConverter brushConverter = new BrushConverter();
            Brush brush = (Brush)brushConverter.ConvertFromString(getColorFill());
            _polygon = new Polygon()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Fill = brush
            };
            GraphicsOperations.setPolygon(_polygon);
        }

        public void onColorPick(InkCanvas _InkCanvas, Xceed.Wpf.Toolkit.ColorPicker _colorPicker, Polygon _polygon)
        {
            if (_colorPicker.SelectedColor.HasValue)
            {
                setColorFill(_colorPicker.SelectedColor.ToString());
                fillPolygon(_InkCanvas, _polygon);
                _InkCanvas.Children.Remove(_polygon);
                //printPolygon(_InkCanvas.GetSelectedStrokes(), _InkCanvas);
            }
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

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Ink;

namespace TestWPF1
{
    class GraphicsOperations
    {
        private Polygon polygon;
        private Polyline polyline;
        private Point point;
        private Color color;
        private bool duplicateButtonCheck = false;

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

        public GraphicsOperations()
        {
            setState(StateEnum.DRAW);
            color = new Color();
        }

        public void getFirstMousePoint(MouseEventArgs _e, MainWindow _mainWindow) {
            point = _e.GetPosition(_mainWindow);
        }

        public void getMouseDownInfo(MouseEventArgs _e, MainWindow _mainWindow, InkCanvas _InkCanvas)
        {
            getFirstMousePoint(_e, _mainWindow);
            if (_e.OriginalSource is Polyline && duplicateButtonCheck)
            {
                duplicateLine(_e, _InkCanvas);
            }
            else if (_e.OriginalSource is Polygon && duplicateButtonCheck)
            {
                duplicatePolygon(_e, _InkCanvas);
            }
        }

        public void toggleDuplicateButton()
        {
            duplicateButtonCheck = !duplicateButtonCheck;
        }

        public void duplicateLine(MouseEventArgs _obj, InkCanvas _InkCanvas)
        {
            Polyline tempLine = (Polyline)_obj.OriginalSource;
            DrawingAttributes drawingAttribute = new DrawingAttributes()
            {
                Color = Colors.Black
            };
            StylusPointCollection points = new StylusPointCollection();
            foreach (Point aPoint in tempLine.Points)
            {
                points.Add(new StylusPoint(aPoint.X, aPoint.Y));
            }
            Stroke newStroke = new Stroke(points, drawingAttribute);
            _InkCanvas.Strokes.Add(newStroke);
            tempLine = new Polyline();
            tempLine.Stroke = Brushes.Black;
            foreach (StylusPoint aStylusPoint in newStroke.StylusPoints)
            {
                tempLine.Points.Add(aStylusPoint.ToPoint());
            }
            _InkCanvas.Strokes.Remove(newStroke);
            _InkCanvas.Children.Add(tempLine);
        }

        public void duplicatePolygon(MouseEventArgs _obj, InkCanvas _InkCanvas)
        {
            Polygon tempPolygon = (Polygon)_obj.OriginalSource;
            DrawingAttributes drawingAttribute = new DrawingAttributes()
            {
                Color = Colors.Black
            };
            StylusPointCollection points = new StylusPointCollection();
            foreach (Point aPoint in tempPolygon.Points)
            {
                points.Add(new StylusPoint(aPoint.X, aPoint.Y));
            }
            Stroke newStroke = new Stroke(points, drawingAttribute);
            _InkCanvas.Strokes.Add(newStroke);
            PolygonShape newPolygonShape = new PolygonShape(tempPolygon, tempPolygon.Fill.ToString());
            tempPolygon = new Polygon();
            tempPolygon.Stroke = Brushes.Black;
            foreach (StylusPoint aStylusPoint in newStroke.StylusPoints)
            {
                tempPolygon.Points.Add(aStylusPoint.ToPoint());
            }
            BrushConverter brushConverter = new BrushConverter();
            Brush brush = (Brush)brushConverter.ConvertFromString(newPolygonShape.getColorFill());
            tempPolygon.Fill = brush;
            _InkCanvas.Strokes.Remove(newStroke);
            _InkCanvas.Children.Add(tempPolygon);
        }

        public void trackMouseMove(InkCanvas _InkCanvas)
        {
            foreach (Stroke s in _InkCanvas.Strokes)
            {
                foreach (StylusPoint sp in s.StylusPoints)
                {
                    Console.WriteLine(sp.ToPoint());
                }
            }
        }

        public void selectState(InkCanvas _InkCanvas, InkCanvasEditingMode _InkCanvasEditingMode, string _state)
        {
            if (duplicateButtonCheck)
            {
                duplicateButtonCheck = false;
            }
            _InkCanvas.EditingMode = _InkCanvasEditingMode;
            setState(_state);
        }

        public void copySelection(InkCanvas _InkCanvas)
        {
            _InkCanvas.CopySelection();
        }

        public void pasteFromClipboard(InkCanvas _InkCanvas)
        {
            if (_InkCanvas.CanPaste())
            {
                _InkCanvas.Paste(
                    new Point(0, 0));
            }
        }

        public void fillColor(InkCanvas _InkCanvas)
        {
            polygon = color.fillPolygon(_InkCanvas, polygon);
            replaceSelectedStroke(_InkCanvas);
        }

        public void replaceSelectedStroke(InkCanvas _InkCanvas) {
            StrokeCollection strokeCollection = new StrokeCollection(_InkCanvas.GetSelectedStrokes());
            printPolygon(strokeCollection, _InkCanvas);
            foreach (Stroke aStroke in strokeCollection)
            {
                _InkCanvas.Strokes.Remove(aStroke);
            }
        }

        public void onColorPick(InkCanvas _InkCanvas, Xceed.Wpf.Toolkit.ColorPicker _colorPicker)
        {
            if (_colorPicker.SelectedColor.HasValue)
            {
                color.setColorFill(_colorPicker.SelectedColor.ToString());
                fillColor(_InkCanvas);
                _InkCanvas.Children.Remove(polygon);
                printPolygon(_InkCanvas.GetSelectedStrokes(), _InkCanvas);
            }
        }

        public void printPolygon(StrokeCollection strokeCollection, InkCanvas _InkCanvas)
        {
            StrokeCollection strokeCollections = new StrokeCollection(strokeCollection);
            foreach (Stroke aStroke in strokeCollections)
            {
                foreach (StylusPoint s in aStroke.StylusPoints)
                {
                    polygon.Points.Add(s.ToPoint());
                }
            }
            printPolygonToCanvas(polygon, _InkCanvas);
        }

        public void printPolygonToCanvas(Polygon _polygon, InkCanvas _InkCanvas)
        {
            _InkCanvas.Children.Add(_polygon);
        }

        public void onMouseUp(InkCanvas _InkCanvas, MouseButtonEventArgs _e, MainWindow _mainWindow)
        {
            if (getState() == StateEnum.DRAW_LINE)
            {
                Point firstPoint = new Point(point.X, point.Y);
                Point endPoint = _e.GetPosition(_mainWindow);
                polyline = new Polyline();
                polyline.Points.Add(firstPoint);
                polyline.Points.Add(endPoint);
                polyline.Stroke = Brushes.Black;
                _InkCanvas.Children.Add(polyline);
            }
            Console.WriteLine("Mouse Up");
        }

        public Polygon getPolygon() {
            return this.polygon;
        }
    }
}

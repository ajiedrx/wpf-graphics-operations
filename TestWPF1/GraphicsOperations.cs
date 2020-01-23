﻿using System;
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
        private static Polygon polygon;
        private Polyline polyline;
        private Point point;
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
            MyStroke newStroke = new MyStroke(points, drawingAttribute);
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
            MyStroke newStroke = new MyStroke(points, drawingAttribute);
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

        public void replaceSelectedStroke(InkCanvas _InkCanvas) {
            MyStrokeCollection strokeCollection = new MyStrokeCollection(_InkCanvas.GetSelectedStrokes());
            printPolygon(strokeCollection, _InkCanvas);
            foreach (Stroke aStroke in strokeCollection){
                _InkCanvas.Strokes.Remove(aStroke);
            }
        }

        public void printPolygon(MyStrokeCollection strokeCollection, InkCanvas _InkCanvas)
        {
            MyStrokeCollection strokeCollections = new MyStrokeCollection(strokeCollection);
            for (int i = 0; i < strokeCollections.Count; i++) {
                for (int j = 0; j < strokeCollections[i].StylusPoints.Count; j++)
                {
                    polygon.Points.Add(strokeCollections[i].StylusPoints[j].ToPoint());
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
        }

        public static Polygon getPolygon() {
            return polygon;
        }

        public static void setPolygon(Polygon _polygon){
            polygon = _polygon;
        }
    }
}

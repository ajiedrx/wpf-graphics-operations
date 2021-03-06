﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Ink;

namespace TestWPF1
{
    class PolylineShape
    {
        public void duplicateLine(MouseEventArgs _obj, InkCanvas _InkCanvas){
            Polyline tempLine = (Polyline)_obj.OriginalSource;
            MyDrawingAttributes drawingAttribute = new MyDrawingAttributes()
            {
                Color = Colors.Black
            };
            MyStylusPointCollection points = new MyStylusPointCollection();
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

        public void printPolyline(InkCanvas _InkCanvas, Point _firstPoint, Point _endPoint)
        {
            Polyline polyline = new Polyline();
            polyline.Points.Add(_firstPoint);
            polyline.Points.Add(_endPoint);
            polyline.Stroke = Brushes.Black;
            _InkCanvas.Children.Add(polyline);
        }
    }
}

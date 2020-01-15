using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Ink;
using System.Collections;
using System.Collections.Generic;

namespace TestWPF1
{
    public partial class MainWindow : Window
    {
        Line line = new Line();
        Polygon polygon = new Polygon();
        String colorFill = "#32a852";
        //Polygon temp;
        private double X1, Y1;
        List<Polygon> polygons = new List<Polygon>();
        //List<Point> path = new List<Point>();

        public enum Modes {
            draw,
            drawLine,
            paint,
            select
        };

        public Modes currentDrawMode;
        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine("Initialized");
            InkCanvas.AddHandler(InkCanvas.MouseDownEvent, new MouseButtonEventHandler(OnInkCanvasMouseDown), true);
            this.currentDrawMode = Modes.draw;
        }

        private void OnInkCanvasMouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Mouse down");
            Point p = e.GetPosition(this);
            X1 = p.X;
            Y1 = p.Y;
        }

        private void OnInkCanvasMouseMove(object sender, MouseEventArgs e)
        {
            foreach (Stroke s in InkCanvas.Strokes)
            {
                foreach (StylusPoint sp in s.StylusPoints)
                {
                    //Console.WriteLine(sp.X + " " + sp.Y);
                    Console.WriteLine(sp.ToPoint());
                    //path.Add(sp.ToPoint());
                }
            }
            //InkCanvas.Strokes.Clear();
        }

        private void OnClickDrawLine_btn(object sender, RoutedEventArgs e)
        {
            this.currentDrawMode = Modes.drawLine;
            InkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            InkCanvas.Strokes.Clear();
        }

        private void OnClickDraw_btn(object sender, RoutedEventArgs e)
        {
            this.currentDrawMode = Modes.draw;
            InkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            //InkCanvas.Strokes.Clear();
        }

        private void OnClickSelect_btn(object sender, RoutedEventArgs e)
        {
            InkCanvas.EditingMode = InkCanvasEditingMode.Select;
            this.currentDrawMode = Modes.select;
        }

        private void OnClickPaste_btn(object sender, RoutedEventArgs e)
        {
            if (InkCanvas.CanPaste())
            {
                InkCanvas.Paste(
                    new Point(0, 0));
            }
            /*
            InkCanvas.Children.Add(temp);
            polygons.Clear();
            temp = null;
            */
        }

        private void OnClickCopy_btn(object sender, RoutedEventArgs e)
        {
            InkCanvas.CopySelection();
            /*
            foreach (Polygon aPolygon in polygons)
            {
                foreach (Stroke selectedStroke in InkCanvas.GetSelectedStrokes())
                {
                    if (aPolygon.Equals(selectedStroke))
                    {
                        temp = aPolygon;
                    }
                }
            }
            */
        }

        private void OnClickColor_btn(object sender, RoutedEventArgs e)
        {
            BrushConverter brushConverter = new BrushConverter();
            Brush brush = (Brush)brushConverter.ConvertFromString(colorFill);
            polygon = new Polygon()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Fill = brush
            };
            PrintPolygon(); 
            polygons.Add(polygon);
        }

        private void OnColorPick_cp(object sender, RoutedPropertyChangedEventArgs<Color?> e) 
        {
            //bool flag = false;
            //int i = 0;
            if (cp.SelectedColor.HasValue) {
                InkCanvas.Children.Remove(polygon);
                colorFill = cp.SelectedColor.ToString();
                /*
                StrokeCollection strokeCollections = InkCanvas.GetSelectedStrokes();
                if (polygons.Count >= 0)
                {
                    foreach (Stroke aStroke in strokeCollections)
                    {
                        i = 0;
                        foreach (StylusPoint s in aStroke.StylusPoints)
                        {

                            if (polygons[i].Points.Equals(s.ToPoint()))
                            {
                                flag = true;
                                break;
                            }

                            i++;
                        }
                    }
                }
                if (!flag) {
                    PrintPolygon();
                }*/
                PrintPolygon();
            }
        }

        private void PrintPolygon() {
            StrokeCollection strokeCollections = InkCanvas.GetSelectedStrokes();
            /*
            Rect r = strokeCollections.GetBounds();
            PointCollection pointCollection = new PointCollection();
            Matrix mat = new Matrix();
            mat.Translate(-r.Left, -r.Top);
            strokeCollections.Transform(mat, false);

            foreach (Stroke aStroke in strokeCollections)
            {
                foreach (Point p in aStroke.StylusPoints)
                {
                    pointCollection.Add(p);
                    //polygon.Points.Add(s.ToPoint());
                }
            }
            polygon = new Polygon();
            polygon.SetValue(InkCanvas.LeftProperty, r.Left);
            polygon.SetValue(InkCanvas.TopProperty, r.Top);
            */
            foreach (Stroke aStroke in strokeCollections)
            {
                foreach (StylusPoint s in aStroke.StylusPoints)
                {
                    //pointCollection.Add(p);
                    polygon.Points.Add(s.ToPoint());
                }
            }
            InkCanvas.Children.Add(polygon);
        }

        private void OnInkCanvasMouseUp(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            if (this.currentDrawMode == Modes.drawLine)
            {
                line.X1 = X1;
                line.Y1 = Y1;
                line.X2 = p.X;
                line.Y2 = p.Y;
                line.Stroke = Brushes.Black;
                line.StrokeThickness = 4;
                InkCanvas.Children.Add(line);
                InkCanvas.Strokes.Clear();
                line = new Line();
            }
            Console.WriteLine("Mouse Up");
        }

        private bool IsShape(StrokeCollection strokeCollection) {
            if (strokeCollection[0].StylusPoints.Equals(strokeCollection[strokeCollection.Count-1].StylusPoints))
            {
                return true;
            }
            else
                return false;
        }
    }
}

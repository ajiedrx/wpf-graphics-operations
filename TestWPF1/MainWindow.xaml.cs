using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Ink;

namespace TestWPF1
{
    public partial class MainWindow : Window
    {
        private GraphicsOperations graphicsOperations;
        private Color colorClass;

        public MainWindow()
        {
            InitializeComponent();
            intializeEvents();
            initializeModule();
        }

        private void initializeModule() {
            this.graphicsOperations = new GraphicsOperations();
            this.colorClass = new Color();
        }

        private void intializeEvents()
        {
            InkCanvas.AddHandler(InkCanvas.MouseDownEvent, new MouseButtonEventHandler(OnInkCanvasMouseDown), true);
        }

        private void OnInkCanvasMouseDown(object sender, MouseEventArgs e){
            graphicsOperations.getMouseDownInfo(e, this, InkCanvas);
        }

        private void OnClickDuplicate_btn(object sender, RoutedEventArgs e){
            graphicsOperations.toggleDuplicateButton();
        }

        private void OnInkCanvasMouseMove(object sender, MouseEventArgs e)
        {
            //graphicsOperations.trackMouseMove(InkCanvas);
        }

        private void OnClickDrawLine_btn(object sender, RoutedEventArgs e){
            graphicsOperations.selectState(InkCanvas, InkCanvasEditingMode.GestureOnly, StateEnum.DRAW_LINE);
        }

        private void OnClickDraw_btn(object sender, RoutedEventArgs e){ 
            graphicsOperations.selectState(InkCanvas, InkCanvasEditingMode.Ink, StateEnum.DRAW);
        }

        private void OnClickSelect_btn(object sender, RoutedEventArgs e){
            graphicsOperations.selectState(InkCanvas, InkCanvasEditingMode.Select, StateEnum.SELECT);
        }

        private void OnClickPaste_btn(object sender, RoutedEventArgs e){
            graphicsOperations.pasteFromClipboard(InkCanvas);
        }

        private void OnClickCopy_btn(object sender, RoutedEventArgs e){
            graphicsOperations.copySelection(InkCanvas);
        }

        private void OnClickColor_btn(object sender, RoutedEventArgs e){
            colorClass.fillPolygon(InkCanvas, GraphicsOperations.getPolygon());
            graphicsOperations.replaceSelectedStroke(InkCanvas);
        }

        private void OnColorPick_cp(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color?> e) 
        {
            MyStrokeCollection strokeCollection = new MyStrokeCollection(InkCanvas.GetSelectedStrokes());
            colorClass.onColorPick(InkCanvas, colorPicker, GraphicsOperations.getPolygon());
            graphicsOperations.replaceSelectedStroke(InkCanvas);
        }

        private void OnInkCanvasMouseUp(object sender, MouseButtonEventArgs e){
            graphicsOperations.onMouseUp(InkCanvas, e, this);
        }
    }
}

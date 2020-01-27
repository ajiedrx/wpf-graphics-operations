using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Ink;
using System.Windows.Controls.Primitives;

namespace TestWPF1
{
    public partial class MainWindow : Window
    {
        private GraphicsOperations graphicsOperations;
        private ColorHandler colorHandler;
        private MouseHandler mouseHandler;
        private CanvasObjectHandler canvasObjectHandler;

        public MainWindow()
        {
            InitializeComponent();
            intializeEvents();
            initializeModule();
        }

        private void initializeModule() {
            this.graphicsOperations = new GraphicsOperations();
            this.canvasObjectHandler = new CanvasObjectHandler();
            this.graphicsOperations.setCanvasObjectHandler(this.canvasObjectHandler);
            this.colorHandler = new ColorHandler(graphicsOperations);
            this.mouseHandler = new MouseHandler(graphicsOperations);
            this.canvasObjectHandler.getPolygonShape().setColorHandler(colorHandler);
        }

        private void intializeEvents(){
            InkCanvas.AddHandler(InkCanvas.MouseDownEvent, new MouseButtonEventHandler(OnInkCanvasMouseDown), true);
        }

        private void OnInkCanvasMouseDown(object sender, MouseEventArgs e){
            mouseHandler.getMouseDownInfo(e, this, InkCanvas);
        }

        private void OnClickDuplicate_btn(object sender, RoutedEventArgs e){
            graphicsOperations.toggleDuplicateButton();
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
            colorHandler.fillPolygon();
            canvasObjectHandler.getPolygonShape().replaceSelectedStroke(InkCanvas);
        }

        private void OnColorPick_cp(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color?> e) 
        {
            if (!GraphicsOperations.getChangeColorButtonCheck())
            {
                colorHandler.onColorPick(InkCanvas, colorPicker);
                canvasObjectHandler.getPolygonShape().replaceSelectedStroke(InkCanvas);
            }
            else {
                colorHandler.onColorPick(InkCanvas, colorPicker);
            }
        }

        private void OnInkCanvasMouseUp(object sender, MouseButtonEventArgs e){
            graphicsOperations.getMouseUpInfo(InkCanvas, e, this);
        }

        private void onClickChangeColor_btn(object sender, RoutedEventArgs e){
            graphicsOperations.toggleChangeColorButton();
        }

        public ToggleButton getChangeColorButton() {
            return changeColor_btn;
        }
    }
}

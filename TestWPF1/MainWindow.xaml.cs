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
        private IGraphicsOperations graphicsOperations;
        public MainWindow() {
            InitializeComponent();
            intializeEvents();
            setGraphicsOperations(new GraphicsOperations());
        }

        public void setGraphicsOperations(GraphicsOperations _graphicsOperations) {
            this.graphicsOperations = _graphicsOperations;
        }

        public void intializeEvents(){
            InkCanvas.AddHandler(InkCanvas.MouseDownEvent, new MouseButtonEventHandler(OnInkCanvasMouseDown), true);
        }

        private void OnInkCanvasMouseDown(object sender, MouseEventArgs e){
            graphicsOperations.onInkCanvasMouseDown(e, this, InkCanvas);
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

        private void OnColorPick_cp(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color?> e) 
        {
            graphicsOperations.onColorPick_cp(InkCanvas, colorPicker);
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

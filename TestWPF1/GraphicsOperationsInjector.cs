using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestWPF1
{
    public class GraphicsOperationsInjector : Window
    {
        private MainWindow mainWindow;
        private GraphicsOperations graphicsOperations;
        public GraphicsOperationsInjector() {
            main();
        }

        public void main() {
            this.mainWindow = new MainWindow();
            this.graphicsOperations = new GraphicsOperations();
            mainWindow.InitializeComponent();
            mainWindow.intializeEvents();
        }
    }
}

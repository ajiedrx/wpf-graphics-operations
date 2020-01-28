using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestWPF1
{
    public class Main
    {
        private GraphicsOperations graphicsOperations;
        private MainWindow mainWindow;
        public void injectDependency() {
            this.graphicsOperations = new GraphicsOperations();
            this.mainWindow.setGraphicsOperations(graphicsOperations);
        }
    }
}

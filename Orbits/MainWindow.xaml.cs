using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point startPoint = new Point();
        Point currentPoint = new Point();
        public MainWindow()
        {
            InitializeComponent();
        }

        /**
         * Check whether the mouse has clicked on the canvas.
         */
        private void Canvas_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {           
                startPoint = e.GetPosition(this);
                Start.Content = startPoint;
            }
        }

        /**
         * Change the size of the circle based on how far the cursor has moved.
         */
        private void Canvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Ellipse body = new Ellipse();
                currentPoint = e.GetPosition(this);
                if (currentPoint.X > startPoint.X)
                {
                    body.Width = currentPoint.X - startPoint.X;
                    Current.Content = currentPoint;
                }
                else
                {
                    body.Width = startPoint.X - currentPoint.X;
                    Current.Content = currentPoint;
                }
                body.Fill = new SolidColorBrush(Colors.Yellow);
                Canvas.SetLeft(body, startPoint.X);
                Canvas.SetTop(body, startPoint.Y);

                DrawingCanvas.Children.Add(body);
            }
        }

        private Color getRandomColour()
        {
            Random randomNumber = new Random();
            return Color.FromArgb((byte)randomNumber.Next(255), (byte)randomNumber.Next(255), (byte)randomNumber.Next(255), (byte)randomNumber.Next(255));            
        }
    }
}

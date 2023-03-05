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
using System.Windows.Threading;

namespace Playground
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _animationsTimer = new DispatcherTimer();
        private bool goRightLeft = true;
        private bool goUpDown = true;

        private int count = 0;
        public MainWindow()
        {
            InitializeComponent();
            _animationsTimer.Interval = TimeSpan.FromMilliseconds(30);
            _animationsTimer.Tick += MovingBall;
        }

        private void MovingBall(object? sender, EventArgs e)
        {
            double x = Canvas.GetLeft(Ball);

            if (goRightLeft)
            {
                Canvas.SetLeft(Ball, x + 5);
            }
            else
            {
                Canvas.SetLeft(Ball, x - 5);
            }

            if(x >= FootballField.Width - Ball.ActualWidth)
            {
                goRightLeft = false;
            }
            else if(x <= 0)
            {
              goRightLeft = true;
            }


            double y = Canvas.GetTop(Ball);

            if (goUpDown)
            {
                Canvas.SetTop(Ball, y + 5);
            }
            else
            {
                Canvas.SetTop(Ball, y - 5);
            }

            if (y >= FootballField.ActualHeight - Ball.ActualHeight)
            {
                goUpDown = false;
            }
            else if (y <= 0)
            {
                goUpDown = true;
            }

        }

        private void StartStopButton_Click(object sender, RoutedEventArgs e)
        {
            if(_animationsTimer.IsEnabled)
            {
                _animationsTimer.Stop();
            }
            else
            {
                _animationsTimer.Start();
                count = 0;
                CountLabel.Content = $"{count} Clicks";
            }
        }

        private void Ball_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if(_animationsTimer.IsEnabled)
            {
                count += 1;
                CountLabel.Content = $"{count} Clicks";
            }
        }
    }
}

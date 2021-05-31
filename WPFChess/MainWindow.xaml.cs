using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace WPFChess
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ImageBrush brush;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void KingBtn_Click(object sender, RoutedEventArgs e)
        {
            brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/King.png"));
        }

        private void QueenBtn_Click(object sender, RoutedEventArgs e)
        {
            brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Queen.png"));
        }

        private void RookBtn_Click(object sender, RoutedEventArgs e)
        {
            brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Rook.png"));
        }

        private void BishopBtn_Click(object sender, RoutedEventArgs e)
        {
            brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Bishop.png"));
        }

        private void KnightBtn_Click(object sender, RoutedEventArgs e)
        {
            brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Knight.png"));
        }

        private void PawnBtn_Click(object sender, RoutedEventArgs e)
        {
            brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Pawn.png"));
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Field_Click(object sender, RoutedEventArgs e)
        {
            Control control = (Control)sender;
            Button button = (Button)sender;
            button.Content = new Rectangle { Fill = brush, Width=75, Height=75};
        }
    }
}
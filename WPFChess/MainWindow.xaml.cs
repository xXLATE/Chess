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
using WPFLibrary;

namespace WPFChess
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected ImageBrush brush;
        protected string SelectedFigure;
        protected List<Button> BoardRectangles;
        private Piece piece;

        public MainWindow()
        {
            InitializeComponent();
            BoardRectangles = new List<Button>();
        }

        private void KingBtn_Click(object sender, RoutedEventArgs e)
        {
            brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/King.png"));
            SelectedFigure = "K";
        }

        private void QueenBtn_Click(object sender, RoutedEventArgs e)
        {
            brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Queen.png"));
            SelectedFigure = "Q";
        }

        private void RookBtn_Click(object sender, RoutedEventArgs e)
        {
            brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Rook.png"));
            SelectedFigure = "R";
        }

        private void BishopBtn_Click(object sender, RoutedEventArgs e)
        {
            brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Bishop.png"));
            SelectedFigure = "B";
        }

        private void KnightBtn_Click(object sender, RoutedEventArgs e)
        {
            brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Knight.png"));
            SelectedFigure = "N";
        }

        private void PawnBtn_Click(object sender, RoutedEventArgs e)
        {
            brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Pawn.png"));
            SelectedFigure = "P";
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button boardBtn in BoardRectangles)
                boardBtn.Content = null;
            ErrorBox.Clear();
        }

        private void Field_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            string btnName = button.Name;
            var btnNames = btnName.Split('_');

            if (button.Content == null && SelectedFigure != "")
            {
                ClearBtn_Click(null, null);

                button.Content = new Rectangle { Fill = brush, Width = 75, Height = 75, Name = SelectedFigure };
                BoardRectangles.Add(button);
                                
                piece = PieceMaker.Make(SelectedFigure, Convert.ToInt32(btnNames[2]), Convert.ToInt32(btnNames[1]));

                SelectedFigure = "";
            }
            else if (piece.PreMove(Convert.ToInt32(btnNames[2]), Convert.ToInt32(btnNames[1])))
            {
                ClearBtn_Click(null, null);

                button.Content = new Rectangle { Fill = brush, Width = 75, Height = 75, Name = SelectedFigure };
                BoardRectangles.Add(button);
            }
            else if (!piece.PreMove(Convert.ToInt32(btnNames[2]), Convert.ToInt32(btnNames[1])))
            {
                ErrorBox.Text = "This move not by the rules!";
            }
        }
    }
}
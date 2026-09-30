using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Memoriajatek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> palyameretek = new List<string> { "4x4", "6x6", "8x8" };
        List<string> palyatipusok = new List<string> { "Számok", "Emojik", "Betűk" };
        List<string> szamok = new List<string> { };
        string meret;
        string tipus;
        public MainWindow()
        {
            InitializeComponent();
            lb_palyameret.ItemsSource = palyameretek;
            lb_tipus.ItemsSource = palyatipusok;
        }

        private void kivalasztott_meret(object sender, SelectionChangedEventArgs e)
        {
            meret = lb_palyameret.SelectedItem as string;
        }

        private void kivalasztott_tipus(object sender, SelectionChangedEventArgs e)
        {
            tipus = lb_tipus.SelectedItem as string;
        }

        private void btn_kezdes_Click(object sender, RoutedEventArgs e)
        {

            jatekter.Children.Clear();
            if (string.IsNullOrEmpty(meret) || string.IsNullOrEmpty(tipus))
            {
                MessageBox.Show("Kérlek válassz pályaméretet és típust!");
                return;
            }
            int meret_int = int.Parse(meret.Split('x')[0]);
            for (int i = 0; i < meret_int; i++)
            {
                jatekter.RowDefinitions.Add(new RowDefinition());
                jatekter.ColumnDefinitions.Add(new ColumnDefinition());

            }
            for (int i = 0; i < meret_int; i++)
            {
                for (int j = 0; j < meret_int; j++)
                {
                    Button btn = new Button();
                    btn.Content = "?";
                    btn.FontSize = 24;
                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);
                    jatekter.Children.Add(btn);
                }
            }
        }
    }
}
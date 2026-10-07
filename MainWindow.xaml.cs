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
        List<string> szamok = new List<string> { "1", "1", "2", "2", "3", "3", "4", "4", "5", "5", "6", "6", "7", "7", "8", "8", "9", "9", "10", "10", "11", "11", "12", "12", "13", "13", "14", "14", "15", "15", "16", "16", "17", "17", "18", "18", "19", "19", "20", "20", "21", "21", "22", "22", "23", "23", "24", "24", "25", "25", "26", "26", "27", "27", "28", "28", "29", "29", "30", "30", "31", "31", "32", "32" };
        List<string> emojik = new List<string> { "😀", "😀", "😂", "😂", "😍", "😍", "😎", "😎", "🤔", "🤔", "😴", "😴", "😡", "😡", "🥳", "🥳", "😇", "😇", "🤩", "🤩", "🥰", "🥰", "😘", "😘", "😜", "😜", "🤪", "🤪", "🤑", "🤑", "🤗", "🤗", "🙄", "🙄", "😏", "😏", "😢", "😢", "😭", "😭", "😱", "😱", "😤", "😤", "🤬", "🤬", "🤯", "🤯", "😳", "😳", "🥺", "🥺", "😶", "😶", "😐", "😐", "😑", "😑", "🙃", "🙃", "😅", "😅", "😂", "😂"};
        List<string> betuk = new List<string> { "A", "A", "B", "B", "C", "C", "D", "D", "E", "E", "F", "F", "G", "G", "H", "H", "I", "I", "J", "J", "K", "K", "L", "L", "M", "M", "N", "N", "O", "O", "P", "P", "Q", "Q", "R", "R", "S", "S", "T", "T", "U", "U", "V", "V", "W", "W", "X", "X", "Y", "Y", "Z", "Z", "AA", "AA", "AB", "AB", "AC", "AC", "AD", "AD", "AE", "AE", "AF", "AF", "AG", "AG", "AH", "AH"};
        List<Button> presedGombok = new List<Button>();
        List<string> presed = new List<string>();
        List<string> jatekban = new List<string>();
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
            jatekban.Clear();
            jatekter.Children.Clear();
            jatekter.RowDefinitions.Clear();
            jatekter.ColumnDefinitions.Clear();
            if (string.IsNullOrEmpty(meret) || string.IsNullOrEmpty(tipus))
            {
                MessageBox.Show("Kérlek válassz pályaméretet és típust!");
                return;
            }
            int meret_int = int.Parse(meret.Split('x')[0]);
            for (int i = 0; i < meret_int*meret_int; i++)
            {
                jatekban.Add(tipus == "Számok" ? szamok[i] : tipus == "Emojik" ? emojik[i] : betuk[i]);
            }
            jatekban = jatekban.Shuffle().ToList();
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
                    btn.Click += button_Click;
                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);
                    jatekter.Children.Add(btn);
                }
            }
        }
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (presedGombok.Count >= 2)
                return;
            if (presedGombok.Contains(btn))
                return;
            int index = jatekter.Children.IndexOf(btn);
            presedGombok.Add(btn);
            presed.Add(jatekban[index]);
            btn.Content = jatekban[index];
            if (presedGombok.Count == 2)
            {
                await Task.Delay(500);
                if (presed[0] != presed[1])
                {
                    presedGombok[0].Content = "?";
                    presedGombok[1].Content = "?";
                }
                presed.Clear();
                presedGombok.Clear();
            }
        }

    }
}
using GetCityData;
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

namespace GetCityDataWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            cityName.Clear();
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            GetData getCityData = new GetData(cityName.Text);
            string DataOrNull = getCityData.PromptCityData();
           
            cityName.Clear();
            
            cityName.Text = DataOrNull;
            
        }
    }
}
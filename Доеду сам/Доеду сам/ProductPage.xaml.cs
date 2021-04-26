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
using System.Windows.Shapes;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Win32;
namespace Доеду_сам
{
    /// <summary>
    /// Interaction logic for ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Window
    {
        string photoPath;
        public string num;
        public string Cos;
        public string Tit;
        public string Des;
        public string Pc;
             public string IA;
        public string img;
        public ProductPage(string id, string Cost, string Title, string Description, string ProductCre, string IsActive,string MainImagePath)
        {
            num = id;
            Cos = Cost;
            Tit = Title;
            Des = Description;
           Pc = ProductCre;
            IA = IsActive;
            img = MainImagePath;
            InitializeComponent();
            LoadOut();
        }
        private void LoadOut()
        {
            

            Id.Text = num;
            Titl.Text = Tit;
            Cst.Text = Cos;
            Desc.Text = Des;

            imgpath.Text = img;
            ProCre.Text = Pc;
            if (IA == "да" || IA == " да")
            {
                Active.IsChecked = true;
            }
            else
            {
                Active.IsChecked = false;
            }
            string img2 = img.Trim();
            string pho = "D:/ПавловИС1-32/NEWSESSIA/" + img2;

            Uri uri = new Uri(pho);
            ImageSource Img = new BitmapImage(uri);
            addImgae.Source = Img;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

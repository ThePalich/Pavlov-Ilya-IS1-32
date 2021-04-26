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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public event EventHandler MouseHover;

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void Evolve(string a, string b)
        {
            Connect.On(0);
            SqlCommand cmd = new SqlCommand(a, Connect.MyConnection);
            cmd.ExecuteNonQuery();
            SqlCommand cmdd = new SqlCommand(b, Connect.MyConnection);
            SqlDataAdapter dataadp = new SqlDataAdapter(cmdd);
            DataTable dt = new DataTable("Books");
            dataadp.Fill(dt);
           
            Connect.Off();
        }

        private void FirstEnter(object sender, MouseEventArgs e)
        {
           
            Firstwindow.Fill = Brushes.Gray;
            
            DataTable dt_product = Select("SELECT * FROM Product");
            for (int i = 0; i < dt_product.Rows.Count; i++)
            {
                Title1.Content = dt_product.Rows[i][1].ToString();
                Cost1.Content = dt_product.Rows[i][2].ToString();
                string img1 = dt_product.Rows[i][4].ToString();
                string img2 = img1.Trim();
                string pho = "D:/ПавловИС1-32/NEWSESSIA/" + img2;
                Uri uri = new Uri(pho);
                ImageSource Img = new BitmapImage(uri);
                Firstone.IsChecked = true;
                Product1.Source = Img;
            }
            //Product1.Source = "D:/Павлов ИС1-32/NEW SESSIA/Сессия 1/Товары автосервиса/0D60A8A4.jpg";
        }

        private void FirstLeave(object sender, MouseEventArgs e)
        {
            Firstwindow.Fill = Brushes.White;

            string Prodimg2 =  "D:/ПавловИС1-32/NEWSESSIA/Сессия 1/Товары автосервиса/0D30C4EE.jpg";
            
            Uri uri = new Uri(Prodimg2);
            ImageSource Img = new BitmapImage(uri);
            Firstone.IsChecked = false;
            Product1.Source = Img;
        }

        private void SecondEnter(object sender, MouseEventArgs e)
        {
            Firstwindow.Fill = Brushes.Gray;
            string Prodimg1 = "D:/ПавловИС1-32/NEWSESSIA/Товары автосервиса/D0D08F32.jpg";
            Uri uri = new Uri(Prodimg1);
            ImageSource Img = new BitmapImage(uri);
            Firstsecond.IsChecked = true;
            Product1.Source = Img;
        }
        private void SecondLeave(object sender, MouseEventArgs e)
        {
            Firstwindow.Fill = Brushes.White;

            string Prodimg2 = "D:/ПавловИС1-32/NEWSESSIA/Сессия 1/Товары автосервиса/0D30C4EE.jpg";

            Uri uri = new Uri(Prodimg2);
            ImageSource Img = new BitmapImage(uri);
            Firstone.IsChecked = false;
            Product1.Source = Img;
        }
        private void ThirdEnter(object sender, MouseEventArgs e)
        {
            Firstwindow.Fill = Brushes.Gray;
            string Prodimg1 = "D:/ПавловИС1-32/NEWSESSIA/Товары автосервиса/EFC05011.jpg";
            Uri uri = new Uri(Prodimg1);
            ImageSource Img = new BitmapImage(uri);
            FirstThird.IsChecked = true;
            Product1.Source = Img;
        }
        private void FourEnter(object sender, MouseEventArgs e)
        {
            Firstwindow.Fill = Brushes.Gray;
            string Prodimg1 = "D:/ПавловИС1-32/NEWSESSIA/Товары автосервиса/F200BC2F.jpg";
            Uri uri = new Uri(Prodimg1);
            ImageSource Img = new BitmapImage(uri);
            FirstFour.IsChecked = true;
            Product1.Source = Img;
        }
        public DataTable Select(string selectSQL)
        {
            DataTable dataTable = new DataTable("dataBase");

            SqlConnection sqlConnection = new SqlConnection("Data Source=vc-stud-mssql1;User ID=user31_db;Password=user31");
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = selectSQL;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        private void card_01_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Insert ins = new Insert();
            this.Close();
            ins.Show();
        }
    }
}

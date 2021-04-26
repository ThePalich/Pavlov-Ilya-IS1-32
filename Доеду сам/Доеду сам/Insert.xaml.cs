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
    /// Interaction logic for Insert.xaml
    /// </summary>
    public partial class Insert : Window
    {
        string photoPath;
        public Insert()
        {
            InitializeComponent();
            LoadOut();
        }
        private void LoadOut()
        {


            string query = "select ID,Title,Cost,Description,MainImagePath,Name,IsActive from Product inner join Manufacturer on Manufacturer.ManuID=Product.ManufacturerID ";
            Evolve(query, query);
            /*int counter = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[specified_column].Value.ToString() != "") counter++;
            }*/

        }
        int count;
        private void dataGridView2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = dataGridView2.SelectedValue as DataRowView;
            string id = row[0].ToString();
            string Cost = row[2].ToString();
            string Title = row[1].ToString();
            string Description = row[3].ToString();
           
            string ProductCre = row[5].ToString();
            string IsActive = row[6].ToString();
            string MainImagePath = row[4].ToString();

           
            count = Int32.Parse(id);
            try
            {
                if (sender != null)
                {
                    DataGrid grid = sender as DataGrid;
                    if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                    {

                        DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                        DataRowView dr = (DataRowView)dgr.Item;
                        id = dr[0].ToString();
                        Cost = dr[2].ToString();
                        Title = dr[1].ToString();
                        Description = dr[3].ToString();

                        ProductCre = dr[5].ToString();
                        IsActive = dr[6].ToString();
                        ProductPage prod = new ProductPage(id,Cost,Title,Description,ProductCre,IsActive,MainImagePath);
                        
                        prod.Show();
                        Id.Text = id;
                        Titl.Text = Title;
                        Cst.Text = Cost;
                        Desc.Text = Description;
                        
                        imgpath.Text = MainImagePath;
                        ProCre.Text = ProductCre;
                        if(IsActive == "да" || IsActive == " да")
                        {
                            Active.IsChecked = true;
                        }
                        else
                        {
                            Active.IsChecked = false;
                        }
                        string img2 = MainImagePath.Trim();
                        string pho = "D:/ПавловИС1-32/NEWSESSIA/" + img2;
                       
                        Uri uri = new Uri(pho);
                        ImageSource Img = new BitmapImage(uri);
                        addImgae.Source = Img;


                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
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
            dataGridView2.ItemsSource = dt.DefaultView;
            Connect.Off();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }

        private void IsAct_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void imgchange(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(fileDialog.FileName, UriKind.RelativeOrAbsolute);
            bi.EndInit();
            addImgae.Source = bi;
            photoPath = fileDialog.FileName;
        }

        private void dataGridView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

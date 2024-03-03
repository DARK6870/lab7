using System;
using System.Collections.Generic;
using System.Data;
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

namespace lab7
{
    /// <summary>
    /// Логика взаимодействия для MatrixWindow.xaml
    /// </summary>
    public partial class MatrixWindow : Window
    {
        public DataTable table { get; set; }
        public Matrix matrix { get; set; }

        public MatrixWindow()
        {
            InitializeComponent();

            table = new DataTable();
            matrix = new Matrix();
            matrix.data = new int[5, 5];

            FillData();
            DataColumn column = table.Columns.Add("Number", typeof(int));
            datagrid.RowBackground = Brushes.AliceBlue;
            SetData();
        }

        private void ShowMsg(string text)
        {
            result_label.Content = text;
        }

        private void FillData()
        {
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix.data[i, j] = rnd.Next(1, 15);
                }
            }
        }

        private void SetData()
        {
            table.Rows.Clear();
            for (int i = 0; i < matrix.data.GetLength(0); i++)
            {
                DataRow row = table.NewRow();
                for (int j = 0; j < matrix.data.GetLength(1); j++)
                {
                    row["Number"] = matrix.data[i, j];
                }
                table.Rows.Add(row);
            }

            datagrid.ItemsSource = table.DefaultView;
        }


        private void massiv_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Sum_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

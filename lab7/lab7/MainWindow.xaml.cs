using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Media;

namespace lab7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DataTable table { get; set; }
        public Massiv mas { get; set; }
        

        public MainWindow()
        {
            InitializeComponent();

            table = new DataTable();
            mas = new Massiv();
            mas.data = new int[15];
            
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
            for(int i = 0; i < 15; i++)
            {
                mas.data[i] = rnd.Next(1, 15);
            }
        }

        private void SetData()
        {
            table.Rows.Clear();
            foreach (var num in mas.data)
            {
                table.Rows.Add(num);
            }

            datagrid.ItemsSource = table.DefaultView;
        }

        private int[] GetDataFromTable()
        {
            var numbers = table.AsEnumerable().Select(row => row.Field<int>("number")).ToArray();
            return numbers;
        }


        private void Pr_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mas.data = GetDataFromTable();
                int res = mas.Pr();
                ShowMsg($"Произведение чисел равно: {res}");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void max_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mas.data = GetDataFromTable();
                int max = mas.Max();

                ShowMsg($"Максимальный элемент массива: {max}");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void odd_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mas.data = GetDataFromTable();
                int nechet = mas.Odd();
                int chet = mas.Even();
                ShowMsg($"Количество чётных: {chet}\nКоличесвто нечётнх: {nechet}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mas.data = GetDataFromTable();
                int number = Convert.ToInt32(numb_tb.Text);
                mas.DeleteElement(number);
                SetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void martrix_btn_Click(object sender, RoutedEventArgs e)
        {
                MatrixWindow f = new MatrixWindow();
            f.Show();
            this.Close();
        }
    }
}

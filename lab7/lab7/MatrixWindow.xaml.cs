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
    public partial class MatrixWindow : Window
    {
        public DataTable table { get; set; }

        public MatrixWindow()
        {
            InitializeComponent();

            table = new DataTable();
            datagrid.RowBackground = Brushes.AliceBlue;
            SetData();
        }

        private void ShowMsg(string text)
        {
            result_label.Content = text;
        }

        private void SetData()
        {
            table.Rows.Clear();

            table.Columns.Add("Index", typeof(int));

            for (int j = 1; j <= 4; j++)
            {
                table.Columns.Add($"{j}", typeof(int));
            }

            Random random = new Random();

            for (int i = 1; i <= 4; i++)
            {
                DataRow row = table.NewRow();
                row["Index"] = i;

                for (int j = 1; j <= 4; j++)
                {
                    row[$"{j}"] = random.Next(-99, 99);
                }

                table.Rows.Add(row);
            }

            datagrid.ItemsSource = table.DefaultView;
        }


        private void massiv_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow f = new MainWindow();
            f.Show();
            this.Close();
        }

        private void Sum_Click(object sender, RoutedEventArgs e)
        {
            int sum = 0;

            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    sum += (int)row[col];
                }
            }

            ShowMsg("Сумма: " + sum.ToString());
        }

        private void min_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder res = new StringBuilder();
            for (int columnIndex = 1; columnIndex < table.Columns.Count; columnIndex++)
            {
                int min = int.MaxValue;
                foreach (DataRow row in table.Rows)
                {
                    int currentValue = (int)row[columnIndex];
                    if (currentValue < min)
                    {
                        min = currentValue;
                    }
                }
                res.Append($"Column {columnIndex}: {min}\n");
            }
            ShowMsg(res.ToString());
        }

        private void count_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder res = new StringBuilder();
            for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
            {
                int zeroCount = 0;
                int p = 0, o = 0;
                for (int columnIndex = 0; columnIndex < table.Columns.Count; columnIndex++)
                {
                    int currentValue = (int)table.Rows[rowIndex][columnIndex];

                    if (currentValue == 0)
                    {
                        zeroCount++;
                    }
                    if (currentValue >= 0)
                    {
                        p++;
                    }
                    if (currentValue < 0)
                    {
                        o++;
                    }
                }

                res.Append($"{rowIndex + 1}: {zeroCount} | {o} | {p}\n");
            }

            ShowMsg(res.ToString());
        }

        private void deleteColumn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int colNum = Convert.ToInt32(col.Text);

                if (colNum >= 0 && colNum < table.Columns.Count)
                {
                    table.Columns.RemoveAt(colNum);

                    if (colNum < datagrid.Columns.Count)
                    {
                        datagrid.Columns.RemoveAt(colNum);
                    }

                    datagrid.ItemsSource = table.DefaultView;
                }
                else
                {
                    ShowMsg("Invalid column number. Please enter a valid column number to delete.");
                }
            }
            catch (FormatException)
            {
                ShowMsg("Please enter a valid number for the column.");
            }
            catch (Exception ex)
            {
                ShowMsg($"An error occurred: {ex.Message}");
            }
        }

    }
}

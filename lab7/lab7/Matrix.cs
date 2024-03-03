using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    public class Matrix
    {
        public int[,] data { get; set; }

        public int Sum()
        {
            int sum = 0;
            int rows = data.GetLength(0);
            int columns = data.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    sum += data[i, j];
                }
            }

            return sum;
        }

        public string MaxInRow()
        {
            int rows = data.GetLength(0);
            int columns = data.GetLength(1);

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                int maxInRow = int.MinValue;

                for (int j = 0; j < columns; j++)
                {
                    if (data[i, j] > maxInRow)
                    {
                        maxInRow = data[i, j];
                    }
                }

                result.Append($"Max in row {i + 1}: {maxInRow}\n");
            }

            return result.ToString();
        }

        public string ElemtnsInRow()
        {
            int rows = data.GetLength(0);
            int columns = data.GetLength(1);

            StringBuilder result = new StringBuilder();
            result.Append("zero count, elements >= 0, elements < 0\n");
            for (int i = 0; i < rows; i++)
            {
                int zerocount = 0;
                int p = 0;
                int ot = 0;

                for (int j = 0; j < columns; j++)
                {
                    if (data[i, j] == 0)
                    {
                        zerocount++;
                    }
                    if (data[i, j] < 0)
                    {
                        ot++;
                    }
                    if (data[i, j] >= 0)
                    {
                        p++;
                    }
                }

                result.Append($"Row {i + 1}: {zerocount} | {p} | {ot}\n");
            }

            return result.ToString();
        }

        public void RemoveColumn(int columnIndex)
        {
            int rows = data.GetLength(0);
            int columns = data.GetLength(1);

            if (columnIndex < 0 || columnIndex >= columns)
            {
                throw new ArgumentOutOfRangeException(nameof(columnIndex), "Недопустимый индекс столбца.");
            }

            int[,] newData = new int[rows, columns - 1];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0, newJ = 0; j < columns; j++)
                {
                    if (j != columnIndex)
                    {
                        newData[i, newJ] = data[i, j];
                        newJ++;
                    }
                }
            }

            data = newData;
        }

        public void AddRow(int[] newRow)
        {
            int rows = data.GetLength(0);
            int columns = data.GetLength(1);

            if (newRow.Length != columns)
            {
                throw new ArgumentException("Длина новой строки не соответствует количеству столбцов в матрице.");
            }

            int[,] newData = new int[rows + 1, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    newData[i, j] = data[i, j];
                }
            }

            for (int j = 0; j < columns; j++)
            {
                newData[rows, j] = newRow[j];
            }

            data = newData;
        }

        public void OrderColumnsAscending()
        {
            OrderColumns(true);
        }

        public void OrderColumnsDescending()
        {
            OrderColumns(false);
        }

        private void OrderColumns(bool ascending)
        {
            if (data == null)
            {
                throw new InvalidOperationException("Массив не инициализирован.");
            }

            int rows = data.GetLength(0);
            int columns = data.GetLength(1);

            for (int j = 0; j < columns; j++)
            {
                int[] columnData = new int[rows];

                for (int i = 0; i < rows; i++)
                {
                    columnData[i] = data[i, j];
                }

                if (ascending)
                {
                    Array.Sort(columnData);
                }
                else
                {
                    Array.Sort(columnData, (a, b) => b.CompareTo(a));
                }

                for (int i = 0; i < rows; i++)
                {
                    data[i, j] = columnData[i];
                }
            }
        }
    }
}

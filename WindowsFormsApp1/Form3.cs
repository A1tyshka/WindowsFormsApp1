using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        private void Clear_MatrText()
        {
            // Обнуление ячеек MatrText
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    MatrText[i, j].Text = "0";
        }
        const int MaxN = 10; // максимально допустимая размерность матрицы
        int n = 3; // текущая размерность матрицы
        TextBox[,] MatrText = null; // матрица элементов типа

        double[,] Matr1 = new double[MaxN, MaxN]; // матрица 1 чисел с
         
        double[,] Matr2 = new double[MaxN, MaxN]; // матрица 2 чисел с
     
        double[,] Matr3 = new double[MaxN, MaxN]; // матрица результатов
        bool f1; // флажок, который указывает о вводе данных в матрицу
   
        bool f2; // флажок, который указывает о вводе данных в матрицу
  
        int dx = 40, dy = 20; // ширина и высота ячейки в MatrText[,]
        Form4
        form4 = null; // экземпляр (объект) класса формы Form2
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 1. Чтение размерности матрицы
            if (textBox1.Text == "") return;
            n = int.Parse(textBox1.Text);
            // 2. Обнулить ячейки MatrText Clear_MatrText();
            // 3. Настройка свойств ячеек матрицы MatrText
            // с привязкой к значению n и форме Form2
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // 3.1. Порядок табуляции
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    // 3.2. Сделать ячейку видимой
                    MatrText[i, j].Visible = true;
                }
            // 4. Корректировка размеров формы
            form4.Width = 10 + n * dx + 20;
            form4.Height = 10 + n * dy + form4.button1.Height + 50;
            // 5. Корректировка позиции и размеров кнопки на форме Form2
            form4.button1.Left = 10;
            form4.button1.Top = 10 + n * dy + 10;
            form4.button1.Width = form4.Width - 30;
            // 6. Вызов формы Form2
            if (form4.ShowDialog() == DialogResult.OK)
            {
                // 7. Перенос строк из формы Form2 в матрицу Matr2
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        Matr2[i, j] = Double.Parse(MatrText[i, j].Text);
                // 8. Матрица Matr2 сформирована
                f2 = true;
                label3.Text = "true";
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // І. Инициализация элементов управления и внутренних переменных
            textBox1.Text = "";
            f1 = f2 = false; // матрицы еще не заполнены
            label2.Text = "false";
            label3.Text = "false";
            // ІІ. Выделение памяти и настройка MatrText
            int i, j;
            // 1. Выделение памяти для формы Form2
            form4 = new Form4();
            // 2. Выделение памяти под самую матрицу
            MatrText = new TextBox[MaxN, MaxN];
            // 3. Выделение памяти для каждой ячейки матрицы и ее настройка
            for (i = 0; i < MaxN; i++)
                for (j = 0; j < MaxN; j++)
                {
                    // 3.1. Выделить память
                    MatrText[i, j] = new TextBox();
                    // 3.2. Обнулить эту ячейку
                    MatrText[i, j].Text = "0";
                    // 3.3. Установить позицию ячейки в форме Form2
                    MatrText[i, j].Location = new System.Drawing.Point(10 + i *
                    dx, 10 + j * dy);
                    // 3.4. Установить размер ячейки
                    MatrText[i, j].Size = new System.Drawing.Size(dx, dy);
                    // 3.5. Пока что спрятать ячейку
                    MatrText[i, j].Visible = false;
                    // 3.6. Добавить MatrText[i,j] в форму form2
                    form4.Controls.Add(MatrText[i, j]);
                }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            int nn;
            nn = Int16.Parse(textBox1.Text);
            if (nn != n)
            {
                f1 = f2 = false;
                label2.Text = "false";
                label3.Text = "false";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 1. Проверка, введены ли данные в обеих матрицах
            if (!((f1 == true) && (f2 == true))) return;
            // 2. Вычисление произведения матриц. Результат в Matr3
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Matr3[j, i] = 0;
                    for (int k = 0; k < n; k++)
                        Matr3[j, i] = Matr3[j, i] + Matr1[k, i] * Matr2[j, k];
                }
            // 3. Внесение данных в MatrText
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // 3.1. Порядок табуляции
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    // 3.2. Перевести число в строку
                    MatrText[i, j].Text = Matr3[i, j].ToString();
                }
            // 4. Вывод формы
            form4.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileStream fw = null;
            string msg;
            byte[] msgByte = null; // байтовый массив
                                   // 1. Открыть файл для записи
            fw = new FileStream("Res_Matr.txt", FileMode.Create);
            // 2. Запись матрицы результата в файл

            // 2.1. Сначала записать число элементов матрицы Matr3
            msg = n.ToString() + "\r\n";
            // перевод строки msg в байтовый массив msgByte
            msgByte = Encoding.Default.GetBytes(msg);
            // запись массива msgByte в файл
            fw.Write(msgByte, 0, msgByte.Length);
            // 2.2. Теперь записать саму матрицу
            msg = "";
            for (int i = 0; i < n; i++)
            {
                // формируем строку msg из элементов матрицы
                for (int j = 0; j < n; j++)
                    msg = msg + Matr3[i, j].ToString() + " ";
                msg = msg + "\r\n";
                // добавить перевод строки
            }
            // 3. Перевод строки msg в байтовый массив msgByte
            msgByte = Encoding.Default.GetBytes(msg);
            // 4. запись строк матрицы в файл
            fw.Write(msgByte, 0, msgByte.Length);
            // 5. Закрыть файл
            if (fw != null) fw.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // 1. Проверка, введены ли данные в обеих матрицах
            if (!((f1 == true) && (f2 == true))) return;
            // 2. Вычисление произведения матриц. Результат в Matr3
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Matr3[j, i] = 0;
                    for (int k = 0; k < n; k++)
                        Matr3[j, i] = Matr1[j, i] + Matr2[j, i];
                }
            // 3. Внесение данных в MatrText
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // 3.1. Порядок табуляции
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    // 3.2. Перевести число в строку
                    MatrText[i, j].Text = Matr3[i, j].ToString();
                }
            // 4. Вывод формы
            form4.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // 1. Проверка, введены ли данные в обеих матрицах
            if (!((f1 == true) && (f2 == true))) return;
            // 2. Вычисление произведения матриц. Результат в Matr3
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Matr3[j, i] = 0;
                    for (int k = 0; k < n; k++)
                        Matr3[j, i] = Matr1[j, i] - Matr2[j, i];
                }
            // 3. Внесение данных в MatrText
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // 3.1. Порядок табуляции
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    // 3.2. Перевести число в строку
                    MatrText[i, j].Text = Matr3[i, j].ToString();
                }
            // 4. Вывод формы
            form4.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // 1. Проверка, введены ли данные в обеих матрицах
            if (!((f1 == true) && (f2 == true))) return;
            // 2. Вычисление произведения матриц. Результат в Matr3
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    {
                        Console.WriteLine("Введите количество NxM элементов матрицы sample: ");
                        int N = 0;
                        int M = 0;

                        string str = Console.ReadLine();
                        string stl = Console.ReadLine();
                        N = int.Parse(str);
                        M = int.Parse(stl);


                        Console.WriteLine("Исходная матрица: ");
                        Console.WriteLine();
                        int[,] sample = new int[N, M];
                        Random rnd = new Random();

                        for (int o = 0; o < N; o++)
                        {
                            for (int k = 0; k < M; k++)
                            {
                                sample[o, k] = rnd.Next(1, 100); // заполнение матрицы случайными числами
                                Console.Write(sample[o, k] + " \t ");
                            }
                            Console.WriteLine();
                        }
                        int[,] trans = new int[M, N];
                        Console.WriteLine();
                        Console.WriteLine("Транспонированная матрица: ");
                        Console.WriteLine();
                        for (int o = 0; o < M; o++)
                        {
                            for (int k = 0; k < N; k++)
                            {
                                trans[o, k] = sample[k, o];
                                Console.Write(trans[o, k] + " \t ");
                            }
                            Console.WriteLine();
                        }
                        Console.ReadLine();
                    }
                }
            // 3. Внесение данных в MatrText
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // 3.1. Порядок табуляции
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    // 3.2. Перевести число в строку
                    MatrText[i, j].Text = Matr3[i, j].ToString();
                }
            // 4. Вывод формы
            form4.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Чтение размерности матрицы
            if (textBox1.Text == "") return;
            n = int.Parse(textBox1.Text);
            // 2. Обнуление ячейки MatrText
            Clear_MatrText();
            // 3. Настройка свойств ячеек матрицы MatrText
            // с привязкой к значению n и форме Form2
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // 3.1. Порядок табуляции
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    // 3.2. Сделать ячейку видимой
                    MatrText[i, j].Visible = true;
                }
            // 4. Корректировка размеров формы
            form4.Width = 10 + n * dx + 20;
            form4.Height = 10 + n * dy + form4.button1.Height + 50;
            // 5. Корректировка позиции и размеров кнопки на форме Form2
            form4.button1.Left = 10;
            form4.button1.Top = 10 + n * dy + 10;
            form4.button1.Width = form4.Width - 30;
            // 6. Вызов формы Form2
            if (form4.ShowDialog() == DialogResult.OK)
            {
                // 7. Перенос строк из формы Form2 в матрицу Matr1
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        if (MatrText[i, j].Text != "")
                            Matr1[i, j] = Double.Parse(MatrText[i, j].Text);
                        else
                            Matr1[i, j] = 0;
                // 8. Данные в матрицу Matr1 внесены
                f1 = true;
                label2.Text = "true";
            }
        }

        

    }
}

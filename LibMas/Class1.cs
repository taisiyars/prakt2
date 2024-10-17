using Microsoft.Win32;
using System.IO;

namespace LibMas
{
    public class MasFunction
    {
        /// <summary>
        /// Заполнение массива
        /// </summary>
        /// <param name="mas">Массив</param>
        /// <param name="column">Колличество столбцов, значений</param>
        public static void InitMas(out int[] mas, int column)
        {
            Random Rnd = new Random();
            mas = new Int32[column];
            for (int i = 0; i < column; i++) mas[i] = Rnd.Next(1, 5);

        }

        /// <summary>
        /// Очистка массива
        /// </summary>
        /// <param name="mas">Массив</param>
        public static void ClearMas(ref int[] mas)
        {
            mas = null;
        }

        /// <summary>
        /// Сохранение массива
        /// </summary>
        /// <param name="mas">Массив</param>
        public static void SaveMas(int[] mas)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";

            if (save.ShowDialog() == true)
            {
                StreamWriter file = new StreamWriter(save.FileName);

                file.WriteLine(mas.Length);

                for (int i = 0; i < mas.Length; i++)
                {
                    file.WriteLine(mas[i]);
                }
                file.Close();
            }
        }

        /// <summary>
        /// Открытие сохраненного массива
        /// </summary>
        /// <param name="mas">Массив</param>
        public static void OpenMas(ref int[] mas)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";

            if (open.ShowDialog() == true)
            {
                StreamReader file = new StreamReader(open.FileName);

                int len = Convert.ToInt32(file.ReadLine());
                mas = new Int32[len];
                for (int i = 0; i < mas.Length; i++)
                {
                    mas[i] = Convert.ToInt32(file.ReadLine());
                }
                file.Close();
            }
        }
    }

}

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
using практическая2;
using LibMas;
using Lib_3;


namespace практическая2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Массив как глобальный элемент
        int[] mas;
        
        //Кнопка информации
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ввести n целых чисел. Найти разницу чисел. Результат вывести на экран.\nРазработчик ГришинаТ.С. ИСП-31");
        }

        //Кнопка выхода
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Кнопка создания и заполнения массива
        private void miFill_Click(object sender, RoutedEventArgs e)
        {
            int value1;
            bool f;
            
            f = Int32.TryParse(tbColumnCount.Text, out value1);
            if (f == true && value1 > 0)
            {
                MasFunction.InitMas(out mas, value1);
                dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
                
              
            }
            else MessageBox.Show("Введите корректные значения");
            tbColumnCount.Clear();
            tbRez.Clear();
        }

        //Кнопка создания массива
        private void miCreate_Click(object sender, RoutedEventArgs e)
        {
            int value;
            bool f;
            f = Int32.TryParse(tbColumnCount.Text, out value);
            if (f == true && value > 0)
            {
                mas = new int[value];
                dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }
            else MessageBox.Show("Введите корректные значания");
            tbColumnCount.Clear();
            tbRez.Clear();
        }

        //Кнопка рассчета
        private void miCalc_Click(object sender, RoutedEventArgs e)
        {
            if (mas != null)
            {
                tbRez.Text = Convert.ToString(Raschet.Differrence(mas));
            }
            else MessageBox.Show("Введите значаения");
        }

        //Кнопка очистки
        private void miClear_CLick(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
            MasFunction.ClearMas(ref mas);
            tbColumnCount.Clear();
            tbRez.Clear();
            
        }

        //Проверка кореектности значений вводимых значений 
        private void dataGrid_CellEdithing(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Column is DataGridTextColumn)
            {
                TextBox textBox = e.EditingElement as TextBox;
                if (textBox != null)
                {
                    if (int.TryParse(textBox.Text, out int value))
                    {
                        int indexColumn = e.Column.DisplayIndex;
                        mas[indexColumn] = Convert.ToInt32(value);
                    }
                    else MessageBox.Show("Введите корректное значение!", "Ошибка:");
                }
            }
        }

        //Кнопка сохранения
        private void miSave_Click(object sender, RoutedEventArgs e)
        {
            MasFunction.SaveMas(mas);
        }

        //Кнопка открытия
        private void miOpen_Click(object sender, RoutedEventArgs e)
        {
            MasFunction.OpenMas(ref mas);
            dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
        }
    }
}
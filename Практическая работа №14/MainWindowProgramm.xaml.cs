using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace Практическая_работа__14
{
    /// <summary>
    /// Логика взаимодействия для MainWindowProgramm.xaml
    /// </summary>
    public partial class MainWindowProgramm : Window
    {
        public MainWindowProgramm()
        {
            InitializeComponent();
        }

        private DispatcherTimer timer;

        /// <summary>
        /// Модуль запускающий таймер при открытии главного окна программы который будет показывать дату и время
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 0);
            timer.IsEnabled = true;
        }

        /// <summary>
        /// Модуль, реализующий таймер для обновления времени и даты в главном окне
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            time.Text = d.ToString("HH:mm:ss");
            data.Text = d.ToString("dd.MM.yyyy");
        }

        MessageBoxResult closeProg;

        /// <summary>
        /// Модуль выводящий сообщение при закрытии главного окна программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_CLosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            closeProg = MessageBox.Show("Вы дейстительно хотите закрыть программу?", "Выход из программы:", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (closeProg == MessageBoxResult.No)
                e.Cancel = true;
        }

        /// <summary>
        /// Создание класса для передачи данных количества строк и столбцов, иными слова размера таблицы
        /// </summary>
        public static class data1
        {
            public static int ColumnCount;
            public static int RowCount;
            public static bool SaveSettinhsTable;
        }

        /// <summary>
        /// Метод для открытия окна для указания размера таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openSettingsWindow_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Owner = this;
            settingsWindow.Show();
            
            tbNumCol.Text = data1.ColumnCount.ToString();
            tbNumRow.Text = data1.RowCount.ToString();
            data1.SaveSettinhsTable = false;

            this.IsEnabled = false;
            settingsWindow.Closed += (s, args) => this.IsEnabled = true;
        }

        /// <summary>
        /// Метод который происходит при активации окна для заполнения данных о количестве строк и столбцов в таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Activated(object sender, EventArgs e)
        {
            if(data1.SaveSettinhsTable == true)
            {
                tbNumCol.Text = data1.ColumnCount.ToString();
                tbNumRow.Text = data1.RowCount.ToString();

                StreamWriter writer = new StreamWriter("config.ini");
                writer.WriteLine(data1.ColumnCount);
                writer.WriteLine(data1.RowCount);
                writer.Close();

                data1.SaveSettinhsTable = true;
            }
        }

        /// <summary>
        /// Метод для чтения данных из файла config.ini
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fillSettingsReadFile(object sender, RoutedEventArgs e)
        {
            if (File.Exists("config.ini"))
            {
                StreamWriter reader = new StreamWriter("config.ini");
                reader.WriteLine(data1.ColumnCount);
                reader.WriteLine(data1.RowCount);
                reader.Close();

                tbNumCol.Text = data1.ColumnCount.ToString();
                tbNumRow.Text = data1.RowCount.ToString();
            }
            else MessageBox.Show("Файл не найден", "Ошибка:", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Метод для закрытия программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Метод для отображения информации о задании для разработки программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfoProga_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дана целочисленная матрица \nразмера M * N. Найти количе-\nmство ее столбцов, " +
                "все элеме-\nнты которых различны.", "О программе: ", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Метод для отображения информации о создателе программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfoCreator_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Жаров Артём Андреевич \nСтудент группы ИСП-31", "О создателе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        int indexColumn;
        int indexRow;
        int[,] matr;
        int randMax;
        bool openfile;

        /// <summary>
        /// Метод для автоматического создания матрицы со случайным количеством строк, столбцов и диапозоном значений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.Visibility == Visibility.Hidden)
            {
                dataGrid.Visibility = Visibility.Visible;
                hideTable.IsEnabled = true;
                showTable.IsEnabled = false;
                MenuHideTable.IsEnabled = true;
                MenuShowTable.IsEnabled = false;
            }

            tbRez.Clear();

            LibMatr create = new LibMatr();
            matr = create.CreateTable(dataGrid, indexColumn, indexRow);
            dataGrid.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;

            razmerTable.Text = $"{matr.GetLength(0)}*{matr.GetLength(1)}";
            razmerTable.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Метод для создания пустой матрицы(все значения в таблице "0")
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreatePolzovatel_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(tbNumCol.Text, out indexColumn) && Int32.TryParse(tbNumRow.Text, out indexRow))
            {
                tbRez.Clear();

                indexColumn = Convert.ToInt32(tbNumCol.Text);
                indexRow = Convert.ToInt32(tbNumRow.Text);

                if (dataGrid.Visibility == Visibility.Hidden)
                {
                    dataGrid.Visibility = Visibility.Visible;
                    hideTable.IsEnabled = true;
                    showTable.IsEnabled = false;
                    MenuHideTable.IsEnabled = true;
                    MenuShowTable.IsEnabled = false;
                }

                LibMatr createPolz = new LibMatr();
                matr = createPolz.CreatePolzovatel(dataGrid, indexColumn, indexRow);
                dataGrid.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;

                razmerTable.Text = $"{matr.GetLength(0)}*{matr.GetLength(1)}";
                razmerTable.Visibility = Visibility.Visible;
            }
            else if (File.Exists("config.ini"))
            {
                tbNumCol.Text = data1.ColumnCount.ToString();
                tbNumRow.Text = data1.RowCount.ToString();
            }
            else MessageBox.Show("Введены некоррентные значения!", "Ошибка:", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Метод для заполнения матрицы случайными значениями
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFill_Click(object sender, RoutedEventArgs e)
        {
            if (matr != null && Int32.TryParse(tbDiapozon.Text, out randMax))
            {
                tbRez.Clear();

                randMax = Convert.ToInt32(tbDiapozon.Text);

                if (dataGrid.Visibility == Visibility.Hidden)
                {
                    dataGrid.Visibility = Visibility.Visible;
                    hideTable.IsEnabled = true;
                    showTable.IsEnabled = false;
                    MenuHideTable.IsEnabled = true;
                    MenuShowTable.IsEnabled = false;
                }

                LibMatr fill = new LibMatr();
                matr = fill.FillTable(dataGrid, indexColumn, indexRow, randMax);
                dataGrid.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;

                razmerTable.Text = $"{matr.GetLength(0)}*{matr.GetLength(1)}";
                razmerTable.Visibility = Visibility.Visible;
            }
            else MessageBox.Show("   Вы не создали таблицу,или \nввели некорректные значения!", "Ошибка:", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Метод для проверки корректности введенных данных в таблицу а так же отображения номера выделенной
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int indexRow = e.Row.GetIndex();
            int indexColumn = e.Column.DisplayIndex;
            if (Int32.TryParse(((TextBox)e.EditingElement).Text, out int newValue))
                matr[indexRow, indexColumn] = newValue; tbRez.Clear();
        }

        /// <summary>
        /// Метод для нахождения номера выделенной, двойным кликом мышки, ячейки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var grid = sender as DataGrid;
            if (grid != null)
            {
                DataGridRow row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem);
                if (row != null && grid.CurrentColumn != null)
                {
                    int indexRow = grid.ItemContainerGenerator.IndexFromContainer(row);
                    int indexColumn = grid.CurrentColumn.DisplayIndex;

                    numberCell.Visibility = Visibility.Visible;
                    numberCell.Text = $"{indexRow + 1}*{indexColumn + 1}";
                }
            }
        }

        /// <summary>
        /// Метод для подсчёта количества столбцов все элементы в которых различны
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            tbRez.Clear();

            if (dataGrid.ItemsSource != null)
            {
                int uniqueColumnsCount = VisualArray.CalcFunction(matr);
                tbRez.Text = Convert.ToString(uniqueColumnsCount);
            }
            else MessageBox.Show("Таблицы не существует.\nСоздайте её!", "Ошибка:", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Метод для очистки всех результатов в программе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.Visibility == Visibility.Visible)
            {
                dataGrid.Visibility = Visibility.Hidden;
                hideTable.IsEnabled = false;
                showTable.IsEnabled = true;
                MenuHideTable.IsEnabled = false;
                MenuShowTable.IsEnabled = true;
            }

            data1.SaveSettinhsTable = false;

            LibMatr clear = new LibMatr();
            clear.AllClear(dataGrid, out matr, tbNumCol, tbNumRow, tbDiapozon, tbRez);

            razmerTable.Visibility = Visibility.Hidden;
            numberCell.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Метод для сохранения таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (matr != null)
            {
                LibMatr SaveFileManager = new LibMatr();
                SaveFileManager.SaveDataToFile(matr);
            }
            else MessageBox.Show("Нет данных для сохранения.\nВведите значения!", "Ошибка:", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Метод для открытия уже сохранённой таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            LibMatr OpenFileMenedger = new LibMatr();
            OpenFileMenedger.OpenDataToFile(out matr, out openfile);

            if (openfile == true)
            {
                if (dataGrid.Visibility == Visibility.Hidden)
                {
                    dataGrid.Visibility = Visibility.Visible;
                    hideTable.IsEnabled = true;
                    showTable.IsEnabled = false;
                    MenuHideTable.IsEnabled = true;
                    MenuShowTable.IsEnabled = false;
                }

                dataGrid.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
            }
            else matr = null;
        }

        /// <summary>
        /// Метод для показания таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowTable_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.Visibility == Visibility.Hidden)
            {
                dataGrid.Visibility = Visibility.Visible;
                hideTable.IsEnabled = true;
                showTable.IsEnabled = false;
                MenuHideTable.IsEnabled = true;
                MenuShowTable.IsEnabled = false;
            }
        }

        /// <summary>
        /// Метод для скрытия таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHideTable_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.Visibility == Visibility.Visible)
            {
                dataGrid.Visibility = Visibility.Hidden;
                hideTable.IsEnabled = false;
                showTable.IsEnabled = true;
                MenuHideTable.IsEnabled = false;
                MenuShowTable.IsEnabled = true;
            }
        }
    }
}
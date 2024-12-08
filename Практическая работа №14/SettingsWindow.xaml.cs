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
using static Практическая_работа__14.MainWindowProgramm;

namespace Практическая_работа__14
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            tbNumCol.Focus();
            if (data1.SaveSettinhsTable != false)
            {
                tbNumCol.Text = data1.ColumnCount.ToString();
                tbNumRow.Text = data1.RowCount.ToString();
            }
        }

        private void SaveSettingsTable_Click(object sender, RoutedEventArgs e)
        {
            int value;
            if(Int32.TryParse(tbNumCol.Text, out value))
            {
                data1.ColumnCount = value;
            }
            else
            {
                MessageBox.Show("Ошибка в номере столбца!", "Ошибка:", MessageBoxButton.OK, MessageBoxImage.Error);
                tbNumCol.Focus();
                return;
            }

            if(Int32.TryParse(tbNumRow.Text,out value))
            {
                data1.RowCount = value;
            }
            else
            {
                MessageBox.Show("Ошибка в номере строки!", "Ошибка:", MessageBoxButton.OK, MessageBoxImage.Error);
                tbNumRow.Focus();
                return;
            }

            data1.SaveSettinhsTable = true;
            
            Close();
        }

        private void CloseWindowSettingsWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

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
using System.Windows.Threading;

namespace Практическая_работа__14
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

        private DispatcherTimer timer;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 0);
            timer.IsEnabled = true;
        }

        MessageBoxResult ErrorVvodPassword;

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (firstNumberPassword.Text != "" && secondNumberPassword.Text != "" && thirdNumberPassword.Text != "")
            {
                if (firstNumberPassword.Text == "1" && secondNumberPassword.Text == "2" && thirdNumberPassword.Text == "3")
                {
                    timer.IsEnabled = false;
                    MainWindowProgramm mainWindowProgramm = new MainWindowProgramm();
                    mainWindowProgramm.Show();
                    this.Close();
                }
                else
                {
                    timer.IsEnabled = false;
                    ErrorVvodPassword = MessageBox.Show("Вы ввели неправильный пароль! \nОчистить пароль, или закрыть программу?", "Ошибка:", MessageBoxButton.YesNo, MessageBoxImage.Error);
                    if (ErrorVvodPassword == MessageBoxResult.Yes)
                    {
                        firstNumberPassword.Text = "";
                        secondNumberPassword.Text = "";
                        thirdNumberPassword.Text = "";

                        first = false;
                        second = false;
                        third = false;

                        timer.IsEnabled = true;
                    }
                    else
                    {
                        timer.IsEnabled = false;
                        this.Close();
                    }
                }
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            firstNumberPassword.Focus();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        bool first;
        bool second;
        bool third;

        private void numberOne_Click(object sender, RoutedEventArgs e)
        {
            if (first == false && second == false && third == false)
            {
                first = true;
                firstNumberPassword.Text = "1";
                secondNumberPassword.Focus();
            }
            else if (first == true && second == false && third == false)
            {
                second = true;
                secondNumberPassword.Text = "1";
                thirdNumberPassword.Focus();
            }
            else if (first == true && second == true && third == false)
            {
                third = true;
                thirdNumberPassword.Text = "1";
            }
        }

        private void numberTwo_Click(object sender, RoutedEventArgs e)
        {
            if (first == false && second == false && third == false)
            {
                first = true;
                firstNumberPassword.Text = "2";
                secondNumberPassword.Focus();
            }
            else if (first == true && second == false && third == false)
            {
                second = true;
                secondNumberPassword.Text = "2";
                thirdNumberPassword.Focus();
            }
            else if (first == true && second == true && third == false)
            {
                third = true;
                thirdNumberPassword.Text = "2";
            }
        }

        private void numberTree_Click(object sender, RoutedEventArgs e)
        {
            if (first == false && second == false && third == false)
            {
                first = true;
                firstNumberPassword.Text = "3";
                secondNumberPassword.Focus();
            }
            else if (first == true && second == false && third == false)
            {
                second = true;
                secondNumberPassword.Text = "3";
                thirdNumberPassword.Focus();
            }
            else if (first == true && second == true && third == false)
            {
                third = true;
                thirdNumberPassword.Text = "3";
            }
        }

        private void numberFour_Click(object sender, RoutedEventArgs e)
        {
            if (first == false && second == false && third == false)
            {
                first = true;
                firstNumberPassword.Text = "4";
                secondNumberPassword.Focus();
            }
            else if (first == true && second == false && third == false)
            {
                second = true;
                secondNumberPassword.Text = "4";
                thirdNumberPassword.Focus();
            }
            else if (first == true && second == true && third == false)
            {
                third = true;
                thirdNumberPassword.Text = "4";
            }
        }

        private void numberFive_Click(object sender, RoutedEventArgs e)
        {
            if (first == false && second == false && third == false)
            {
                first = true;
                firstNumberPassword.Text = "5";
                secondNumberPassword.Focus();
            }
            else if (first == true && second == false && third == false)
            {
                second = true;
                secondNumberPassword.Text = "5";
                thirdNumberPassword.Focus();
            }
            else if (first == true && second == true && third == false)
            {
                third = true;
                thirdNumberPassword.Text = "5";
            }
        }

        private void numberSix_Click(object sender, RoutedEventArgs e)
        {
            if (first == false && second == false && third == false)
            {
                first = true;
                firstNumberPassword.Text = "6";
                secondNumberPassword.Focus();
            }
            else if (first == true && second == false && third == false)
            {
                second = true;
                secondNumberPassword.Text = "6";
                thirdNumberPassword.Focus();
            }
            else if (first == true && second == true && third == false)
            {
                third = true;
                thirdNumberPassword.Text = "6";
            }
        }

        private void numberSeven_Click(object sender, RoutedEventArgs e)
        {
            if (first == false && second == false && third == false)
            {
                first = true;
                firstNumberPassword.Text = "7";
                secondNumberPassword.Focus();
            }
            else if (first == true && second == false && third == false)
            {
                second = true;
                secondNumberPassword.Text = "7";
                thirdNumberPassword.Focus();
            }
            else if (first == true && second == true && third == false)
            {
                third = true;
                thirdNumberPassword.Text = "7";
            }
        }

        private void numberEight_Click(object sender, RoutedEventArgs e)
        {
            if (first == false && second == false && third == false)
            {
                first = true;
                firstNumberPassword.Text = "8";
                secondNumberPassword.Focus();
            }
            else if (first == true && second == false && third == false)
            {
                second = true;
                secondNumberPassword.Text = "8";
                thirdNumberPassword.Focus();
            }
            else if (first == true && second == true && third == false)
            {
                third = true;
                thirdNumberPassword.Text = "8";
            }
        }

        private void numberNine_Click(object sender, RoutedEventArgs e)
        {
            if (first == false && second == false && third == false)
            {
                first = true;
                firstNumberPassword.Text = "9";
                secondNumberPassword.Focus();
            }
            else if (first == true && second == false && third == false)
            {
                second = true;
                secondNumberPassword.Text = "9";
                thirdNumberPassword.Focus();
            }
            else if (first == true && second == true && third == false)
            {
                third = true;
                thirdNumberPassword.Text = "9";
            }
        }

        private void numberNull_Click(object sender, RoutedEventArgs e)
        {
            if (first == false && second == false && third == false)
            {
                first = true;
                firstNumberPassword.Text = "0";
                secondNumberPassword.Focus();
            }
            else if (first == true && second == false && third == false)
            {
                second = true;
                secondNumberPassword.Text = "0";
                thirdNumberPassword.Focus();
            }
            else if (first == true && second == true && third == false)
            {
                third = true;
                thirdNumberPassword.Text = "0";
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (first == true && second == false && third == false)
            {
                first = false;
                firstNumberPassword.Clear();
                firstNumberPassword.Focus();
            }
            else if (first == true && second == true && third == false)
            {
                second = false;
                secondNumberPassword.Clear();
                firstNumberPassword.Focus();
            }
            else if (first == true && second == true && third == true)
            {
                third = false;
                thirdNumberPassword.Clear();
                secondNumberPassword.Focus();
            }
        }
    }
}
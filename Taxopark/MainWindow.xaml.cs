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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Taxopark
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
        StreamReader reader;
        const string path = @"C:\Users\student\Documents\Vasin_practika\Taxopark\Taxopark\user.txt";

        private bool CheckLoginRepeat(User user) // метод для проверки логина и пароля пользователя
        {
            


        }

        private void avtor_Click(object sender, RoutedEventArgs e)
        {
            var user = new User(login.Text, parol.Text);

            if (CheckLoginRepeat(user))

            {
                MessageBox.Show("Неверный логин и/или пароль");
            }
            else if (!CheckLoginRepeat(user))
            {
                MessageBox.Show("Вы успешно вошли");

                Window2 c = new Window2(); // переход на таблицу
                this.Hide();
                c.ShowDialog();
                this.Show();
                Close();

            }

        }

        private void rega_Click(object sender, RoutedEventArgs e)
        {
            Window1 a = new Window1();
            this.Hide();
            a.ShowDialog();
            this.Show();
            Close();
        }
    }
}

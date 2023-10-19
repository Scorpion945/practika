using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
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

namespace Taxopark
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        StreamReader reader;
        const string path = @"C:\Users\student\Documents\Vasin_practika\Taxopark\Taxopark\user.txt";

        private static string connectionStrings = ConfigurationManager.ConnectionStrings["tax"].ConnectionString;

        private static SqlConnection sqlConnection  = new SqlConnection(connectionStrings);

        private void zarega_Click(object sender, RoutedEventArgs e) // функционал кнопки «Зарегистрироваться»
        {

            sqlConnection.Open();

            SqlCommand command = new SqlCommand($"SELECT * users", sqlConnection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (reader[1].ToString() == logintextBox.Text)
                {
                    MessageBox.Show($"Такой пользователь уже есть!!");
                }
                else 
                {
                    sqlConnection.Open();

                    SqlCommand insert_command = new SqlCommand($"INSERT INTO user VALUES {logintextBox.Text}, {paroltextBox.Text}", sqlConnection);
                    insert_command.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show($"Вы успешно зарегистрировались!");
                }
            }
            
            sqlConnection.Close();
            //if (!CheckLoginRepeat()) // проверка логина на повторение в файле

            //{
            //    MessageBox.Show("Данный пользователь уже существует.");

            //    return;
            //}


            //if (paroltextBox.Text != parol2textBox.Text) // проверка на соответствие введенных паролей
            //{
            //    MessageBox.Show("Пароли не совпадают. Повторите попытку.");
            //    return;
            //}

            MessageBox.Show("Вы успешно создали нового пользователя.");
        }
        

        

        private bool charVerification(object itemCharPassword, string[] symbols)
        {
            throw new NotImplementedException();
        }

        private bool CheckLoginRepeat(User user) // метод для проверки логина

        {
            reader = new StreamReader(path);
            var users = new List<User>();
            var rows = reader.ReadToEnd().Split('\n');
            rows = rows.Where(a => !string.IsNullOrEmpty(a)).ToArray();
            reader.Close();

            foreach (string row in rows)
            {
                var splitRow = row.Split(' ');

                users.Add(new User(splitRow[0], splitRow[1]));
            }

            return users.FirstOrDefault(u => u.Login == user.Login) is null;


        }

        private void vxod_Click(object sender, RoutedEventArgs e)
        {
            MainWindow b = new MainWindow();
            this.Hide();
            b.ShowDialog();
            this.Show();
            Close();
        }
    }
}

using System;
using System.Collections.Generic;
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

namespace OOTVETINAVOPROSII
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
    OtvetiNaVoprosiEntities db = new OtvetiNaVoprosiEntities();
        public Registration()
        {
            InitializeComponent();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SecNameTB.Text) ||
            string.IsNullOrEmpty(NameTB.Text) ||
            string.IsNullOrEmpty(LastNameTB.Text) ||
            string.IsNullOrEmpty(MailTB.Text) ||
            string.IsNullOrEmpty(LoginTB.Text) ||
            string.IsNullOrEmpty(PasswordTB.Text)){
                MessageBox.Show("Не оставляйте поля пустыми");
            }
            else{
                List<Пользователи> allpol = db.Пользователи.ToList();

                using (var context = new OtvetiNaVoprosiEntities()){
                    var newuser = new Пользователи
                    {
                        Фамилия = SecNameTB.Text,
                        Имя = NameTB.Text,
                        Отчество = LastNameTB.Text,
                        Электронная_почта = MailTB.Text,
                        Логин = LoginTB.Text,
                        Пароль = PasswordTB.Text,
                        Код_должности = 1
                    };
                    context.Пользователи.Add(newuser);
                    context.SaveChanges();
                    MessageBox.Show("Поздравляю! Регистрация прошла успешно");

                    //Перехдо на страницу гостя
                    GuestPage guestPage = new GuestPage(allpol.Count + 1);
                    guestPage.Show();
                    this.Close();
                }
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}

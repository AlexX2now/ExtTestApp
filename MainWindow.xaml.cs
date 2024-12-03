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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOTVETINAVOPROSII
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OtvetiNaVoprosiEntities db = new OtvetiNaVoprosiEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void enterbtn_Click(object sender, RoutedEventArgs e)
        {
            //Вход
            if (string.IsNullOrEmpty(logintxt.Text) ||
            string.IsNullOrEmpty(passwordtxt.Text)){
                MessageBox.Show("Не оставляйте поля пустыми");
            }
            else{
                var user = db.Пользователи.FirstOrDefault(x=>x.Логин.TrimEnd() == logintxt.Text && x.Пароль.TrimEnd() == passwordtxt.Text);

                if (user == null){
                    MessageBox.Show("Что-то введено не так");
                }
                else{
                    switch (user.Код_должности){
                        case 1:
                        //Переход на гостевую форму
                        GuestPage gp = new GuestPage(user.Код);
                        gp.Show();
                            this.Close();
                        break;
                        case 2:
                            //переход на форму администратора
                            AdminPage ap = new AdminPage();
                            ap.Show();
                            this.Close();
                        break;
                    }
                }
            }
        }

        private void regbtn_Click(object sender, RoutedEventArgs e)
        {
            //Переход на регистрацию
            Registration reg = new Registration();
            reg.Show();
            this.Close();
        }
    }
}

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
    /// Логика взаимодействия для ResPage.xaml
    /// </summary>
    public partial class ResPage : Window
    {
        OtvetiNaVoprosiEntities db = new OtvetiNaVoprosiEntities();
        private int userid;
        public ResPage(int usrid)
        {
            InitializeComponent();
            userid = usrid;

            var user = db.Пользователи.FirstOrDefault(x=>x.Код == userid);

            maintxt.Text = "Результаты " + user.Фамилия.TrimEnd() + " " + user.Имя;

            List<Результаты> allres = db.Результаты.ToList();
            List<Результаты> needeedres = allres.Where(x=>x.Код_пользователя == userid).ToList();

            for (int i = 0; i < needeedres.Count; i++){
                showres.Text += "Тема:" + needeedres[i].Тематика_загадок.Название.TrimEnd() + ", правильных ответов: " + needeedres[i].Кол_во_верных_ответов + " из " + needeedres[i].Всего_вопросов_было + " вопросов " + "\r\n";
            }

        }

        private void esitbtn_Click(object sender, RoutedEventArgs e)
        {
            GuestPage gp = new GuestPage(userid);
            gp.Show();
            this.Close();
        }
    }
}

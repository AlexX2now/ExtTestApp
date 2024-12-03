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
    /// Логика взаимодействия для Test.xaml
    /// </summary>
    public partial class Test : Window
    {
    OtvetiNaVoprosiEntities db = new OtvetiNaVoprosiEntities();
        private int userid, testid, pravil = 0, cunt = 0;
        public Test(int usrid, int tstid)
        {
            InitializeComponent();
            userid = usrid;
            testid = tstid;

            List<Загадки_и_ответы> allzagadotv = db.Загадки_и_ответы.ToList();
            List<Загадки_и_ответы> neededzagad = allzagadotv.Where(x=>x.Код_тематики == tstid).ToList();

            question.Text = neededzagad[cunt].Загадка.TrimEnd();
            answr1.Text = neededzagad[cunt].Ответ_1.TrimEnd();
            answr2.Text = neededzagad[cunt].Ответ_2.TrimEnd();
            answr3.Text = neededzagad[cunt].Ответ_3.TrimEnd();
        }

        private void otvet_Click(object sender, RoutedEventArgs e)
        {
            List<Загадки_и_ответы> allzagadotv = db.Загадки_и_ответы.ToList();
            List<Загадки_и_ответы> neededzagad = allzagadotv.Where(x => x.Код_тематики == testid).ToList();

            try
            {
            if(string.IsNullOrEmpty(uranswr.Text)){
                    MessageBox.Show("Выберите правильный ответ");
            }
            else{
                    if (uranswr.SelectedIndex + 1 == Convert.ToInt32(neededzagad[cunt].Правильный_ответ))
                    {
                        pravil++;
                    }

                    cunt++;
                    question.Text = neededzagad[cunt].Загадка.TrimEnd();
                    answr1.Text = neededzagad[cunt].Ответ_1.TrimEnd();
                    answr2.Text = neededzagad[cunt].Ответ_2.TrimEnd();
                    answr3.Text = neededzagad[cunt].Ответ_3.TrimEnd();
                }
            }
            catch{
                MessageBox.Show("Вы прошли тест! Кол-во верных ответов:" + pravil + " из " + neededzagad.Count);

                using (var context = new OtvetiNaVoprosiEntities()){
                    var newres = new Результаты
                    {
                    Код_пользователя = userid,
                    Код_тематики_вопросов = testid,
                    Кол_во_верных_ответов = pravil,
                    Всего_вопросов_было = neededzagad.Count
                    };
                    context.Результаты.Add(newres);
                    context.SaveChanges();
                }
                MessageBox.Show("Результаты успешно сохранены. Переносим вас обратно на главную страницу...");

                    GuestPage gp = new GuestPage(userid);
                    gp.Show();
                this.Close();
            }
        }
    }
}

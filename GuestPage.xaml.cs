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
    /// Логика взаимодействия для GuestPage.xaml
    /// </summary>
    public partial class GuestPage : Window
    {
        OtvetiNaVoprosiEntities db = new OtvetiNaVoprosiEntities();
        private int userid;
        public GuestPage(int usrid)
        {
            InitializeComponent();
            userid = usrid;
            
            List<Тематика_загадок> alltemka = db.Тематика_загадок.ToList();

            for (int i = 0; i < alltemka.Count; i++){
                tematicvibr.Items.Add(alltemka[i].Название.TrimEnd());
            }
        }

        private void checkres_Click(object sender, RoutedEventArgs e)
        {
            //Переход на форму с результатами
            ResPage rp = new ResPage(userid);
            rp.Show();
            this.Close();
        }

        private void esitbtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void totest_Click(object sender, RoutedEventArgs e)
        {
            //К тестированию
            if (string.IsNullOrEmpty(tematicvibr.Text)){
                MessageBox.Show("Выберите сначала тему");
            }
            else{
            List<Загадки_и_ответы> allzagad = db.Загадки_и_ответы.ToList();
                List<Загадки_и_ответы> neededzag = allzagad.Where(x => x.Код_тематики == tematicvibr.SelectedIndex + 1).ToList();
            if (neededzag.Count == 0){
                    MessageBox.Show("Упс...Пока что загадок по этой тематике нет");
            }
            else{
                    //Переход на форму с тесированием
                    Test tp = new Test(userid, tematicvibr.SelectedIndex + 1);
                    tp.Show();
                    this.Close();
                }
            }
        }
    }
}

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
    /// Логика взаимодействия для NewZag.xaml
    /// </summary>
    public partial class NewZag : Window
    {
        OtvetiNaVoprosiEntities db = new OtvetiNaVoprosiEntities();
        public NewZag()
        {
            InitializeComponent();

            List<Тематика_загадок> alltem = db.Тематика_загадок.ToList();

            for(int i = 0; i < alltem.Count; i++){
                tematicvibr.Items.Add(alltem[i].Название.TrimEnd());
            }
        }

        private void addvopr_Click(object sender, RoutedEventArgs e)
        {
        try{
                if (string.IsNullOrEmpty(vopros.Text) ||
                    string.IsNullOrEmpty(anser1.Text) ||
                    string.IsNullOrEmpty(anser2.Text) ||
                    string.IsNullOrEmpty(anser3.Text) ||
                    string.IsNullOrEmpty(pravilni.Text))
                {
                    MessageBox.Show("Запоните все, что надо");
                }
                else
                {
                    using (var context = new OtvetiNaVoprosiEntities())
                    {
                        var newzagaddk = new Загадки_и_ответы
                        {
                            Код_тематики = tematicvibr.SelectedIndex + 1,
                            Загадка = vopros.Text,
                            Ответ_1 = anser1.Text,
                            Ответ_2 = anser2.Text,
                            Ответ_3 = anser3.Text,
                            Правильный_ответ = pravilni.Text
                        };
                    }
                    MessageBox.Show("Вопрос успешно добавлен!");
                    vopros.Clear();
                    anser1.Clear();
                    anser2.Clear();
                    anser3.Clear();
                    pravilni.Text = "";

                }
            }
        catch{
                MessageBox.Show("Что-то пошло не так");
        } 
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            AdminPage ap = new AdminPage();
            ap.Show();
            this.Close();
        }
    }
}

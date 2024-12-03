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
    /// Логика взаимодействия для NewTematil.xaml
    /// </summary>
    public partial class NewTematil : Window
    {
    OtvetiNaVoprosiEntities db = new OtvetiNaVoprosiEntities();
        public NewTematil()
        {
            InitializeComponent();

            List<Тематика_загадок> alltematiks = db.Тематика_загадок.ToList();

            for (int i = 0; i < alltematiks.Count; i++){
                alltematik.Text += alltematiks[i].Название.TrimEnd() + "\r\n";
            }
        }

        private void createnewtematik_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(newtematik.Text)){
                MessageBox.Show("Напишите название новой тематики");
            }
            else{
                using (var context = new OtvetiNaVoprosiEntities()){
                    var newtema = new Тематика_загадок
                    {
                        Название = newtematik.Text
                    };
                    context.Тематика_загадок.Add(newtema );
                    context.SaveChanges();
                }
                MessageBox.Show("Новая тематика добавлена!");
            }
        }

        private void toadmpae_Click(object sender, RoutedEventArgs e)
        {
            AdminPage ap = new AdminPage();
            ap.Show();
            this.Close();
        }
    }
}

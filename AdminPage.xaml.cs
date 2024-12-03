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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Window
    {
        OtvetiNaVoprosiEntities db = new OtvetiNaVoprosiEntities();
        public AdminPage()
        {
            InitializeComponent();
        }

        private void esitbtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void tovoprosi_Click(object sender, RoutedEventArgs e)
        {
            NewZag nz = new NewZag();
            nz.Show();
            this.Close();
        }

        private void totematik_Click(object sender, RoutedEventArgs e)
        {
            NewTematil nt = new NewTematil();
            nt.Show();
            this.Close();
        }
    }
}

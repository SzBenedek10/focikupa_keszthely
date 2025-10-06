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

namespace focikupa_keszthely
{
    /// <summary>
    /// Interaction logic for csapatokwindow.xaml
    /// </summary>
    public partial class CsapatokWindow : Window
    {
        public CsapatokWindow()
        {
            InitializeComponent();
            lstCsapatok.ItemsSource = AdatTarolo.Csapatok;
        }

        private void lstCsapatok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstCsapatok.SelectedItem is Csapat csapat)
            {
                lstJatekosok.ItemsSource = csapat.Jatekosok;
            }
        }

        private void BtnEredmeny_Click(object sender, RoutedEventArgs e)
        {
            EredmenyWindow win = new EredmenyWindow();
            win.Show();
            this.Close();
        }
    }

}

using System.Linq;
using System.Windows;

namespace focikupa_keszthely
{
    public partial class EredmenyWindow : Window
    {
        public EredmenyWindow()
        {
            InitializeComponent();

            
           

            Csapat1ComboBox.ItemsSource = AdatTarolo.Csapatok;
            Csapat2ComboBox.ItemsSource = AdatTarolo.Csapatok;

            Csapat1ComboBox.DisplayMemberPath = "Nev";
            Csapat2ComboBox.DisplayMemberPath = "Nev";

            
            TabellaGrid.ItemsSource = AdatTarolo.Csapatok;
        }

        private void EredmenyRogzites_Click(object sender, RoutedEventArgs e)
        {

            if (Csapat1ComboBox.SelectedItem is Csapat cs1 &&
                Csapat2ComboBox.SelectedItem is Csapat cs2 &&
                int.TryParse(Csapat1GolBox.Text, out int gol1) &&
                int.TryParse(Csapat2GolBox.Text, out int gol2))
            {
                if (cs1 == cs2)
                {
                    MessageBox.Show("Nem játszhat ugyanaz a csapat önmagával!");
                    return;
                }

                AdatTarolo.EredmenyRogzitese(cs1, cs2, gol1, gol2);

                
                var rendezett = AdatTarolo.Csapatok
                .OrderByDescending(c => c.Pontok)
                .ThenByDescending(c => c.GolKulonbseg)
                .ToList();

                for (int i = 0; i < rendezett.Count; i++)
                {
                    rendezett[i].Index = i + 1;
                }

                TabellaGrid.ItemsSource = rendezett;
                TabellaGrid.Items.Refresh();

                
                Csapat1ComboBox.SelectedIndex = -1;
                Csapat2ComboBox.SelectedIndex = -1;
                Csapat1GolBox.Clear();
                Csapat2GolBox.Clear();

            }
            else
            {
                MessageBox.Show("Kérlek válassz ki két különböző csapatot és írd be az érvényes eredményt!");
            }
        }
    }
}

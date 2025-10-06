using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace focikupa_keszthely
{
    public static class AdatTarolo
    {
        public static List<Csapat> Csapatok { get; set; } = new List<Csapat>();

        static Random rnd = new Random();
        static string[] poziciok = { "Kapus", "Védő", "Középpályás", "Csatár" };

      
        static string[] vezetekNevek = { "Kovács", "Nagy", "Tóth", "Szabó", "Varga", "Kiss", "Molnár", "Horváth" };
        static string[] keresztNevek = { "Péter", "László", "Gábor", "Zoltán", "Tamás", "József", "István", "Attila" };

        
        static List<string> osszesNev = new List<string>();

        public static void Inicializalas()
        {
            
            osszesNev.Clear();
            foreach (var v in vezetekNevek)
            {
                foreach (var k in keresztNevek)
                {
                    osszesNev.Add($"{v} {k}");
                }
            }

            
            osszesNev = osszesNev.OrderBy(x => rnd.Next()).ToList();

            string[] csapatNevek = { "Vajda", "Premontrei", "Közgáz", "Bibó" };

            foreach (var csapatNev in csapatNevek)
            {
                var csapat = new Csapat { Nev = csapatNev };

                for (int i = 1; i <= 8; i++)
                {
                   
                    string randomNev = osszesNev[0];
                    osszesNev.RemoveAt(0); 

                    csapat.Jatekosok.Add(new Jatekos
                    {
                        Nev = randomNev,
                        Kor = rnd.Next(15, 20),
                        Pozicio = poziciok[rnd.Next(poziciok.Length)]
                    });
                }

                Csapatok.Add(csapat);
            }
        }
        public static void EredmenyRogzitese(Csapat cs1, Csapat cs2, int gol1, int gol2)
        {
            
            if (gol1 > gol2) cs1.Pontok += 3;
            else if (gol2 > gol1) cs2.Pontok += 3;
            else
            {
                cs1.Pontok += 1;
                cs2.Pontok += 1;
            }

            
            cs1.GolokRogzitve += gol1;
            cs1.GolokKapott += gol2;
            cs1.MegjatszottMerkozesek++;

            cs2.GolokRogzitve += gol2;
            cs2.GolokKapott += gol1;
            cs2.MegjatszottMerkozesek++;

            
            if (Csapatok.All(c => c.MegjatszottMerkozesek == 3))
            {
                var rendezett = Csapatok
                                .OrderByDescending(c => c.Pontok)
                                .ThenByDescending(c => c.GolKulonbseg)
                                .ToList();

                var maxPont = rendezett.First().Pontok;
                var gyoztesek = rendezett.Where(c => c.Pontok == maxPont).ToList();

                if (gyoztesek.Count == 1)
                {
                    MessageBox.Show($"A győztes: {gyoztesek[0].Nev}!");
                }
                else
                {
                    var maxGolKulonbseg = gyoztesek.Max(c => c.GolKulonbseg);
                    var nyertes = gyoztesek.First(c => c.GolKulonbseg == maxGolKulonbseg);
                    MessageBox.Show($"A győztes a holtverseny után: {nyertes.Nev}!");
                }
            }
        }

    }
}

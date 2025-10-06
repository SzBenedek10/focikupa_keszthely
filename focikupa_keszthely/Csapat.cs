using System.Collections.Generic;
using System.ComponentModel;
using focikupa_keszthely;

public class Csapat : INotifyPropertyChanged
{
    public string Nev { get; set; }
    public List<Jatekos> Jatekosok { get; set; } = new List<Jatekos>();

    private int pontok;
    public int Pontok
    {
        get => pontok;
        set { pontok = value; OnPropertyChanged(nameof(Pontok)); }
    }

    private int golokRogzitve;
    public int GolokRogzitve
    {
        get => golokRogzitve;
        set { golokRogzitve = value; OnPropertyChanged(nameof(GolokRogzitve)); OnPropertyChanged(nameof(GolKulonbseg)); }
    }

    private int golokKapott;
    public int GolokKapott
    {
        get => golokKapott;
        set { golokKapott = value; OnPropertyChanged(nameof(GolokKapott)); OnPropertyChanged(nameof(GolKulonbseg)); }
    }

    private int megjatszottMerkozesek;
    public int MegjatszottMerkozesek
    {
        get => megjatszottMerkozesek;
        set { megjatszottMerkozesek = value; OnPropertyChanged(nameof(MegjatszottMerkozesek)); }
    }

    private int index;
    public int Index
    {
        get => index;
        set { index = value; OnPropertyChanged(nameof(Index)); }
    }

    public int GolKulonbseg => GolokRogzitve - GolokKapott;

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string nev)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nev));
    }
}

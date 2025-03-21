namespace ConsoleApp1;

abstract class Kontener
{
    private static int kolejnyNumer = 1;
    public string NumerSeryjny { get; }
    public double MasaLadunku { get; private set; }
    public double Wysokosc { get; }
    public double WagaWlasna { get;  }
    public double Glebokosc { get; }
    public double MaksymalnaLadownosc { get; protected set; }

    public Kontener(double masaLadunku, double wysokosc, double wagaWlasna, double glebokosc, string typ)
    {
        if (masaLadunku > MaksymalnaLadownosc)
            throw new OverfillException("Przekroczono maksymalna ladownosc");

        NumerSeryjny = $"KON-{typ}-{kolejnyNumer++}";
        MasaLadunku = masaLadunku;
        Wysokosc = wysokosc;
        WagaWlasna = wagaWlasna;
        Glebokosc = glebokosc;
    }

    public void Zaladuj(double masa)
    {
        if (MasaLadunku + masa > MaksymalnaLadownosc)
            throw new OverfillException("Przekroczono maksymalna ladownosc");
        MasaLadunku += masa;
    }

    public void Oproznij()
    {
        MasaLadunku = 0;
    }

    public override string ToString()
    {
        return $"{NumerSeryjny} | Ładunek: {MasaLadunku}/{MaksymalnaLadownosc} kg | Wysokość: " +
               $"{Wysokosc} cm | Waga własna: {WagaWlasna} kg | Głębokość: {Glebokosc} cm";
    }

    class OverfillException : Exception
    {
        public OverfillException(string message) : base(message) { }
        
    }


}
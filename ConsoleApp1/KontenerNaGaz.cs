namespace ConsoleApp1;

public class KontenerNaGaz : Kontener,IHazardNotifier
{
    public double Cisnienie { get; } //cisnienie  w atmosferach

    public KontenerNaGaz(double masaLadunku, double cisnienie)
        : base(masaLadunku, 220, 1800, 280, "G")
    {
        MaksymalnaLadownosc = 10000;
        if (masaLadunku > MaksymalnaLadownosc)
            throw new OverfillException($"Przekroczono maksymalną ładowność kontenera gazowego ");
        Cisnienie = cisnienie;
    }
    
    public void PowiadomONiebezpieczenstwie(string wiadomosc)
    {
        Console.WriteLine($"Uwaga {wiadomosc} (Kontener: {NumerSeryjny})");
    }

    public override void Zaladuj(double masa,string produkt)
    {
    
        if (MasaLadunku + masa > MaksymalnaLadownosc)
        {   
            PowiadomONiebezpieczenstwie("Próba przeładowania kontenera z gazem");
            throw new OverflowException("Przekroczono dopuszczalną ładowność dla na gaz");
        }

        MasaLadunku += masa;
        Console.WriteLine($"Do kontenera: {NumerSeryjny} załadowano {masa}. " +
                          $"Aktualnie załadowano: {MasaLadunku}/{MaksymalnaLadownosc} kg.");

    }

    public override void Oproznij()
    {
        //Musi zostac 5% gazu
        double pozostalyGaz = MasaLadunku * 0.05;
        MasaLadunku = pozostalyGaz;
        Console.WriteLine($"Kontener {NumerSeryjny} został opróżniony. Pozostało {MasaLadunku} kg gazu (5%).");
    }

    public override string ToString()
    {
        return base.ToString() + $", Cisnienie: {Cisnienie} atm";
    }

}
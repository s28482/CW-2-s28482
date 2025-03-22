namespace ConsoleApp1;
public class KontenerChlodniczy : Kontener
{
    public string RodzajProduktu { get; }
    //temperatura w kontenerze
    public double Temperatura { get; private set; }
    
    // Słownik z  minimalnymi temperaturami dla  produktów
    private static readonly Dictionary<string, double> MinimalneTemperatury = new Dictionary<string, double>
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 }
    };
    
    // Konstruktor
    public KontenerChlodniczy(double masaLadunku, string rodzajProduktu, double temperatura)
        : base(masaLadunku, 240, 220, 290, "C")
    {
        MaksymalnaLadownosc = 20000;
        if (masaLadunku > MaksymalnaLadownosc)
            throw new OverfillException($"Przekroczono maksymalną ładowność kontenera chłodniczego");
        if (!MinimalneTemperatury.ContainsKey(rodzajProduktu))
            throw new ArgumentException($"Produkt '{rodzajProduktu}' nie jest obsługiwany.");
        double minimalnaTemperatura = MinimalneTemperatury[rodzajProduktu];
        
        //sprawdzam czy podana temperatura nie jest nizsza niz dopuszczalna dla produktu
        if (temperatura < minimalnaTemperatura)
            throw new ArgumentException($"Temperatura ({temperatura} stopni) jest za " +
                                        $"niska dla '{rodzajProduktu}'-- (Minimalna : {minimalnaTemperatura}  stopni.");
        
        RodzajProduktu = rodzajProduktu;
        Temperatura = temperatura;
    }
    
    // Nadpisanie metody Zaladuj
    // Trzeba sprawdzic czy towar ktory chcemy zaladowac to ten towar ktory juz jest w kontenerze
    public override void Zaladuj(double masa,string produkt)
    {
        if (!string.Equals(produkt, RodzajProduktu, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException(
                $"Nie można załadować produktu: '{produkt}' do kontenera" +
                $"chłodniczego typu '{RodzajProduktu}'.");
        }
        base.Zaladuj(masa,produkt);
    }

    public void ZmienTemperature(double nowaTemperatura)
    {
        // trzeba pobrac minimalna temperature
        double minimalnaTemp = MinimalneTemperatury[RodzajProduktu];
        if(nowaTemperatura < minimalnaTemp)
            throw new ArgumentException($"Temperatura {nowaTemperatura}°C za niska dla '{RodzajProduktu}' (min: {minimalnaTemp}°C).");
        Temperatura = nowaTemperatura;
    }
    public override string ToString()
    {
        // Zwraca dane z klasy bazowej + typ produktu i temperatura
        return base.ToString() + $" | Produkt: {RodzajProduktu} | Temperatura: {Temperatura}°C";
    }
    
    

}
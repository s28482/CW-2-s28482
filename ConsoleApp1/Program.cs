using ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        
        // 1. Sworzenie kontenera danego typu

        var kontenerPlyny = new KontenerNaPlyny(1000, false);
        var kontenerGaz = new KontenerNaGaz(2000, 5.5);
        var kontenerChlodnia = new KontenerChlodniczy(1500, "Bananas", 15);
        
        // 2. Zaladowanie ladunku do danego kontenera
        kontenerPlyny.Zaladuj(300,"Woda");
        kontenerGaz.Zaladuj(500,"Gaz");
        kontenerChlodnia.Zaladuj(200,"Bananas");
        
        // 3. Zaladowanie kontenera na statek
            //tworze statki
        var statek1 = new Kontenerowiec(10, 50000, 40);
        var statek2 = new Kontenerowiec(10, 50000, 40);
        statek1.ZaladujKontener(kontenerPlyny);
        statek1.ZaladujKontener(kontenerGaz);   
        statek1.ZaladujKontener(kontenerChlodnia);
        // 4. Zaladowanie listy kontenerow na statek
        
            //tworze dwa nowe kontenery
            var kontenerPlynyNiebezp = new KontenerNaPlyny(800, true);
            var kontenerGaz2 = new KontenerNaGaz(500, 3.5);
            // ładuje wiele kontenerów na raz
            statek1.Zaladujkontenery(new List<Kontener>{kontenerPlynyNiebezp,kontenerGaz2});
        // 5. Usuniecie kontenera ze statku
        statek1.UsunKontener(kontenerPlynyNiebezp.NumerSeryjny);
        // 6. Rozladowanie kontenera
        var kontenerGaz1 = new KontenerNaGaz(2000, 5.5);
        kontenerGaz1.Oproznij();
        // 7. Zastąpienie kontenera na statku o danym numerze seryjnym innym kontenerem
        var nowyKontenerGaz = new KontenerNaGaz(1000, 2.0);
        statek1.ZamienKontener(kontenerGaz.NumerSeryjny,nowyKontenerGaz);
        // 8. Możliwość przeniesienia kontenera między dwoma statkami
        statek1.PrzeniesKontener(statek2,kontenerChlodnia.NumerSeryjny);
        // 9. Wypisanie kontenera o danym kontenerze
        Console.WriteLine("\n Informacja o kontenerze: ");
        Console.WriteLine(kontenerPlyny);
        // 10. Wypisanie informacji o danym statku i jego ładunku:
        Console.WriteLine("\n Informacje o statku 1: ");
        statek1.WypiszInformacje();

    }
}

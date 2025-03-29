
namespace ConsoleApp1;

    public class KontenerNaPlyny : Kontener,IHazardNotifier
    {
        public bool CzyNiebezpieczny { get; }
        
       
        public KontenerNaPlyny(double masaLadunku, bool czyNiebezpieczny) 
            : base(masaLadunku, 250, 2000, 300, "L")
        {
            MaksymalnaLadownosc = 15000;
            CzyNiebezpieczny = czyNiebezpieczny; 
            if (masaLadunku > MaksymalnaLadownosc)
                throw new OverfillException("Przekroczono maksymalna ladownosc (Płyny)");
        }

        public void PowiadomONiebezpieczenstwie(string wiadomosc)
        {
            Console.WriteLine($"Uwaga {wiadomosc} (Kontener: {NumerSeryjny})");
        }

        public override void Zaladuj(double masa,string produkt)
        {
            // - Jeśli ładunek niebezpieczny -- max. 50% pojemności
            // - Jeśli ładunek zwykły -- max. 90% pojemności
            double dostepnaPojemnosc = CzyNiebezpieczny ? MaksymalnaLadownosc * 0.5 : MaksymalnaLadownosc * 0.9;
            if (MasaLadunku + masa > dostepnaPojemnosc)
            {   
                PowiadomONiebezpieczenstwie("Próba przeładowania kontenera z niebezpiecznym ładunkiem");
                throw new OverflowException("Przekroczono dopuszczalną ładowność dla kontenera tego typu");
            }

            MasaLadunku += masa;
            Console.WriteLine($"Do kontenera: {NumerSeryjny} załadowano {masa}. " +
                              $"Aktualnie załadowano: {MasaLadunku}/{MaksymalnaLadownosc} kg.");

        }

        public override string ToString()
        {
            return base.ToString() + $" Niebezpieczny: {(CzyNiebezpieczny ? "Tak" : "Nie")}";
        }
        
    }

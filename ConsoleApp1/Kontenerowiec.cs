namespace ConsoleApp1
{

    public class Kontenerowiec
    {
        // Wszystkie kontenery jakie dany statek transportuje - lista
        private List<Kontener> kontenery = new List<Kontener>();

        // Maksymalna prędkość jaką kontenerowiec może rozwijać (w węzłach)
        public double MaksymalnaPredkosc { get; }

        // Maksymalna liczba kontenerów, które mogą być przewożone
        public int MaksymalnaIloscKontenerow { get; }

        //Maksymalna waga wszystkich kontenerów jakie mogą być transportowane poprzez statek (w tonach)
        public double MaksymalnaWaga { get; }

        public Kontenerowiec(int maksIlosc, double maksWaga, double maksymalnaPredkosc)
        {
            MaksymalnaIloscKontenerow = maksIlosc;
            MaksymalnaWaga = maksWaga;
            MaksymalnaPredkosc = maksymalnaPredkosc;
        }

        //Aktualna sumwa wagi kontenerow
        public double AktualnaWaga => kontenery.Sum(k => k.MasaLadunku);

        // Liczba kontenerów załadowanych na statek
        public int AktualnaIlosc => kontenery.Count;

        // Załadowanie kontenera na statek
        public void ZaladujKontener(Kontener k)
        {
            // sprawdzam czy jest miejsce na wiecej kontenerow
            if (AktualnaIlosc >= MaksymalnaIloscKontenerow)
                throw new InvalidOperationException("Przekroczono liczbę kontenerów na statku");
            // spradzam czy nowy kontener nie przekroczy maksymalnej wagi
            if (AktualnaWaga + k.MasaLadunku > MaksymalnaWaga)
                throw new InvalidOperationException("Przekroczono wage kontenerow na statku");
            kontenery.Add(k);
        }
        
        // Zaladowanie wiele kontenerow na raz
        public void Zaladujkontenery(IEnumerable<Kontener> lista)
        {
            foreach (var k in lista)
                ZaladujKontener(k);
        }
        
        // usuniecie kontenera z listy na podstawie numeru seryjnego
        public void UsunKontener(string numer)
        {
            var kontener = kontenery.FirstOrDefault(
                k=> k.NumerSeryjny == numer);
            if(kontener != null)
                kontenery.Remove(kontener);
        }
        // rozladowanie kontenera o konkretnym numerze
        public void RozladujKontener(string numer)
        {
            var kontener = kontenery.FirstOrDefault(
                k=> k.NumerSeryjny == numer);
            kontener?.Oproznij();
        }
        
        // Zamien kontener o podanym numerze na nowy
        public void ZamienKontener(string numer, Kontener nowy)
        {
            // szukam starego kontenera
            var stary = kontenery.FirstOrDefault(k => k.NumerSeryjny == numer);
            if (stary == null)
                throw new InvalidOperationException("Nie znaleziono kontenera do zamiany.");

            // obliczam nowa wage
            double nowaWaga = AktualnaWaga - stary.MasaLadunku + nowy.MasaLadunku;

            // srprawdzam czy nowa waga nie bedzie wieksza od ograniczen konenerowca
            if (nowaWaga > MaksymalnaWaga)
                throw new InvalidOperationException("Zamiana przekroczyłaby maksymalną wagę kontenerowca.");
    
            // Zamiana kontenerow
            kontenery.Remove(stary);
            kontenery.Add(nowy);
        }
        
        // przeniesienie kontenera między dwoma statkami
        public void PrzeniesKontener(Kontenerowiec innyKontenerowiec, string numer)
        {
            var kontener = kontenery.FirstOrDefault( k=> k.NumerSeryjny == numer );
            if (kontener != null)
            {
                innyKontenerowiec.ZaladujKontener(kontener);
                kontenery.Remove(kontener);
            }
        }
        
        // Wypisanie informacji o danym statku i jego ładunku

        public void WypiszInformacje()
        {
            Console.WriteLine($"--- Statek: ");
            Console.WriteLine($"Liczba kontenerów: {AktualnaIlosc}, Waga: {AktualnaWaga}/{MaksymalnaWaga} kg");
            foreach (var k in kontenery)
                Console.WriteLine(k); // używa ToString() kontenera
        }


    }
}
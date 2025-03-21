namespace ConsoleApp1;

public class Kontenerowiec
{
    private List<Kontener> kontenery = new List<Kontener>();
    public int MaksymalnaIloscKontenerow { get; }
    public double MaksymalnaWaga { get; }
    public double MaksymalnaPredkosc { get; } // Prędkość w węzłach
    public double AktualnaWaga => kontenery.Sum(k => k.MasaLadunku);

}
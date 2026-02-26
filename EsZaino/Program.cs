
namespace EsZaino
{
    internal class Program
    {
        const int capacitaMassima = 50;
        static void Main(string[] args)
        {
            int pesoOttimo = 0;
            List<int> soluzioneOttima = new List<int>();
            int[] valori = { 11, 13, 7, 21, 40 };

            if (valori.Length < 0)
            {
                throw new Exception("non ci sono valori");
            }
            if (capacitaMassima <= 0)
            {
                throw new Exception("Capacità non valida!");
            }
            
            Zaino zaino = new Zaino(0, 0, new List<int>());
            Nodo<Zaino> radice = new Nodo<Zaino>(zaino);

            NavigaZaino(radice, valori, ref pesoOttimo, ref soluzioneOttima);

            Console.WriteLine($"Risultato ottimo: {pesoOttimo}");
            Console.Write("Oggetti Inclusi : ");

            foreach (int indice in soluzioneOttima)
            {
                Console.Write($"{valori[indice]} ");
            }              
        }

        static void NavigaZaino(Nodo<Zaino> nodo, int[] valori, ref int pesoOttimo, ref List<int> soluzioneOttima)
        {
            Zaino z = nodo.Dati;

            if (z.IndiceUltimoOggetto >= valori.Length)
            {
                if (z.PesoAccumulato > pesoOttimo || (z.PesoAccumulato == pesoOttimo && z.OggettiPresi.Count < soluzioneOttima.Count))
                {
                    pesoOttimo = z.PesoAccumulato;
                    soluzioneOttima = new List<int>(z.OggettiPresi);
                }
                return;
            }
            int pesoConNuovoOggetto = z.PesoAccumulato + valori[z.IndiceUltimoOggetto];

            if (pesoConNuovoOggetto <= capacitaMassima)
            {
                List<int> nuovaLista = new List<int>(z.OggettiPresi);
                nuovaLista.Add(z.IndiceUltimoOggetto);

                nodo.Prendo = new Nodo<Zaino>(new Zaino(z.IndiceUltimoOggetto + 1, pesoConNuovoOggetto, nuovaLista));
                NavigaZaino(nodo.Prendo, valori, ref pesoOttimo, ref soluzioneOttima);
            }
            nodo.NonPrendo = new Nodo<Zaino>(new Zaino(z.IndiceUltimoOggetto + 1, z.PesoAccumulato, new List<int>(z.OggettiPresi)));
            NavigaZaino(nodo.NonPrendo, valori, ref pesoOttimo, ref soluzioneOttima);
        }
    }
}
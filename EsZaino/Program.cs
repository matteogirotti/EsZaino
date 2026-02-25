
namespace EsZaino
{
    internal class Program
    {
        public static int RiempiZaino(int capacita, int[] pesi, int nPasso, int[] risultato, int spazioOccupato, int[] risultatoOttimo, int spazioOccupatoOttimo)
        {
            capacita = 50;
            pesi = new int[]{ 13, 27, 11, 7, 40};
            nPasso = 0;
            risultato = new int[] { 0, 0, 0, 0, 0};
            spazioOccupato = 0;
            risultatoOttimo = new int[] { 0 };
            spazioOccupatoOttimo = 0;

            foreach (int i in pesi)
            {
                if(spazioOccupato == 0)
                {
                    while (!(i >= capacita))
                    {
                        risultato[i] = pesi[i];
                        nPasso++;
                        spazioOccupato += pesi[i];
                    }
                }
            }
            return spazioOccupato;
        }
        private static void Main(string[] args)
        {
            int[] pesi = new int[] { 13, 27, 11, 7, 40 };
            int[] risultato = new int[] { 0, 0, 0, 0, 0 };
            int[] risultatoOttimo = new int[] { 0 };
            RiempiZaino(50, pesi, 0, risultato, 0, risultatoOttimo, 0);
        }
    }
}
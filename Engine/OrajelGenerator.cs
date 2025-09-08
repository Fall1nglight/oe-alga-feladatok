namespace OE.ALGA.Engine
{
    public interface IOrajelFogado
    {
        void Orajel(int ido);
    }

    public class OrajelGenerator
    {
        Timer? timer;

        public int Ido { get; private set; } = 0;

        public void Start()
        {
            timer = new Timer(FoCiklus, null, 0, 100);
        }

        public void Stop()
        {
            timer?.Change(Timeout.Infinite, Timeout.Infinite);
        }

        bool foglalt = false;
        private void FoCiklus(object? state)
        {
            if (!foglalt) // ha nem végzett az előző ciklus, akkor kihagyja a következőt
            {
                foglalt = true;
                Ido++;

                List<IOrajelFogado> aktivOrajelFogadok = new List<IOrajelFogado>(orajelFogadok); // azért kell a másolat, mert valamelyik órajel kezelés módosíthatja az orajelFogadok listát
                foreach (IOrajelFogado fogado in aktivOrajelFogadok)
                {
                    fogado.Orajel(Ido);
                }

                foglalt = false;
            }
        }

        private readonly List<IOrajelFogado> orajelFogadok = new List<IOrajelFogado>();

        public void OrajelFogadoFelvetele(IOrajelFogado fogado)
        {
            orajelFogadok.Add(fogado);
        }

        public void OrajelFogadoEltavolitasa(IOrajelFogado fogado)
        {
            orajelFogadok.Remove(fogado);
        }
    }
}

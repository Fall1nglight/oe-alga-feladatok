using OE.ALGA.Engine;

namespace OE.ALGA.ALGAme
{
    public class Jatek
    {
        readonly Terkep terkep;
        public Terkep Terkep { get { return terkep; } }

        readonly Backend backend;
        public Backend Backend { get { return backend; } }

        public Jatek()
        {
            backend = new Backend();
            terkep = new Terkep(Param.TERKEP_SZELESSEG, Param.TERKEP_MAGASSAG);

            PalyaGeneralas();
            NezopontokLetrehozasa();
        }

        public void Start()
        {
            backend.Start();
        }

        public void Stop()
        {
            backend.Stop();
        }

        private void PalyaGeneralas()
        {
            terkep.LabirintusGeneralas();
        }

        private void NezopontokLetrehozasa()
        {
            backend.Megjelenites.NezopontFelvetele(terkep);
        }
    }
}

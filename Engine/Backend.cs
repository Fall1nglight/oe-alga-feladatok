namespace OE.ALGA.Engine
{
    public class Backend
    {
        public Kepernyo Megjelenites { get; } = new Kepernyo();
        public BillentyuzetKezelo Bemenet { get; } = new BillentyuzetKezelo();
        public OrajelGenerator Orajel { get; } = new OrajelGenerator();

        public Backend()
        {
            Orajel.OrajelFogadoFelvetele(Bemenet);
            Orajel.OrajelFogadoFelvetele(Megjelenites);
        }

        bool kilepes = false;
        public void Start()
        {
            Orajel.Start();
            while (!kilepes)
            {
                Thread.Sleep(1000);
            }
        }

        public void Stop()
        {
            Orajel.Stop();
            kilepes = true;
        }
    }
}

namespace OE.ALGA.Engine
{
    public interface IBillentyuLenyomasKezelo
    {
        void BillentyuLenyomas(ConsoleKey billentyu);
    }

    public class BillentyuzetKezelo : IOrajelFogado
    {
        private readonly List<IBillentyuLenyomasKezelo> billentyuLenyomasKezelok = new List<IBillentyuLenyomasKezelo>();

        public void BillentyuLenyomasKezeloFelvetele(IBillentyuLenyomasKezelo kezelo)
        {
            billentyuLenyomasKezelok.Add(kezelo);
        }

        public void BillentyuLenyomasKezeloEltavolitasa(IBillentyuLenyomasKezelo kezelo)
        {
            billentyuLenyomasKezelok.Remove(kezelo);
        }

        private readonly Dictionary<ConsoleKey, Action> billentyuAkciok = new Dictionary<ConsoleKey, Action>();

        public void BillentyuAkcioFelvetele(ConsoleKey billentyu, Action akcio)
        {
            billentyuAkciok.Add(billentyu, akcio);
        }

        public void Orajel(int ido)
        {
            while (Console.KeyAvailable)
            {
                ConsoleKey billentyu = Console.ReadKey(true).Key;
                foreach (IBillentyuLenyomasKezelo kezelo in billentyuLenyomasKezelok)
                {
                    kezelo.BillentyuLenyomas(billentyu);
                }
                if (billentyuAkciok.TryGetValue(billentyu, out Action? value))
                    value();
            }
        }
    }
}

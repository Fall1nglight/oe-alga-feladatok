using System.Globalization;
using OE.ALGA.Paradigmak;

namespace OE.ALGA.Sandbox
{
    class Szemely : IVegrehajto
    {
        private string _name;

        public Szemely(string name)
        {
            _name = name;
        }

        public void Vegrehajtas()
        {
            Console.WriteLine($"Név: {_name}");
        }
    }

    internal class Program
    {
        static void Main()
        {
            FeladatTarolo<Szemely> tarolo = new FeladatTarolo<Szemely>(3);
            Szemely sz1 = new Szemely("Marci");
            Szemely sz2 = new Szemely("Akos");
            Szemely sz3 = new Szemely("Milan");
            tarolo.Felvesz(sz1);
            tarolo.Felvesz(sz2);
            tarolo.Felvesz(sz3);

            foreach (Szemely szemely in tarolo)
            {
                szemely.Vegrehajtas();
            }
        }
    }
}

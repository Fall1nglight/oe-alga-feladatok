using OE.ALGA.Paradigmak;

namespace Guardian
{
    public static class Recursion
    {
        /// <summary>
        /// This method is injected into every method and property call to check the current state
        /// of the stack. If the number of calls on the stack exceeds 500, infinite recursion is
        /// assumed and an exception is thrown, avoiding a complete program crash.
        /// </summary>
        /// <exception cref="System.StackOverflowException"></exception>
        public static void CheckStackTrace()
        {
            System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
            if (st.FrameCount > 500)
                throw new System.StackOverflowException($"A stack overflow has occurred! Method call depth has reached the limit (500<=): {st.FrameCount}!");
        }
    }
}

namespace OE.ALGA.Tesztek
{
    #region Paradigmak
    class TesztFeladat : IVegrehajthato
    {
        public string Azonosito { get; set; }
        public bool Vegrehajtott { get; set; }

        public void Vegrehajtas() => Vegrehajtott = true;
        public TesztFeladat(string nev) => Azonosito = nev;
    }
    class TesztFuggoFeladat : TesztFeladat, IFuggo
    {
        public bool Vegrehajthato { get; set; }

        public virtual bool FuggosegTeljesul => Vegrehajthato;

        public TesztFuggoFeladat(string nev) : base(nev) { }
    }
    class TesztElokovetelmenytolFuggoFeladat : TesztFuggoFeladat
    {
        readonly TesztFeladat elokovetelmeny;

        public override bool FuggosegTeljesul => base.FuggosegTeljesul && elokovetelmeny.Vegrehajtott;
        public TesztElokovetelmenytolFuggoFeladat(string nev, TesztFeladat elokovetelmeny) : base(nev) { this.elokovetelmeny = elokovetelmeny; }
    }
    #endregion

    #region Optimalizalas
    public class PakolasTesztEsetek
    {
        public static readonly bool[] uresPakolas = [false, false, false, false, false, false];
        public static readonly bool[] feligPakolas = [false, true, false, true, false, false];
        public static readonly bool[] teljesPakolas = [true, true, true, true, true, true];

        public static readonly int[] jegyzet_w = [2, 1, 1, 1, 3, 2];
        public static readonly float[] jegyzet_p = [4, 3, 2, 8, 7, 5];
        public static readonly int jegyzet_n = jegyzet_w.Length;
        public static readonly int jegyzet_Wmax = 4;
        public static readonly float jegyzet_optimalis_ertek = 16;
        public static readonly bool[] jegyzet_optimalis_pakolas = [false, true, false, true, false, true];

        public static readonly int[] nagy_w = [21, 41, 26, 11, 37, 25, 25, 44, 33, 29, 32, 52, 41, 62, 56, 81, 43];
        public static readonly float[] nagy_p = [4, 3, 2, 8, 7, 5, 4, 3, 2, 5, 3, 9, 5, 1, 7, 9, 4];
        public static readonly int nagy_n = nagy_w.Length;
        public static readonly int nagy_Wmax = 100;
        public static readonly float nagy_optimalis_ertek = 24;
        public static readonly bool[] nagy_optimalis_pakolas = [true, false, false, true, true, true, false, false, false, false, false, false, false, false, false, false, false];
    }
    #endregion
}

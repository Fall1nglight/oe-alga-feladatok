namespace OE.ALGA.Engine
{
    public class UtkozesKivetel : Exception
    {
        public TerkepElem Forras { get; set; }
        public TerkepElem Utkozes { get; set; }

        public UtkozesKivetel(TerkepElem forras, TerkepElem utkozes)
        {
            this.Forras = forras;
            this.Utkozes = utkozes;
        }
    }

    public class NemLehetIdeLepniKivetel : UtkozesKivetel
    {
        public NemLehetIdeLepniKivetel(TerkepElem forras, TerkepElem utkozes) : base(forras, utkozes)
        {

        }
    }
}

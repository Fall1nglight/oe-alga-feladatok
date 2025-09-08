namespace OE.ALGA.Engine
{
    public class KetElemuVektor : IComparable
    {
        readonly int x;
        readonly int y;

        public int X { get { return x; } }
        public int Y { get { return y; } }

        public KetElemuVektor(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj is KetElemuVektor b)
            {
                return X == b.X && Y == b.Y;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public int CompareTo(object? obj)
        {
            if (obj != null && obj is KetElemuVektor b)
            {
                if (x != b.x)
                    return x.CompareTo(b.x);
                else
                    return y.CompareTo(b.y);
            }
            throw new InvalidOperationException();
        }

        public static bool operator ==(KetElemuVektor a, KetElemuVektor b) => a.Equals(b);
        public static bool operator !=(KetElemuVektor a, KetElemuVektor b) => !a.Equals(b);
    }

    public class Pozicio : KetElemuVektor
    {
        public Pozicio(int x, int y) : base(x, y)
        {
        }

        

        public static Pozicio operator +(Pozicio p, Irany m) => new Pozicio(p.X + m.X, p.Y + m.Y);
        public static double Tavolsag(Pozicio a, Pozicio b) => Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
    }

    public class Irany : KetElemuVektor
    {
        public static readonly Irany[] FoIranyok = new Irany[4] { new Irany(0, -1), new Irany(-1, 0), new Irany(0, 1), new Irany(1, 0) };

        public static int Balra(int iranyIndex)
        {
            return (iranyIndex - 1 + 4) % 4;
        }

        public static int Jobbra(int iranyIndex)
        {
            return (iranyIndex + 1) % 4;
        }

        public Irany(int x, int y) : base(x, y)
        {
        }

        public static Irany operator *(Irany i, int s) => new Irany(i.X * s, i.Y * s);
    }

    public class Meret
    {
        public int Szelesseg { get; set; }
        public int Magassag { get; set; }

        public Meret(int szelesseg, int magassag)
        {
            this.Szelesseg = szelesseg;
            this.Magassag = magassag;
        }
    }
}

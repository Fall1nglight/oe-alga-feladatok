namespace OE.ALGA.Engine
{
    public class Terkep : INezopont
    {
        readonly Random rnd = new Random();

        public string Fejlec { get { return "Térkép"; } }

        readonly Meret meret;
        public Meret Meret { get { return meret; } }

        readonly List<TerkepElem> elemek = new List<TerkepElem>();

        public void Felvesz(TerkepElem elem)
        {
            elemek.Add(elem);
        }

        public void Eltavolit(TerkepElem elem)
        {
            elemek.Remove(elem);
        }

        public bool Mozgat(TerkepElem elem, Irany irany)
        {
            Pozicio ujPoz = elem.Pozicio + irany;

            bool odaLephet = true;

            foreach (TerkepElem ottvan in AdottHelyen(ujPoz))
            {
                ottvan.Utkozes?.Invoke(elem);
                elem.Utkozes?.Invoke(ottvan);
            }

            elem.Athelyez(ujPoz);

            return odaLephet;
        }

        public List<TerkepElem> AdottHelyen(Pozicio pozicio)
        {
            return elemek.FindAll(x => x.Pozicio == pozicio);
        }

        public TerkepElem[] Kornyezet(Pozicio pozicio, int tavolsag)
        {
            List<TerkepElem> elemek = new List<TerkepElem>();
            for (int x = -tavolsag; x <= tavolsag; x++)
                for (int y = -tavolsag; y <= tavolsag; y++)
                    elemek.AddRange(AdottHelyen(new Pozicio(pozicio.X + x, pozicio.Y + y)));
            return elemek.ToArray();
        }

        public IMegjelenitheto[] MegjelenitendoElemek()
        {
            return elemek.ToArray();
        }


        public Terkep(int szelesseg, int magassag)
        {
            this.meret = new Meret(szelesseg, magassag);
        }

        public void LabirintusGeneralas()
        {
            List<Fal> falak = new List<Fal>();
            List<Pozicio> bovitheto = new List<Pozicio>();

            // korbe falak letrehozasa
            for (int x = 0; x < meret.Szelesseg; x++)
            {
                falak.Add(new Fal(this, new Pozicio(x, 0)));
                falak.Add(new Fal(this, new Pozicio(x, meret.Magassag - 1)));
            }
            for (int y = 0; y < meret.Magassag; y++)
            {
                falak.Add(new Fal(this, new Pozicio(0, y)));
                falak.Add(new Fal(this, new Pozicio(meret.Szelesseg - 1, y)));
            }
            falak.Add(new Fal(this, new Pozicio(1, 2)));

            // belso szerkezet letrehozasa
            Pozicio kezdoPozicio = new Pozicio(2, 2);
            falak.Add(new Fal(this, kezdoPozicio));
            bovitheto.Add(kezdoPozicio);

            int falProba;
            do
            {
                int falRnd = rnd.Next(bovitheto.Count); // melyik falnal probaljon eloszor tovabb boviteni
                falProba = 0; // az elso fal valasztas random, de utana szisztematikusan tovabbnezi a mogotte levoket
                bool ok = false;
                while (falProba < bovitheto.Count && !ok) // ha nem nezte meg at az osszes falat es nem sikerult boviteni
                {
                    Pozicio vizsgalt = bovitheto[(falRnd + falProba) % bovitheto.Count]; // ezt a falat vizsgaljuk

                    int iranyRnd = rnd.Next(4); // ebbe az iranyba probal eloszor boviteni
                    int iranyProba = 0; // az elso irany valasztas random, de utana szisztematikusan nezi a tobbi iranyt
                    while (iranyProba < 4 && !ok) // meg nem nezte azt az osszes iranyt es nem sikerult boviteni
                    {
                        Irany irany = Irany.FoIranyok[(iranyRnd + iranyProba) % 4];
                        Pozicio uj = vizsgalt + irany * 2;
                        if (TerkepenBelulVan(uj) && !falak.Exists(x => x.Pozicio == uj)) // ha itt nincs meg fal
                        {
                            falak.Add(new Fal(this, uj)); // uj 2. tavolsagra levo fal letrehozasa, ebbol indulhat bovites is
                            falak.Add(new Fal(this, vizsgalt + irany)); // uj koztes fal letrehozasa
                            bovitheto.Add(uj);
                            ok = true; // sikerult boviteni
                        }
                        iranyProba++; // uj iranyt probalunk
                    }
                    falProba++; // uj falat probalunk
                }
            } while (falProba < bovitheto.Count); // minden fal minden iranyt vegigneztunk es nincs bovites
        }

        public bool TerkepenBelulVan(Pozicio pozicio)
        {
            return pozicio.X > 0 && pozicio.X < meret.Szelesseg - 1 && pozicio.Y > 0 && pozicio.Y < meret.Magassag - 1;
        }

        public bool NincsFal(Pozicio pozicio)
        {
            return !AdottHelyen(pozicio).Exists(x => x is Fal);
        }
    }

    abstract public class TerkepElem : IMegjelenitheto, IComparable
    {
        readonly private Terkep terkep;
        public Terkep Terkep { get { return terkep; } }

        protected Pozicio pozicio;
        public Pozicio Pozicio { get { return pozicio; } }

        abstract public Jel Jel { get; }

        public Action<TerkepElem>? Utkozes { get; set; }

        public virtual void Athelyez(Pozicio ujPozicio)
        {
            if (terkep.TerkepenBelulVan(ujPozicio))
                pozicio = ujPozicio;
        }

        protected TerkepElem(Terkep terkep, Pozicio pozicio)
        {
            this.terkep = terkep;
            terkep.Felvesz(this);
            this.pozicio = pozicio;
        }

        public virtual void Megszunik()
        {
            terkep.Eltavolit(this);
        }

        static int idSzamlalo = 0;
        readonly int id = idSzamlalo++;

        public int CompareTo(object? obj)
        {
            if (obj is TerkepElem o)
                return id.CompareTo(o.id);
            else
                throw new ArgumentException("Hibás összehasonlítás");
        }
    }

    public class FixTerkepElem : TerkepElem
    {
        protected Jel jel;

        public override Jel Jel
        {
            get { return jel; }
        }

        protected FixTerkepElem(Terkep terkep, Pozicio pozicio, Jel jel) : base(terkep, pozicio)
        {
            this.pozicio = pozicio;
            this.jel = jel;
        }
    }

    public class Fal : FixTerkepElem
    {
        static readonly Jel FAL_KARAKTER = new Jel(Param.FAL, ConsoleColor.DarkRed);

        public Fal(Terkep terkep, Pozicio pozicio) : base(terkep, pozicio, FAL_KARAKTER)
        {
            Utkozes = elem => throw new NemLehetIdeLepniKivetel(this, elem);
        }
    }

    public class Kincs : TerkepElem
    {
        readonly ConsoleColor[] szinek = new ConsoleColor[] { ConsoleColor.DarkRed, ConsoleColor.Red, ConsoleColor.DarkYellow, ConsoleColor.Yellow,
        ConsoleColor.DarkYellow, ConsoleColor.Red };

        public char Azonosito { get; private set; }
        public float Ertek { get; private set; }
        public int Suly { get; private set; }

        int villogasSzamlalo = 0;
        public override Jel Jel
        {
            get { return new Jel(Azonosito, szinek[villogasSzamlalo++ % szinek.Length]); }
        }

        public Kincs(Terkep terkep, Pozicio pozicio, char azonosito, float ertek, int suly) : base(terkep, pozicio)
        {
            this.Azonosito = azonosito;
            this.Ertek = ertek;
            this.Suly = suly;
        }
    }

    public class KincsKezelo : INezopont
    {
        readonly protected Kincs[] kincsek = new Kincs[Param.KINCSEK_SZAMA];
        readonly protected Terkep terkep;

        public KincsKezelo(Terkep terkep)
        {
            this.terkep = terkep;
            megjelenithetoKincsAdatok = Array.Empty<FixJel>();
        }

        public void KincsekGeneralasa()
        {
            Random rnd = new Random();
            for (int i = 0; i < Param.KINCSEK_SZAMA; i++)
                kincsek[i] = new Kincs(terkep, new Pozicio(0, 0), (char)(i + 97), rnd.Next(1, 100 / Param.KINCSEK_SZAMA), rnd.Next(1, Param.KINCSEK_MAX_MERETE));
            KincsekElhelyezese();
            MegjelenitesRendereles();
        }

        protected virtual void KincsekElhelyezese()
        {
            Random rnd = new Random();
            int i = 0;
            while (i < Param.KINCSEK_SZAMA)
            {
                Pozicio rndPozicio = new Pozicio(rnd.Next(terkep.Meret.Szelesseg), rnd.Next(terkep.Meret.Magassag));
                if (terkep.AdottHelyen(rndPozicio).Count == 0)
                {
                    kincsek[i].Athelyez(rndPozicio);
                    i++;
                }
            }
        }

        private IMegjelenitheto[] megjelenithetoKincsAdatok;
        private void MegjelenitesRendereles()
        {
            List<FixJel> elemek = new List<FixJel>();
            for (int i = 0; i < kincsek.Length; i++)
            {
                string szoveg = kincsek[i].Jel.Karakter + " " + kincsek[i].Ertek + "/" + kincsek[i].Suly;
                elemek.AddRange(FixJel.SzovegbolJelsor(szoveg, new Pozicio(1, i), ConsoleColor.White));
            }
            megjelenithetoKincsAdatok = elemek.ToArray();
        }

        public string Fejlec => "Kincsek";

        public Meret Meret => new Meret(9, Param.KINCSEK_SZAMA);

        public IMegjelenitheto[] MegjelenitendoElemek()
        {
            return megjelenithetoKincsAdatok;
        }
    }
}

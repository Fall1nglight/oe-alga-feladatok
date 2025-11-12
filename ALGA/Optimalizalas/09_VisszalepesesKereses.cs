using System;

namespace OE.ALGA.Optimalizalas
{
    // 9. heti labor feladat - Tesztek: 09VisszalepesesKeresesTesztek.cs

    public class VisszalepesesOptimalizacio<T>
    {
        // fields & properties

        /// <summary>
        /// Részproblémák/szintek száma
        /// </summary>
        protected int n;

        /// <summary>
        /// Egyes szinteken a lehetséges megoldások száma
        /// </summary>
        protected int[] M;

        /// <summary>
        /// Lehetséges részmegoldásokat tárolja
        /// M[x,i] lesz az x-edik szint i-edik megoldása
        /// </summary>
        protected T[,] R;

        /// <summary>
        /// Az algoritmus első korlát függvényét tárolja
        /// Az ft(x,r) -> igaz, ha az x-edik szinten az r egy választható részmegoldás
        /// </summary>
        protected Func<int, T, bool> ft;

        /// <summary>
        /// Az algoritmus második korlát függvényét tárolja
        /// Az fk(x,r,E) -> igaz, ha az x-edik szinten az r egy válstzható részmegoldás
        /// akkor, ha az előző szinteken az E-ben lévő részmegoldásokat választottuk
        /// </summary>
        protected Func<int, T, T[], bool> fk;

        /// <summary>
        /// Az egyes teljes megoldások értékelését végzi
        /// A josag(r) visszaadja az r teljes megoldás értéke
        /// </summary>
        protected Func<T[], float> josag;

        public int LepesSzam { get; protected set; }

        public VisszalepesesOptimalizacio(
            int n,
            int[] M,
            T[,] R,
            Func<int, T, bool> ft,
            Func<int, T, T[], bool> fk,
            Func<T[], float> josag
        )
        {
            this.n = n;
            this.M = M;
            this.R = R;
            this.ft = ft;
            this.fk = fk;
            this.josag = josag;
        }

        /// <summary>
        /// Legjobb megoldást keressük visszalépéses kereséssel
        /// </summary>
        /// <param name="szint">Az aktuálisan vizsgált részprobléma száma</param>
        /// <param name="E">Az eddig választott részmegoldásokat tárolja</param>
        /// <param name="van">Eddig talált-e már teljest megoldást</param>
        /// <param name="O">Az eddigi talált legjobb optimális eredmény</param>
        protected virtual void Backtrack(int szint, ref T[] E, ref bool van, ref T[] O)
        {
            int i = 0;

            // bejárjuk a lehetséges szinten lévő megoldásokat
            while (i < M[szint])
            {
                LepesSzam++;
                i++;

                // Ha az adott szinten választható az r megoldás
                if (ft(szint, R[szint, i - 1]))
                {
                    // Az adott szinten választható az r megoldás, ha eddig
                    // az E részmegoldásokat választottuk
                    if (fk(szint, R[szint, i - 1], E))
                    {
                        E[szint] = R[szint, i - 1];

                        if (szint == n - 1)
                        {
                            if (!van || josag(E) > josag(O))
                                O = (T[])E.Clone();

                            van = true;
                        }
                        else
                        {
                            Backtrack(szint + 1, ref E, ref van, ref O);
                        }
                    }
                }
            }
        }

        public T[] OptimalisMegoldas()
        {
            T[] E = new T[n];
            T[] O = new T[n];
            bool van = false;

            Backtrack(0, ref E, ref van, ref O);

            return O;
        }
    }

    public class VisszalepesesHatizsakPakolas
    {
        protected HatizsakProblema problema;
        public int LepesSzam { get; protected set; }

        public VisszalepesesHatizsakPakolas(HatizsakProblema problema)
        {
            this.problema = problema;
        }

        public virtual bool[] OptimalisMegoldas()
        {
            int[] M = new int[problema.n];

            for (int i = 0; i < M.Length; i++)
                M[i] = 2;

            bool[,] R = new bool[problema.n, 2];

            for (int i = 0; i < R.GetLength(0); i++)
            {
                R[i, 0] = true;
                R[i, 1] = false;
            }

            VisszalepesesOptimalizacio<bool> visszalepesesOptimalizacio =
                new VisszalepesesOptimalizacio<bool>(
                    problema.n,
                    M,
                    R,
                    (_, _) => true,
                    (szint, r, e) =>
                    {
                        bool[] copy = (bool[])e.Clone();
                        copy[szint] = r;
                        return problema.Ervenyes(copy);
                    },
                    problema.OsszErtek
                );

            bool[] optMegoldas = visszalepesesOptimalizacio.OptimalisMegoldas();

            LepesSzam = visszalepesesOptimalizacio.LepesSzam;

            return optMegoldas;
        }

        public float OptimalisErtek()
        {
            return problema.OsszErtek(OptimalisMegoldas());
        }
    }

    public class SzetvalasztasEsKorlatozasOptimalizacio<T> : VisszalepesesOptimalizacio<T>
    {
        protected Func<int, T[], float> fb;

        public SzetvalasztasEsKorlatozasOptimalizacio(
            int n,
            int[] M,
            T[,] R,
            Func<int, T, bool> ft,
            Func<int, T, T[], bool> fk,
            Func<T[], float> josag,
            Func<int, T[], float> fb
        )
            : base(n, M, R, ft, fk, josag)
        {
            this.fb = fb;
        }

        protected override void Backtrack(int szint, ref T[] E, ref bool van, ref T[] O)
        {
            int i = 0;

            while (i < M[szint])
            {
                LepesSzam++;
                i++;

                if (ft(szint, R[szint, i - 1]))
                {
                    if (fk(szint, R[szint, i - 1], E))
                    {
                        E[szint] = R[szint, i - 1];

                        if (szint == n - 1)
                        {
                            if (!van || josag(E) > josag(O))
                                O = (T[])E.Clone();

                            van = true;
                        }
                        else
                        {
                            if (josag(E) + fb(szint, E) > josag(O))
                                Backtrack(szint + 1, ref E, ref van, ref O);
                        }
                    }
                }
            }
        }
    }

    public class SzetvalasztasEsKorlatozasHatizsakPakolas : VisszalepesesHatizsakPakolas
    {
        public SzetvalasztasEsKorlatozasHatizsakPakolas(HatizsakProblema problema)
            : base(problema) { }

        public override bool[] OptimalisMegoldas()
        {
            int[] M = new int[problema.n];

            for (int i = 0; i < M.Length; i++)
                M[i] = 2;

            bool[,] R = new bool[problema.n, 2];

            for (int i = 0; i < R.GetLength(0); i++)
            {
                R[i, 0] = true;
                R[i, 1] = false;
            }

            SzetvalasztasEsKorlatozasOptimalizacio<bool> opt =
                new SzetvalasztasEsKorlatozasOptimalizacio<bool>(
                    problema.n,
                    M,
                    R,
                    (_, _) => true,
                    (szint, r, e) =>
                    {
                        bool[] copy = (bool[])e.Clone();
                        copy[szint] = r;
                        return problema.Ervenyes(copy);
                    },
                    problema.OsszErtek,
                    (szint, e) =>
                    {
                        float b = 0;

                        for (int i = szint; i < problema.n; i++)
                        {
                            if (problema.OsszSuly(e) + problema.w[i] <= problema.Wmax)
                            {
                                b += problema.p[i];
                            }
                        }

                        return b;
                    }
                );

            bool[] optMegoldas = opt.OptimalisMegoldas();
            LepesSzam = opt.LepesSzam;

            return optMegoldas;
        }
    }
}

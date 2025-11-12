using System;

namespace OE.ALGA.Adatszerkezetek
{
    // 10. heti labor feladat - Tesztek: 10_SulyozatlanGrafTesztek.cs

    /// <summary>
    /// Egész szám csúcsokat tartalmazó súlyozatlan gráf éleit reprezentálja
    /// </summary>
    public class EgeszGrafEl : GrafEl<int>, IComparable
    {
        /// <summary>
        /// Melyik csúcsból mutat az él
        /// </summary>
        public int Honnan { get; }

        /// <summary>
        /// Melyik csúcsba mutat az él
        /// </summary>
        public int Hova { get; }

        public EgeszGrafEl(int honnan, int hova)
        {
            Honnan = honnan;
            Hova = hova;
        }

        public int CompareTo(object? other)
        {
            if (ReferenceEquals(this, other))
                return 0;

            if (ReferenceEquals(null, other))
                throw new NullReferenceException();

            if (other is not EgeszGrafEl b)
                throw new ArgumentException();

            if (Honnan != b.Honnan)
                return Honnan.CompareTo(b.Honnan);

            return Hova.CompareTo(b.Hova);
        }
    }

    /// <summary>
    /// Megvalósítja a súlyozott gráf interfész által előírt műveleteket
    /// </summary>
    public class CsucsmatrixSulyozatlanEgeszGraf : SulyozatlanGraf<int, EgeszGrafEl>
    {
        /// <summary>
        /// Csúcsok száma
        /// </summary>
        private int n;

        /// <summary>
        /// Csúcsmátrix | M[i, j] => i. csúcsból vezet-e él j. csúcsba
        /// </summary>
        private bool[,] M;

        /// <summary>
        /// Megadja a csúcsok azonosítóit (0->n-1)
        /// </summary>
        public Halmaz<int> Csucsok => GetCsucsok();

        /// <summary>
        /// Megadja a gráfban található éleket
        /// </summary>
        public Halmaz<EgeszGrafEl> Elek => GetElek();

        /// <summary>
        /// Megadja a gráfban található csúcsok számát
        /// </summary>
        public int CsucsokSzama => n;

        /// <summary>
        /// Megadja a gráfban található élek számát
        /// </summary>
        public int ElekSzama => GetElekSzama();

        public CsucsmatrixSulyozatlanEgeszGraf(int n)
        {
            this.n = n;
            M = new bool[n, n];
        }

        public bool VezetEl(int honnan, int hova)
        {
            return M[honnan, hova];
        }

        public Halmaz<int> Szomszedai(int csucs)
        {
            FaHalmaz<int> szomszedok = new FaHalmaz<int>();

            for (int j = 0; j < M.GetLength(1); j++)
            {
                if (M[csucs, j])
                    szomszedok.Beszur(j);
            }

            return szomszedok;
        }

        public void UjEl(int honnan, int hova)
        {
            M[honnan, hova] = true;
        }

        private int GetElekSzama()
        {
            // kell egy változó, amiben eltároljuk az összeget (sum)
            // bejárjuk a mátrix-ot
            // ha az adott elem értéke 'igaz' növeljük a sum értékét 1-el
            // bejárás után visszaadjuk a sum értékét

            int sum = 0;

            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                {
                    if (M[i, j])
                        sum++;
                }
            }

            return sum;
        }

        private FaHalmaz<int> GetCsucsok()
        {
            FaHalmaz<int> csucsok = new FaHalmaz<int>();

            for (int i = 0; i < n; i++)
                csucsok.Beszur(i);

            return csucsok;
        }

        private FaHalmaz<EgeszGrafEl> GetElek()
        {
            FaHalmaz<EgeszGrafEl> elek = new FaHalmaz<EgeszGrafEl>();

            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                {
                    if (!M[i, j])
                        continue;

                    elek.Beszur(new EgeszGrafEl(i, j));
                }
            }

            return elek;
        }
    }

    /// <summary>
    /// Megvalósítja a szélességi és mélységi bejárást
    /// </summary>
    public class GrafBejarasok
    {
        /// <summary>
        /// Végrehatja az adott gráf-on a szélességi bejárás algoritmust
        /// </summary>
        /// <param name="g">Bejárandó gráf</param>
        /// <param name="start">Bejárás kezdőpontja (csúcs)</param>
        /// <param name="eljaras">Végrehajtandó művelet az elemeken</param>
        /// <typeparam name="V">Csúcsok típusa</typeparam>
        /// <typeparam name="E">Élek típusa</typeparam>
        /// <returns></returns>
        public static Halmaz<V> SzelessegiBejaras<V, E>(Graf<V, E> g, V start, Action<V> eljaras)
            where V : IComparable
        {
            Sor<V> sor = new TombSor<V>(g.CsucsokSzama);
            Halmaz<V> elertElemek = new FaHalmaz<V>();

            sor.Sorba(start);
            elertElemek.Beszur(start);

            while (!sor.Ures)
            {
                V csucs = sor.Sorbol();

                // feldolgozzuk a csúcsot
                eljaras(csucs);

                // bejárjuka a csúcs szomszédait
                g.Szomszedai(csucs)
                    .Bejar(szomszed =>
                    {
                        // ha még nem értük el az adott elemet
                        if (!elertElemek.Eleme(szomszed))
                        {
                            sor.Sorba(szomszed);
                            elertElemek.Beszur(szomszed);
                        }
                    });
            }

            return elertElemek;
        }

        public static Halmaz<V> MelysegiBejaras<V, E>(Graf<V, E> g, V start, Action<V> eljaras)
            where V : IComparable
        {
            Halmaz<V> elertElemek = new FaHalmaz<V>();

            MelysegiBejarasRekurzio(g, start, elertElemek, eljaras);

            return elertElemek;
        }

        public static void MelysegiBejarasRekurzio<V, E>(
            Graf<V, E> g,
            V jelenlegiCsucs,
            Halmaz<V> elertElemek,
            Action<V> eljaras
        )
            where V : IComparable
        {
            elertElemek.Beszur(jelenlegiCsucs);
            eljaras(jelenlegiCsucs);

            g.Szomszedai(jelenlegiCsucs)
                .Bejar(szomszed =>
                {
                    if (!elertElemek.Eleme(szomszed))
                        MelysegiBejarasRekurzio<V, E>(g, szomszed, elertElemek, eljaras);
                });
        }
    }
}

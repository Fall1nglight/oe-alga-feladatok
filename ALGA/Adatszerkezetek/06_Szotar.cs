using System;

namespace OE.ALGA.Adatszerkezetek
{
    // 6. heti labor feladat - Tesztek: 06_SzotarTesztek.cs

    public class SzotarElem<K, T>
    {
        // fields
        public K kulcs;
        public T tart;

        // constructors
        public SzotarElem(K kulcs, T tart)
        {
            this.kulcs = kulcs;
            this.tart = tart;
        }
    }

    public class HasitoSzotarTulcsordulasiTerulettel<K, T> : Szotar<K, T>
    {
        // fields
        private SzotarElem<K, T>[] E;
        private Func<K, int> h;
        private Lista<SzotarElem<K, T>> U = new LancoltLista<SzotarElem<K, T>>();

        // constructors
        public HasitoSzotarTulcsordulasiTerulettel(int meret, Func<K, int> hasitoFuggveny)
        {
            E = new SzotarElem<K, T>[meret];
            h = x => Math.Abs(hasitoFuggveny(x)) % E.Length;
        }

        public HasitoSzotarTulcsordulasiTerulettel(int meret)
            : this(meret, x => x.GetHashCode()) { }

        // methods
        private SzotarElem<K, T> KulcsKeres(K kulcs)
        {
            if (E[h(kulcs)] != null! && E[h(kulcs)].kulcs.Equals(kulcs))
                return E[h(kulcs)];

            SzotarElem<K, T> e = null!;

            U.Bejar(x =>
            {
                if (x.kulcs.Equals(kulcs))
                    e = x;
            });

            return e;
        }

        public void Beir(K kulcs, T ertek)
        {
            SzotarElem<K, T> meglevo = KulcsKeres(kulcs);

            if (meglevo != null!)
            {
                meglevo.tart = ertek;
                return;
            }

            SzotarElem<K, T> uj = new SzotarElem<K, T>(kulcs, ertek);

            if (E[h(kulcs)] == null!)
                E[h(kulcs)] = uj;
            else
                U.Hozzafuz(uj);
        }

        public T Kiolvas(K kulcs)
        {
            SzotarElem<K, T> meglevo = KulcsKeres(kulcs);

            if (meglevo == null!)
                throw new HibasKulcsKivetel();

            return meglevo.tart;
        }

        public void Torol(K kulcs)
        {
            if (E[h(kulcs)] != null! && E[h(kulcs)].kulcs.Equals(kulcs))
            {
                E[h(kulcs)] = null!;
                return;
            }

            SzotarElem<K, T> e = null!;

            U.Bejar(x =>
            {
                if (x.kulcs.Equals(kulcs))
                    e = x;
            });

            if (e == null!)
                throw new HibasKulcsKivetel();

            U.Torol(e);
        }
    }
}

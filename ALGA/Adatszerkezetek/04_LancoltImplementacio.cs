using System;
using System.Collections;
using System.Collections.Generic;

// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract

namespace OE.ALGA.Adatszerkezetek
{
    // 4. heti labor feladat - Tesztek: 04_LancoltImplementacioTesztek.cs

    public class LancElem<T>
    {
        // fields
        public T tart;
        public LancElem<T> kov;

        // constructors
        public LancElem(T tart, LancElem<T> kov)
        {
            this.tart = tart;
            this.kov = kov;
        }
    }

    public class LancoltVerem<T> : Verem<T>
    {
        // fields
        private LancElem<T> fej;

        // properties
        public bool Ures => fej == null;

        // constructors

        // methods
        public void Verembe(T ertek)
        {
            fej = new LancElem<T>(ertek, fej);

            // ugyan az a megoldás
            // if (Ures)
            //     fej = new LancElem<T>(ertek, null!);
            // else
            //     fej = new LancElem<T>(ertek, fej);
        }

        public T Verembol()
        {
            if (Ures)
                throw new NincsElemKivetel();

            T tartalom = fej.tart;
            fej = fej.kov;

            return tartalom;
        }

        public T Felso()
        {
            if (Ures)
                throw new NincsElemKivetel();

            return fej.tart;
        }
    }

    public class LancoltSor<T> : Sor<T>
    {
        // fields
        private LancElem<T> fej;
        private LancElem<T> vege;

        // properties
        public bool Ures => vege == null;

        // constructors

        // methods
        public void Sorba(T ertek)
        {
            LancElem<T> uj = new LancElem<T>(ertek, null!);

            if (Ures)
            {
                fej = uj;
            }
            else
            {
                vege.kov = uj;
            }

            vege = uj;
        }

        public T Sorbol()
        {
            if (Ures)
                throw new NincsElemKivetel();

            T tartalom = fej.tart;
            fej = fej.kov;

            if (fej == null)
                vege = null!;

            return tartalom;
        }

        public T Elso()
        {
            if (Ures)
                throw new NincsElemKivetel();

            return fej.tart;
        }
    }

    public class LancoltLista<T> : Lista<T>, IEnumerable<T>
    {
        // fields
        public LancElem<T> fej;
        private int n;

        // properties
        public int Elemszam => n;

        public IEnumerator<T> GetEnumerator() => new LancoltListaBejaro<T>(fej);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        // constructors
        public LancoltLista() { }

        // methods
        private bool Ures => Elemszam == 0;

        private bool HibasIndex(int index) => index < 0 || index > Elemszam;

        private LancElem<T> KiolvasLancElem(int index)
        {
            // ha hibás az index kivételt dobunk
            if (HibasIndex(index))
                throw new HibasIndexKivetel();

            // segédváltozók, amelyek a bejáráshoz szükségesek
            LancElem<T> atmeneti = fej;
            int i = 0;

            // bejárjuk a listát, ameddig az következő elemre mutató referencia nem null
            // és az i kisebb mint az index
            while (atmeneti != null && i < index)
            {
                atmeneti = atmeneti.kov;
                i++;
            }

            // visszaadjuk a kért indexen lévő LancElemet
            return atmeneti!;
        }

        public T Kiolvas(int index)
        {
            // kiolvassuk az kapott indexen lévő elemet
            LancElem<T> keresett = KiolvasLancElem(index);

            // ha az elem null akkor kivétlelt dobunk
            if (keresett == null)
                throw new HibasIndexKivetel();

            // visszaadjuk a keresett elem által tárolt értéket
            return keresett.tart;
        }

        public void Modosit(int index, T ertek)
        {
            // Kiolvassuk a paraméterként kapott indexen elhelyezkedő elemet
            LancElem<T> atmeneti = KiolvasLancElem(index);

            // módosítjuk az értékét a kapott értékre
            atmeneti.tart = ertek;
        }

        public void Hozzafuz(T ertek)
        {
            // létrehozunk egy új elemet, amely null-ra mutat (minden lista végén lévő elem ide mutat)
            LancElem<T> uj = new LancElem<T>(ertek, null!);

            // növeljük az elemszámot
            n++;

            // amennyiben a lista üres, felülírjuk a fej referenciáját az új elem referenciájával
            // és kilépünk
            if (fej == null)
            {
                fej = uj;
                return;
            }

            // segédváltozó -> a lista bejárásához szükséges
            LancElem<T> atmeneti = fej;

            // bejárjuk a listát ameddig a következő elemre mutató referencia nem null
            while (atmeneti.kov != null)
                atmeneti = atmeneti.kov;

            // felülírjuk az utolsó elem KÖVETKEZŐ elemre mutató referenciáját
            // az új elem referenciájával
            atmeneti.kov = uj;
        }

        public void Beszur(int index, T ertek)
        {
            // ha az elemet a lista elejére szetenénk beszúrni
            if (index == 0)
            {
                // az új elem referenciája a fej-re fog mutatni
                LancElem<T> uj = new LancElem<T>(ertek, fej);

                // majd felülírjuk a fej-et az új elem referenciájával
                fej = uj;
            }
            else
            // ha az elemet NEM az elejére szeretnénk beszúrni
            {
                // megkeressük a beszúrandó index előtti elemet
                LancElem<T> elotte = KiolvasLancElem(index - 1);

                // létrehozzuk az új elemet, amely az előtte álló
                // elem KÖVETKEZŐ elemre mutató referenciájára fog mutatni
                // majd felülírjuk az előtte álló elem referenciáját
                // az új elem referenciájával
                elotte.kov = new LancElem<T>(ertek, elotte.kov);
            }

            // növeljük az elemszámot
            n++;
        }

        public void Torol(T ertek)
        {
            // A lista bejárásához szükséges segédváltozók
            // 'e' a jelenlegi elem előtti elemet tárolja
            // 'p' a jelenlegi elemet tárolja
            LancElem<T> e = null!;
            LancElem<T> p = fej;

            // A lista bejárása egyetlen ciklussal
            while (p != null)
            {
                // Ha megtaláltuk a törlendő elemet
                if (p.tart!.Equals(ertek))
                {
                    // Ha az első elemet kell törölni (az 'e' még null)
                    if (e == null)
                    {
                        // A lista feje a következő elemre mutat majd
                        fej = p.kov;
                    }
                    // Ha egy belső elemet kell törölni
                    else
                    {
                        // A törölt elem előtti elem most a törölt elem utáni elemre mutat
                        // Ez a lépés "átugorja" a törlendő elemet
                        e.kov = p.kov;
                    }

                    // Csökkentjük a lista méretét
                    n--;
                }
                else
                {
                    // Ha az aktuális elem nem a törlendő elem, haladunk tovább a listán
                    // Az 'e' (előző) most a 'p' (jelenlegi) elem lesz
                    e = p;
                }

                // Tovább lépünk a következő elemre
                p = p.kov;
            }
        }

        public void Bejar(Action<T> muvelet)
        {
            // segédváltozó a bejáráshoz
            LancElem<T> atmeneti = fej;

            // bejárjuk a listát
            while (atmeneti != null)
            {
                // minden egyes elemre végrehatjuk a paraméterként kapott műveletet
                muvelet(atmeneti.tart);
                atmeneti = atmeneti.kov;
            }
        }
    }

    public class LancoltListaBejaro<T> : IEnumerator<T>
    {
        // fields
        private LancElem<T> fej;
        private LancElem<T> aktualisElem;

        // properties
        public T Current => aktualisElem.tart;

        object? IEnumerator.Current => Current;

        // constructors
        public LancoltListaBejaro(LancElem<T> fej)
        {
            this.fej = fej;
        }

        // methods
        public bool MoveNext()
        {
            if (aktualisElem == null)
            {
                aktualisElem = fej;
            }
            else
            {
                aktualisElem = aktualisElem.kov;
            }

            return aktualisElem != null;
        }

        public void Reset()
        {
            aktualisElem = null!;
        }

        public void Dispose() { }
    }
}

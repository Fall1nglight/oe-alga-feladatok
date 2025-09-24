using System;
using System.Collections;
using System.Collections.Generic;

namespace OE.ALGA.Adatszerkezetek
{
    // 3. heti labor feladat - Tesztek: 03_TombImplementacioTesztek.cs

    public class TombVerem<T> : Verem<T>
    {
        // fields
        private T[] E;
        private int n;

        // properties
        public bool Ures => n == 0;

        // constructors
        public TombVerem(int meret)
        {
            E = new T[meret];
        }

        // methods
        public void Verembe(T ertek)
        {
            if (n == E.Length)
                throw new NincsHelyKivetel();

            E[n++] = ertek;
        }

        public T Verembol()
        {
            if (Ures)
                throw new NincsElemKivetel();

            T elem = E[n - 1];

            // ez nem szükséges, de ajánlott a memória felszabadítás céljából
            E[n - 1] = default(T)!;
            n--;

            return elem;
        }

        public T Felso()
        {
            if (Ures)
                throw new NincsElemKivetel();

            return E[n - 1];
        }

        public void Felszabadit() { }
    }

    public class TombSor<T> : Sor<T>
    {
        // fields
        private T[] E;
        private int e; // első (kivett elem) pozíciója
        private int u; // utoljára tárolt elem pozíciója
        private int n; // sorban lévő elemek száma

        // properties
        public bool Ures => n == 0;
        public bool Teli => n == E.Length;

        // constructors
        public TombSor(int meret)
        {
            E = new T[meret];
        }

        // methods
        public void Sorba(T ertek)
        {
            if (Teli)
                throw new NincsHelyKivetel();

            E[u++] = ertek;

            // u = u+1 % E.Length;
            if (u == E.Length)
            {
                u = 0;
            }

            n++;
        }

        public T Sorbol()
        {
            if (Ures)
                throw new NincsElemKivetel();

            T elem = E[e++];

            if (e == E.Length)
                e = 0;

            n--;

            return elem;
        }

        public T Elso()
        {
            if (Ures)
                throw new NincsElemKivetel();

            if (e == E.Length)
                return E[0];

            return E[e];
        }

        public void Felszabadit() { }
    }

    public class TombLista<T> : Lista<T>, IEnumerable<T>
    {
        // fields
        private T[] E;
        private int n;

        // properties
        public int Elemszam => n;

        // constructors
        public TombLista(int meret = 32)
        {
            E = new T[meret];
        }

        // methods
        public IEnumerator<T> GetEnumerator() => new TombListaBejaro<T>(E, n);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void MeretNovel()
        {
            // eltároljuk az eredeti tömb referenciáját
            T[] atmeneti = E;

            // felülírjuk az eredeti tömböt egy újjal,
            // aminek a mérete kétszer akkora mint volt
            E = new T[E.Length * 2];

            // bejárjuk az átmeneti tömbünket n-ig
            // és átmosuljuk az elemeket az új, nagyobb tömbbe
            for (int i = 0; i < n; i++)
            {
                E[i] = atmeneti[i];
            }
        }

        private bool IsIndexInvalid(int index) => index < 0 || index >= Elemszam;

        public T Kiolvas(int index)
        {
            if (IsIndexInvalid(index))
                throw new HibasIndexKivetel();

            return E[index];
        }

        public void Modosit(int index, T ertek)
        {
            if (IsIndexInvalid(index))
                throw new HibasIndexKivetel();

            E[index] = ertek;
        }

        public void Hozzafuz(T ertek)
        {
            if (Elemszam == E.Length)
                MeretNovel();

            E[n++] = ertek;
        }

        public void Beszur(int index, T ertek)
        {
            // ha az index negatív vagy
            // nagyobb az elemszámnál hibát dobunk
            // fontos: megengedjük, hogy az a "n"-edik
            // helyre való elem beszúrást
            if (index < 0 || index > Elemszam)
                throw new HibasIndexKivetel();

            // ha megtelt a tömb, növeljük a méretét
            if (Elemszam == E.Length)
                MeretNovel();

            // n-től index-ig visszafelé haladva
            // eltoljuk az elemeket egyel jobbra
            for (int i = n; i > index; i--)
            {
                E[i] = E[i - 1];
            }

            // növeljük az elemszámot és beszúrjuk az új értéket
            n++;
            E[index] = ertek;
        }

        public void Torol(T ertek)
        {
            // itt tároljuk a talált elemek számáz
            int db = 0;

            // bejárjuk a tömböt egy számláló ciklussal i<--1-től n-ig
            for (int i = 0; i < n; i++)
            {
                // ha az aktuális elem megegyezik a törlendő értékkel növeljük a "db" értékét egyel
                if (E[i]!.Equals(ertek))
                {
                    db++;
                }
                // ha nincs egyezés akkor mozgatjuk az elemet
                // mégpedig annyival, amennyit előtte megtaláltunk
                // ezáltal felülírjuk a törlendő elemeket
                else
                {
                    E[i - db] = E[i];
                }
            }

            // csökkentjük az elemszámot a talált elemek értékével
            n -= db;
        }

        public void Bejar(Action<T> muvelet)
        {
            // bejárjuk a tömböt i<--1-től n-ig
            for (int i = 0; i < n; i++)
            {
                // az aktuális elemen végrehatjuk a paraméterként
                // kapott műveletet
                muvelet(E[i]);
            }
        }

        public void Felszabadit() { }
    }

    public class TombListaBejaro<T> : IEnumerator<T>
    {
        // fields
        private T[] E;
        private int n;
        private int aktualisIndex = -1;

        // properties
        public T Current => E[aktualisIndex];

        object? IEnumerator.Current => Current;

        // constructors
        public TombListaBejaro(T[] E, int n)
        {
            this.E = E;
            this.n = n;
        }

        // methods
        public bool MoveNext()
        {
            aktualisIndex++;
            return aktualisIndex < n;
        }

        public void Reset()
        {
            aktualisIndex = -1;
        }

        public void Dispose() { }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace OE.ALGA.Paradigmak
{
    // 2. heti labor feladat - Tesztek: 02_FunkcionálisParadigmaTesztek.cs

    // FeltetelesFeladatTarolo
    public class FeltetelesFeladatTarolo<T> : FeladatTarolo<T>
        where T : IVegrehajthato
    {
        // fields
        public Predicate<T> BejaroFeltetel { get; set; }

        // constructors
        public FeltetelesFeladatTarolo(int meret)
            : base(meret) { }

        // methods
        public virtual void FeltetelesVegrehajtas(Predicate<T> match)
        {
            // bejárjuk a tömböt n-ig
            for (int i = 0; i < n; i++)
            {
                // ha az adott elemre meghívott
                // match Predicate visszatérési
                // értéke IGAZ meghívjuk a
                // 'Vegrehajtas' metódusát

                if (match(tarolo[i]))
                    tarolo[i].Vegrehajtas();
            }
        }

        public override IEnumerator<T> GetEnumerator()
        {
            Predicate<T> match;

            if (BejaroFeltetel == null)
            {
                match = (item) => true;
            }
            else
            {
                match = BejaroFeltetel;
            }

            FeltetelesFeladatTaroloBejaro<T> bejaro = new FeltetelesFeladatTaroloBejaro<T>(
                tarolo,
                n,
                match
            );

            return bejaro;
        }

        // properties
    }

    // BEJARO
    public class FeltetelesFeladatTaroloBejaro<T> : IEnumerator<T>
    {
        // fields
        public Predicate<T> feltetel;
        private T[] tarolo;
        private int n;
        private int aktualisIndex = -1;

        // properties
        public T Current { get; }

        object? IEnumerator.Current => Current;

        // constructors

        public FeltetelesFeladatTaroloBejaro(T[] tarolo, int n, Predicate<T> feltetel)
        {
            this.tarolo = tarolo;
            this.n = n;
            this.feltetel = feltetel;
        }

        // methods
        public bool MoveNext()
        {
            aktualisIndex++;

            while (aktualisIndex < n && !feltetel(tarolo[aktualisIndex]))
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

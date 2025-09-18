using System;
using System.Collections;
using System.Collections.Generic;

namespace OE.ALGA.Paradigmak
{
    // 1. heti labor feladat - Tesztek: 01_ImperativParadigmaTesztek.cs
    public interface IVegrehajthato
    {
        void Vegrehajtas();
    }

    public interface IFuggo
    {
        bool FuggosegTeljesul { get; }
    }

    public class TaroloMegteltKivetel : Exception
    {
        // constructors
        public TaroloMegteltKivetel() { }

        public TaroloMegteltKivetel(string message)
            : base(message) { }
    }

    public class FeladatTaroloBejaro<T> : IEnumerator<T>
    {
        // fields
        private T[] tarolo;
        private int n;
        private int aktualisIndex = -1;

        public T Current => tarolo[aktualisIndex];

        // public T Current
        // {
        //     get { return tarolo[aktualisIndex]; }
        // }

        // constructors
        public FeladatTaroloBejaro(T[] tarolo, int n)
        {
            this.tarolo = tarolo;
            this.n = n;
        }

        // methods
        public bool MoveNext()
        {
            aktualisIndex++;
            return aktualisIndex < n;

            // if (++aktualisIndex < n)
            //     return true;
            //
            // return false;
        }

        public void Reset()
        {
            aktualisIndex = -1;
        }

        object? IEnumerator.Current => Current;

        public void Dispose() { }
    }

    public class FeladatTarolo<T> : IEnumerable<T>
        where T : IVegrehajthato
    {
        // fields
        protected T[] tarolo;
        protected int n = 0;

        // constructors
        public FeladatTarolo(int meret)
        {
            tarolo = new T[meret];
        }

        // methods
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<T> GetEnumerator() => new FeladatTaroloBejaro<T>(tarolo, n);

        public void Felvesz(T elem)
        {
            if (n == tarolo.Length)
                throw new TaroloMegteltKivetel();

            tarolo[n++] = elem;
        }

        public virtual void MindentVegrehajt()
        {
            for (int i = 0; i < n; i++)
            {
                tarolo[i].Vegrehajtas();
            }
        }
    }

    public class FuggoFeladatTarolo<T> : FeladatTarolo<T>
        where T : IVegrehajthato, IFuggo
    {
        public FuggoFeladatTarolo(int meret)
            : base(meret) { }

        public override void MindentVegrehajt()
        {
            for (int i = 0; i < n; i++)
            {
                if (tarolo[i].FuggosegTeljesul)
                    tarolo[i].Vegrehajtas();
            }
        }
    }
}

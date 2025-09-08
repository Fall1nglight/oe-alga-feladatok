using System;

namespace OE.ALGA
{
    public interface Lista<T>
    {
        public int Elemszam { get; }

        public T Kiolvas(int index);
        public void Modosit(int index, T ertek);
        public void Hozzafuz(T ertek);
        public void Beszur(int index, T ertek);
        public void Torol(T ertek);
        public void Bejar(Action<T> muvelet);
    }

    public interface Halmaz<T>
    {
        public void Beszur(T ertek);
        public bool Eleme(T ertek);
        public void Torol(T ertek);
        public void Bejar(Action<T> muvelet);
    }

    public interface Verem<T>
    {
        bool Ures { get; }
        void Verembe(T ertek);
        T Verembol();
        T Felso();
    }

    public interface Sor<T>
    {
        bool Ures { get; }
        void Sorba(T ertek);
        T Sorbol();
        T Elso();
    }

    public interface PrioritasosSor<T>
    {
        bool Ures { get; }
        void Sorba(T ertek);
        T Sorbol();
        T Elso();
        void Frissit(T elem);
    }

    public interface GrafEl<V>
    {
        V Honnan { get; }
        V Hova { get; }
    }

    public interface Graf<V, E>
    {
        int CsucsokSzama { get; }
        int ElekSzama { get; }
        Halmaz<V> Csucsok { get; }
        Halmaz<E> Elek { get; }
        bool VezetEl(V honnan, V hova);
        Halmaz<V> Szomszedai(V csucs);
    }

    public interface SulyozatlanGraf<V, E> : Graf<V, E>
    {
        void UjEl(V honnan, V hova);
    }

    public interface SulyozottGrafEl<V> : GrafEl<V>
    {
        float Suly { get; }
    }

    public interface SulyozottGraf<V, E> : Graf<V, E>
    {
        void UjEl(V honnan, V hova, float suly);
        float Suly(V honnan, V hova);
    }

    public interface Szotar<K, T>
    {
        public void Beir(K kulcs, T ertek);
        public T Kiolvas(K kulcs);
        public void Torol(K kulcs);
    }

    public class HibasKulcsKivetel : Exception
    {
    }

    public class HibasIndexKivetel : Exception
    {
    }

    public class NincsElemKivetel : Exception
    {
    }

    public class NincsHelyKivetel : Exception
    {
    }

    public class NincsElKivetel : Exception
    {
    }

    public class NemOsszehasonlithatoKivetel : Exception
    {
    }

}

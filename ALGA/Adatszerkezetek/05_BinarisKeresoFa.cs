using System;

namespace OE.ALGA.Adatszerkezetek
{
    // 5. heti labor feladat - Tesztek: 05_BinarisKeresoFaTesztek.cs

    #region FaElem

    public class FaElem<T>
        where T : IComparable
    {
        // fields
        public T tart;
        public FaElem<T> bal;
        public FaElem<T> jobb;

        // constructors
        public FaElem(T tart, FaElem<T> bal, FaElem<T> jobb)
        {
            this.tart = tart;
            this.bal = bal;
            this.jobb = jobb;
        }
    }
    #endregion

    #region FaHalmaz

    public class FaHalmaz<T> : Halmaz<T>
        where T : IComparable
    {
        // fields
        private FaElem<T> gyoker;

        // properties

        // constructors
        public FaHalmaz()
        {
            gyoker = null!;
        }

        public FaHalmaz(FaElem<T> gyoker)
        {
            this.gyoker = gyoker;
        }

        // methods
        public void Beszur(T ertek) => gyoker = ReszfabaBeszur(gyoker, ertek);

        private static FaElem<T> ReszfabaBeszur(FaElem<T> p, T ertek)
        {
            if (p == null!)
                return new FaElem<T>(ertek, null!, null!);

            // ha p értéke nagyobb mint a beszurandó elem => balra kell menni a fában
            // ha a beszurandó elem kisebb mint p értéke => balra kell menni
            if (p.tart.CompareTo(ertek) > 0)
            {
                p.bal = ReszfabaBeszur(p.bal, ertek);
            }
            // ha p értéke kisebb mint a beszurandó elem => jobbra kell menni a fában
            // ha a beszurandó elem nagyobb mint p értéke => jobbra kell menni
            else if (p.tart.CompareTo(ertek) < 0)
            {
                p.jobb = ReszfabaBeszur(p.jobb, ertek);
            }

            return p;
        }

        public bool Eleme(T ertek) => ReszfaEleme(gyoker, ertek);

        private static bool ReszfaEleme(FaElem<T> p, T ertek)
        {
            if (p == null!)
                return false;

            if (p.tart.CompareTo(ertek) > 0)
                return ReszfaEleme(p.bal, ertek);

            if (p.tart.CompareTo(ertek) < 0)
                return ReszfaEleme(p.jobb, ertek);

            return p.tart.CompareTo(ertek) == 0;
        }

        public void Torol(T ertek) => gyoker = ReszfabolTorol(gyoker, ertek);

        private static FaElem<T> ReszfabolTorol(FaElem<T> p, T ertek)
        {
            // hiba jelzése ha nincs elem a fában
            if (p == null!)
                throw new NincsElemKivetel();

            // ha p.tart > ertek
            // haladunk tovább balra a fában
            if (p.tart.CompareTo(ertek) > 0)
            {
                p.bal = ReszfabolTorol(p.bal, ertek);

                // ha p.tart < ertek
                // haladunk tovább jobra a fában
            }
            else if (p.tart.CompareTo(ertek) < 0)
            {
                p.jobb = ReszfabolTorol(p.jobb, ertek);
            }
            // megtaláltuk a törlendő elemet (p)
            else
            {
                // nincs bal oldali gyerek
                // a törlendő gyökérre/szülőre mutató referenciát (p),
                // felülírjuk a jobb oldali (p.jobb) gyerek referenciájával
                // így megtörténik a kiláncolás
                if (p.bal == null!)
                {
                    p = p.jobb;
                }
                else
                {
                    // nincs jobb oldali gyerek
                    // a törlendő gyökérre/szülőre mutató referenciát (p),
                    // felülírjuk a bal oldali (p.jobb) gyerek referenciájával
                    // így megtörténik a kiláncolás

                    if (p.jobb == null!)
                    {
                        p = p.bal;
                    }
                    // van bal és jobb gyerek is
                    else
                    {
                        // felülírjuk a bal oldali gyerek referenciáját
                        // a KetGyerekesTorles() fv. által visszakapott referenciával
                        // => a törlendő elemnél kisebb tartalmú elemek közül a legnagyobbat keresi meg
                        // => a törlendő csomopónt baloldai részfájának legjobboldali eleme lesz a visszatérési érték
                        p.bal = KetGyerekesTorles(p, p.bal);
                    }
                }
            }

            return p;
        }

        private static FaElem<T> KetGyerekesTorles(FaElem<T> e, FaElem<T> r)
        {
            // ha van jobb oldali részfa, rekurzióval addig lépkedünk
            // ameddig ennek értéke nem lesz null
            if (r.jobb != null!)
            {
                r.jobb = KetGyerekesTorles(e, r.jobb);
            }
            // megtaláltuk a törlendp elemnél kisebb tartalmú elemek közül a legnagyobbat
            else
            {
                // felülírjuk a törlendő elem tartalmát
                e.tart = r.tart;

                // kiláncolás
                r = r.bal;
            }

            return r;
        }

        public void Bejar(Action<T> muvelet) => ReszfaBejarasPreOrder(gyoker, muvelet);

        private static void ReszfaBejarasPreOrder(FaElem<T> p, Action<T> muvelet)
        {
            // PreOrder: művelet, bal-oldali részfa, jobb oldali részfa
            // használat => fa teljes elmentése (akár fájlba)

            // null érték esetén kilépünk
            if (p == null!)
                return;

            // elvégezzük a kapott műveletet p.tart-on
            muvelet(p.tart);

            // rekurzívan haladunk a bal oldali részfán tovább
            ReszfaBejarasPreOrder(p.bal, muvelet);

            // rekurzívan haladunk a jobb oldali részfán tovább
            ReszfaBejarasPreOrder(p.jobb, muvelet);
        }

        private static void ReszfaBejarasInOrder(FaElem<T> p, Action<T> muvelet)
        {
            // InOrder: bal-oldali részfa, művelet, jobb oldali részfa
            // használat => fa elemeit kapjuk növekvő módon rendezve

            // null érték esetén kilépünk
            if (p == null!)
                return;

            // rekurzívan haladunk a bal oldali részfán tovább
            ReszfaBejarasInOrder(p.bal, muvelet);

            // elvégezzük a kapott műveletet p.tart-on
            muvelet(p.tart);

            // rekurzívan haladunk a jobb oldali részfán tovább
            ReszfaBejarasInOrder(p.jobb, muvelet);
        }

        private static void ReszfaBejarasPostOrder(FaElem<T> p, Action<T> muvelet)
        {
            // PostOrder: bal-oldali részfa, művelet, jobb oldali részfa
            // használat => fa levélelemeit kapjuk meg először

            // null érték esetén kilépünk
            if (p == null!)
                return;

            // rekurzívan haladunk a bal oldali részfán tovább
            ReszfaBejarasPostOrder(p.bal, muvelet);

            // rekurzívan haladunk a jobb oldali részfán tovább
            ReszfaBejarasPostOrder(p.jobb, muvelet);

            // elvégezzük a kapott műveletet p.tart-on
            muvelet(p.tart);
        }
    }
    #endregion
}

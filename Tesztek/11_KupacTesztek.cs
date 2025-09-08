//using NUnit.Framework;
//using System;
//using OE.ALGA.Adatszerkezetek;

//namespace OE.ALGA.Tesztek.Adatszerkezetek
//{
//    [TestFixture(Category = "Adatszerkezetek", TestName = "11 - Kupac Prioritásos Sor Tesztek")]
//    public class KupacPrioritasosSorTesztek
//    {
//        [TestCase]
//        public void TulSokElemTeszt()
//        {
//            PrioritasosSor<int> s = new KupacPrioritasosSor<int>(2, (x, y) => x > y);
//            s.Sorba(1);
//            s.Sorba(2);
//            Assert.Throws<NincsHelyKivetel>(() => s.Sorba(3));
//        }

//        [TestCase]
//        public void TulKevesElemTeszt()
//        {
//            PrioritasosSor<int> s = new KupacPrioritasosSor<int>(5, (x, y) => x > y);
//            s.Sorba(1);
//            s.Sorba(2);
//            s.Sorba(3);
//            s.Sorbol();
//            s.Sorbol();
//            s.Sorbol();
//            Assert.Throws<NincsElemKivetel>(() => s.Sorbol());
//        }

//        [TestCase]
//        public void UresTeszt()
//        {
//            PrioritasosSor<int> s = new KupacPrioritasosSor<int>(5, (x, y) => x > y);
//            Assert.That(s.Ures, Is.True);
//            s.Sorba(1);
//            Assert.That(s.Ures, Is.False);
//            s.Sorba(2);
//            Assert.That(s.Ures, Is.False);
//            s.Sorbol();
//            Assert.That(s.Ures, Is.False);
//            s.Elso();
//            Assert.That(s.Ures, Is.False);
//            s.Sorbol();
//            Assert.That(s.Ures, Is.True);
//        }

//        [TestCase]
//        public void SorbaSorbolElsoTeszt()
//        {
//            PrioritasosSor<int> s = new KupacPrioritasosSor<int>(10, (x, y) => x > y);
//            s.Sorba(1);
//            s.Sorba(4);
//            Assert.Multiple(() =>
//            {
//                Assert.That(s.Elso(), Is.EqualTo(4));
//                Assert.That(s.Sorbol(), Is.EqualTo(4));
//                Assert.That(s.Elso(), Is.EqualTo(1));
//            });
//            s.Sorba(4);
//            s.Sorba(2);
//            s.Sorba(8);
//            s.Sorba(3);
//            Assert.That(s.Elso(), Is.EqualTo(8));
//            s.Sorba(9);
//            s.Sorba(5);
//            Assert.Multiple(() =>
//            {
//                Assert.That(s.Elso(), Is.EqualTo(9));
//                Assert.That(s.Elso(), Is.EqualTo(9));
//                Assert.That(s.Sorbol(), Is.EqualTo(9));
//                Assert.That(s.Elso(), Is.EqualTo(8));
//            });
//            s.Sorba(7);
//            Assert.Multiple(() =>
//            {
//                Assert.That(s.Sorbol(), Is.EqualTo(8));
//                Assert.That(s.Sorbol(), Is.EqualTo(7));
//                Assert.That(s.Sorbol(), Is.EqualTo(5));
//            });
//            s.Sorba(2);
//            Assert.Multiple(() =>
//            {
//                Assert.That(s.Sorbol(), Is.EqualTo(4));
//                Assert.That(s.Sorbol(), Is.EqualTo(3));
//                Assert.That(s.Sorbol(), Is.EqualTo(2));
//                Assert.That(s.Sorbol(), Is.EqualTo(2));
//                Assert.That(s.Elso(), Is.EqualTo(1));
//                Assert.That(s.Sorbol(), Is.EqualTo(1));
//            });
//        }

//        class PrioritasosSzoveg : IComparable
//        {
//            public string Szoveg { get; set; }
//            public float Prioritas { get; set; }
//            public PrioritasosSzoveg(string szoveg, float prioritas)
//            {
//                this.Szoveg = szoveg;
//                this.Prioritas = prioritas;
//            }

//            public int CompareTo(object? obj)
//            {
//                if (obj is not PrioritasosSzoveg o)
//                    throw new NullReferenceException();
//                else
//                    return Prioritas.CompareTo(o.Prioritas);
//            }
//        }

//        [TestCase]
//        public void PrioritasValtozasTeszt()
//        {
//            PrioritasosSzoveg a = new PrioritasosSzoveg("a", 10.0f);
//            PrioritasosSzoveg b = new PrioritasosSzoveg("b", 5.0f);
//            PrioritasosSzoveg c = new PrioritasosSzoveg("c", 2.0f);
//            PrioritasosSzoveg d = new PrioritasosSzoveg("d", 12.0f);
//            PrioritasosSzoveg e = new PrioritasosSzoveg("e", 15.0f);
//            PrioritasosSzoveg f = new PrioritasosSzoveg("f", 9.0f);
//            PrioritasosSzoveg g = new PrioritasosSzoveg("g", 2.0f);
//            PrioritasosSor<PrioritasosSzoveg> s = new KupacPrioritasosSor<PrioritasosSzoveg>(10, (x, y) => x.CompareTo(y) > 0);
//            s.Sorba(a);
//            s.Sorba(b);
//            s.Sorba(c);
//            s.Sorba(d);
//            s.Sorba(e);
//            Assert.That(s.Elso().Szoveg, Is.EqualTo("e"));
//            d.Prioritas = 22.0f;
//            s.Frissit(d);
//            Assert.That(s.Elso().Szoveg, Is.EqualTo("d"));
//            d.Prioritas = 8.0f;
//            s.Frissit(d);
//            e.Prioritas = 7.0f;
//            s.Frissit(e);
//            Assert.That(s.Sorbol().Szoveg, Is.EqualTo("a"));
//            s.Sorba(f);
//            s.Sorba(g);
//            Assert.Multiple(() =>
//            {
//                Assert.That(s.Sorbol().Szoveg, Is.EqualTo("f"));
//                Assert.That(s.Sorbol().Szoveg, Is.EqualTo("d"));
//                Assert.That(s.Sorbol().Szoveg, Is.EqualTo("e"));
//                Assert.That(s.Sorbol().Szoveg, Is.EqualTo("b"));
//            });
//            c.Prioritas = 1.5f;
//            s.Frissit(c);
//            Assert.Multiple(() =>
//            {
//                Assert.That(s.Sorbol().Szoveg, Is.EqualTo("g"));
//                Assert.That(s.Sorbol().Szoveg, Is.EqualTo("c"));
//                Assert.That(s.Ures, Is.True);
//            });
//        }
//    }

//    [TestFixture(Category = "Adatszerkezetek", TestName = "11 - Kupac Külső Fügvénnyel Tesztek")]
//    public class KupacKulsoFuggvennyelTesztek
//    {
//        /// <summary>
//        /// Nincs külön rendező függvény, ezért ABC sorrendben rendez az IComparable alapján.
//        /// </summary>
//        [TestCase]
//        public void KupacEpitesIComparableAlapjan()
//        {
//            KupacPrioritasosSor<string> ps = new KupacPrioritasosSor<string>(10, (x, y) => x.CompareTo(y) > 0);
//            ps.Sorba("oszibarack");
//            ps.Sorba("alma");
//            ps.Sorba("korte");
//            ps.Sorba("birsalma");
//            ps.Sorba("barack");
//            ps.Sorba("dio");
//            Assert.Multiple(() =>
//            {
//                Assert.That(ps.Sorbol(), Is.EqualTo("oszibarack"));
//                Assert.That(ps.Sorbol(), Is.EqualTo("korte"));
//                Assert.That(ps.Sorbol(), Is.EqualTo("dio"));
//                Assert.That(ps.Sorbol(), Is.EqualTo("birsalma"));
//                Assert.That(ps.Sorbol(), Is.EqualTo("barack"));
//                Assert.That(ps.Sorbol(), Is.EqualTo("alma"));
//            });
//        }

//        /// <summary>
//        /// Van egy saját hossz alapú rendező függvény, ezért elsőként a leghosszabb stringeket adja vissza.
//        /// </summary>
//        [TestCase]
//        public void KupacEpitesSajatFuggvennyel()
//        {
//            KupacPrioritasosSor<string> ps = new KupacPrioritasosSor<string>(10, (ez, ennel) => ez.Length > ennel.Length);
//            ps.Sorba("oszibarack");
//            ps.Sorba("alma");
//            ps.Sorba("korte");
//            ps.Sorba("birsalma");
//            ps.Sorba("barack");
//            ps.Sorba("dio");
//            Assert.Multiple(() =>
//            {
//                Assert.That(ps.Sorbol(), Is.EqualTo("oszibarack"));
//                Assert.That(ps.Sorbol(), Is.EqualTo("birsalma"));
//                Assert.That(ps.Sorbol(), Is.EqualTo("barack"));
//                Assert.That(ps.Sorbol(), Is.EqualTo("korte"));
//                Assert.That(ps.Sorbol(), Is.EqualTo("alma"));
//                Assert.That(ps.Sorbol(), Is.EqualTo("dio"));
//            });
//        }
//    }

//    [TestFixture(Category = "Adatszerkezetek", TestName = "11 - Kupac Rendezés Tesztek")]
//    public class KupacRendezesTesztek
//    {
//        [TestCase]
//        public void KupacEpites()
//        {
//            int[] A = [1, 3, 2, 4, 9, 12, 32, 21, 12, 8, 11];
//            _ = new Kupac<int>(A, A.Length, (x, y) => x > y);

//            Assert.Multiple(() =>
//            {
//                for (int i = 1; i < A.Length; i++)
//                    Assert.That(A[Kupac<int>.Szulo(i)] >= A[i], Is.True);
//            });
//        }

//        [TestCase]
//        public void KupacRendezes()
//        {
//            int[] A = [5, 8, 7, 0, 9, 6, 4, 1, 3, 2];
//            KupacRendezes<int> k = new KupacRendezes<int>(A);
//            k.Rendezes();

//            Assert.Multiple(() =>
//            {
//                for (int i = 1; i < A.Length; i++)
//                    Assert.That(A[i], Is.EqualTo(i));
//            });
//        }
//    }
//}

//using NUnit.Framework;
//using OE.ALGA.Adatszerkezetek;

//namespace OE.ALGA.Tesztek.Adatszerkezetek
//{
//    [TestFixture(Category = "Adatszerkezetek", TestName = "04 - Lancolt Lista Tesztek")]
//    public class LancoltListaTesztek
//    {
//        [TestCase]
//        public void Elemszam()
//        {
//            Lista<string> l = new LancoltLista<string>();
//            Assert.That(l.Elemszam, Is.EqualTo(0));
//            l.Hozzafuz("A");
//            Assert.That(l.Elemszam, Is.EqualTo(1));
//            l.Hozzafuz("B");
//            Assert.That(l.Elemszam, Is.EqualTo(2));
//            l.Torol("A");
//            Assert.That(l.Elemszam, Is.EqualTo(1));
//        }
//        [TestCase]
//        public void Bejaras()
//        {
//            Lista<int> l = new LancoltLista<int>();
//            l.Hozzafuz(1);
//            l.Hozzafuz(3);
//            l.Hozzafuz(2);
//            string s = "";
//            l.Bejar(x => { Guardian.Recursion.CheckStackTrace(); s += x.ToString(); });
//            Assert.That(s, Is.EqualTo("132"));
//        }
//        [TestCase]
//        public void Beszuras()
//        {
//            Lista<int> l = new LancoltLista<int>();
//            l.Beszur(0, 1);
//            l.Beszur(0, 2);
//            l.Beszur(1, 3);
//            l.Beszur(3, 4);
//            l.Beszur(2, 5);
//            Assert.Multiple(() =>
//            {
//                Assert.That(l.Kiolvas(0), Is.EqualTo(2));
//                Assert.That(l.Kiolvas(1), Is.EqualTo(3));
//                Assert.That(l.Kiolvas(2), Is.EqualTo(5));
//                Assert.That(l.Kiolvas(3), Is.EqualTo(1));
//                Assert.That(l.Kiolvas(4), Is.EqualTo(4));
//            });
//        }
//        [TestCase]
//        public void BeszurasUres()
//        {
//            Lista<string> l = new LancoltLista<string>();
//            l.Beszur(0, "1");
//            l.Beszur(0, "2");
//            l.Beszur(1, "");
//            l.Beszur(3, "");
//            l.Beszur(2, "5");
//            Assert.Multiple(() =>
//            {
//                Assert.That(l.Kiolvas(0), Is.EqualTo("2"));
//                Assert.That(l.Kiolvas(1), Is.EqualTo(""));
//                Assert.That(l.Kiolvas(2), Is.EqualTo("5"));
//                Assert.That(l.Kiolvas(3), Is.EqualTo("1"));
//                Assert.That(l.Kiolvas(4), Is.EqualTo(""));
//            });
//        }
//        [TestCase]
//        public void HozzaFuzes()
//        {
//            Lista<int> l = new LancoltLista<int>();
//            l.Hozzafuz(1);
//            l.Hozzafuz(3);
//            l.Hozzafuz(2);
//            Assert.Multiple(() =>
//            {
//                Assert.That(l.Kiolvas(0), Is.EqualTo(1));
//                Assert.That(l.Kiolvas(1), Is.EqualTo(3));
//                Assert.That(l.Kiolvas(2), Is.EqualTo(2));
//            });
//        }
//        [TestCase]
//        public void HozzaFuzesUres()
//        {
//            Lista<string> l = new LancoltLista<string>();
//            l.Hozzafuz("1");
//            l.Hozzafuz("");
//            l.Hozzafuz("");
//            l.Hozzafuz("1");
//            Assert.Multiple(() =>
//            {
//                Assert.That(l.Kiolvas(0), Is.EqualTo("1"));
//                Assert.That(l.Kiolvas(1), Is.EqualTo(""));
//                Assert.That(l.Kiolvas(2), Is.EqualTo(""));
//                Assert.That(l.Kiolvas(3), Is.EqualTo("1"));
//            });
//        }
//        [TestCase]
//        public void Novekedes()
//        {
//            Lista<int> l = new LancoltLista<int>();
//            for (int i = 0; i < 1000; i++)
//                l.Hozzafuz(i * i);
//            Assert.That(l.Elemszam, Is.EqualTo(1000));
//            Assert.Multiple(() =>
//            {
//                for (int i = 0; i < 1000; i++)
//                    Assert.That(l.Kiolvas(i), Is.EqualTo(i * i));
//            });
//            Assert.That(l.Elemszam, Is.EqualTo(1000));
//        }
//        [TestCase]
//        public void Torles()
//        {
//            Lista<int> l = new LancoltLista<int>();
//            l.Hozzafuz(1);
//            l.Hozzafuz(3);
//            l.Hozzafuz(2);
//            l.Hozzafuz(3);
//            l.Hozzafuz(4);
//            Assert.That(l.Elemszam, Is.EqualTo(5));
//            l.Torol(3);
//            Assert.That(l.Elemszam, Is.EqualTo(3));
//            Assert.Multiple(() =>
//            {
//                Assert.That(l.Kiolvas(0), Is.EqualTo(1));
//                Assert.That(l.Kiolvas(1), Is.EqualTo(2));
//                Assert.That(l.Kiolvas(2), Is.EqualTo(4));
//            });
//        }
//        [TestCase]
//        public void TorlesNincsElem()
//        {
//            Lista<int> l = new LancoltLista<int>();
//            Assert.That(l.Elemszam, Is.EqualTo(0));
//            l.Torol(0);
//            Assert.That(l.Elemszam, Is.EqualTo(0));
//        }
//        [TestCase]
//        public void TorlesUres()
//        {
//            Lista<string> l = new LancoltLista<string>();
//            l.Hozzafuz("1");
//            l.Hozzafuz("");
//            l.Hozzafuz("");
//            l.Hozzafuz("");
//            l.Hozzafuz("1");
//            Assert.That(l.Elemszam, Is.EqualTo(5));
//            l.Torol("");
//            Assert.That(l.Elemszam, Is.EqualTo(2));
//            Assert.Multiple(() =>
//            {
//                Assert.That(l.Kiolvas(0), Is.EqualTo("1"));
//                Assert.That(l.Kiolvas(1), Is.EqualTo("1"));
//            });
//        }
//        [TestCase]
//        public void NemletezoTorles()
//        {
//            Lista<int> l = new LancoltLista<int>();
//            l.Hozzafuz(1);
//            l.Hozzafuz(2);
//            l.Hozzafuz(3);
//            Assert.That(l.Elemszam, Is.EqualTo(3));
//            l.Torol(0);
//            Assert.That(l.Elemszam, Is.EqualTo(3));
//            Assert.Multiple(() =>
//            {
//                Assert.That(l.Kiolvas(0), Is.EqualTo(1));
//                Assert.That(l.Kiolvas(1), Is.EqualTo(2));
//                Assert.That(l.Kiolvas(2), Is.EqualTo(3));
//            });
//        }
//        [TestCase]
//        public void Modositas()
//        {
//            Lista<int> l = new LancoltLista<int>();
//            l.Hozzafuz(1);
//            l.Hozzafuz(3);
//            l.Hozzafuz(2);
//            l.Modosit(1, 5);
//            l.Modosit(0, 4);
//            Assert.Multiple(() =>
//            {
//                Assert.That(l.Kiolvas(0), Is.EqualTo(4));
//                Assert.That(l.Kiolvas(1), Is.EqualTo(5));
//                Assert.That(l.Kiolvas(2), Is.EqualTo(2));
//            });
//        }
//        [TestCase]
//        public void ForeachBejaras()
//        {
//            LancoltLista<string> l = new LancoltLista<string>();
//            l.Hozzafuz("a");
//            l.Hozzafuz("c");
//            l.Hozzafuz("d");
//            l.Hozzafuz("b");
//            string osszefuzo = "";
//            foreach (string x in l)
//            {
//                osszefuzo += x;
//            }
//            Assert.That(osszefuzo, Is.EqualTo("acdb"));
//        }
//    }

//    [TestFixture(Category = "Adatszerkezetek", TestName = "04 - Lancolt Sor Tesztek")]
//    public class LancoltSorTesztek
//    {
//        [TestCase]
//        public void Ures()
//        {
//            Sor<int> s = new LancoltSor<int>();
//            Assert.That(s.Ures, Is.True);
//            Assert.Throws<NincsElemKivetel>(() => s.Elso());
//            Assert.Throws<NincsElemKivetel>(() => s.Sorbol());
//            s.Sorba(1);
//            Assert.That(s.Ures, Is.False);
//            s.Sorbol();
//            Assert.That(s.Ures, Is.True);
//        }
//        [TestCase]
//        public void AlapMukodes()
//        {
//            Sor<int> s = new LancoltSor<int>();
//            s.Sorba(1);
//            s.Sorba(3);
//            s.Sorba(2);
//            Assert.Multiple(() =>
//            {
//                Assert.That(s.Sorbol(), Is.EqualTo(1));
//                Assert.That(s.Sorbol(), Is.EqualTo(3));
//                Assert.That(s.Sorbol(), Is.EqualTo(2));
//            });
//        }
//        [TestCase]
//        public void UresElem()
//        {
//            Sor<string> s = new LancoltSor<string>();
//            s.Sorba("");
//            s.Sorba("1");
//            s.Sorba("");
//            Assert.Multiple(() =>
//            {
//                Assert.That(s.Sorbol(), Is.EqualTo(""));
//                Assert.That(s.Sorbol(), Is.EqualTo("1"));
//                Assert.That(s.Sorbol(), Is.EqualTo(""));
//            });
//        }
//        [TestCase]
//        public void TulKevesElem()
//        {
//            Sor<int> s = new LancoltSor<int>();
//            s.Sorba(1);
//            s.Sorba(3);
//            s.Sorba(2);
//            s.Sorbol();
//            s.Sorbol();
//            s.Sorbol();
//            Assert.Throws<NincsElemKivetel>(() => s.Sorbol());
//        }
//        [TestCase]
//        public void Elso()
//        {
//            Sor<int> s = new LancoltSor<int>();
//            s.Sorba(1);
//            s.Sorba(3);
//            s.Sorba(2);
//            Assert.Multiple(() =>
//            {
//                Assert.That(s.Elso(), Is.EqualTo(1));
//                Assert.That(s.Elso(), Is.EqualTo(1));
//            });
//            s.Sorbol();
//            Assert.That(s.Elso(), Is.EqualTo(3));
//        }
//    }

//    [TestFixture(Category = "Adatszerkezetek", TestName = "04 - Lancolt Verem Tesztek")]
//    public class LancoltVeremTesztek
//    {
//        [TestCase]
//        public void Ures()
//        {
//            Verem<int> v = new LancoltVerem<int>();
//            Assert.That(v.Ures, Is.True);
//            Assert.Throws<NincsElemKivetel>(() => v.Felso());
//            Assert.Throws<NincsElemKivetel>(() => v.Verembol());
//            v.Verembe(1);
//            Assert.That(v.Ures, Is.False);
//            v.Verembol();
//            Assert.That(v.Ures, Is.True);
//        }
//        [TestCase]
//        public void AlapMukodes()
//        {
//            Verem<int> v = new LancoltVerem<int>();
//            v.Verembe(1);
//            v.Verembe(3);
//            v.Verembe(2);
//            Assert.That(v.Verembol(), Is.EqualTo(2));
//            v.Verembe(4);
//            Assert.Multiple(() =>
//            {
//                Assert.That(v.Verembol(), Is.EqualTo(4));
//                Assert.That(v.Verembol(), Is.EqualTo(3));
//                Assert.That(v.Verembol(), Is.EqualTo(1));
//            });
//        }
//        [TestCase]
//        public void UresElem()
//        {
//            Verem<string> v = new LancoltVerem<string>();
//            v.Verembe("");
//            v.Verembe("1");
//            v.Verembe("");
//            Assert.Multiple(() =>
//            {
//                Assert.That(v.Verembol(), Is.EqualTo(""));
//                Assert.That(v.Verembol(), Is.EqualTo("1"));
//                Assert.That(v.Verembol(), Is.EqualTo(""));
//            });
//        }
//        [TestCase]
//        public void TulKevesElem()
//        {
//            Verem<int> v = new LancoltVerem<int>();
//            v.Verembe(1);
//            v.Verembe(3);
//            v.Verembe(2);
//            v.Verembol();
//            v.Verembol();
//            v.Verembol();
//            Assert.Throws<NincsElemKivetel>(() => v.Verembol());
//        }
//        [TestCase]
//        public void Felso()
//        {
//            Verem<int> v = new LancoltVerem<int>();
//            v.Verembe(1);
//            v.Verembe(3);
//            v.Verembe(2);
//            Assert.Multiple(() =>
//            {
//                Assert.That(v.Felso(), Is.EqualTo(2));
//                Assert.That(v.Felso(), Is.EqualTo(2));
//            });
//            v.Verembol();
//            Assert.That(v.Felso(), Is.EqualTo(3));
//        }

//    }
//}
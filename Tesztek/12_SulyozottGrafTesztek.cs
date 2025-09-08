//using NUnit.Framework;
//using OE.ALGA.Adatszerkezetek;

//namespace OE.ALGA.Tesztek.Adatszerkezetek
//{
//    [TestFixture(Category = "Adatszerkezetek", TestName = "12 - Csúcs Mátrix Súlyozott Gráf Tesztek")]
//    public class CsucsMatrixSulyozottGrafTesztek
//    {
//        [TestCase]
//        public void MindenCsucsTeszt()
//        {
//            CsucsmatrixSulyozottEgeszGraf csg = new CsucsmatrixSulyozottEgeszGraf(2);
//            Assert.Multiple(() =>
//            {
//                Assert.That(csg.Csucsok.Eleme(0), Is.True);
//                Assert.That(csg.Csucsok.Eleme(1), Is.True);
//            });
//        }

//        [TestCase]
//        public void MindenElTeszt()
//        {
//            CsucsmatrixSulyozottEgeszGraf csg = new CsucsmatrixSulyozottEgeszGraf(3);
//            csg.UjEl(0, 1, 1.0f);
//            csg.UjEl(0, 2, 2.0f);
//            csg.UjEl(1, 2, 3.0f);

//            Assert.Multiple(() =>
//            {
//                Assert.That(csg.Elek.Eleme(new SulyozottEgeszGrafEl(0, 0, 0.0f)), Is.False);
//                Assert.That(csg.Elek.Eleme(new SulyozottEgeszGrafEl(0, 1, 1.0f)), Is.True);
//                Assert.That(csg.Elek.Eleme(new SulyozottEgeszGrafEl(0, 2, 2.0f)), Is.True);

//                Assert.That(csg.Elek.Eleme(new SulyozottEgeszGrafEl(1, 0, 0.0f)), Is.False);
//                Assert.That(csg.Elek.Eleme(new SulyozottEgeszGrafEl(1, 1, 0.0f)), Is.False);
//                Assert.That(csg.Elek.Eleme(new SulyozottEgeszGrafEl(1, 2, 3.0f)), Is.True);

//                Assert.That(csg.Elek.Eleme(new SulyozottEgeszGrafEl(2, 0, 0.0f)), Is.False);
//                Assert.That(csg.Elek.Eleme(new SulyozottEgeszGrafEl(2, 1, 0.0f)), Is.False);
//                Assert.That(csg.Elek.Eleme(new SulyozottEgeszGrafEl(2, 2, 0.0f)), Is.False);
//            });
//        }

//        [TestCase]
//        public void VezetElTeszt()
//        {
//            CsucsmatrixSulyozottEgeszGraf csg = new CsucsmatrixSulyozottEgeszGraf(2);
//            Assert.That(csg.VezetEl(0, 1), Is.False);
//            csg.UjEl(0, 1, 1.0f);
//            Assert.Multiple(() =>
//            {
//                Assert.That(csg.VezetEl(0, 1), Is.True);
//                Assert.That(csg.VezetEl(1, 0), Is.False);
//            });
//        }

//        [TestCase]
//        public void SzomszedsagTeszt()
//        {
//            CsucsmatrixSulyozottEgeszGraf csg = new CsucsmatrixSulyozottEgeszGraf(3);
//            csg.UjEl(0, 1, 1.0f);
//            csg.UjEl(0, 2, 1.0f);
//            csg.UjEl(1, 2, 1.0f);

//            Halmaz<int> a_szomszedai = csg.Szomszedai(0);
//            Halmaz<int> b_szomszedai = csg.Szomszedai(1);
//            Halmaz<int> c_szomszedai = csg.Szomszedai(2);

//            Assert.Multiple(() =>
//            {
//                Assert.That(a_szomszedai.Eleme(0), Is.False);
//                Assert.That(a_szomszedai.Eleme(1), Is.True);
//                Assert.That(a_szomszedai.Eleme(2), Is.True);

//                Assert.That(b_szomszedai.Eleme(0), Is.False);
//                Assert.That(b_szomszedai.Eleme(1), Is.False);
//                Assert.That(b_szomszedai.Eleme(2), Is.True);

//                Assert.That(c_szomszedai.Eleme(0), Is.False);
//                Assert.That(c_szomszedai.Eleme(1), Is.False);
//                Assert.That(c_szomszedai.Eleme(2), Is.False);
//            });
//        }

//        [TestCase]
//        public void NemLetezoElTeszt()
//        {
//            CsucsmatrixSulyozottEgeszGraf csg = new CsucsmatrixSulyozottEgeszGraf(3);
//            csg.UjEl(0, 1, 1.0f);
//            csg.UjEl(0, 2, 1.0f);
//            Assert.Throws<NincsElKivetel>(() => csg.Suly(1, 0));
//        }

//        [TestCase]
//        public void ElSulyTeszt()
//        {
//            CsucsmatrixSulyozottEgeszGraf csg = new CsucsmatrixSulyozottEgeszGraf(3);
//            csg.UjEl(0, 1, 2.0f);
//            csg.UjEl(0, 2, 3.0f);
//            float szum = 0.0f;
//            csg.Elek.Bejar(x => szum += csg.Suly(x.Honnan, x.Hova));
//            Assert.That(szum, Is.EqualTo(5.0f));
//        }
//    }

//    [TestFixture(Category = "Adatszerkezetek", TestName = "12 - Gráf Min Feszítőfa Tesztek")]
//    public class GrafMinFeszitofaTesztek
//    {
//        [TestCase]
//        public void KisPrimTeszt()
//        {
//            CsucsmatrixSulyozottEgeszGraf csg = new CsucsmatrixSulyozottEgeszGraf(3);
//            csg.UjEl(0, 1, 10.0f);
//            csg.UjEl(0, 2, 20.0f);
//            csg.UjEl(1, 2, 5.0f);
//            Szotar<int, int> elek = FeszitofaKereses.Prim(csg, 0);
//            Assert.Multiple(() =>
//            {
//                Assert.That(elek.Kiolvas(1), Is.EqualTo(0));
//                Assert.That(elek.Kiolvas(2), Is.EqualTo(1));
//            });
//        }

//        [TestCase]
//        public void NagyPrimTeszt()
//        {
//            CsucsmatrixSulyozottEgeszGraf csg = new CsucsmatrixSulyozottEgeszGraf(5);
//            csg.UjEl(0, 1, 5.0f);
//            csg.UjEl(0, 3, 4.0f);

//            csg.UjEl(1, 0, 5.0f);
//            csg.UjEl(1, 3, 2.0f);
//            csg.UjEl(1, 2, 1.0f);

//            csg.UjEl(2, 1, 1.0f);
//            csg.UjEl(2, 3, 3.0f);
//            csg.UjEl(2, 4, 4.0f);

//            csg.UjEl(3, 0, 4.0f);
//            csg.UjEl(3, 1, 2.0f);
//            csg.UjEl(3, 2, 3.0f);
//            csg.UjEl(3, 4, 1.0f);

//            csg.UjEl(4, 2, 4.0f);
//            csg.UjEl(4, 3, 1.0f);

//            Szotar<int, int> elek = FeszitofaKereses.Prim(csg, 0);
//            float sum = 0.0f;
//            csg.Csucsok.Bejar(x =>
//            {
//                if (x != 0)
//                {
//                    int p = elek.Kiolvas(x);
//                    sum += csg.Suly(p, x);
//                }
//            }
//            );
//            Assert.That(sum, Is.EqualTo(8.0f));
//        }

//        [TestCase]
//        public void KisKruskalTeszt()
//        {
//            CsucsmatrixSulyozottEgeszGraf csg = new CsucsmatrixSulyozottEgeszGraf(3);
//            csg.UjEl(0, 1, 10.0f);
//            csg.UjEl(0, 2, 20.0f);
//            csg.UjEl(1, 2, 5.0f);
//            Halmaz<SulyozottEgeszGrafEl> elek = FeszitofaKereses.Kruskal(csg);
//            Assert.Multiple(() =>
//            {
//                Assert.That(elek.Eleme(new SulyozottEgeszGrafEl(0, 1, 10.0f)), Is.True);
//                Assert.That(elek.Eleme(new SulyozottEgeszGrafEl(0, 2, 20.0f)), Is.False);
//                Assert.That(elek.Eleme(new SulyozottEgeszGrafEl(1, 2, 5.0f)), Is.True);
//            });
//        }

//        [TestCase]
//        public void NagyKruskalTeszt()
//        {
//            CsucsmatrixSulyozottEgeszGraf csg = new CsucsmatrixSulyozottEgeszGraf(5);
//            csg.UjEl(0, 1, 5.0f);
//            csg.UjEl(0, 3, 4.0f);

//            csg.UjEl(1, 0, 5.0f);
//            csg.UjEl(1, 3, 2.0f);
//            csg.UjEl(1, 2, 1.0f);

//            csg.UjEl(2, 1, 1.0f);
//            csg.UjEl(2, 3, 3.0f);
//            csg.UjEl(2, 4, 4.0f);

//            csg.UjEl(3, 0, 4.0f);
//            csg.UjEl(3, 1, 2.0f);
//            csg.UjEl(3, 2, 3.0f);
//            csg.UjEl(3, 4, 1.0f);

//            csg.UjEl(4, 2, 4.0f);
//            csg.UjEl(4, 3, 1.0f);

//            Halmaz<SulyozottEgeszGrafEl> elek = FeszitofaKereses.Kruskal(csg);
//            float sum = 0.0f;
//            elek.Bejar(x =>
//            {
//                sum += x.Suly;
//            }
//            );
//            Assert.That(sum, Is.EqualTo(8.0f));
//        }
//    }

//    [TestFixture(Category = "Adatszerkezetek", TestName = "12 - Gráf Útkeresés Tesztek")]
//    public class GrafUtkeresesTesztek
//    {
//        [TestCase]
//        public void DijkstraKicsiGrafTeszt()
//        {
//            CsucsmatrixSulyozottEgeszGraf csg = new CsucsmatrixSulyozottEgeszGraf(3);
//            csg.UjEl(0, 1, 10.0f);
//            csg.UjEl(0, 2, 20.0f);
//            Szotar<int, float> hossz = Utkereses.Dijkstra(csg, 0);
//            Assert.Multiple(() =>
//            {
//                Assert.That(hossz.Kiolvas(0), Is.EqualTo(0.0f));
//                Assert.That(hossz.Kiolvas(1), Is.EqualTo(10.0f));
//                Assert.That(hossz.Kiolvas(2), Is.EqualTo(20.0f));
//            });

//            csg.UjEl(1, 2, 5.0f);
//            hossz = Utkereses.Dijkstra(csg, 0);
//            Assert.Multiple(() =>
//            {
//                Assert.That(hossz.Kiolvas(0), Is.EqualTo(0.0f));
//                Assert.That(hossz.Kiolvas(1), Is.EqualTo(10.0f));
//                Assert.That(hossz.Kiolvas(2), Is.EqualTo(15.0f));
//            });
//        }

//        [TestCase]
//        public void DijkstraJegyzetGrafTeszt()
//        {
//            CsucsmatrixSulyozottEgeszGraf csg = new CsucsmatrixSulyozottEgeszGraf(7);
//            csg.UjEl(0, 1, 1.0f);
//            csg.UjEl(0, 3, 2.0f);
//            csg.UjEl(0, 4, 4.0f);

//            csg.UjEl(1, 0, 1.0f);
//            csg.UjEl(1, 3, 2.0f);
//            csg.UjEl(1, 2, 9.0f);

//            csg.UjEl(2, 1, 9.0f);
//            csg.UjEl(2, 3, 5.0f);
//            csg.UjEl(2, 5, 1.0f);

//            csg.UjEl(3, 0, 2.0f);
//            csg.UjEl(3, 1, 2.0f);
//            csg.UjEl(3, 2, 5.0f);
//            csg.UjEl(3, 5, 3.0f);

//            csg.UjEl(5, 2, 1.0f);
//            csg.UjEl(5, 3, 3.0f);
//            csg.UjEl(5, 6, 3.0f);

//            csg.UjEl(6, 5, 3.0f);

//            Szotar<int, float> hossz = Utkereses.Dijkstra(csg, 1);
//            Assert.Multiple(() =>
//            {
//                Assert.That(hossz.Kiolvas(0), Is.EqualTo(1.0f));
//                Assert.That(hossz.Kiolvas(1), Is.EqualTo(0.0f));
//                Assert.That(hossz.Kiolvas(2), Is.EqualTo(6.0f));
//                Assert.That(hossz.Kiolvas(3), Is.EqualTo(2.0f));
//                Assert.That(hossz.Kiolvas(4), Is.EqualTo(5.0f));
//                Assert.That(hossz.Kiolvas(5), Is.EqualTo(5.0f));
//                Assert.That(hossz.Kiolvas(6), Is.EqualTo(8.0f));
//            });
//        }
//    }
//}

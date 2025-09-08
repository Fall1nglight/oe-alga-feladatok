//using NUnit.Framework;
//using OE.ALGA.Adatszerkezetek;


//namespace OE.ALGA.Tesztek.Adatszerkezetek
//{
//    [TestFixture(Category = "Adatszerkezetek", TestName = "10 - Csúcsmátrix Gráf Tesztek")]
//    public class CsucsMatrixGrafTesztek
//    {
//        [TestCase]
//        public void MindenCsucsTeszt()
//        {
//            CsucsmatrixSulyozatlanEgeszGraf csg = new CsucsmatrixSulyozatlanEgeszGraf(2);
//            Assert.Multiple(() =>
//            {
//                Assert.That(csg.Csucsok.Eleme(0), Is.True);
//                Assert.That(csg.Csucsok.Eleme(1), Is.True);
//            });
//        }

//        [TestCase]
//        public void MindenElTeszt()
//        {
//            CsucsmatrixSulyozatlanEgeszGraf csg = new CsucsmatrixSulyozatlanEgeszGraf(3);
//            csg.UjEl(0, 1);
//            csg.UjEl(0, 2);
//            csg.UjEl(1, 2);

//            Assert.Multiple(() =>
//            {
//                Assert.That(csg.Elek.Eleme(new EgeszGrafEl(0, 0)), Is.False);
//                Assert.That(csg.Elek.Eleme(new EgeszGrafEl(0, 1)), Is.True);
//                Assert.That(csg.Elek.Eleme(new EgeszGrafEl(0, 2)), Is.True);

//                Assert.That(csg.Elek.Eleme(new EgeszGrafEl(1, 0)), Is.False);
//                Assert.That(csg.Elek.Eleme(new EgeszGrafEl(1, 1)), Is.False);
//                Assert.That(csg.Elek.Eleme(new EgeszGrafEl(1, 2)), Is.True);

//                Assert.That(csg.Elek.Eleme(new EgeszGrafEl(2, 0)), Is.False);
//                Assert.That(csg.Elek.Eleme(new EgeszGrafEl(2, 1)), Is.False);
//                Assert.That(csg.Elek.Eleme(new EgeszGrafEl(2, 2)), Is.False);
//            });
//        }

//        [TestCase]
//        public void VezetElTeszt()
//        {
//            CsucsmatrixSulyozatlanEgeszGraf csg = new CsucsmatrixSulyozatlanEgeszGraf(2);
//            Assert.That(csg.VezetEl(0, 1), Is.False);
//            csg.UjEl(0, 1);
//            Assert.Multiple(() =>
//            {
//                Assert.That(csg.VezetEl(0, 1), Is.True);
//                Assert.That(csg.VezetEl(1, 0), Is.False);
//            });
//        }

//        [TestCase]
//        public void SzomszedsagTeszt()
//        {
//            CsucsmatrixSulyozatlanEgeszGraf csg = new CsucsmatrixSulyozatlanEgeszGraf(3);
//            csg.UjEl(0, 1);
//            csg.UjEl(0, 2);
//            csg.UjEl(1, 2);

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
//    }

//    [TestFixture(Category = "Adatszerkezetek", TestName = "10 - Gráf Bejárás Tesztek")]
//    public class GrafBejarasTesztek
//    {
//        [TestCase]
//        public void SzelessegiBejarasTeszt()
//        {
//            CsucsmatrixSulyozatlanEgeszGraf g = new CsucsmatrixSulyozatlanEgeszGraf(6);
//            g.UjEl(0, 1);
//            g.UjEl(1, 2);
//            g.UjEl(1, 4);
//            g.UjEl(2, 3);
//            g.UjEl(2, 4);
//            g.UjEl(4, 3);
//            g.UjEl(3, 0);

//            string ut = "";
//            Halmaz<int> elertCsucsok = GrafBejarasok.SzelessegiBejaras(g, 0, (a) => { ut += a; });

//            Assert.Multiple(() =>
//            {
//                Assert.That(ut == "01243" || ut == "01423", Is.True);
//                for (int i = 0; i <= 4; i++)
//                    Assert.That(elertCsucsok.Eleme(i), Is.True);
//                Assert.That(elertCsucsok.Eleme(6), Is.False);
//            });
//        }

//        [TestCase]
//        public void MelysegiBejarasTeszt()
//        {
//            CsucsmatrixSulyozatlanEgeszGraf g = new CsucsmatrixSulyozatlanEgeszGraf(6);
//            g.UjEl(0, 1);
//            g.UjEl(1, 2);
//            g.UjEl(1, 4);
//            g.UjEl(2, 3);
//            g.UjEl(2, 4);
//            g.UjEl(4, 3);
//            g.UjEl(3, 0);

//            string ut = "";
//            Halmaz<int> elertCsucsok = GrafBejarasok.MelysegiBejaras(g, 0, (a) => { ut += a; });

//            Assert.Multiple(() =>
//            {
//                Assert.That(ut == "01243" || ut == "01432" || ut == "01234", Is.True);
//                for (int i = 0; i <= 4; i++)
//                    Assert.That(elertCsucsok.Eleme(i), Is.True);
//                Assert.That(elertCsucsok.Eleme(6), Is.False);
//            });
//        }
//    }
//}

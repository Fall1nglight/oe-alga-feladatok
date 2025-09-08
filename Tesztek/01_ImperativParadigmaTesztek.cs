//using NUnit.Framework;
//using OE.ALGA.Paradigmak;


//namespace OE.ALGA.Tesztek.Paradigmak
//{
//    [TestFixture(Category = "Paradigmák", TestName = "01 - Feladat Tároló Tesztek")]
//    public class FeladatTaroloTesztek
//    {
//        [TestCase]
//        public void Ures()
//        {
//            FeladatTarolo<TesztFeladat> tarolo = new FeladatTarolo<TesztFeladat>(0);
//            TesztFeladat a = new TesztFeladat("a");
//            Assert.Throws<TaroloMegteltKivetel>(() => tarolo.Felvesz(a));
//        }
//        [TestCase]
//        public void Felvesz()
//        {
//            FeladatTarolo<TesztFeladat> tarolo = new FeladatTarolo<TesztFeladat>(5);
//            TesztFeladat a = new TesztFeladat("a");
//            tarolo.Felvesz(a);
//            tarolo.Felvesz(a);
//            tarolo.Felvesz(a);
//        }

//        [TestCase]
//        public void TulsokatFelvesz()
//        {
//            FeladatTarolo<TesztFeladat> tarolo = new FeladatTarolo<TesztFeladat>(3);
//            TesztFeladat a = new TesztFeladat("a");
//            tarolo.Felvesz(a);
//            tarolo.Felvesz(a);
//            tarolo.Felvesz(a);
//            Assert.Throws<TaroloMegteltKivetel>(() => tarolo.Felvesz(a));
//        }
//        [TestCase]
//        public void NincsMitVegrehajtani()
//        {
//            FeladatTarolo<TesztFeladat> tarolo = new FeladatTarolo<TesztFeladat>(2);
//            tarolo.MindentVegrehajt();
//        }
//        [TestCase]
//        public void MindentVegrehajt()
//        {
//            FeladatTarolo<TesztFeladat> tarolo = new FeladatTarolo<TesztFeladat>(2);
//            TesztFeladat a = new TesztFeladat("a");
//            TesztFeladat b = new TesztFeladat("b");
//            tarolo.Felvesz(a);
//            tarolo.Felvesz(b);
//            Assert.Multiple(() =>
//            {
//                Assert.That(a.Vegrehajtott, Is.False);
//                Assert.That(b.Vegrehajtott, Is.False);
//            });
//            tarolo.MindentVegrehajt();
//            Assert.Multiple(() =>
//            {
//                Assert.That(a.Vegrehajtott, Is.True);
//                Assert.That(b.Vegrehajtott, Is.True);
//            });
//        }
//        [TestCase]
//        public void FelvettetVegrehajt()
//        {
//            FeladatTarolo<TesztFeladat> tarolo = new FeladatTarolo<TesztFeladat>(10);
//            TesztFeladat a = new TesztFeladat("a");
//            TesztFeladat b = new TesztFeladat("b");
//            tarolo.Felvesz(a);
//            tarolo.Felvesz(b);
//            Assert.Multiple(() =>
//            {
//                Assert.That(a.Vegrehajtott, Is.False);
//                Assert.That(b.Vegrehajtott, Is.False);
//            });
//            tarolo.MindentVegrehajt();
//            Assert.Multiple(() =>
//            {
//                Assert.That(a.Vegrehajtott, Is.True);
//                Assert.That(b.Vegrehajtott, Is.True);
//            });
//        }
//    }

//    [TestFixture(Category = "Paradigmák", TestName = "01 - Függő Feladat Tároló Tesztek")]
//    public class FuggoFeladatTaroloTesztek
//    {
//        [TestCase]
//        public void Felvesz()
//        {
//            FuggoFeladatTarolo<TesztFuggoFeladat> tarolo = new FuggoFeladatTarolo<TesztFuggoFeladat>(5);
//            TesztFuggoFeladat a = new TesztFuggoFeladat("a");
//            tarolo.Felvesz(a);
//            tarolo.Felvesz(a);
//            tarolo.Felvesz(a);
//        }
//        [TestCase]
//        public void TulsokatFelvesz()
//        {
//            FuggoFeladatTarolo<TesztFuggoFeladat> tarolo = new FuggoFeladatTarolo<TesztFuggoFeladat>(3);
//            TesztFuggoFeladat a = new TesztFuggoFeladat("a");
//            tarolo.Felvesz(a);
//            tarolo.Felvesz(a);
//            tarolo.Felvesz(a);
//            Assert.Throws<TaroloMegteltKivetel>(() => tarolo.Felvesz(a));
//        }
//        [TestCase]
//        public void NincsMitVegrehajtani()
//        {
//            FuggoFeladatTarolo<TesztFuggoFeladat> tarolo = new FuggoFeladatTarolo<TesztFuggoFeladat>(2);
//            tarolo.MindentVegrehajt();
//        }
//        [TestCase]
//        public void MindentVegrehajt()
//        {
//            FuggoFeladatTarolo<TesztFuggoFeladat> tarolo = new FuggoFeladatTarolo<TesztFuggoFeladat>(2);
//            TesztFuggoFeladat a = new TesztFuggoFeladat("a") { Vegrehajthato = true };
//            TesztFuggoFeladat b = new TesztFuggoFeladat("b") { Vegrehajthato = true };
//            tarolo.Felvesz(a);
//            tarolo.Felvesz(b);
//            Assert.Multiple(() =>
//            {
//                Assert.That(a.Vegrehajtott, Is.False);
//                Assert.That(b.Vegrehajtott, Is.False);
//            });
//            tarolo.MindentVegrehajt();
//            Assert.Multiple(() =>
//            {
//                Assert.That(a.Vegrehajtott, Is.True);
//                Assert.That(b.Vegrehajtott, Is.True);
//            });
//        }
//        [TestCase]
//        public void VegrehajtasAmikorNemVegrehajthatok()
//        {
//            FuggoFeladatTarolo<TesztFuggoFeladat> tarolo = new FuggoFeladatTarolo<TesztFuggoFeladat>(5);
//            TesztFuggoFeladat a = new TesztFuggoFeladat("a");
//            TesztFuggoFeladat b = new TesztFuggoFeladat("b");
//            tarolo.Felvesz(a);
//            tarolo.Felvesz(b);
//            Assert.Multiple(() =>
//            {
//                Assert.That(a.Vegrehajtott, Is.False);
//                Assert.That(b.Vegrehajtott, Is.False);
//            });
//            tarolo.MindentVegrehajt();
//            Assert.Multiple(() =>
//            {
//                Assert.That(a.Vegrehajtott, Is.False);
//                Assert.That(b.Vegrehajtott, Is.False);
//            });
//        }
//        [TestCase]
//        public void VegrehajtasAmikorVegrehajthatok()
//        {
//            FuggoFeladatTarolo<TesztFuggoFeladat> tarolo = new FuggoFeladatTarolo<TesztFuggoFeladat>(5);
//            TesztFuggoFeladat a = new TesztFuggoFeladat("a") { Vegrehajthato = true };
//            TesztFuggoFeladat b = new TesztFuggoFeladat("b");
//            tarolo.Felvesz(a);
//            tarolo.Felvesz(b);
//            Assert.Multiple(() =>
//            {
//                Assert.That(a.Vegrehajtott, Is.False);
//                Assert.That(b.Vegrehajtott, Is.False);
//            });
//            tarolo.MindentVegrehajt();
//            Assert.Multiple(() =>
//            {
//                Assert.That(a.Vegrehajtott, Is.True);
//                Assert.That(b.Vegrehajtott, Is.False);
//            });
//            b.Vegrehajthato = true;
//            tarolo.MindentVegrehajt();
//            Assert.Multiple(() =>
//            {
//                Assert.That(a.Vegrehajtott, Is.True);
//                Assert.That(b.Vegrehajtott, Is.True);
//            });
//        }
//    }
//    [TestFixture(Category = "Paradigmák", TestName = "01 - Feltételes Feladat Tároló Előkövetelményekkel Tesztek")]
//    public class FuggoFeladatTaroloElokovetelmenyekkelTesztek
//    {
//        [TestCase]
//        public void Elokovetelmenyes()
//        {
//            FuggoFeladatTarolo<TesztFuggoFeladat> tarolo = new FuggoFeladatTarolo<TesztFuggoFeladat>(5);
//            TesztFuggoFeladat a = new TesztFuggoFeladat("a");
//            TesztElokovetelmenytolFuggoFeladat b = new TesztElokovetelmenytolFuggoFeladat("b", a) { Vegrehajthato = true };
//            // a->b
//            tarolo.Felvesz(a);
//            tarolo.Felvesz(b);
//            tarolo.MindentVegrehajt();
//            Assert.Multiple(() =>
//            {
//                Assert.That(a.Vegrehajtott, Is.False);
//                Assert.That(b.Vegrehajtott, Is.False);
//            });
//            a.Vegrehajthato = true;
//            tarolo.MindentVegrehajt();
//            Assert.Multiple(() =>
//            {
//                Assert.That(a.Vegrehajtott, Is.True);
//                Assert.That(b.Vegrehajtott, Is.True);
//            });
//        }
//        [TestCase]
//        public void TobbKorosElokovetelmenyes()
//        {
//            FuggoFeladatTarolo<TesztFuggoFeladat> tarolo = new FuggoFeladatTarolo<TesztFuggoFeladat>(5);
//            TesztFuggoFeladat a = new TesztFuggoFeladat("a") { Vegrehajthato = true };
//            TesztElokovetelmenytolFuggoFeladat b = new TesztElokovetelmenytolFuggoFeladat("b", a) { Vegrehajthato = true };
//            TesztElokovetelmenytolFuggoFeladat c = new TesztElokovetelmenytolFuggoFeladat("c", a) { Vegrehajthato = true };
//            TesztElokovetelmenytolFuggoFeladat d = new TesztElokovetelmenytolFuggoFeladat("d", b) { Vegrehajthato = true };
//            // a->b->d
//            //  ->c
//            tarolo.Felvesz(d);
//            tarolo.Felvesz(c);
//            tarolo.Felvesz(b);
//            tarolo.Felvesz(a);
//            tarolo.MindentVegrehajt();
//            Assert.Multiple(() =>
//            {
//                Assert.That(a.Vegrehajtott, Is.True);
//                Assert.That(b.Vegrehajtott, Is.False); // a 'b' kiértékelése az 'a' végrehajtása előtt volt, ezért az még nem lett feldolgozva
//                Assert.That(c.Vegrehajtott, Is.False); // a 'c' kiértékelése az 'a' végrehajtása előtt volt, ezért az még nem lett feldolgozva
//                Assert.That(d.Vegrehajtott, Is.False);
//            });
//            tarolo.MindentVegrehajt();
//            Assert.Multiple(() =>
//            {
//                Assert.That(a.Vegrehajtott, Is.True);
//                Assert.That(b.Vegrehajtott, Is.True);
//                Assert.That(c.Vegrehajtott, Is.True);
//                Assert.That(d.Vegrehajtott, Is.False); // a 'd' kiértékelése a 'b' végrehajtása előtt volt, ezért az még nem lett feldolgozva
//            });
//            tarolo.MindentVegrehajt();
//            Assert.Multiple(() =>
//            {
//                Assert.That(a.Vegrehajtott, Is.True);
//                Assert.That(b.Vegrehajtott, Is.True);
//                Assert.That(c.Vegrehajtott, Is.True);
//                Assert.That(d.Vegrehajtott, Is.True);
//            });
//        }
//    }
//    [TestFixture(Category = "Paradigmák", TestName = "01 - Bejáró Tesztek")]
//    class BejarasokTesztek
//    {
//        [TestCase]
//        public void FeladatTaroloBejaro()
//        {
//            FeladatTarolo<TesztFeladat> tarolo = new FeladatTarolo<TesztFeladat>(10);
//            TesztFeladat a = new TesztFeladat("a");
//            TesztFeladat b = new TesztFeladat("b");
//            tarolo.Felvesz(a);
//            tarolo.Felvesz(b);
//            string nevek = "";
//            foreach (TesztFeladat u in tarolo)
//                nevek += u.Azonosito;
//            Assert.That(nevek, Is.EqualTo("ab"));
//        }

//        [TestCase]
//        public void FuggoFeladatTaroloBejaro()
//        {
//            FuggoFeladatTarolo<TesztFuggoFeladat> tarolo = new FuggoFeladatTarolo<TesztFuggoFeladat>(5);
//            TesztFuggoFeladat a = new TesztFuggoFeladat("a");
//            TesztFuggoFeladat b = new TesztFuggoFeladat("b") { Vegrehajthato = true };
//            tarolo.Felvesz(a);
//            tarolo.Felvesz(b);
//            tarolo.MindentVegrehajt();
//            string nevek = "";
//            foreach (TesztFuggoFeladat u in tarolo)
//                if (u.Vegrehajtott)
//                    nevek += u.Azonosito;
//            Assert.That(nevek, Is.EqualTo("b"));
//        }
//    }
//}
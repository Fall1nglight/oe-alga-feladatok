//using NUnit.Framework;
//using OE.ALGA.Adatszerkezetek;

//namespace OE.ALGA.Tesztek.Adatszerkezetek
//{
//    [TestFixture(Category = "Adatszerkezetek", TestName = "06 - Szótár Tesztek")]
//    public class SzotarTesztek
//    {
//        private static int TesztHasitoFuggveny(string kulcs)
//        {
//            if (string.IsNullOrEmpty(kulcs))
//                return 0;
//            int sum = 0;
//            foreach (char c in kulcs.ToCharArray())
//                sum += ((byte)c);
//            return sum * sum; // a modulo osztást a szótárnak kell végeznie, mert ő tudja csak a belső tömb méretet
//        }

//        [TestCase]
//        public void AlapMukodes()
//        {
//            Szotar<string, int> sz = new HasitoSzotarTulcsordulasiTerulettel<string, int>(10, TesztHasitoFuggveny);
//            sz.Beir("Bela", 5);
//            sz.Beir("Lajos", 2);
//            Assert.Multiple(() =>
//            {
//                Assert.That(sz.Kiolvas("Bela"), Is.EqualTo(5));
//                Assert.That(sz.Kiolvas("Lajos"), Is.EqualTo(2));
//            });
//        }
//        [TestCase]
//        public void AlapertelmezettHasitoFuggvennyel() //F2.(f)
//        {
//            Szotar<string, int> sz = new HasitoSzotarTulcsordulasiTerulettel<string, int>(10);
//            sz.Beir("Bela", 5);
//            sz.Beir("Lajos", 2);
//            Assert.Multiple(() =>
//            {
//                Assert.That(sz.Kiolvas("Bela"), Is.EqualTo(5));
//                Assert.That(sz.Kiolvas("Lajos"), Is.EqualTo(2));
//            });
//        }
//        [TestCase]
//        public void Kulcsutkozes()
//        {
//            Szotar<string, int> sz = new HasitoSzotarTulcsordulasiTerulettel<string, int>(10, TesztHasitoFuggveny);
//            sz.Beir("Bela", 5);
//            sz.Beir("Bale", 15);
//            sz.Beir("Lajos", 2);
//            sz.Beir("Lasoj", 12);
//            Assert.Multiple(() =>
//            {
//                Assert.That(sz.Kiolvas("Bela"), Is.EqualTo(5));
//                Assert.That(sz.Kiolvas("Lajos"), Is.EqualTo(2));
//                Assert.That(sz.Kiolvas("Bale"), Is.EqualTo(15));
//                Assert.That(sz.Kiolvas("Lasoj"), Is.EqualTo(12));
//            });
//        }
//        [TestCase]
//        public void NullElem()
//        {
//            Szotar<string, string> sz = new HasitoSzotarTulcsordulasiTerulettel<string, string>(5, TesztHasitoFuggveny);
//            sz.Beir("null", null!);
//        }
//        [TestCase]
//        public void UresKulcs()
//        {
//            Szotar<string, int> sz = new HasitoSzotarTulcsordulasiTerulettel<string, int>(5, TesztHasitoFuggveny);
//            sz.Beir("", 0);
//        }
//        [TestCase]
//        public void UresElem()
//        {
//            Szotar<string, string> sz = new HasitoSzotarTulcsordulasiTerulettel<string, string>(5, TesztHasitoFuggveny);
//            sz.Beir("Bela", "");
//        }
//        [TestCase]
//        public void NincsElem()
//        {
//            Szotar<string, int> sz = new HasitoSzotarTulcsordulasiTerulettel<string, int>(5, TesztHasitoFuggveny);
//            sz.Beir("Bela", 5);
//            sz.Beir("Lajos", 2);
//            Assert.Throws<HibasKulcsKivetel>(() => sz.Kiolvas("Ferenc"));
//        }
//        [TestCase]
//        public void TorlesNull()
//        {
//            Szotar<string, int> sz = new HasitoSzotarTulcsordulasiTerulettel<string, int>(5, TesztHasitoFuggveny);
//            sz.Beir("Bela", 5);
//            sz.Beir("Lajos", 2);
//            Assert.Throws<HibasKulcsKivetel>(() => sz.Torol(null!));
//        }
//        [TestCase]
//        public void TorlesMarad()
//        {
//            Szotar<string, int> sz = new HasitoSzotarTulcsordulasiTerulettel<string, int>(5, TesztHasitoFuggveny);
//            sz.Beir("Bela", 5);
//            sz.Beir("Lajos", 2);
//            sz.Torol("Bela");
//            Assert.That(sz.Kiolvas("Lajos"), Is.EqualTo(2));
//        }
//        [TestCase]
//        public void TorlesEltunt()
//        {
//            Szotar<string, int> sz = new HasitoSzotarTulcsordulasiTerulettel<string, int>(5, TesztHasitoFuggveny);
//            sz.Beir("Bela", 5);
//            sz.Beir("Lajos", 2);
//            sz.Torol("Bela");
//            Assert.Throws<HibasKulcsKivetel>(() => sz.Kiolvas("Bela"));
//        }
//    }
//}
//using NUnit.Framework;
//using OE.ALGA.Adatszerkezetek;

//namespace OE.ALGA.Tesztek.Adatszerkezetek
//{
//    [TestFixture(Category = "Adatszerkezetek", TestName = "05 - Fa Halmaz Tesztek")]
//    public class FaHalmazTesztek
//    {
//        [TestCase]
//        public void BeszurasUres()
//        {
//            Halmaz<string> v = new FaHalmaz<string>();
//            v.Beszur("");
//            Assert.Multiple(() =>
//            {
//                Assert.That(v.Eleme(""), Is.True);
//            });
//        }
//        [TestCase]
//        public void Beszuras()
//        {
//            Halmaz<int> v = new FaHalmaz<int>();
//            v.Beszur(1);
//            v.Beszur(3);
//            v.Beszur(2);
//            Assert.Multiple(() =>
//            {
//                Assert.That(v.Eleme(1), Is.True);
//                Assert.That(v.Eleme(2), Is.True);
//                Assert.That(v.Eleme(3), Is.True);
//            });
//        }
//        [TestCase]
//        public void DuplaBeszuras()
//        {
//            Halmaz<int> v = new FaHalmaz<int>();
//            v.Beszur(1);
//            v.Beszur(2);
//            v.Beszur(3);
//            v.Beszur(2);
//            Assert.Multiple(() =>
//            {
//                Assert.That(v.Eleme(1), Is.True);
//                Assert.That(v.Eleme(2), Is.True);
//                Assert.That(v.Eleme(3), Is.True);
//            });
//        }
//        [TestCase]
//        public void Torles()
//        {
//            Halmaz<int> v = new FaHalmaz<int>();
//            v.Beszur(1);
//            v.Beszur(3);
//            v.Beszur(2);
//            v.Torol(2);
//            Assert.Multiple(() =>
//            {
//                Assert.That(v.Eleme(1), Is.True);
//                Assert.That(v.Eleme(2), Is.False);
//                Assert.That(v.Eleme(3), Is.True);
//            });
//        }
//        [TestCase]
//        public void TorlesUres()
//        {
//            Halmaz<string> v = new FaHalmaz<string>();
//            v.Beszur("");
//            v.Beszur("1");
//            v.Beszur("");
//            v.Torol("");
//            Assert.Multiple(() =>
//            {
//                Assert.That(v.Eleme(""), Is.False);
//                Assert.That(v.Eleme("1"), Is.True);
//            });
//        }
//        [TestCase]
//        public void NemletezoTorles()
//        {
//            Halmaz<int> v = new FaHalmaz<int>();
//            v.Beszur(1);
//            v.Beszur(3);
//            v.Beszur(2);
//            Assert.Throws<NincsElemKivetel>(() => v.Torol(0));
//            Assert.Multiple(() =>
//            {
//                Assert.That(v.Eleme(1), Is.True);
//                Assert.That(v.Eleme(2), Is.True);
//                Assert.That(v.Eleme(3), Is.True);
//            });
//        }
//        [TestCase]
//        public void DuplaTorles()
//        {
//            Halmaz<int> v = new FaHalmaz<int>();
//            v.Beszur(1);
//            v.Beszur(2);
//            v.Beszur(3);
//            v.Beszur(2);
//            v.Torol(2);
//            Assert.Multiple(() =>
//            {
//                Assert.That(v.Eleme(1), Is.True);
//                Assert.That(v.Eleme(2), Is.False);
//                Assert.That(v.Eleme(3), Is.True);
//                Assert.That(v.Eleme(4), Is.False);
//            });
//        }
//        [TestCase]
//        public void PreorderBejaras()
//        {
//            Halmaz<int> v = new FaHalmaz<int>();
//            v.Beszur(5);
//            v.Beszur(3);
//            v.Beszur(1);
//            v.Beszur(8);
//            v.Beszur(4);
//            v.Beszur(9);
//            v.Beszur(7);
//            string osszefuzo = "";
//            v.Bejar(x => osszefuzo += x);
//            Assert.That(osszefuzo, Is.EqualTo("5314879"));
//        }
//    }
//}

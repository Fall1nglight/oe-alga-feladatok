// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using OE.ALGA.Paradigmak;
//
// namespace OE.ALGA.Tesztek
// {
//     [TestClass()]
//     public class FeltetelesFeladatTaroloTesztek
//     {
//         [TestMethod()]
//         public void FelveszTeszt() //F1.(a)
//         {
//             FeltetelesFeladatTarolo<TesztFeladat> tarolo =
//                 new FeltetelesFeladatTarolo<TesztFeladat>(10);
//             TesztFeladat a = new TesztFeladat("a");
//             tarolo.Felvesz(a);
//             tarolo.Felvesz(a);
//             tarolo.Felvesz(a);
//             tarolo.Felvesz(a);
//             tarolo.Felvesz(a);
//         }
//
//         [TestMethod()]
//         [ExpectedException(typeof(TaroloMegteltKivetel))]
//         public void TulsokatFelveszTeszt() //F1.(a)
//         {
//             FeltetelesFeladatTarolo<TesztFeladat> tarolo =
//                 new FeltetelesFeladatTarolo<TesztFeladat>(5);
//             TesztFeladat a = new TesztFeladat("a");
//             tarolo.Felvesz(a);
//             tarolo.Felvesz(a);
//             tarolo.Felvesz(a);
//             tarolo.Felvesz(a);
//             tarolo.Felvesz(a);
//             tarolo.Felvesz(a);
//         }
//
//         [TestMethod()]
//         public void MindenVegrehajtasTeszt() //F1.(a)
//         {
//             FeltetelesFeladatTarolo<TesztFeladat> tarolo =
//                 new FeltetelesFeladatTarolo<TesztFeladat>(10);
//             TesztFeladat a = new TesztFeladat("a");
//             TesztFeladat b = new TesztFeladat("b");
//             tarolo.Felvesz(a);
//             tarolo.Felvesz(b);
//             Assert.IsFalse(a.Vegrehajtott);
//             Assert.IsFalse(b.Vegrehajtott);
//             tarolo.MindentVegrehajt();
//             Assert.IsTrue(a.Vegrehajtott);
//             Assert.IsTrue(b.Vegrehajtott);
//         }
//
//         [TestMethod()]
//         public void BejaroTeszt() //F1.(a)
//         {
//             FeltetelesFeladatTarolo<TesztFeladat> tarolo =
//                 new FeltetelesFeladatTarolo<TesztFeladat>(10);
//             TesztFeladat a = new TesztFeladat("a");
//             TesztFeladat b = new TesztFeladat("b");
//             tarolo.Felvesz(a);
//             tarolo.Felvesz(b);
//             string nevek = "";
//             foreach (TesztFeladat u in tarolo)
//             {
//                 nevek += u.Azonosito;
//             }
//             Assert.AreEqual("ab", nevek);
//         }
//
//         [TestMethod()]
//         public void FeltetelesVegrehajtasTeszt() //F1.(b)
//         {
//             FeltetelesFeladatTarolo<TesztFeladat> tarolo =
//                 new FeltetelesFeladatTarolo<TesztFeladat>(10);
//             TesztFeladat a1 = new TesztFeladat("a1");
//             TesztFeladat b1 = new TesztFeladat("b1");
//             TesztFeladat a2 = new TesztFeladat("a2");
//             tarolo.Felvesz(a1);
//             tarolo.Felvesz(b1);
//             tarolo.Felvesz(a2);
//             Assert.IsFalse(a1.Vegrehajtott);
//             Assert.IsFalse(b1.Vegrehajtott);
//             Assert.IsFalse(a2.Vegrehajtott);
//             tarolo.FeltetelesVegrehajtas(x => x.Azonosito[0] == 'a'); // csak 'a' kezdetűek végrehajtása
//             Assert.IsTrue(a1.Vegrehajtott);
//             Assert.IsFalse(b1.Vegrehajtott);
//             Assert.IsTrue(a2.Vegrehajtott);
//             tarolo.FeltetelesVegrehajtas(x => x.Azonosito[0] == 'b'); // csak 'b' kezdetűek végrehajtása
//             Assert.IsTrue(a1.Vegrehajtott);
//             Assert.IsTrue(b1.Vegrehajtott);
//             Assert.IsTrue(a2.Vegrehajtott);
//         }
//
//         [TestMethod()]
//         public void FeltetelesFuggosegesVegrehajtasTeszt() //F1.(b)
//         {
//             FeltetelesFeladatTarolo<TesztFuggoFeladat> tarolo =
//                 new FeltetelesFeladatTarolo<TesztFuggoFeladat>(10);
//             TesztFuggoFeladat a1 = new TesztFuggoFeladat("a1") { Vegrehajthato = true };
//             TesztFuggoFeladat b1 = new TesztFuggoFeladat("b1") { Vegrehajthato = true };
//             TesztFuggoFeladat a2 = new TesztFuggoFeladat("a2") { Vegrehajthato = false };
//             tarolo.Felvesz(a1);
//             tarolo.Felvesz(b1);
//             tarolo.Felvesz(a2);
//             Assert.IsFalse(a1.Vegrehajtott);
//             Assert.IsFalse(b1.Vegrehajtott);
//             Assert.IsFalse(a2.Vegrehajtott);
//             tarolo.FeltetelesVegrehajtas(x => x.Azonosito[0] == 'a' && x.FuggosegTeljesul); // csak 'a' kezdetű és végrehajtható
//             Assert.IsTrue(a1.Vegrehajtott);
//             Assert.IsFalse(b1.Vegrehajtott);
//             Assert.IsFalse(a2.Vegrehajtott);
//             tarolo.FeltetelesVegrehajtas(x => x.Azonosito[0] == 'b' && x.FuggosegTeljesul); // csak 'b' kezdetű és végrehajtható
//             Assert.IsTrue(a1.Vegrehajtott);
//             Assert.IsTrue(b1.Vegrehajtott);
//             Assert.IsFalse(a2.Vegrehajtott);
//             a2.Vegrehajthato = true;
//             tarolo.FeltetelesVegrehajtas(x => x.Azonosito[0] == 'a' && x.FuggosegTeljesul); // csak 'a' kezdetű és végrehajtható
//             Assert.IsTrue(a1.Vegrehajtott);
//             Assert.IsTrue(b1.Vegrehajtott);
//             Assert.IsTrue(a2.Vegrehajtott);
//         }
//
//         [TestMethod()]
//         public void FeltetelesBejaroTeszt() //F3.(b)
//         {
//             FeltetelesFeladatTarolo<TesztFuggoFeladat> tarolo =
//                 new FeltetelesFeladatTarolo<TesztFuggoFeladat>(10);
//             tarolo.BejaroFeltetel = (x => x.FuggosegTeljesul);
//             TesztFuggoFeladat a = new TesztFuggoFeladat("a") { Vegrehajthato = true };
//             TesztFuggoFeladat b = new TesztFuggoFeladat("b") { Vegrehajthato = false };
//             TesztFuggoFeladat c = new TesztFuggoFeladat("c") { Vegrehajthato = true };
//             tarolo.Felvesz(a);
//             tarolo.Felvesz(b);
//             tarolo.Felvesz(c);
//             string nevek = "";
//             foreach (TesztFeladat u in tarolo)
//             {
//                 nevek += u.Azonosito;
//             }
//             Assert.AreEqual("ac", nevek);
//         }
//     }
// }

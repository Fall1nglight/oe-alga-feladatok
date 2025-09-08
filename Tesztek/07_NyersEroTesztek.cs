//using NUnit.Framework;
//using System;
//using OE.ALGA.Optimalizalas;

//namespace OE.ALGA.Tesztek.Optimalizalas
//{
//    [TestFixture(Category = "Optimalizalas", TestName = "07 - Hátiszák Tesztek")]
//    public class HatizsakTesztek
//    {
//        [TestCase]
//        public void UresTeszt()
//        {
//            HatizsakProblema problema = new HatizsakProblema(0, 0, [], []);
//            Assert.Multiple(() =>
//            {
//                Assert.That(problema.OsszSuly(PakolasTesztEsetek.uresPakolas), Is.EqualTo(0));
//                Assert.That(problema.OsszSuly(PakolasTesztEsetek.teljesPakolas), Is.EqualTo(0));
//                Assert.That(problema.OsszSuly(PakolasTesztEsetek.feligPakolas), Is.EqualTo(0));
//            });
//            Assert.Multiple(() =>
//            {
//                Assert.That(problema.OsszErtek(PakolasTesztEsetek.uresPakolas), Is.EqualTo(0));
//                Assert.That(problema.OsszErtek(PakolasTesztEsetek.teljesPakolas), Is.EqualTo(0));
//                Assert.That(problema.OsszErtek(PakolasTesztEsetek.feligPakolas), Is.EqualTo(0));
//            });
//            Assert.Multiple(() =>
//            {
//                Assert.That(problema.Ervenyes(PakolasTesztEsetek.uresPakolas), Is.True);
//                Assert.That(problema.Ervenyes(PakolasTesztEsetek.teljesPakolas), Is.True);
//                Assert.That(problema.Ervenyes(PakolasTesztEsetek.feligPakolas), Is.True);
//            });
//        }
//        [TestCase]
//        public void SulyTeszt()
//        {
//            HatizsakProblema problema = new HatizsakProblema(PakolasTesztEsetek.jegyzet_n, PakolasTesztEsetek.jegyzet_Wmax, PakolasTesztEsetek.jegyzet_w, PakolasTesztEsetek.jegyzet_p);
//            Assert.Multiple(() =>
//            {
//                Assert.That(problema.OsszSuly(PakolasTesztEsetek.uresPakolas), Is.EqualTo(0));
//                Assert.That(problema.OsszSuly(PakolasTesztEsetek.teljesPakolas), Is.EqualTo(10));
//                Assert.That(problema.OsszSuly(PakolasTesztEsetek.feligPakolas), Is.EqualTo(2));
//            });
//        }
//        [TestCase]
//        public void JosagTeszt()
//        {
//            HatizsakProblema problema = new HatizsakProblema(PakolasTesztEsetek.jegyzet_n, PakolasTesztEsetek.jegyzet_Wmax, PakolasTesztEsetek.jegyzet_w, PakolasTesztEsetek.jegyzet_p);
//            Assert.Multiple(() =>
//            {
//                Assert.That(problema.OsszErtek(PakolasTesztEsetek.uresPakolas), Is.EqualTo(0));
//                Assert.That(problema.OsszErtek(PakolasTesztEsetek.teljesPakolas), Is.EqualTo(29));
//                Assert.That(problema.OsszErtek(PakolasTesztEsetek.feligPakolas), Is.EqualTo(11));
//            });
//        }
//        [TestCase]
//        public void ErvenyesTeszt()
//        {
//            HatizsakProblema problema = new HatizsakProblema(PakolasTesztEsetek.jegyzet_n, PakolasTesztEsetek.jegyzet_Wmax, PakolasTesztEsetek.jegyzet_w, PakolasTesztEsetek.jegyzet_p);
//            Assert.Multiple(() =>
//            {
//                Assert.That(problema.Ervenyes(PakolasTesztEsetek.uresPakolas), Is.True);
//                Assert.That(problema.Ervenyes(PakolasTesztEsetek.teljesPakolas), Is.False);
//                Assert.That(problema.Ervenyes(PakolasTesztEsetek.feligPakolas), Is.True);
//            });
//        }
//    }

//    [TestFixture(Category = "Optimalizalas", TestName = "07 - Nyers Ero Tesztek")]
//    public class NyersEroTesztek
//    {
//        [TestCase]
//        public void UresTeszt()
//        {
//            int[] A = { 4, 6, 7, 4, 2, 1 };
//            NyersEro<int> opt = new NyersEro<int>(
//                0,
//                x => { Guardian.Recursion.CheckStackTrace(); return A[x - 1]; },
//                x => { Guardian.Recursion.CheckStackTrace(); return x; });
//            Assert.Multiple(() =>
//            {
//                Assert.That(opt.OptimalisMegoldas(), Is.EqualTo(4));
//                Assert.That(opt.LepesSzam, Is.EqualTo(0));
//            });
//        }
//        [TestCase]
//        public void TombLegnagyobbEleme()
//        {
//            int[] A = { 4, 6, 7, 4, 2, 1 };
//            NyersEro<int> opt = new NyersEro<int>(
//                A.Length,
//                x => { Guardian.Recursion.CheckStackTrace(); return A[x - 1]; },
//                x => { Guardian.Recursion.CheckStackTrace(); return x; });
//            Assert.Multiple(() =>
//            {
//                Assert.That(opt.OptimalisMegoldas(), Is.EqualTo(7));
//                Assert.That(opt.LepesSzam, Is.EqualTo(5));
//            });
//        }

//    }

//    [TestFixture(Category = "Optimalizalas", TestName = "07 - Nyers Ero Hátizsák Pakolás Tesztek")]
//    public class NyersEroHatizsakPakolasTesztek
//    {
//        [TestCase]
//        public void UresTeszt()
//        {
//            HatizsakProblema problema = new HatizsakProblema(0, 0, [], []);
//            NyersEroHatizsakPakolas opt = new NyersEroHatizsakPakolas(problema);
//            Assert.Multiple(() =>
//            {
//                Assert.That(opt.OptimalisErtek(), Is.EqualTo(0));
//                Assert.That(opt.OptimalisMegoldas(), Is.EquivalentTo(Array.Empty<bool>()));
//                Assert.That(opt.LepesSzam, Is.EqualTo(0));
//            });
//        }
//        [TestCase]
//        public void JegyzetbenLevoPeldaErtekTeszt()
//        {
//            HatizsakProblema problema = new HatizsakProblema(PakolasTesztEsetek.jegyzet_n, PakolasTesztEsetek.jegyzet_Wmax, PakolasTesztEsetek.jegyzet_w, PakolasTesztEsetek.jegyzet_p);
//            NyersEroHatizsakPakolas opt = new NyersEroHatizsakPakolas(problema);
//            Assert.Multiple(() =>
//            {
//                Assert.That(opt.OptimalisErtek(), Is.EqualTo(PakolasTesztEsetek.jegyzet_optimalis_ertek));
//                Assert.That(opt.LepesSzam, Is.EqualTo(63));
//            });
//        }
//        [TestCase]
//        public void JegyzetbenLevoPeldaMegoldasTeszt()
//        {
//            HatizsakProblema problema = new HatizsakProblema(PakolasTesztEsetek.jegyzet_n, PakolasTesztEsetek.jegyzet_Wmax, PakolasTesztEsetek.jegyzet_w, PakolasTesztEsetek.jegyzet_p);
//            NyersEroHatizsakPakolas opt = new NyersEroHatizsakPakolas(problema);
//            Assert.Multiple(() =>
//            {
//                Assert.That(opt.OptimalisMegoldas(), Is.EquivalentTo(PakolasTesztEsetek.jegyzet_optimalis_pakolas));
//                Assert.That(opt.LepesSzam, Is.EqualTo(63));
//            });
//        }
//        [TestCase]
//        public void NagyPeldaMegoldasErtekTeszt()
//        {
//            HatizsakProblema problema = new HatizsakProblema(PakolasTesztEsetek.nagy_n, PakolasTesztEsetek.nagy_Wmax, PakolasTesztEsetek.nagy_w, PakolasTesztEsetek.nagy_p);
//            NyersEroHatizsakPakolas opt = new NyersEroHatizsakPakolas(problema);
//            Assert.Multiple(() =>
//            {
//                Assert.That(opt.OptimalisErtek(), Is.EqualTo(PakolasTesztEsetek.nagy_optimalis_ertek));
//                Assert.That(opt.LepesSzam, Is.EqualTo(131071));
//            });
//        }
//        [TestCase]
//        public void NagyPeldaMegoldasTeszt()
//        {
//            HatizsakProblema problema = new HatizsakProblema(PakolasTesztEsetek.nagy_n, PakolasTesztEsetek.nagy_Wmax, PakolasTesztEsetek.nagy_w, PakolasTesztEsetek.nagy_p);
//            NyersEroHatizsakPakolas opt = new NyersEroHatizsakPakolas(problema);
//            Assert.Multiple(() =>
//            {
//                Assert.That(opt.OptimalisMegoldas(), Is.EquivalentTo(PakolasTesztEsetek.nagy_optimalis_pakolas));
//                Assert.That(opt.LepesSzam, Is.EqualTo(131071));
//            });
//        }
//    }
//}
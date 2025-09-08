//using NUnit.Framework;
//using System;
//using OE.ALGA.Optimalizalas;

//namespace OE.ALGA.Tesztek.Optimalizalas
//{
//    [TestFixture(Category = "Optimalizalas", TestName = "08 - Dinamikus Programozás Tesztek")]
//    public class DinamikusProgramozasTesztek
//    {
//        [TestCase]
//        public void UresTeszt()
//        {
//            HatizsakProblema problema = new HatizsakProblema(0, 0, [], []);
//            DinamikusHatizsakPakolas opt = new DinamikusHatizsakPakolas(problema);
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
//            DinamikusHatizsakPakolas opt = new DinamikusHatizsakPakolas(problema);
//            Assert.Multiple(() =>
//            {
//                Assert.That(opt.OptimalisErtek(), Is.EqualTo(PakolasTesztEsetek.jegyzet_optimalis_ertek));
//                Assert.That(opt.LepesSzam, Is.EqualTo(24));
//            });
//        }
//        [TestCase]
//        public void JegyzetbenLevoPeldaMegoldasTeszt()
//        {
//            HatizsakProblema problema = new HatizsakProblema(PakolasTesztEsetek.jegyzet_n, PakolasTesztEsetek.jegyzet_Wmax, PakolasTesztEsetek.jegyzet_w, PakolasTesztEsetek.jegyzet_p);
//            DinamikusHatizsakPakolas opt = new DinamikusHatizsakPakolas(problema);
//            Assert.Multiple(() =>
//            {
//                Assert.That(opt.OptimalisMegoldas(), Is.EquivalentTo(PakolasTesztEsetek.jegyzet_optimalis_pakolas));
//                Assert.That(opt.LepesSzam, Is.EqualTo(24));
//            });
//        }
//        [TestCase]
//        public void NagyPeldaMegoldasErtekTeszt()
//        {
//            HatizsakProblema problema = new HatizsakProblema(PakolasTesztEsetek.nagy_n, PakolasTesztEsetek.nagy_Wmax, PakolasTesztEsetek.nagy_w, PakolasTesztEsetek.nagy_p);
//            DinamikusHatizsakPakolas opt = new DinamikusHatizsakPakolas(problema);
//            Assert.Multiple(() =>
//            {
//                Assert.That(opt.OptimalisErtek(), Is.EqualTo(PakolasTesztEsetek.nagy_optimalis_ertek));
//                Assert.That(opt.LepesSzam, Is.EqualTo(1700));
//            });
//        }
//        [TestCase]
//        public void NagyPeldaMegoldasTeszt()
//        {
//            HatizsakProblema problema = new HatizsakProblema(PakolasTesztEsetek.nagy_n, PakolasTesztEsetek.nagy_Wmax, PakolasTesztEsetek.nagy_w, PakolasTesztEsetek.nagy_p);
//            DinamikusHatizsakPakolas opt = new DinamikusHatizsakPakolas(problema);
//            Assert.Multiple(() =>
//            {
//                Assert.That(opt.OptimalisMegoldas(), Is.EquivalentTo(PakolasTesztEsetek.nagy_optimalis_pakolas));
//                Assert.That(opt.LepesSzam, Is.EqualTo(1700));
//            });
//        }
//    }
//}
using System.Text;

namespace OE.ALGA.Engine
{
    public interface IMegjelenitheto
    {
        public Pozicio Pozicio { get; }
        public Jel Jel { get; }
    }

    public class FixJel : IMegjelenitheto
    {
        public Pozicio Pozicio { get; private set; }

        public Jel Jel { get; private set; }

        public FixJel(Pozicio pozicio, Jel jel)
        {
            this.Pozicio = pozicio;
            this.Jel = jel;
        }

        public FixJel(IMegjelenitheto eredeti)
        {
            this.Pozicio = eredeti.Pozicio;
            this.Jel = eredeti.Jel;
        }

        public static FixJel[] SzovegbolJelsor(string szoveg, Pozicio hely, ConsoleColor szin)
        {
            FixJel[] jelsor = new FixJel[szoveg.Length];
            for (int i = 0; i < szoveg.Length; i++)
                jelsor[i] = new FixJel(new Pozicio(hely.X + i, hely.Y), new Jel(szoveg[i], szin));
            return jelsor;
        }
    }

    public class Jel
    {
        readonly char karakter;
        readonly ConsoleColor szin;

        public char Karakter { get { return karakter; } }
        public ConsoleColor Szin { get { return szin; } }

        public Jel(char karakter, ConsoleColor szin)
        {
            this.karakter = karakter;
            this.szin = szin;
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj is Jel b)
            {
                return this.Karakter == b.Karakter && this.Szin == b.Szin;
            }
            else
                return false;
        }

        public override int GetHashCode()
        {
            return karakter.GetHashCode() ^ szin.GetHashCode();
        }

        public static bool operator ==(Jel a, Jel b) => a is not null && a.Equals(b);
        public static bool operator !=(Jel a, Jel b) => a is null || !a.Equals(b);
    }

    public interface INezopont
    {
        string Fejlec { get; }
        Meret Meret { get; }
        IMegjelenitheto[] MegjelenitendoElemek();
    }

    public class Kepernyo : IOrajelFogado
    {
        readonly Meret meret;
        readonly Jel[,] puffer;
        readonly Jel[,] utolso;

        public Kepernyo(int szelesseg, int magassag)
        {
            meret = new Meret(szelesseg, magassag);

            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.Unicode;

            puffer = new Jel[szelesseg, magassag];
            utolso = new Jel[szelesseg, magassag];
        }

        public Kepernyo() : this(Console.WindowWidth, Console.WindowHeight)
        {

        }

        readonly List<Func<string>> HUDmegjelenitok = new List<Func<string>>();

        public void HUDAdatFelvetele(Func<string> hudMegjelenito)
        {
            HUDmegjelenitok.Add(hudMegjelenito);
        }

        readonly List<INezopont> nezopontok = new List<INezopont>();

        public void NezopontFelvetele(INezopont nezopont)
        {
            nezopontok.Add(nezopont);
        }

        public void NezopontEltavolitasa(INezopont nezopont)
        {
            nezopontok.Remove(nezopont);
        }

        public void Kirajzolas()
        {
            PufferTorles();

            int eltolasX = 0;
            foreach (INezopont nezopont in nezopontok)
            {
                KeretRajzolas(eltolasX, 0, nezopont.Meret, nezopont.Fejlec);
                ElemekRajzolasa(eltolasX, 0, nezopont);
                eltolasX += nezopont.Meret.Szelesseg + 2;
            }

            eltolasX = 0;
            foreach (Func<string> hudMegjelenito in HUDmegjelenitok)
            {
                string adat = hudMegjelenito();
                for (int i = 0; i < adat.Length; i++)
                    puffer[eltolasX + i, meret.Magassag - 1] = new Jel(adat[i], ConsoleColor.White);
                puffer[eltolasX + adat.Length, meret.Magassag - 1] = new Jel('|', ConsoleColor.Red);
                eltolasX += adat.Length + 1;
            }

            PufferKirajzolas();
        }

        readonly Jel ures = new Jel(' ', ConsoleColor.Black);

        private void PufferTorles()
        {
            for (int i = 0; i < meret.Szelesseg; i++)
                for (int j = 0; j < meret.Magassag; j++)
                {
                    puffer[i, j] = ures;
                }
        }

        private void KeretRajzolas(int eltolasX, int eltolasY, Meret meret, string fejlec)
        {
            for (int i = 1; i <= meret.Szelesseg; i++)
            {
                puffer[eltolasX + i, eltolasY] = new Jel('\u2550', ConsoleColor.Gray);
                puffer[eltolasX + i, eltolasY + meret.Magassag + 1] = new Jel('\u2550', ConsoleColor.Gray);
            }

            for (int i = 1; i <= meret.Magassag; i++)
            {
                puffer[eltolasX, eltolasY + i] = new Jel('\u2551', ConsoleColor.Gray);
                puffer[eltolasX + meret.Szelesseg + 1, eltolasY + i] = new Jel('\u2551', ConsoleColor.Gray);
            }

            puffer[eltolasX, eltolasY] = new Jel('\u2554', ConsoleColor.Gray);
            puffer[eltolasX + meret.Szelesseg + 1, eltolasY] = new Jel('\u2557', ConsoleColor.Gray);
            puffer[eltolasX, eltolasY + meret.Magassag + 1] = new Jel('\u255a', ConsoleColor.Gray);
            puffer[eltolasX + meret.Szelesseg + 1, eltolasY + meret.Magassag + 1] = new Jel('\u255d', ConsoleColor.Gray);

            for (int i = 0; i < fejlec.Length; i++)
                puffer[eltolasX + 2 + i, eltolasY] = new Jel(fejlec[i], ConsoleColor.Gray);
        }

        private void ElemekRajzolasa(int eltolasX, int eltolasY, INezopont nezopont)
        {
            foreach (IMegjelenitheto elem in nezopont.MegjelenitendoElemek())
            {
                puffer[eltolasX + 1 + elem.Pozicio.X, eltolasY + 1 + elem.Pozicio.Y] = elem.Jel;
            }
        }

        private void PufferKirajzolas()
        {
            for (int j = 0; j < meret.Magassag; j++)
            {
                for (int i = 0; i < meret.Szelesseg; i++)
                {
                    if (utolso[i, j] != puffer[i, j])
                    {
                        Console.SetCursorPosition(i, j);
                        Console.ForegroundColor = puffer[i, j].Szin;
                        Console.Write(puffer[i, j].Karakter);
                        utolso[i, j] = puffer[i, j];
                    }

                }
            }
        }

        public void Orajel(int ido)
        {
            Kirajzolas();
        }
    }
}

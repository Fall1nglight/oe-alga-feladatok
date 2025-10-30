using System;

namespace OE.ALGA.Optimalizalas;

// 7. heti labor feladat - Tesztek: 07_NyersEroTesztek.cs
public class HatizsakProblema
{
    // fields & properties

    /// <summary>
    /// Tárgyak száma
    /// </summary>
    public int n { get; }

    /// <summary>
    /// Hátizsák mérete
    /// </summary>
    public int Wmax { get; }

    /// <summary>
    /// Egyes tárgyak súlyai
    /// </summary>
    public int[] w { get; }

    /// <summary>
    /// Egyes tárgyak értékei
    /// </summary>
    public float[] p { get; }

    // constructors
    public HatizsakProblema(int n, int Wmax, int[] w, float[] p)
    {
        this.n = n;
        this.Wmax = Wmax;
        this.w = w;
        this.p = p;
    }

    // methods
    public int OsszSuly(bool[] pakolas)
    {
        int sum = 0;

        for (int i = 0; i < n; i++)
        {
            sum += pakolas[i] ? w[i] : 0;
        }

        return sum;
    }

    public float OsszErtek(bool[] pakolas)
    {
        float sum = 0;

        for (int i = 0; i < n; i++)
        {
            sum += pakolas[i] ? p[i] : 0;
        }

        return sum;
    }

    public bool Ervenyes(bool[] pakolas) => OsszSuly(pakolas) <= Wmax;
}

public class NyersEro<T>
{
    // fields & properties
    private int m; // lehetséges megoldások száma
    private Func<int, T> generator;
    private Func<T, float> josag;
    public int LepesSzam { get; private set; } // összehasonlítások száma

    // constructors
    public NyersEro(int m, Func<int, T> generator, Func<T, float> josag)
    {
        this.m = m;
        this.generator = generator;
        this.josag = josag;
    }

    // methods
    public T OptimalisMegoldas()
    {
        T opt = generator(1);

        for (int i = 2; i <= m; i++)
        {
            T atmenetiOpt = generator(i);

            if (josag(atmenetiOpt) > josag(opt))
                opt = atmenetiOpt;

            LepesSzam++;
        }

        return opt;
    }
}

public class NyersEroHatizsakPakolas
{
    // fields & properties
    public int LepesSzam { get; private set; }
    private HatizsakProblema problema;

    // constructors
    public NyersEroHatizsakPakolas(HatizsakProblema problema)
    {
        this.problema = problema;
    }

    // methods
    public bool[] Generator(int x)
    {
        bool[] eredmeny = new bool[problema.n];
        int szam = x - 1;

        for (int i = 0; i < eredmeny.Length; i++)
            eredmeny[i] = szam / (int)Math.Pow(2, i) % 2 == 1;

        return eredmeny;
    }

    public float Josag(bool[] pakolas) =>
        problema.Ervenyes(pakolas) ? problema.OsszErtek(pakolas) : -1;

    public bool[] OptimalisMegoldas()
    {
        int lehetsegesMegoldasokSzama = (int)Math.Pow(2, problema.n);

        NyersEro<bool[]> nyersEro = new NyersEro<bool[]>(
            lehetsegesMegoldasokSzama,
            Generator,
            Josag
        );

        bool[] megoldas = nyersEro.OptimalisMegoldas();
        LepesSzam = nyersEro.LepesSzam;

        return megoldas;
    }

    public float OptimalisErtek() => problema.OsszErtek(OptimalisMegoldas());
}

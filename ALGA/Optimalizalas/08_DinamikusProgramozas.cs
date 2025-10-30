using System;

namespace OE.ALGA.Optimalizalas;

// 8. heti labor feladat - Tesztek: 08_DinamikusProgramozasTesztek.cs

public class DinamikusHatizsakPakolas
{
    private HatizsakProblema problema;
    public int LepesSzam { get; private set; }

    public DinamikusHatizsakPakolas(HatizsakProblema problema)
    {
        this.problema = problema;
    }

    private float[,] TablazatFeltoltes()
    {
        // +1 szükséges mert egy plusz sor és oszlop is lesz
        float[,] F = new float[problema.w.Length + 1, problema.Wmax + 1];

        int rowCount = F.GetLength(0);
        int colCount = F.GetLength(1);

        // először fel kell tölteni az első oszlopot
        for (int i = 0; i < rowCount; i++)
        {
            F[i, 0] = 0;
        }

        // majd feltöltjük az első sort
        for (int i = 0; i < colCount; i++)
        {
            F[0, i] = 0;
        }

        // bejárjuk a 2D-s tömböt, az első oszlopot+sort kihagyva
        // t -> tárgyak száma
        // h -> szabad hely (súly) száma
        for (int t = 1; t < rowCount; t++)
        {
            for (int h = 1; h < colCount; h++)
            {
                LepesSzam++;
                // ha h > 0 és t > 0 és h < w[t]
                // ha van szabad hely
                // és van tárgy amit a hátizssákba szeretnénk pakolni
                // az előző két feltétel fölösleges, mert a ciklus (t=1 és h=1)-től indul

                // ha az adott (i.) tárgy nem fér bele a hátizsákba (h < w[t])
                // w[t-1] => indexelés miatt
                if (h < problema.w[t - 1])
                {
                    F[t, h] = F[t - 1, h];
                }
                // ha az adott (i.) tárgy belefér a hátizsákba (h >= w[t])
                else
                {
                    float result = Math.Max(
                        F[t - 1, h],
                        F[t - 1, h - problema.w[t - 1]] + problema.p[t - 1]
                    );

                    F[t, h] = result;
                }
            }
        }

        return F;
    }

    public float OptimalisErtek()
    {
        // mivel +1-e hozzáadtunk
        // ezek az értékek megadják az utolsó elemet
        return TablazatFeltoltes()[problema.w.Length, problema.Wmax];
    }

    public bool[] OptimalisMegoldas()
    {
        float[,] F = TablazatFeltoltes();
        // annyi elemű tömbnek kell lennie, ahány tárgy van
        // =>
        // mind egyes index egy tárgyat reprezentál
        int t = problema.w.Length;
        int h = problema.Wmax;

        bool[] O = new bool[t];

        while (t > 0 && h > 0)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (F[t, h] != F[t - 1, h])
            {
                O[t - 1] = true;
                h -= problema.w[t - 1];
            }

            t -= 1;
        }

        return O;
    }
}

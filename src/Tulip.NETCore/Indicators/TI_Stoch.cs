namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int StochStart(T[] options) =>
        Int32.CreateTruncating(options[0]) + Int32.CreateTruncating(options[1]) + Int32.CreateTruncating(options[2]) - 3;

    private static int Stoch(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var kPeriod = Int32.CreateTruncating(options[0]);
        var kSlow = Int32.CreateTruncating(options[1]);
        var dPeriod = Int32.CreateTruncating(options[2]);

        if (kPeriod < 1 || kSlow < 1 || dPeriod < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= StochStart(options))
        {
            return TI_OKAY;
        }

        var (high, low, close) = inputs;
        var (stoch, stochMa) = outputs;

        T kPer = T.One / T.CreateChecked(kSlow);
        T dPer = T.One / T.CreateChecked(dPeriod);

        int trail = default;
        var maxi = -1;
        var mini = -1;
        T max = high[0];
        T min = low[0];
        var kSum = BufferFactory(kSlow);
        var dSum = BufferFactory(dPeriod);
        int stochIndex = default;
        int stochMaIndex = default;
        for (var i = 0; i < size; ++i)
        {
            if (i >= kPeriod)
            {
                ++trail;
            }

            // Maintain highest.
            T bar = high[i];
            if (maxi < trail)
            {
                maxi = trail;
                max = high[maxi];
                int j = trail;
                while (++j <= i)
                {
                    bar = high[j];
                    if (bar >= max)
                    {
                        max = bar;
                        maxi = j;
                    }
                }
            }
            else if (bar >= max)
            {
                maxi = i;
                max = bar;
            }

            // Maintain lowest.
            bar = low[i];
            if (mini < trail)
            {
                mini = trail;
                min = low[mini];
                int j = trail;
                while (++j <= i)
                {
                    bar = low[j];
                    if (bar <= min)
                    {
                        min = bar;
                        mini = j;
                    }
                }
            }
            else if (bar <= min)
            {
                mini = i;
                min = bar;
            }

            // Calculate it.
            T kDiff = max - min;
            T kFast = T.IsZero(kDiff) ? T.Zero : THundred * ((close[i] - min) / kDiff);
            BufferPush(ref kSum, kFast);

            if (i >= kPeriod - 1 + kSlow - 1)
            {
                T k = kSum.sum * kPer;
                BufferPush(ref dSum, k);

                if (i >= kPeriod - 1 + kSlow - 1 + dPeriod - 1)
                {
                    stoch[stochIndex++] = k;
                    stochMa[stochMaIndex++] = dSum.sum * dPer;
                }
            }
        }

        return TI_OKAY;
    }
}

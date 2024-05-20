namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int FisherStart(T[] options) => Int32.CreateTruncating(options[0]) - 1;

    private static int Fisher(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= FisherStart(options))
        {
            return TI_OKAY;
        }

        var (high, low) = inputs;
        var (fisher, signal) = outputs;

        var maxi = -1;
        var mini = -1;
        var THalf = T.CreateChecked(0.5);
        T max = THalf * (high[0] + low[0]);
        T min = THalf * (high[0] + low[0]);
        T val1 = T.Zero;
        T fish = T.Zero;
        int fisherIndex = default;
        int signalIndex = default;
        for (int i = period - 1, trail = 0; i < size; ++i, ++trail)
        {
            // Maintain highest.
            T bar = THalf * (high[i] + low[i]);
            if (maxi < trail)
            {
                maxi = trail;
                max = THalf * (high[maxi] + low[maxi]);
                int j = trail;
                while (++j <= i)
                {
                    bar = THalf * (high[j] + low[j]);
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
            bar = THalf * (high[i] + low[i]);
            if (mini < trail)
            {
                mini = trail;
                min = THalf * (high[mini] + low[mini]);
                int j = trail;
                while (++j <= i)
                {
                    bar = THalf * (high[j] + low[j]);
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

            T mm = max - min;
            if (T.IsZero(mm))
            {
                mm = T.CreateChecked(0.001);
            }

            val1 = T.CreateChecked(0.66) * ((THalf * (high[i] + low[i]) - min) / mm - THalf) + T.CreateChecked(0.67) * val1;
            if (val1 > T.CreateChecked(0.99))
            {
                val1 = T.CreateChecked(0.999);
            }

            if (val1 < T.CreateChecked(-0.99))
            {
                val1 = T.CreateChecked(-0.999);
            }

            signal[signalIndex++] = fish;
            fish = THalf * T.Log((T.One + val1) / (T.One - val1)) + THalf * fish;
            fisher[fisherIndex++] = fish;
        }

        return TI_OKAY;
    }
}

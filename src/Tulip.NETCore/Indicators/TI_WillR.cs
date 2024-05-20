namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int WillRStart(T[] options) => Int32.CreateTruncating(options[0]) - 1;

    private static int WillR(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= WillRStart(options))
        {
            return TI_OKAY;
        }

        var (high, low, close) = inputs;
        var output = outputs[0];

        var maxi = -1;
        var mini = -1;
        T max = high[0];
        T min = low[0];
        int outputIndex = default;
        for (int i = period - 1, trail = 0; i < size; ++i, ++trail)
        {
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
            T highLow = max - min;
            T r = T.IsZero(highLow) ? T.Zero : T.NegativeOne * THundred * ((max - close[i]) / highLow);
            output[outputIndex++] = r;
        }

        return TI_OKAY;
    }
}

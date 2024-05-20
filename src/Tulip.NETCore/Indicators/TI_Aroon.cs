namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int AroonStart(T[] options) => Int32.CreateTruncating(options[0]);

    private static int Aroon(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= AroonStart(options))
        {
            return TI_OKAY;
        }

        var (high, low) = inputs;
        var (aDown, aUp) = outputs;

        T scale = THundred / T.CreateChecked(period);
        var maxi = -1;
        var mini = -1;
        T max = high[0];
        T min = low[0];

        int aDownIndex = default;
        int aUpIndex = default;
        for (int i = period, trail = 0; i < size; ++i, ++trail)
        {
            // Maintain highest.
            T bar = high[i];
            int j;
            if (maxi < trail)
            {
                maxi = trail;
                max = high[maxi];
                j = trail;
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
                j = trail;
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

            // Calculate the indicator.
            aDown[aDownIndex++] = T.CreateChecked(period - (i - mini)) * scale;
            aUp[aUpIndex++] = T.CreateChecked(period - (i - maxi)) * scale;
        }

        return TI_OKAY;
    }
}

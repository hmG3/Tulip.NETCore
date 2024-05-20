namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int AdOscStart(T[] options) => Int32.CreateTruncating(options[1]) - 1;

    private static int AdOsc(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var shortPeriod = Int32.CreateTruncating(options[0]);
        var longPeriod = Int32.CreateTruncating(options[1]);

        if (shortPeriod < 1 || longPeriod < shortPeriod)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= AdOscStart(options))
        {
            return TI_OKAY;
        }

        var (high, low, close, volume) = inputs;
        var output = outputs[0];

        int start = longPeriod - 1;
        T shortPer = TTwo / T.CreateChecked(shortPeriod + 1);
        T longPer = TTwo / T.CreateChecked(longPeriod + 1);
        T sum = T.Zero;
        T shortEma = T.Zero;
        T longEma = T.Zero;
        int outputIndex = default;
        for (var i = 0; i < size; ++i)
        {
            T hl = high[i] - low[i];
            if (!T.IsZero(hl))
            {
                sum += (close[i] - low[i] - high[i] + close[i]) / hl * volume[i];
            }

            if (i == 0)
            {
                shortEma = sum;
                longEma = sum;
            }
            else
            {
                shortEma = (sum - shortEma) * shortPer + shortEma;
                longEma = (sum - longEma) * longPer + longEma;
            }

            if (i >= start)
            {
                output[outputIndex++] = shortEma - longEma;
            }
        }

        return TI_OKAY;
    }
}

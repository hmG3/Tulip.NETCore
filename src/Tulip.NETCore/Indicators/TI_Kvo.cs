namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int KvoStart(T[] options) => 1;

    private static int Kvo(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var shortPeriod = Int32.CreateTruncating(options[0]);
        var longPeriod = Int32.CreateTruncating(options[1]);

        if (shortPeriod < 1 || longPeriod < shortPeriod)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= KvoStart(options))
        {
            return TI_OKAY;
        }

        var (high, low, close, volume) = inputs;
        var output = outputs[0];

        T shortPer = TTwo / T.CreateChecked(shortPeriod + 1);
        T longPer = TTwo / T.CreateChecked(longPeriod + 1);
        T cm = T.Zero;
        T prevHlc = high[0] + low[0] + close[0];
        var trend = -1;
        T shortEma = T.Zero;
        T longEma = T.Zero;
        int outputIndex = default;
        for (var i = 1; i < size; ++i)
        {
            T hlc = high[i] + low[i] + close[i];
            T dm = high[i] - low[i];
            if (hlc > prevHlc && trend != 1)
            {
                trend = 1;
                cm = high[i - 1] - low[i - 1];
            }
            else if (hlc < prevHlc && trend != 0)
            {
                trend = 0;
                cm = high[i - 1] - low[i - 1];
            }

            cm += dm;
            T vf = volume[i] * T.Abs(dm / cm * TTwo - T.One) * THundred * (trend == 0 ? T.NegativeOne : T.One);
            if (i == 1)
            {
                shortEma = vf;
                longEma = vf;
            }
            else
            {
                shortEma = (vf - shortEma) * shortPer + shortEma;
                longEma = (vf - longEma) * longPer + longEma;
            }

            output[outputIndex++] = shortEma - longEma;
            prevHlc = hlc;
        }

        return TI_OKAY;
    }
}

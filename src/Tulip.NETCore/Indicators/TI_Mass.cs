namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int MassStart(T[] options)
    {
        var sumP = Int32.CreateTruncating(options[0]) - 1;
        // The ema uses a hard-coded period of 9. (9-1)*2 = 16
        return 16 + sumP;
    }

    private static int Mass(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= MassStart(options))
        {
            return TI_OKAY;
        }

        var (high, low) = inputs;
        var output = outputs[0];

        // mass uses a hard-coded 9 period for the ema
        T per = TTwo / T.CreateChecked(9 + 1);
        T per1 = T.One - per;

        // Calculate EMA(h-l)
        T ema = high[0] - low[0];

        // Calculate EMA(EMA(h-l))
        T ema2 = ema;
        var sum = BufferFactory(period);
        int outputIndex = default;
        for (var i = 0; i < size; ++i)
        {
            T hl = high[i] - low[i];
            ema = ema * per1 + hl * per;
            if (i == 8)
            {
                ema2 = ema;
            }

            if (i < 8)
            {
                continue;
            }

            ema2 = ema2 * per1 + ema * per;
            if (i >= 16)
            {
                BufferPush(ref sum, ema / ema2);

                if (i >= period + 16 - 1)
                {
                    output[outputIndex++] = sum.sum;
                }
            }
        }

        return TI_OKAY;
    }
}

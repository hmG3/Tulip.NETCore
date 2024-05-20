namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int UltOscStart(T[] options) => Int32.CreateTruncating(options[2]);

    private static int UltOsc(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var shortPeriod = Int32.CreateTruncating(options[0]);
        var mediumPeriod = Int32.CreateTruncating(options[1]);
        var longPeriod = Int32.CreateTruncating(options[2]);

        if (shortPeriod < 1 || mediumPeriod < shortPeriod || longPeriod < mediumPeriod)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= UltOscStart(options))
        {
            return TI_OKAY;
        }

        var (high, low, close) = inputs;
        var output = outputs[0];

        var bpBuf = BufferFactory(longPeriod);
        var rBuf = BufferFactory(longPeriod);
        T bpShortSum = T.Zero;
        T bpMediumSum = T.Zero;
        T rShortSum = T.Zero;
        T rMediumSum = T.Zero;
        int outputIndex = default;
        for (var i = 1; i < size; ++i)
        {
            T trueLow = T.Min(low[i], close[i - 1]);
            T trueHigh = T.Max(high[i], close[i - 1]);
            T bp = close[i] - trueLow;
            T r = trueHigh - trueLow;
            bpShortSum += bp;
            bpMediumSum += bp;
            rShortSum += r;
            rMediumSum += r;

            BufferPush(ref bpBuf, bp);
            BufferPush(ref rBuf, r);

            // The long sum takes care of itself, but we're piggy-backing the medium and short sums off the same buffers.
            if (i > shortPeriod)
            {
                int shortIndex = bpBuf.index - shortPeriod - 1;
                if (shortIndex < 0)
                {
                    shortIndex += longPeriod;
                }

                bpShortSum -= bpBuf.vals[shortIndex];
                rShortSum -= rBuf.vals[shortIndex];
                if (i > mediumPeriod)
                {
                    int mediumIndex = bpBuf.index - mediumPeriod - 1;
                    if (mediumIndex < 0)
                    {
                        mediumIndex += longPeriod;
                    }

                    bpMediumSum -= bpBuf.vals[mediumIndex];
                    rMediumSum -= rBuf.vals[mediumIndex];
                }
            }

            if (i >= longPeriod)
            {
                T first = T.CreateChecked(4) * bpShortSum / rShortSum;
                T second = TTwo * bpMediumSum / rMediumSum;
                T third = T.One * bpBuf.sum / rBuf.sum;
                T ult = (first + second + third) * THundred / T.CreateChecked(7);
                output[outputIndex++] = ult;
            }
        }

        return TI_OKAY;
    }
}

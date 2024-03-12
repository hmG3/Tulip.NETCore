namespace Tulip
{
    internal static partial class Tinet
    {
        private static int UltOscStart(double[] options) => (int) options[2];

        private static int UltOscStart(decimal[] options) => (int) options[2];

        private static int UltOsc(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var shortPeriod = (int) options[0];
            var mediumPeriod = (int) options[1];
            var longPeriod = (int) options[2];

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

            var bpBuf = BufferDoubleFactory(longPeriod);
            var rBuf = BufferDoubleFactory(longPeriod);
            double bpShortSum = default;
            double bpMediumSum = default;
            double rShortSum = default;
            double rMediumSum = default;
            int outputIndex = default;
            for (var i = 1; i < size; ++i)
            {
                double trueLow = Math.Min(low[i], close[i - 1]);
                double trueHigh = Math.Max(high[i], close[i - 1]);
                double bp = close[i] - trueLow;
                double r = trueHigh - trueLow;
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
                    double first = 4.0 * bpShortSum / rShortSum;
                    double second = 2.0 * bpMediumSum / rMediumSum;
                    double third = 1.0 * bpBuf.sum / rBuf.sum;
                    double ult = (first + second + third) * 100.0 / 7.0;
                    output[outputIndex++] = ult;
                }
            }

            return TI_OKAY;
        }

        private static int UltOsc(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var shortPeriod = (int) options[0];
            var mediumPeriod = (int) options[1];
            var longPeriod = (int) options[2];

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

            var bpBuf = BufferDecimalFactory(longPeriod);
            var rBuf = BufferDecimalFactory(longPeriod);
            decimal bpShortSum = default;
            decimal bpMediumSum = default;
            decimal rShortSum = default;
            decimal rMediumSum = default;
            int outputIndex = default;
            for (var i = 1; i < size; ++i)
            {
                decimal trueLow = Math.Min(low[i], close[i - 1]);
                decimal trueHigh = Math.Max(high[i], close[i - 1]);
                decimal bp = close[i] - trueLow;
                decimal r = trueHigh - trueLow;
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
                    decimal first = 4m * bpShortSum / rShortSum;
                    decimal second = 2m * bpMediumSum / rMediumSum;
                    decimal third = Decimal.One * bpBuf.sum / rBuf.sum;
                    decimal ult = (first + second + third) * 100m / 7m;
                    output[outputIndex++] = ult;
                }
            }

            return TI_OKAY;
        }
    }
}

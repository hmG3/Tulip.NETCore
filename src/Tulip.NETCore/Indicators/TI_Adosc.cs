namespace Tulip
{
    internal static partial class Tinet
    {
        private static int AdOscStart(double[] options) => (int) options[1] - 1;

        private static int AdOscStart(decimal[] options) => (int) options[1] - 1;

        private static int AdOsc(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var shortPeriod = (int) options[0];
            var longPeriod = (int) options[1];

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
            double shortPer = 2.0 / (shortPeriod + 1);
            double longPer = 2.0 / (longPeriod + 1);
            double sum = default;
            double shortEma = default;
            double longEma = default;
            int outputIndex = default;
            for (var i = 0; i < size; ++i)
            {
                double hl = high[i] - low[i];
                if (!hl.Equals(0.0))
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

        private static int AdOsc(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var shortPeriod = (int) options[0];
            var longPeriod = (int) options[1];

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
            decimal shortPer = 2m / (shortPeriod + 1);
            decimal longPer = 2m / (longPeriod + 1);
            decimal sum = default;
            decimal shortEma = default;
            decimal longEma = default;
            int outputIndex = default;
            for (var i = 0; i < size; ++i)
            {
                decimal hl = high[i] - low[i];
                if (hl != Decimal.Zero)
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
}

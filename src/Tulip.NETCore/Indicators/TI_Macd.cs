namespace Tulip
{
    internal static partial class Tinet
    {
        private static int MacdStart(double[] options)
        {
            // NB we return data before signal is strictly valid.
            int longPeriod = (int) options[1];
            return longPeriod - 1;
        }

        private static int MacdStart(decimal[] options)
        {
            // NB we return data before signal is strictly valid.
            int longPeriod = (int) options[1];
            return longPeriod - 1;
        }

        private static int Macd(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var shortPeriod = (int) options[0];
            var longPeriod = (int) options[1];
            var signalPeriod = (int) options[2];

            if (shortPeriod < 1 || longPeriod < 2 || longPeriod < shortPeriod || signalPeriod < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= MacdStart(options))
            {
                return TI_OKAY;
            }

            var input = inputs[0];
            var (macd, signal, hist) = outputs;

            double shortPer = 2.0 / (shortPeriod + 1);
            double longPer = 2.0 / (longPeriod + 1);
            if (shortPeriod == 12 && longPeriod == 26)
            {
                // It's what people expect.
                shortPer = 0.15;
                longPer = 0.075;
            }

            double signalPer = 2.0 / (signalPeriod + 1);
            double shortEma = input[0];
            double longEma = input[0];
            double signalEma = default;
            int macdIndex = default;
            int signalIndex = default;
            int histIndex = default;
            for (var i = 1; i < size; ++i)
            {
                shortEma = (input[i] - shortEma) * shortPer + shortEma;
                longEma = (input[i] - longEma) * longPer + longEma;
                double outEma = shortEma - longEma;
                if (i == longPeriod - 1)
                {
                    signalEma = outEma;
                }

                if (i >= longPeriod - 1)
                {
                    signalEma = (outEma - signalEma) * signalPer + signalEma;
                    macd[macdIndex++] = outEma;
                    signal[signalIndex++] = signalEma;
                    hist[histIndex++] = outEma - signalEma;
                }
            }

            return TI_OKAY;
        }

        private static int Macd(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var shortPeriod = (int) options[0];
            var longPeriod = (int) options[1];
            var signalPeriod = (int) options[2];

            if (shortPeriod < 1 || longPeriod < 2 || longPeriod < shortPeriod || signalPeriod < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= MacdStart(options))
            {
                return TI_OKAY;
            }

            var input = inputs[0];
            var (macd, signal, hist) = outputs;

            decimal shortPer = 2m / (shortPeriod + 1);
            decimal longPer = 2m / (longPeriod + 1);
            if (shortPeriod == 12 && longPeriod == 26)
            {
                // It's what people expect.
                shortPer = 0.15m;
                longPer = 0.075m;
            }

            decimal signalPer = 2m / (signalPeriod + 1);
            decimal shortEma = input[0];
            decimal longEma = input[0];
            decimal signalEma = default;
            int macdIndex = default;
            int signalIndex = default;
            int histIndex = default;
            for (var i = 1; i < size; ++i)
            {
                shortEma = (input[i] - shortEma) * shortPer + shortEma;
                longEma = (input[i] - longEma) * longPer + longEma;
                decimal outEma = shortEma - longEma;
                if (i == longPeriod - 1)
                {
                    signalEma = outEma;
                }

                if (i >= longPeriod - 1)
                {
                    signalEma = (outEma - signalEma) * signalPer + signalEma;
                    macd[macdIndex++] = outEma;
                    signal[signalIndex++] = signalEma;
                    hist[histIndex++] = outEma - signalEma;
                }
            }

            return TI_OKAY;
        }
    }
}

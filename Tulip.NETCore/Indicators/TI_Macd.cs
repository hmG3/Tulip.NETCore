using System;

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
            double[] input = inputs[0];
            double[] macd = outputs[0];
            double[] signal = outputs[1];
            double[] hist = outputs[2];
            int shortPeriod = (int) options[0];
            int longPeriod = (int) options[1];
            int signalPeriod = (int) options[2];

            if (shortPeriod < 1 || longPeriod < 2 || longPeriod < shortPeriod || signalPeriod < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= MacdStart(options))
            {
                return TI_OKAY;
            }

            double shortPer = 2.0 / (shortPeriod + 1.0);
            double longPer = 2.0 / (longPeriod + 1.0);
            double signalPer = 2.0 / (signalPeriod + 1.0);
            if (shortPeriod == 12 && longPeriod == 26)
            {
                // I don't like this, but it's what people expect.
                shortPer = 0.15;
                longPer = 0.075;
            }

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
            decimal[] input = inputs[0];
            decimal[] macd = outputs[0];
            decimal[] signal = outputs[1];
            decimal[] hist = outputs[2];
            int shortPeriod = (int) options[0];
            int longPeriod = (int) options[1];
            int signalPeriod = (int) options[2];

            if (shortPeriod < 1 || longPeriod < 2 || longPeriod < shortPeriod || signalPeriod < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= MacdStart(options))
            {
                return TI_OKAY;
            }

            decimal shortPer = 2m / (shortPeriod + Decimal.One);
            decimal longPer = 2m / (longPeriod + Decimal.One);
            decimal signalPer = 2m / (signalPeriod + Decimal.One);
            if (shortPeriod == 12 && longPeriod == 26)
            {
                // I don't like this, but it's what people expect.
                shortPer = 0.15m;
                longPer = 0.075m;
            }

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

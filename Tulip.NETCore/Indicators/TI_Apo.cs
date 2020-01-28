using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int ApoStart(double[] options)
        {
            return 1;
        }
        private static int ApoStart(decimal[] options)
        {
            return 1;
        }

        private static int Apo(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] apo = outputs[0];
            var shortPeriod = (int) options[0];
            var longPeriod = (int) options[1];

            if (shortPeriod < 1 || longPeriod < 2 || longPeriod < shortPeriod)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= ApoStart(options))
            {
                return TI_OKAY;
            }

            double shortPer = 2.0 / (shortPeriod + 1.0);
            double longPer = 2.0 / (longPeriod + 1.0);
            double shortEma = input[0];
            double longEma = input[0];
            int apoIndex = default;
            for (var i = 1; i < size; ++i)
            {
                shortEma = (input[i] - shortEma) * shortPer + shortEma;
                longEma = (input[i] - longEma) * longPer + longEma;
                apo[apoIndex++] = shortEma - longEma;
            }

            return TI_OKAY;
        }

        private static int Apo(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] input = inputs[0];
            decimal[] apo = outputs[0];
            var shortPeriod = (int) options[0];
            var longPeriod = (int) options[1];

            if (shortPeriod < 1 || longPeriod < 2 || longPeriod < shortPeriod)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= ApoStart(options))
            {
                return TI_OKAY;
            }

            decimal shortPer = 2m / (shortPeriod + Decimal.One);
            decimal longPer = 2m / (longPeriod + Decimal.One);
            decimal shortEma = input[0];
            decimal longEma = input[0];
            int apoIndex = default;
            for (var i = 1; i < size; ++i)
            {
                shortEma = (input[i] - shortEma) * shortPer + shortEma;
                longEma = (input[i] - longEma) * longPer + longEma;
                apo[apoIndex++] = shortEma - longEma;
            }

            return TI_OKAY;
        }
    }
}

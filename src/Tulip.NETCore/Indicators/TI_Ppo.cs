namespace Tulip
{
    internal static partial class Tinet
    {
        private static int PpoStart(double[] options) => 1;

        private static int PpoStart(decimal[] options) => 1;

        private static int Ppo(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            int shortPeriod = (int) options[0];
            int longPeriod = (int) options[1];

            if (shortPeriod < 1 || longPeriod < 2 || longPeriod < shortPeriod)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= PpoStart(options))
            {
                return TI_OKAY;
            }

            double[] input = inputs[0];
            double[] ppo = outputs[0];

            double shortPer = 2.0 / (shortPeriod + 1);
            double longPer = 2.0 / (longPeriod + 1);
            double shortEma = input[0];
            double longEma = input[0];
            int ppoIndex = default;
            for (var i = 1; i < size; ++i)
            {
                shortEma = (input[i] - shortEma) * shortPer + shortEma;
                longEma = (input[i] - longEma) * longPer + longEma;
                double outEma = 100.0 * (shortEma - longEma) / longEma;
                ppo[ppoIndex++] = outEma;
            }

            return TI_OKAY;
        }

        private static int Ppo(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            int shortPeriod = (int) options[0];
            int longPeriod = (int) options[1];

            if (shortPeriod < 1 || longPeriod < 2 || longPeriod < shortPeriod)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= PpoStart(options))
            {
                return TI_OKAY;
            }

            decimal[] input = inputs[0];
            decimal[] ppo = outputs[0];

            decimal shortPer = 2m / (shortPeriod + 1);
            decimal longPer = 2m / (longPeriod + 1);
            decimal shortEma = input[0];
            decimal longEma = input[0];
            int ppoIndex = default;
            for (var i = 1; i < size; ++i)
            {
                shortEma = (input[i] - shortEma) * shortPer + shortEma;
                longEma = (input[i] - longEma) * longPer + longEma;
                decimal outEma = 100m * (shortEma - longEma) / longEma;
                ppo[ppoIndex++] = outEma;
            }

            return TI_OKAY;
        }
    }
}

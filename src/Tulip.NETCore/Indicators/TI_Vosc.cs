namespace Tulip
{
    internal static partial class Tinet
    {
        private static int VoscStart(double[] options) => (int) options[1] - 1;

        private static int VoscStart(decimal[] options) => (int) options[1] - 1;

        private static int Vosc(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var shortPeriod = (int) options[0];
            var longPeriod = (int) options[1];

            if (shortPeriod < 1 || longPeriod < shortPeriod)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= VoscStart(options))
            {
                return TI_OKAY;
            }

            var input = inputs[0];
            var output = outputs[0];

            double shortSum = default;
            double longSum = default;
            for (var i = 0; i < longPeriod; ++i)
            {
                if (i >= longPeriod - shortPeriod)
                {
                    shortSum += input[i];
                }

                longSum += input[i];
            }

            double shortDiv = 1.0 / shortPeriod;
            double longDiv = 1.0 / longPeriod;
            double savg = shortSum * shortDiv;
            double lavg = longSum * longDiv;
            int outputIndex = default;
            output[outputIndex++] = 100.0 * (savg - lavg) / lavg;
            for (var i = longPeriod; i < size; ++i)
            {
                shortSum += input[i];
                shortSum -= input[i - shortPeriod];

                longSum += input[i];
                longSum -= input[i - longPeriod];

                savg = shortSum * shortDiv;
                lavg = longSum * longDiv;
                output[outputIndex++] = 100.0 * (savg - lavg) / lavg;
            }

            return TI_OKAY;
        }

        private static int Vosc(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var shortPeriod = (int) options[0];
            var longPeriod = (int) options[1];

            if (shortPeriod < 1 || longPeriod < shortPeriod)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= VoscStart(options))
            {
                return TI_OKAY;
            }

            var input = inputs[0];
            var output = outputs[0];

            decimal shortSum = default;
            decimal longSum = default;
            for (var i = 0; i < longPeriod; ++i)
            {
                if (i >= longPeriod - shortPeriod)
                {
                    shortSum += input[i];
                }

                longSum += input[i];
            }

            decimal shortDiv = Decimal.One / shortPeriod;
            decimal longDiv = Decimal.One / longPeriod;
            decimal savg = shortSum * shortDiv;
            decimal lavg = longSum * longDiv;
            int outputIndex = default;
            output[outputIndex++] = 100m * (savg - lavg) / lavg;
            for (var i = longPeriod; i < size; ++i)
            {
                shortSum += input[i];
                shortSum -= input[i - shortPeriod];

                longSum += input[i];
                longSum -= input[i - longPeriod];

                savg = shortSum * shortDiv;
                lavg = longSum * longDiv;
                output[outputIndex++] = 100m * (savg - lavg) / lavg;
            }

            return TI_OKAY;
        }
    }
}

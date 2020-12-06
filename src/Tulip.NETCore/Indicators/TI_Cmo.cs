using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int CmoStart(double[] options) => (int) options[0];

        private static int CmoStart(decimal[] options) => (int) options[0];

        private static int Cmo(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= CmoStart(options))
            {
                return TI_OKAY;
            }

            var input = inputs[0];
            var output = outputs[0];

            double upSum = default;
            double downSum = default;
            for (var i = 1; i <= period; ++i)
            {
                upSum += input[i] > input[i - 1] ? input[i] - input[i - 1] : 0.0;
                downSum += input[i] < input[i - 1] ? input[i - 1] - input[i] : 0.0;
            }

            int outputIndex = default;
            output[outputIndex++] = 100.0 * (upSum - downSum) / (upSum + downSum);
            for (var i = period + 1; i < size; ++i)
            {
                upSum -= input[i - period] > input[i - period - 1] ? input[i - period] - input[i - period - 1] : 0.0;
                downSum -= input[i - period] < input[i - period - 1] ? input[i - period - 1] - input[i - period] : 0.0;

                upSum += input[i] > input[i - 1] ? input[i] - input[i - 1] : 0.0;
                downSum += input[i] < input[i - 1] ? input[i - 1] - input[i] : 0.0;

                output[outputIndex++] = 100.0 * (upSum - downSum) / (upSum + downSum);
            }

            return TI_OKAY;
        }

        private static int Cmo(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= CmoStart(options))
            {
                return TI_OKAY;
            }

            var input = inputs[0];
            var output = outputs[0];

            decimal upSum = default;
            decimal downSum = default;
            for (var i = 1; i <= period; ++i)
            {
                upSum += input[i] > input[i - 1] ? input[i] - input[i - 1] : Decimal.Zero;
                downSum += input[i] < input[i - 1] ? input[i - 1] - input[i] : Decimal.Zero;
            }

            int outputIndex = default;
            output[outputIndex++] = 100m * (upSum - downSum) / (upSum + downSum);
            for (var i = period + 1; i < size; ++i)
            {
                upSum -= input[i - period] > input[i - period - 1] ? input[i - period] - input[i - period - 1] : Decimal.Zero;
                downSum -= input[i - period] < input[i - period - 1] ? input[i - period - 1] - input[i - period] : Decimal.Zero;

                upSum += input[i] > input[i - 1] ? input[i] - input[i - 1] : Decimal.Zero;
                downSum += input[i] < input[i - 1] ? input[i - 1] - input[i] : Decimal.Zero;

                output[outputIndex++] = 100m * (upSum - downSum) / (upSum + downSum);
            }

            return TI_OKAY;
        }
    }
}

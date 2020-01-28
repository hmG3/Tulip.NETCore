using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int DemaStart(double[] options)
        {
            int period = (int) options[0];
            return (period - 1) * 2;
        }

        private static int DemaStart(decimal[] options)
        {
            int period = (int) options[0];
            return (period - 1) * 2;
        }

        private static int Dema(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int period = (int) options[0];
            double[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= DemaStart(options))
            {
                return TI_OKAY;
            }

            double per = 2.0 / (period + 1.0);
            double per1 = 1.0 - per;

            // Calculate EMA(input)
            double ema = input[0];

            // Calculate EMA(EMA(input))
            double ema2 = ema;
            int outputIndex = default;
            for (var i = 0; i < size; ++i)
            {
                ema = ema * per1 + input[i] * per;
                if (i == period - 1)
                {
                    ema2 = ema;
                }

                if (i >= period - 1)
                {
                    ema2 = ema2 * per1 + ema * per;
                    if (i >= (period - 1) * 2)
                    {
                        output[outputIndex++] = ema * 2.0 - ema2;
                    }
                }
            }

            return TI_OKAY;
        }

        private static int Dema(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] input = inputs[0];
            int period = (int) options[0];
            decimal[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= DemaStart(options))
            {
                return TI_OKAY;
            }

            decimal per = 2m / (period + Decimal.One);
            decimal per1 = Decimal.One - per;

            // Calculate EMA(input)
            decimal ema = input[0];

            // Calculate EMA(EMA(input))
            decimal ema2 = ema;
            int outputIndex = default;
            for (var i = 0; i < size; ++i)
            {
                ema = ema * per1 + input[i] * per;
                if (i == period - 1)
                {
                    ema2 = ema;
                }

                if (i >= period - 1)
                {
                    ema2 = ema2 * per1 + ema * per;
                    if (i >= (period - 1) * 2)
                    {
                        output[outputIndex++] = ema * 2m - ema2;
                    }
                }
            }

            return TI_OKAY;
        }
    }
}

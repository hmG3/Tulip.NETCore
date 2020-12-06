using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int TemaStart(double[] options) => ((int) options[0] - 1) * 3;

        private static int TemaStart(decimal[] options) => ((int) options[0] - 1) * 3;

        private static int Tema(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= TemaStart(options))
            {
                return TI_OKAY;
            }

            var input = inputs[0];
            var output = outputs[0];

            double per = 2.0 / (period + 1);
            double per1 = 1.0 - per;
            // Calculate EMA(input)
            double ema = input[0];

            // Calculate EMA(EMA(input))
            double ema2 = default;

            // Calculate EMA(EMA(EMA(input)))
            double ema3 = default;
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
                    if (i == (period - 1) * 2)
                    {
                        ema3 = ema2;
                    }

                    if (i >= (period - 1) * 2)
                    {
                        ema3 = ema3 * per1 + ema2 * per;
                        if (i >= (period - 1) * 3)
                        {
                            output[outputIndex++] = 3.0 * ema - 3.0 * ema2 + ema3;
                        }
                    }
                }
            }

            return TI_OKAY;
        }

        private static int Tema(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= TemaStart(options))
            {
                return TI_OKAY;
            }

            var input = inputs[0];
            var output = outputs[0];

            decimal per = 2m / (period + 1);
            decimal per1 = Decimal.One - per;
            // Calculate EMA(input)
            decimal ema = input[0];

            // Calculate EMA(EMA(input))
            decimal ema2 = default;

            // Calculate EMA(EMA(EMA(input)))
            decimal ema3 = default;
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
                    if (i == (period - 1) * 2)
                    {
                        ema3 = ema2;
                    }

                    if (i >= (period - 1) * 2)
                    {
                        ema3 = ema3 * per1 + ema2 * per;
                        if (i >= (period - 1) * 3)
                        {
                            output[outputIndex++] = 3m * ema - 3m * ema2 + ema3;
                        }
                    }
                }
            }

            return TI_OKAY;
        }
    }
}

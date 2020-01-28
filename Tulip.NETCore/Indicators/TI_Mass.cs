using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int MassStart(double[] options)
        {
            int sumP = (int) options[0] - 1;
            // The ema uses a hard-coded period of 9. (9-1)*2 = 16
            return 16 + sumP;
        }

        private static int MassStart(decimal[] options)
        {
            int sumP = (int) options[0] - 1;
            // The ema uses a hard-coded period of 9. (9-1)*2 = 16
            return 16 + sumP;
        }

        private static int Mass(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] high = inputs[0];
            double[] low = inputs[1];
            int period = (int) options[0];
            double[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= MassStart(options))
            {
                return TI_OKAY;
            }

            // mass uses a hard-coded 9 period for the ema
            double per = 2.0 / (9.0 + 1.0);
            double per1 = 1.0 - per;

            // Calculate EMA(h-l)
            double ema = high[0] - low[0];

            // Calculate EMA(EMA(h-l))
            double ema2 = ema;
            var sum = BufferDoubleNew(period);
            int outputIndex = default;
            for (var i = 0; i < size; ++i)
            {
                double hl = high[i] - low[i];
                ema = ema * per1 + hl * per;
                if (i == 8)
                {
                    ema2 = ema;
                }

                if (i < 8)
                {
                    continue;
                }

                ema2 = ema2 * per1 + ema * per;
                if (i >= 16)
                {
                    BufferPush(ref sum, ema / ema2);

                    if (i >= period + 16 - 1)
                    {
                        output[outputIndex++] = sum.sum;
                    }
                }
            }

            return TI_OKAY;
        }

        private static int Mass(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] high = inputs[0];
            decimal[] low = inputs[1];
            int period = (int) options[0];
            decimal[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= MassStart(options))
            {
                return TI_OKAY;
            }

            // mass uses a hard-coded 9 period for the ema
            decimal per = 2m / (9m + Decimal.One);
            decimal per1 = Decimal.One - per;

            // Calculate EMA(h-l)
            decimal ema = high[0] - low[0];

            // Calculate EMA(EMA(h-l))
            decimal ema2 = ema;
            var sum = BufferDecimalNew(period);
            int outputIndex = default;
            for (var i = 0; i < size; ++i)
            {
                decimal hl = high[i] - low[i];
                ema = ema * per1 + hl * per;
                if (i == 8)
                {
                    ema2 = ema;
                }

                if (i < 8)
                {
                    continue;
                }

                ema2 = ema2 * per1 + ema * per;
                if (i >= 16)
                {
                    BufferPush(ref sum, ema / ema2);

                    if (i >= period + 16 - 1)
                    {
                        output[outputIndex++] = sum.sum;
                    }
                }
            }

            return TI_OKAY;
        }
    }
}

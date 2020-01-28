using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int DmStart(double[] options)
        {
            return (int) options[0] - 1;
        }

        private static int DmStart(decimal[] options)
        {
            return (int) options[0] - 1;
        }

        private static int Dm(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] high = inputs[0];
            double[] low = inputs[1];
            int period = (int) options[0];
            double[] plusDm = outputs[0];
            double[] minusDm = outputs[1];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= DmStart(options))
            {
                return TI_OKAY;
            }

            double per = (period - 1.0) / period;
            double dmUp = default;
            double dmDown = default;
            for (var i = 1; i < period; ++i)
            {
                CalcDirection(high, low, i, out double dp, out double dm);

                dmUp += dp;
                dmDown += dm;
            }

            int plusDmIndex = default;
            int minusDmIndex = default;
            plusDm[plusDmIndex++] = dmUp;
            minusDm[minusDmIndex++] = dmDown;
            for (int i = period; i < size; ++i)
            {
                CalcDirection(high, low, i, out double dp, out double dm);

                dmUp = dmUp * per + dp;
                dmDown = dmDown * per + dm;
                plusDm[plusDmIndex++] = dmUp;
                minusDm[minusDmIndex++] = dmDown;
            }

            return TI_OKAY;
        }

        private static int Dm(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] high = inputs[0];
            decimal[] low = inputs[1];
            int period = (int) options[0];
            decimal[] plusDm = outputs[0];
            int plusDmIndex = default;
            decimal[] minusDm = outputs[1];
            int minusDmIndex = default;
            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= DmStart(options))
            {
                return TI_OKAY;
            }

            decimal per = (period - Decimal.One) / period;
            decimal dmUp = default;
            decimal dmDown = default;
            for (var i = 1; i < period; ++i)
            {
                CalcDirection(high, low, i, out decimal dp, out decimal dm);

                dmUp += dp;
                dmDown += dm;
            }

            plusDm[plusDmIndex++] = dmUp;
            minusDm[minusDmIndex++] = dmDown;
            for (int i = period; i < size; ++i)
            {
                CalcDirection(high, low, i, out decimal dp, out decimal dm);

                dmUp = dmUp * per + dp;
                dmDown = dmDown * per + dm;
                plusDm[plusDmIndex++] = dmUp;
                minusDm[minusDmIndex++] = dmDown;
            }

            return TI_OKAY;
        }
    }
}

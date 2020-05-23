using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int DmStart(double[] options) => (int) options[0] - 1;

        private static int DmStart(decimal[] options) => (int) options[0] - 1;

        private static int Dm(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= DmStart(options))
            {
                return TI_OKAY;
            }

            double[] high = inputs[0];
            double[] low = inputs[1];
            double[] plusDm = outputs[0];
            double[] minusDm = outputs[1];

            double dmUp = default;
            double dmDown = default;
            for (var i = 1; i < period; ++i)
            {
                CalcDirection(high, low, i, out double dp, out double dm);

                dmUp += dp;
                dmDown += dm;
            }

            double per = (period - 1.0) / period;
            int plusDmIndex = default;
            int minusDmIndex = default;
            plusDm[plusDmIndex++] = dmUp;
            minusDm[minusDmIndex++] = dmDown;
            for (var i = period; i < size; ++i)
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
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= DmStart(options))
            {
                return TI_OKAY;
            }

            decimal[] high = inputs[0];
            decimal[] low = inputs[1];
            decimal[] plusDm = outputs[0];
            decimal[] minusDm = outputs[1];

            decimal dmUp = default;
            decimal dmDown = default;
            for (var i = 1; i < period; ++i)
            {
                CalcDirection(high, low, i, out decimal dp, out decimal dm);

                dmUp += dp;
                dmDown += dm;
            }

            decimal per = (period - Decimal.One) / period;
            int plusDmIndex = default;
            int minusDmIndex = default;
            plusDm[plusDmIndex++] = dmUp;
            minusDm[minusDmIndex++] = dmDown;
            for (var i = period; i < size; ++i)
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

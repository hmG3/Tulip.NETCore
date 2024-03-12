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

            var (high, low) = inputs;
            var (plusDm, minusDm) = outputs;

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

            var (high, low) = inputs;
            var (plusDm, minusDm) = outputs;

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

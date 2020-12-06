using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int MswStart(double[] options) => (int) options[0];

        private static int MswStart(decimal[] options) => (int) options[0];

        private static int Msw(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= MswStart(options))
            {
                return TI_OKAY;
            }

            var input = inputs[0];
            var (sine, lead) = outputs;

            const double tpi = 2 * Math.PI;
            int sineIndex = default;
            int leadIndex = default;
            for (var i = period; i < size; ++i)
            {
                double rp = default;
                double ip = default;
                for (var j = 0; j < period; ++j)
                {
                    double weight = input[i - j];
                    rp += Math.Cos(tpi * j / period) * weight;
                    ip += Math.Sin(tpi * j / period) * weight;
                }

                double phase;
                if (Math.Abs(rp) > .001)
                {
                    phase = Math.Atan(ip / rp);
                }
                else
                {
                    phase = tpi / 2.0 * (ip < 0 ? -1.0 : 1.0);
                }

                if (rp < 0.0)
                {
                    phase += Math.PI;
                }

                phase += Math.PI / 2.0;
                if (phase < 0.0)
                {
                    phase += tpi;
                }

                if (phase > tpi)
                {
                    phase -= tpi;
                }

                sine[sineIndex++] = Math.Sin(phase);
                lead[leadIndex++] = Math.Sin(phase + Math.PI / 4.0);
            }

            return TI_OKAY;
        }

        private static int Msw(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= MswStart(options))
            {
                return TI_OKAY;
            }

            var input = inputs[0];
            var (sine, lead) = outputs;

            const decimal tpi = 2m * DecimalMath.PI;
            int sineIndex = default;
            int leadIndex = default;
            for (var i = period; i < size; ++i)
            {
                decimal rp = default;
                decimal ip = default;
                for (var j = 0; j < period; ++j)
                {
                    decimal weight = input[i - j];
                    rp += DecimalMath.Cos(tpi * j / period) * weight;
                    ip += DecimalMath.Sin(tpi * j / period) * weight;
                }

                decimal phase;
                if (Math.Abs(rp) > .001m)
                {
                    phase = DecimalMath.Atan(ip / rp);
                }
                else
                {
                    phase = tpi / 2m * (ip < 0 ? Decimal.MinusOne : Decimal.One);
                }

                if (rp < Decimal.Zero)
                {
                    phase += DecimalMath.PI;
                }

                phase += DecimalMath.PI / 2m;
                if (phase < Decimal.Zero)
                {
                    phase += tpi;
                }

                if (phase > tpi)
                {
                    phase -= tpi;
                }

                sine[sineIndex++] = DecimalMath.Sin(phase);
                lead[leadIndex++] = DecimalMath.Sin(phase + DecimalMath.PI / 4m);
            }

            return TI_OKAY;
        }
    }
}

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int MdStart(double[] options) => (int) options[0] - 1;

        private static int MdStart(decimal[] options) => (int) options[0] - 1;

        private static int Md(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= MdStart(options))
            {
                return TI_OKAY;
            }

            var input = inputs[0];
            var output = outputs[0];

            double scale = 1.0 / period;
            double sum = default;
            int outputIndex = default;
            for (var i = 0; i < size; ++i)
            {
                double today = input[i];
                sum += today;
                if (i >= period)
                {
                    sum -= input[i - period];
                }

                double avg = sum * scale;
                if (i >= period - 1)
                {
                    double acc = default;
                    for (var j = 0; j < period; ++j)
                    {
                        acc += Math.Abs(avg - input[i - j]);
                    }

                    output[outputIndex++] = acc * scale;
                }
            }

            return TI_OKAY;
        }

        private static int Md(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= MdStart(options))
            {
                return TI_OKAY;
            }

            var input = inputs[0];
            var output = outputs[0];

            decimal scale = Decimal.One / period;
            decimal sum = default;
            int outputIndex = default;
            for (var i = 0; i < size; ++i)
            {
                decimal today = input[i];
                sum += today;
                if (i >= period)
                {
                    sum -= input[i - period];
                }

                decimal avg = sum * scale;
                if (i >= period - 1)
                {
                    decimal acc = default;
                    for (var j = 0; j < period; ++j)
                    {
                        acc += Math.Abs(avg - input[i - j]);
                    }

                    output[outputIndex++] = acc * scale;
                }
            }

            return TI_OKAY;
        }
    }
}

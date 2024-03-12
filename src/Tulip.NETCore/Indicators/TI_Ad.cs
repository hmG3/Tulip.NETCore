namespace Tulip
{
    internal static partial class Tinet
    {
        private static int AdStart(double[] options) => 0;

        private static int AdStart(decimal[] options) => 0;

        private static int Ad(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var (high, low, close, volume) = inputs;
            var output = outputs[0];

            double sum = default;
            for (var i = 0; i < size; ++i)
            {
                double hl = high[i] - low[i];
                if (!hl.Equals(0.0))
                {
                    sum += (close[i] - low[i] - high[i] + close[i]) / hl * volume[i];
                }

                output[i] = sum;
            }

            return TI_OKAY;
        }

        private static int Ad(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var (high, low, close, volume) = inputs;
            var output = outputs[0];

            decimal sum = default;
            for (var i = 0; i < size; ++i)
            {
                decimal hl = high[i] - low[i];
                if (hl != Decimal.Zero)
                {
                    sum += (close[i] - low[i] - high[i] + close[i]) / hl * volume[i];
                }

                output[i] = sum;
            }

            return TI_OKAY;
        }
    }
}

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int EmvStart(double[] options) => 1;

        private static int EmvStart(decimal[] options) => 1;

        private static int Emv(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            if (size <= EmvStart(options))
            {
                return TI_OKAY;
            }

            double[] high = inputs[0];
            double[] low = inputs[1];
            double[] volume = inputs[2];
            double[] output = outputs[0];

            double last = (high[0] + low[0]) * 0.5;
            int outputIndex = default;
            for (var i = 1; i < size; ++i)
            {
                double hl = (high[i] + low[i]) * 0.5;
                double br = volume[i] / 10000.0 / (high[i] - low[i]);
                output[outputIndex++] = (hl - last) / br;
                last = hl;
            }

            return TI_OKAY;
        }

        private static int Emv(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            if (size <= EmvStart(options))
            {
                return TI_OKAY;
            }

            decimal[] high = inputs[0];
            decimal[] low = inputs[1];
            decimal[] volume = inputs[2];
            decimal[] output = outputs[0];

            decimal last = (high[0] + low[0]) * 0.5m;
            int outputIndex = default;
            for (var i = 1; i < size; ++i)
            {
                decimal hl = (high[i] + low[i]) * 0.5m;
                decimal br = volume[i] / 10000m / (high[i] - low[i]);
                output[outputIndex++] = (hl - last) / br;
                last = hl;
            }

            return TI_OKAY;
        }
    }
}

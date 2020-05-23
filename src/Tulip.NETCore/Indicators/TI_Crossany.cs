namespace Tulip
{
    internal static partial class Tinet
    {
        private static int CrossanyStart(double[] options) => 1;

        private static int CrossanyStart(decimal[] options) => 1;

        private static int Crossany(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] a = inputs[0];
            double[] b = inputs[1];
            double[] output = outputs[0];

            int outputIndex = default;
            for (var i = 1; i < size; ++i)
            {
                output[outputIndex++] = a[i] > b[i] && a[i - 1] <= b[i - 1] || a[i] < b[i] && a[i - 1] >= b[i - 1] ? 1 : 0;
            }

            return TI_OKAY;
        }

        private static int Crossany(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] a = inputs[0];
            decimal[] b = inputs[1];
            decimal[] output = outputs[0];

            int outputIndex = default;
            for (var i = 1; i < size; ++i)
            {
                output[outputIndex++] = a[i] > b[i] && a[i - 1] <= b[i - 1] || a[i] < b[i] && a[i - 1] >= b[i - 1] ? 1 : 0;
            }

            return TI_OKAY;
        }
    }
}

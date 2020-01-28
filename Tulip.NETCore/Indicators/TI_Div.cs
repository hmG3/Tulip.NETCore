namespace Tulip
{
    internal static partial class Tinet
    {
        private static int DivStart(double[] options)
        {
            return 0;
        }

        private static int DivStart(decimal[] options)
        {
            return 0;
        }

        private static int Div(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple2(inputs, outputs, DivStart(options), (d1, d2) => d1 / d2);

            return TI_OKAY;
        }

        private static int Div(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple2(inputs, outputs, DivStart(options), (d1, d2) => d1 / d2);

            return TI_OKAY;
        }
    }
}

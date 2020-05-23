namespace Tulip
{
    internal static partial class Tinet
    {
        private static int DivStart(double[] options) => 0;

        private static int DivStart(decimal[] options) => 0;

        private static int Div(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple2(size, inputs[0], inputs[1], outputs[0], (d1, d2) => d1 / d2);

            return TI_OKAY;
        }

        private static int Div(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple2(size, inputs[0], inputs[1], outputs[0], (d1, d2) => d1 / d2);

            return TI_OKAY;
        }
    }
}

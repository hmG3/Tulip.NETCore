using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int TanhStart(double[] options)
        {
            return 0;
        }

        private static int TanhStart(decimal[] options)
        {
            return 0;
        }

        private static int Tanh(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(inputs, outputs, TanhStart(options), Math.Tanh);

            return TI_OKAY;
        }

        private static int Tanh(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(inputs, outputs, TanhStart(options), DecimalMath.Tanh);

            return TI_OKAY;
        }
    }
}

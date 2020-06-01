using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int AcosStart(double[] options) => 0;

        private static int AcosStart(decimal[] options) => 0;

        private static int Acos(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], Math.Acos);

            return TI_OKAY;
        }

        private static int Acos(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], DecimalMath.Acos);

            return TI_OKAY;
        }
    }
}

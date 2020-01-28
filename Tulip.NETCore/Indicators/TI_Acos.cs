using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int AcosStart(double[] options)
        {
            return 0;
        }

        public static int AcosStart(decimal[] options)
        {
            return 0;
        }

        private static int Acos(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(inputs, outputs, AcosStart(options), Math.Acos);

            return TI_OKAY;
        }

        private static int Acos(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(inputs, outputs, AcosStart(options), DecimalMath.Acos);

            return TI_OKAY;
        }
    }
}

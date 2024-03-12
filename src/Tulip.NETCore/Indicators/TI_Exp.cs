namespace Tulip;

internal static partial class Tinet
{
    private static int ExpStart(double[] options) => 0;

    private static int ExpStart(decimal[] options) => 0;

    private static int Exp(int size, double[][] inputs, double[] options, double[][] outputs)
    {
        Simple1(size, inputs[0], outputs[0], Math.Exp);

        return TI_OKAY;
    }

    private static int Exp(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
    {
        Simple1(size, inputs[0], outputs[0], DecimalMath.Exp);

        return TI_OKAY;
    }
}

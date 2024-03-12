namespace Tulip;

internal static partial class Tinet
{
    private static int RoundStart(double[] options) => 0;

    private static int RoundStart(decimal[] options) => 0;

    private static int Round(int size, double[][] inputs, double[] options, double[][] outputs)
    {
        Simple1(size, inputs[0], outputs[0], Math.Round);

        return TI_OKAY;
    }

    private static int Round(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
    {
        Simple1(size, inputs[0], outputs[0], Math.Round);

        return TI_OKAY;
    }
}

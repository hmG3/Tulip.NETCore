namespace Tulip;

internal static partial class Tinet
{
    private static int CrossoverStart(double[] options) => 1;

    private static int CrossoverStart(decimal[] options) => 1;

    private static int Crossover(int size, double[][] inputs, double[] options, double[][] outputs)
    {
        var (a, b) = inputs;
        var output = outputs[0];

        int outputIndex = default;
        for (var i = 1; i < size; ++i)
        {
            output[outputIndex++] = a[i] > b[i] && a[i - 1] <= b[i - 1] ? 1 : 0;
        }

        return TI_OKAY;
    }

    private static int Crossover(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
    {
        var (a, b) = inputs;
        var output = outputs[0];

        int outputIndex = default;
        for (var i = 1; i < size; ++i)
        {
            output[outputIndex++] = a[i] > b[i] && a[i - 1] <= b[i - 1] ? 1 : 0;
        }

        return TI_OKAY;
    }
}

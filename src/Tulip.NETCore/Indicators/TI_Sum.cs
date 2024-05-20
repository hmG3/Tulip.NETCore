namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int SumStart(T[] options) => Int32.CreateTruncating(options[0]) - 1;

    private static int Sum(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= SumStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        T sum = T.Zero;
        for (var i = 0; i < period; ++i)
        {
            sum += input[i];
        }

        int outputIndex = default;
        output[outputIndex++] = sum;
        for (var i = period; i < size; ++i)
        {
            sum = sum + input[i] - input[i - period];
            output[outputIndex++] = sum;
        }

        return TI_OKAY;
    }
}

namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int LagStart(T[] options) => Int32.CreateTruncating(options[0]);

    private static int Lag(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 0)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= LagStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        int outputIndex = default;
        for (var i = period; i < size; ++i)
        {
            output[outputIndex++] = input[i - period];
        }

        return TI_OKAY;
    }
}

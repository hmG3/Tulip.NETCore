namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int RocStart(T[] options) => Int32.CreateTruncating(options[0]);

    private static int Roc(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= RocStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        int outputIndex = default;
        for (var i = period; i < size; ++i)
        {
            output[outputIndex++] = (input[i] - input[i - period]) / input[i - period];
        }

        return TI_OKAY;
    }
}

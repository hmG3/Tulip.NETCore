namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int ZlEmaStart(T[] options) => (Int32.CreateTruncating(options[0]) - 1) / 2 - 1;

    private static int ZlEma(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= ZlEmaStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        var lag = (period - 1) / 2;
        T per = TTwo / T.CreateChecked(period + 1);
        T val = input[lag - 1];
        int outputIndex = default;
        output[outputIndex++] = val;
        for (var i = lag; i < size; ++i)
        {
            T c = input[i];
            T l = input[i - lag];
            val = (c + (c - l) - val) * per + val;
            output[outputIndex++] = val;
        }

        return TI_OKAY;
    }
}

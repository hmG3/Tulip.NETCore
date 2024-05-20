namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int EmaStart(T[] options) => 0;

    private static int Ema(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= EmaStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        T per = TTwo / T.CreateChecked(period + 1);
        T val = input[0];
        int outputIndex = default;
        output[outputIndex++] = val;
        for (var i = 1; i < size; ++i)
        {
            val = (input[i] - val) * per + val;
            output[outputIndex++] = val;
        }

        return TI_OKAY;
    }
}

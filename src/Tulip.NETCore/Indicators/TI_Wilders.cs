namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int WildersStart(T[] options) => Int32.CreateTruncating(options[0]) - 1;

    private static int Wilders(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= WildersStart(options))
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

        T per = T.One / T.CreateChecked(period);
        T val = sum / T.CreateChecked(period);
        int outputIndex = default;
        output[outputIndex++] = val;
        for (var i = period; i < size; ++i)
        {
            val = (input[i] - val) * per + val;
            output[outputIndex++] = val;
        }

        return TI_OKAY;
    }
}

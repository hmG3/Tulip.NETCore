namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int VarStart(T[] options) => Int32.CreateTruncating(options[0]) - 1;

    private static int Var(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= VarStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        T sum = T.Zero;
        T sum2 = T.Zero;
        for (var i = 0; i < period; ++i)
        {
            sum += input[i];
            sum2 += input[i] * input[i];
        }

        T scale = T.One / T.CreateChecked(period);
        int outputIndex = default;
        output[outputIndex++] = sum2 * scale - sum * scale * (sum * scale);
        for (var i = period; i < size; ++i)
        {
            sum += input[i];
            sum2 += input[i] * input[i];

            sum -= input[i - period];
            sum2 -= input[i - period] * input[i - period];

            output[outputIndex++] = sum2 * scale - sum * scale * (sum * scale);
        }

        return TI_OKAY;
    }
}

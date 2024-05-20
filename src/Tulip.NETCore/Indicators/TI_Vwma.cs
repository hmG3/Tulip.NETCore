namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int VwmaStart(T[] options) => Int32.CreateTruncating(options[0]) - 1;

    private static int Vwma(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= VwmaStart(options))
        {
            return TI_OKAY;
        }

        var (input, volume) = inputs;
        var output = outputs[0];

        T sum = T.Zero;
        T vSum = T.Zero;
        for (var i = 0; i < period; ++i)
        {
            sum += input[i] * volume[i];
            vSum += volume[i];
        }

        int outputIndex = default;
        output[outputIndex++] = sum / vSum;
        for (var i = period; i < size; ++i)
        {
            sum += input[i] * volume[i];
            sum -= input[i - period] * volume[i - period];
            vSum += volume[i];
            vSum -= volume[i - period];

            output[outputIndex++] = sum / vSum;
        }

        return TI_OKAY;
    }
}

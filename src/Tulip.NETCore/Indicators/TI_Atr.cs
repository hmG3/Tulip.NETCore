namespace Tulip;

internal static partial class Tinet<T> where T : IFloatingPointIeee754<T>
{
    private static int AtrStart(T[] options) => Int32.CreateTruncating(options[0]) - 1;

    private static int Atr(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= AtrStart(options))
        {
            return TI_OKAY;
        }

        var (high, low, close) = inputs;
        var output = outputs[0];

        T sum = high[0] - low[0];
        for (var i = 1; i < period; ++i)
        {
            CalcTrueRange(low, high, close, i, out T trueRange);
            sum += trueRange;
        }

        T per = T.One / T.CreateChecked(period);
        T val = sum / T.CreateChecked(period);
        int outputIndex = default;
        output[outputIndex++] = val;
        for (var i = period; i < size; ++i)
        {
            CalcTrueRange(low, high, close, i, out T trueRange);
            val = (trueRange - val) * per + val;
            output[outputIndex++] = val;
        }

        return TI_OKAY;
    }
}

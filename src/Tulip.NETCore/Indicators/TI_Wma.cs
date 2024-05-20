namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int WmaStart(T[] options) => Int32.CreateTruncating(options[0]) - 1;

    private static int Wma(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= WmaStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        T weightSum = T.Zero; // Weighted sum of previous numbers.
        T sum = T.Zero; // Flat sum of previous numbers.
        for (var i = 0; i < period - 1; ++i)
        {
            weightSum += input[i] * T.CreateChecked(i + 1);
            sum += input[i];
        }

        T weights = T.CreateChecked(period * (period + 1)) / TTwo; // Weights for 6 period WMA: 1 2 3 4 5 6
        int outputIndex = default;
        for (var i = period - 1; i < size; ++i)
        {
            weightSum += input[i] * T.CreateChecked(period);
            sum += input[i];

            output[outputIndex++] = weightSum / weights;

            weightSum -= sum;
            sum -= input[i - period + 1];
        }

        return TI_OKAY;
    }
}

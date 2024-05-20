namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int VidyaStart(T[] options) => Int32.CreateTruncating(options[1]) - 2;

    private static int Vidya(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var shortPeriod = Int32.CreateTruncating(options[0]);
        var longPeriod = Int32.CreateTruncating(options[1]);
        var alpha = options[2];

        if (shortPeriod < 1 || longPeriod < shortPeriod || longPeriod < 2 || alpha < T.Zero || alpha > T.One)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= VidyaStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        T shortSum = T.Zero;
        T shortSum2 = T.Zero;
        T longSum = T.Zero;
        T longSum2 = T.Zero;
        for (var i = 0; i < longPeriod; ++i)
        {
            longSum += input[i];
            longSum2 += input[i] * input[i];
            if (i >= longPeriod - shortPeriod)
            {
                shortSum += input[i];
                shortSum2 += input[i] * input[i];
            }
        }

        T shortDiv = T.One / T.CreateChecked(shortPeriod);
        T longDiv = T.One / T.CreateChecked(longPeriod);
        T val = input[longPeriod - 2];
        int outputIndex = default;
        output[outputIndex++] = val;
        if (longPeriod - 1 < size)
        {
            var shortStdDev = T.Sqrt(shortSum2 * shortDiv - shortSum * shortDiv * (shortSum * shortDiv));
            var longStdDev = T.Sqrt(longSum2 * longDiv - longSum * longDiv * (longSum * longDiv));
            T k = shortStdDev / longStdDev;

            k *= alpha;
            val = (input[longPeriod - 1] - val) * k + val;
            output[outputIndex++] = val;
        }

        for (var i = longPeriod; i < size; ++i)
        {
            longSum += input[i];
            longSum2 += input[i] * input[i];

            shortSum += input[i];
            shortSum2 += input[i] * input[i];

            longSum -= input[i - longPeriod];
            longSum2 -= input[i - longPeriod] * input[i - longPeriod];

            shortSum -= input[i - shortPeriod];
            shortSum2 -= input[i - shortPeriod] * input[i - shortPeriod];

            T shortStdDev = T.Sqrt(shortSum2 * shortDiv - shortSum * shortDiv * (shortSum * shortDiv));
            T longStdDev = T.Sqrt(longSum2 * longDiv - longSum * longDiv * (longSum * longDiv));
            T k = shortStdDev / longStdDev;

            k *= alpha;
            val = (input[i] - val) * k + val;
            output[outputIndex++] = val;
        }

        return TI_OKAY;
    }
}

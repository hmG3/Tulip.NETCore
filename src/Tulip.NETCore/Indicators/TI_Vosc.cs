namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int VoscStart(T[] options) => Int32.CreateTruncating(options[1]) - 1;

    private static int Vosc(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var shortPeriod = Int32.CreateTruncating(options[0]);
        var longPeriod = Int32.CreateTruncating(options[1]);

        if (shortPeriod < 1 || longPeriod < shortPeriod)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= VoscStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        T shortSum = T.Zero;
        T longSum = T.Zero;
        for (var i = 0; i < longPeriod; ++i)
        {
            if (i >= longPeriod - shortPeriod)
            {
                shortSum += input[i];
            }

            longSum += input[i];
        }

        T shortDiv = T.One / T.CreateChecked(shortPeriod);
        T longDiv = T.One / T.CreateChecked(longPeriod);
        T savg = shortSum * shortDiv;
        T lavg = longSum * longDiv;
        int outputIndex = default;
        output[outputIndex++] = THundred * (savg - lavg) / lavg;
        for (var i = longPeriod; i < size; ++i)
        {
            shortSum += input[i];
            shortSum -= input[i - shortPeriod];

            longSum += input[i];
            longSum -= input[i - longPeriod];

            savg = shortSum * shortDiv;
            lavg = longSum * longDiv;
            output[outputIndex++] = THundred * (savg - lavg) / lavg;
        }

        return TI_OKAY;
    }
}

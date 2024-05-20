namespace Tulip;

internal static partial class Tinet<T> where T : IFloatingPointIeee754<T>
{
    private static int PpoStart(T[] options) => 1;

    private static int Ppo(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var shortPeriod = Int32.CreateTruncating(options[0]);
        var longPeriod = Int32.CreateTruncating(options[1]);

        if (shortPeriod < 1 || longPeriod < 2 || longPeriod < shortPeriod)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= PpoStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        T shortPer = TTwo / T.CreateChecked(shortPeriod + 1);
        T longPer = TTwo / T.CreateChecked(longPeriod + 1);
        T shortEma = input[0];
        T longEma = input[0];
        int ppoIndex = default;
        for (var i = 1; i < size; ++i)
        {
            shortEma = (input[i] - shortEma) * shortPer + shortEma;
            longEma = (input[i] - longEma) * longPer + longEma;
            T outEma = THundred * (shortEma - longEma) / longEma;
            output[ppoIndex++] = outEma;
        }

        return TI_OKAY;
    }
}

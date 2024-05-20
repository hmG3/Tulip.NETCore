namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int MacdStart(T[] options)
    {
        // NB we return data before signal is strictly valid.
        int longPeriod = Int32.CreateTruncating(options[1]);
        return longPeriod - 1;
    }

    private static int Macd(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var shortPeriod = Int32.CreateTruncating(options[0]);
        var longPeriod = Int32.CreateTruncating(options[1]);
        var signalPeriod = Int32.CreateTruncating(options[2]);

        if (shortPeriod < 1 || longPeriod < 2 || longPeriod < shortPeriod || signalPeriod < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= MacdStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var (macd, signal, hist) = outputs;

        T shortPer = TTwo / T.CreateChecked(shortPeriod + 1);
        T longPer = TTwo / T.CreateChecked(longPeriod + 1);
        if (shortPeriod == 12 && longPeriod == 26)
        {
            // It's what people expect.
            shortPer = T.CreateChecked(0.15);
            longPer = T.CreateChecked(0.075);
        }

        T signalPer = TTwo / T.CreateChecked(signalPeriod + 1);
        T shortEma = input[0];
        T longEma = input[0];
        T signalEma = T.Zero;
        int macdIndex = default;
        int signalIndex = default;
        int histIndex = default;
        for (var i = 1; i < size; ++i)
        {
            shortEma = (input[i] - shortEma) * shortPer + shortEma;
            longEma = (input[i] - longEma) * longPer + longEma;
            T outEma = shortEma - longEma;
            if (i == longPeriod - 1)
            {
                signalEma = outEma;
            }

            if (i >= longPeriod - 1)
            {
                signalEma = (outEma - signalEma) * signalPer + signalEma;
                macd[macdIndex++] = outEma;
                signal[signalIndex++] = signalEma;
                hist[histIndex++] = outEma - signalEma;
            }
        }

        return TI_OKAY;
    }
}

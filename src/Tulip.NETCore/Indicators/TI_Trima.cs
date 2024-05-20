namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int TrimaStart(T[] options) => Int32.CreateTruncating(options[0]) - 1;

    private static int Trima(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= TrimaStart(options))
        {
            return TI_OKAY;
        }

        if (period <= 2)
        {
            return Sma(size, inputs, options, outputs);
        }

        var input = inputs[0];
        var output = outputs[0];

        T weightSum = T.Zero; // Weighted sum of previous numbers, spans one period back.
        T leadSum = T.Zero; // Flat sum of most recent numbers.
        T trailSum = T.Zero; // Flat sum of oldest numbers.
        int leadPeriod = period % 2 == 0 ? period / 2 - 1 : period / 2;
        int trailPeriod = leadPeriod + 1;
        int w = 1;
        for (var i = 0; i < period - 1; ++i)
        {
            weightSum += input[i] * T.CreateChecked(w);
            if (i + 1 > period - leadPeriod)
            {
                leadSum += input[i];
            }

            if (i + 1 <= trailPeriod)
            {
                trailSum += input[i];
            }

            if (i + 1 < trailPeriod)
            {
                ++w;
            }

            if (i + 1 >= period - leadPeriod)
            {
                --w;
            }
        }

        // Weights for 6 period TRIMA: 1 2 3 3 2 1 = 12
        // Weights for 7 period TRIMA: 1 2 3 4 3 2 1 = 16
        T weights = T.One / T.CreateChecked(period % 2 != 0 ? (period / 2 + 1) * (period / 2 + 1) : (period / 2 + 1) * (period / 2));
        int lsi = period - leadPeriod;
        int tsi1 = period - period + trailPeriod;
        int tsi2 = period - period;
        int outputIndex = default;
        // Initialize until before the first value.
        for (var i = period - 1; i < size; ++i)
        {
            weightSum += input[i];
            output[outputIndex++] = weightSum * weights;

            leadSum += input[i];

            // 1 2 3 4 5 4 3 2 1
            weightSum += leadSum;
            // 1 2 3 4 5 5 4 3 2
            weightSum -= trailSum;
            //   1 2 3 4 5 4 3 2

            /* weightSum      1 2 3 4 5 4 3 2 1
               leadSum                  1 1 1 1
               trailSum       1 1 1 1 1         */
            leadSum -= input[lsi++];
            trailSum += input[tsi1++];
            trailSum -= input[tsi2++];
        }

        return TI_OKAY;
    }
}

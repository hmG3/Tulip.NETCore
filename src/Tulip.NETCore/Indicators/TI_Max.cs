namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int MaxStart(T[] options) => Int32.CreateTruncating(options[0]) - 1;

    private static int Max(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= MaxStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        var maxi = -1;
        T max = input[0];
        int outputIndex = default;
        for (int i = period - 1, trail = 0; i < size; ++i, ++trail)
        {
            T bar = input[i];

            if (maxi < trail)
            {
                maxi = trail;
                max = input[maxi];
                int j = trail;
                while (++j <= i)
                {
                    bar = input[j];
                    if (bar >= max)
                    {
                        max = bar;
                        maxi = j;
                    }
                }
            }
            else if (bar >= max)
            {
                maxi = i;
                max = bar;
            }

            output[outputIndex++] = max;
        }

        return TI_OKAY;
    }
}

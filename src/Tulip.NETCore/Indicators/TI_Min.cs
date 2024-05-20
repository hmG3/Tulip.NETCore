namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int MinStart(T[] options) => Int32.CreateTruncating(options[0]) - 1;

    private static int Min(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= MinStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        var mini = -1;
        T min = input[0];
        int outputIndex = default;
        for (int i = period - 1, trail = 0; i < size; ++i, ++trail)
        {
            T bar = input[i];
            if (mini < trail)
            {
                mini = trail;
                min = input[mini];
                int j = trail;
                while (++j <= i)
                {
                    bar = input[j];
                    if (bar <= min)
                    {
                        min = bar;
                        mini = j;
                    }
                }
            }
            else if (bar <= min)
            {
                mini = i;
                min = bar;
            }

            output[outputIndex++] = min;
        }

        return TI_OKAY;
    }
}

namespace Tulip;

internal static partial class Tinet
{
    private static int MinStart(double[] options) => (int) options[0] - 1;

    private static int MinStart(decimal[] options) => (int) options[0] - 1;

    private static int Min(int size, double[][] inputs, double[] options, double[][] outputs)
    {
        var period = (int) options[0];

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
        double min = input[0];
        int outputIndex = default;
        for (int i = period - 1, trail = 0; i < size; ++i, ++trail)
        {
            double bar = input[i];
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

    private static int Min(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
    {
        var period = (int) options[0];

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
        decimal min = input[0];
        int outputIndex = default;
        for (int i = period - 1, trail = 0; i < size; ++i, ++trail)
        {
            decimal bar = input[i];
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

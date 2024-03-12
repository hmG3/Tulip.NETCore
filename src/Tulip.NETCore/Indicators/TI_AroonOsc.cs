namespace Tulip;

internal static partial class Tinet
{
    private static int AroonOscStart(double[] options) => (int) options[0];

    private static int AroonOscStart(decimal[] options) => (int) options[0];

    private static int AroonOsc(int size, double[][] inputs, double[] options, double[][] outputs)
    {
        var period = (int) options[0];

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= AroonStart(options))
        {
            return TI_OKAY;
        }

        var (high, low) = inputs;
        var output = outputs[0];

        double scale = 100.0 / period;
        var maxi = -1;
        var mini = -1;
        double max = high[0];
        double min = low[0];

        int outputIndex = default;
        for (int i = period, trail = 0; i < size; ++i, ++trail)
        {
            // Maintain highest.
            double bar = high[i];
            int j;
            if (maxi < trail)
            {
                maxi = trail;
                max = high[maxi];
                j = trail;
                while (++j <= i)
                {
                    bar = high[j];
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


            // Maintain lowest.
            bar = low[i];
            if (mini < trail)
            {
                mini = trail;
                min = low[mini];
                j = trail;
                while (++j <= i)
                {
                    bar = low[j];
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

            output[outputIndex++] = (maxi - mini) * scale;
        }

        return TI_OKAY;
    }

    private static int AroonOsc(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
    {
        var period = (int) options[0];

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= AroonStart(options))
        {
            return TI_OKAY;
        }

        var (high, low) = inputs;
        var output = outputs[0];

        decimal scale = 100m / period;
        var maxi = -1;
        var mini = -1;
        decimal max = high[0];
        decimal min = low[0];

        int outputIndex = default;
        for (int i = period, trail = 0; i < size; ++i, ++trail)
        {
            // Maintain highest.
            decimal bar = high[i];
            int j;
            if (maxi < trail)
            {
                maxi = trail;
                max = high[maxi];
                j = trail;
                while (++j <= i)
                {
                    bar = high[j];
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


            // Maintain lowest.
            bar = low[i];
            if (mini < trail)
            {
                mini = trail;
                min = low[mini];
                j = trail;
                while (++j <= i)
                {
                    bar = low[j];
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

            output[outputIndex++] = (maxi - mini) * scale;
        }

        return TI_OKAY;
    }
}

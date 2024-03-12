namespace Tulip
{
    internal static partial class Tinet
    {
        private static int WillRStart(double[] options) => (int) options[0] - 1;

        private static int WillRStart(decimal[] options) => (int) options[0] - 1;

        private static int WillR(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= WillRStart(options))
            {
                return TI_OKAY;
            }

            var (high, low, close) = inputs;
            var output = outputs[0];

            var maxi = -1;
            var mini = -1;
            double max = high[0];
            double min = low[0];
            int outputIndex = default;
            for (int i = period - 1, trail = 0; i < size; ++i, ++trail)
            {
                // Maintain highest.
                double bar = high[i];
                if (maxi < trail)
                {
                    maxi = trail;
                    max = high[maxi];
                    int j = trail;
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
                    int j = trail;
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

                // Calculate it.
                double highLow = max - min;
                double r = highLow.Equals(0.0) ? 0.0 : -100.0 * ((max - close[i]) / highLow);
                output[outputIndex++] = r;
            }

            return TI_OKAY;
        }

        private static int WillR(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= WillRStart(options))
            {
                return TI_OKAY;
            }

            var (high, low, close) = inputs;
            var output = outputs[0];

            var maxi = -1;
            var mini = -1;
            decimal max = high[0];
            decimal min = low[0];
            int outputIndex = default;
            for (int i = period - 1, trail = 0; i < size; ++i, ++trail)
            {
                // Maintain highest.
                decimal bar = high[i];
                if (maxi < trail)
                {
                    maxi = trail;
                    max = high[maxi];
                    int j = trail;
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
                    int j = trail;
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

                // Calculate it.
                decimal highLow = max - min;
                decimal r = highLow == Decimal.Zero ? Decimal.Zero : -100m * ((max - close[i]) / highLow);
                output[outputIndex++] = r;
            }

            return TI_OKAY;
        }
    }
}

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int AroonStart(double[] options)
        {
            return (int) options[0];
        }

        private static int AroonStart(decimal[] options)
        {
            return (int) options[0];
        }

        private static int Aroon(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] high = inputs[0];
            double[] low = inputs[1];
            double[] aDown = outputs[0];
            double[] aUp = outputs[1];
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= AroonStart(options))
            {
                return TI_OKAY;
            }

            double scale = 100.0 / period;
            int maxi = -1;
            int mini = -1;
            double max = high[0];
            double min = low[0];

            int aDownIndex = default;
            int aUpIndex = default;
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

                // Calculate the indicator.
                aDown[aDownIndex++] = (period - i - mini) * scale;
                aUp[aUpIndex++] = (period - i - maxi) * scale;
            }

            return TI_OKAY;
        }

        private static int Aroon(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] high = inputs[0];
            decimal[] low = inputs[1];
            decimal[] aDown = outputs[0];
            decimal[] aUp = outputs[1];
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= AroonStart(options))
            {
                return TI_OKAY;
            }

            decimal scale = 100m / period;
            int maxi = -1;
            int mini = -1;
            decimal max = high[0];
            decimal min = low[0];

            int aDownIndex = default;
            int aUpIndex = default;
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

                // Calculate the indicator.
                aDown[aDownIndex++] = (period - i - mini) * scale;
                aUp[aUpIndex++] = (period - i - maxi) * scale;
            }

            return TI_OKAY;
        }
    }
}

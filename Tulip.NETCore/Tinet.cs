using System;

namespace Tulip
{
    internal static class Tinet
    {
        internal static int ti_abs_start(double[] options)
        {
            return 0;
        }

        internal static int ti_abs(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = Math.Abs(input[index]);
            }

            return 0;
        }

        internal static int ti_acos_start(double[] options)
        {
            return 0;
        }

        internal static int ti_acos(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = Math.Acos(input[index]);
            }

            return 0;
        }

        internal static int ti_ad_start(double[] options)
        {
            return 0;
        }

        internal static int ti_ad(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] input3 = inputs[2];
            double[] input4 = inputs[3];
            double[] output = outputs[0];
            double num1 = 0.0;
            for (int index = 0; index < size; ++index)
            {
                double num2 = input1[index] - input2[index];
                if (num2 != 0.0)
                {
                    num1 += (input3[index] - input2[index] - input1[index] + input3[index]) / num2 * input4[index];
                }

                output[index] = num1;
            }

            return 0;
        }

        internal static int ti_add_start(double[] options)
        {
            return 0;
        }

        internal static int ti_add(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = input1[index] + input2[index];
            }

            return 0;
        }

        internal static int ti_adosc_start(double[] options)
        {
            return (int) options[1] - 1;
        }

        internal static int ti_adosc(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] input3 = inputs[2];
            double[] input4 = inputs[3];
            int option1 = (int) options[0];
            int option2 = (int) options[1];
            int num1 = option2 - 1;
            int num2;
            if (option1 < 1)
            {
                num2 = 1;
            }
            else if (option2 < option1)
            {
                num2 = 1;
            }
            else if (size <= ti_adosc_start(options))
            {
                num2 = 0;
            }
            else
            {
                double num3 = 2.0 / (option1 + 1.0);
                double num4 = 2.0 / (option2 + 1.0);
                double[] output = outputs[0];
                int index1 = 0;
                double num5 = 0.0;
                double num6 = 0.0;
                double num7 = 0.0;
                for (int index2 = 0; index2 < size; ++index2)
                {
                    double num8 = input1[index2] - input2[index2];
                    if (num8 != 0.0)
                    {
                        num5 += (input3[index2] - input2[index2] - input1[index2] + input3[index2]) / num8 * input4[index2];
                    }

                    if (index2 == 0)
                    {
                        num6 = num5;
                        num7 = num5;
                    }
                    else
                    {
                        num6 = (num5 - num6) * num3 + num6;
                        num7 = (num5 - num7) * num4 + num7;
                    }

                    if (index2 < num1)
                    {
                        continue;
                    }

                    output[index1] = num6 - num7;
                    ++index1;
                }

                num2 = 0;
            }

            return num2;
        }

        internal static int ti_adx_start(double[] options)
        {
            return ((int) options[0] - 1) * 2;
        }

        internal static int ti_adx(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] input3 = inputs[2];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 2)
            {
                num1 = 1;
            }
            else if (size <= ti_adx_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = (option - 1.0) / option;
                double num3 = 1.0 / option;
                double num4 = 0.0;
                double num5 = 0.0;
                double num6 = 0.0;
                for (int index2 = 1; index2 < option; ++index2)
                {
                    double num7;
                    do
                    {
                        double num8 = input2[index2];
                        double num9 = input1[index2];
                        double num10 = input3[index2 - 1];
                        double num11 = Math.Abs(num9 - num10);
                        double num12 = Math.Abs(num8 - num10);
                        double num13 = num9 - num8;
                        if (num11 > num13)
                        {
                            num13 = num11;
                        }

                        if (num12 > num13)
                        {
                            num13 = num12;
                        }

                        num7 = num13;
                    } while (false);

                    num4 += num7;
                    double num14;
                    double num15;
                    do
                    {
                        num14 = input1[index2] - input1[index2 - 1];
                        num15 = input2[index2 - 1] - input2[index2];
                        if (num14 < 0.0)
                        {
                            num14 = 0.0;
                        }
                        else if (num14 > num15)
                        {
                            num15 = 0.0;
                        }

                        if (num15 < 0.0)
                        {
                            num15 = 0.0;
                        }
                        else if (num15 > num14)
                        {
                            num14 = 0.0;
                        }
                    } while (false);

                    num5 += num14;
                    num6 += num15;
                }

                double num16 = 0.0;
                double num17 = num5 / num4;
                double num18 = num6 / num4;
                double num19 = Math.Abs(num17 - num18) / (num17 + num18) * 100.0;
                double num20 = num16 + num19;
                for (int index2 = option; index2 < size; ++index2)
                {
                    double num7;
                    do
                    {
                        double num8 = input2[index2];
                        double num9 = input1[index2];
                        double num10 = input3[index2 - 1];
                        double num11 = Math.Abs(num9 - num10);
                        double num12 = Math.Abs(num8 - num10);
                        double num13 = num9 - num8;
                        if (num11 > num13)
                        {
                            num13 = num11;
                        }

                        if (num12 > num13)
                        {
                            num13 = num12;
                        }

                        num7 = num13;
                    } while (false);

                    num4 = num4 * num2 + num7;
                    double num14;
                    double num15;
                    do
                    {
                        num14 = input1[index2] - input1[index2 - 1];
                        num15 = input2[index2 - 1] - input2[index2];
                        if (num14 < 0.0)
                        {
                            num14 = 0.0;
                        }
                        else if (num14 > num15)
                        {
                            num15 = 0.0;
                        }

                        if (num15 < 0.0)
                        {
                            num15 = 0.0;
                        }
                        else if (num15 > num14)
                        {
                            num14 = 0.0;
                        }
                    } while (false);

                    num5 = num5 * num2 + num14;
                    num6 = num6 * num2 + num15;
                    double num21 = num5 / num4;
                    double num22 = num6 / num4;
                    double num23 = Math.Abs(num21 - num22) / (num21 + num22) * 100.0;
                    if (index2 - option >= option - 2)
                    {
                        goto label_42;
                    }

                    num20 += num23;
                    continue;
                    label_42:
                    if (index2 - option == option - 2)
                    {
                        num20 += num23;
                        output[index1] = num20 * num3;
                        ++index1;
                    }
                    else
                    {
                        num20 = num20 * num2 + num23;
                        output[index1] = num20 * num3;
                        ++index1;
                    }
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_adxr_start(double[] options)
        {
            return ((int) options[0] - 1) * 3;
        }

        internal static int ti_adxr(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] input3 = inputs[2];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 2)
            {
                num1 = 1;
            }
            else if (size <= ti_adxr_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = (option - 1.0) / option;
                double num3 = 1.0 / option;
                double num4 = 0.0;
                double num5 = 0.0;
                double num6 = 0.0;
                for (int index2 = 1; index2 < option; ++index2)
                {
                    double num7;
                    do
                    {
                        double num8 = input2[index2];
                        double num9 = input1[index2];
                        double num10 = input3[index2 - 1];
                        double num11 = Math.Abs(num9 - num10);
                        double num12 = Math.Abs(num8 - num10);
                        double num13 = num9 - num8;
                        if (num11 > num13)
                        {
                            num13 = num11;
                        }

                        if (num12 > num13)
                        {
                            num13 = num12;
                        }

                        num7 = num13;
                    } while (false);

                    num4 += num7;
                    double num14;
                    double num15;
                    do
                    {
                        num14 = input1[index2] - input1[index2 - 1];
                        num15 = input2[index2 - 1] - input2[index2];
                        if (num14 < 0.0)
                        {
                            num14 = 0.0;
                        }
                        else if (num14 > num15)
                        {
                            num15 = 0.0;
                        }

                        if (num15 < 0.0)
                        {
                            num15 = 0.0;
                        }
                        else if (num15 > num14)
                        {
                            num14 = 0.0;
                        }
                    } while (false);

                    num5 += num14;
                    num6 += num15;
                }

                double num16 = 0.0;
                double num17 = num5 / num4;
                double num18 = num6 / num4;
                double num19 = Math.Abs(num17 - num18) / (num17 + num18) * 100.0;
                double num20 = num16 + num19;
                var buffer = ti_buffer_new(option - 1);
                int num21 = ti_adxr_start(options);
                for (int index2 = option; index2 < size; ++index2)
                {
                    double num7;
                    do
                    {
                        double num8 = input2[index2];
                        double num9 = input1[index2];
                        double num10 = input3[index2 - 1];
                        double num11 = Math.Abs(num9 - num10);
                        double num12 = Math.Abs(num8 - num10);
                        double num13 = num9 - num8;
                        if (num11 > num13)
                        {
                            num13 = num11;
                        }

                        if (num12 > num13)
                        {
                            num13 = num12;
                        }

                        num7 = num13;
                    } while (false);

                    num4 = num4 * num2 + num7;
                    double num14;
                    double num15;
                    do
                    {
                        num14 = input1[index2] - input1[index2 - 1];
                        num15 = input2[index2 - 1] - input2[index2];
                        if (num14 < 0.0)
                        {
                            num14 = 0.0;
                        }
                        else if (num14 > num15)
                        {
                            num15 = 0.0;
                        }

                        if (num15 < 0.0)
                        {
                            num15 = 0.0;
                        }
                        else if (num15 > num14)
                        {
                            num14 = 0.0;
                        }
                    } while (false);

                    num5 = num5 * num2 + num14;
                    num6 = num6 * num2 + num15;
                    double num22 = num5 / num4;
                    double num23 = num6 / num4;
                    double num24 = Math.Abs(num22 - num23) / (num22 + num23) * 100.0;
                    if (index2 - option >= option - 2)
                    {
                        goto label_42;
                    }

                    num20 += num24;
                    continue;
                    label_42:
                    if (index2 - option == option - 2)
                    {
                        num20 += num24;
                        do
                        {
                            buffer.vals[buffer.index] = num20 * num3;
                            ++buffer.index;
                            if (buffer.index >= buffer.size)
                            {
                                buffer.index = 0;
                            }
                        } while (false);
                    }
                    else
                    {
                        num20 = num20 * num2 + num24;
                        if (index2 >= num21)
                        {
                            output[index1] = 0.5 * (num20 * num3 + buffer.vals[(buffer.index + buffer.size - 1 + 1) % buffer.size]);
                            ++index1;
                        }

                        do
                        {
                            buffer.vals[buffer.index] = num20 * num3;
                            ++buffer.index;
                            if (buffer.index >= buffer.size)
                            {
                                buffer.index = 0;
                            }
                        } while (false);
                    }
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_ao_start(double[] options)
        {
            return 33;
        }

        internal static int ti_ao(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (size <= ti_ao_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = 0.0;
                double num3 = 0.0;
                for (int index2 = 0; index2 < 34; ++index2)
                {
                    double num4 = 0.5 * (input1[index2] + input2[index2]);
                    num2 += num4;
                    if (index2 < 29)
                    {
                        continue;
                    }

                    num3 += num4;
                }

                output[index1] = 0.2 * num3 - 1.0 / 34.0 * num2;
                int index3 = index1 + 1;
                for (int index2 = 34; index2 < size; ++index2)
                {
                    double num4 = 0.5 * (input1[index2] + input2[index2]);
                    double num5 = num2 + num4;
                    double num6 = num3 + num4;
                    num2 = num5 - 0.5 * (input1[index2 - 34] + input2[index2 - 34]);
                    num3 = num6 - 0.5 * (input1[index2 - 5] + input2[index2 - 5]);
                    output[index3] = 0.2 * num3 - 1.0 / 34.0 * num2;
                    ++index3;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_apo_start(double[] options)
        {
            return 1;
        }

        internal static int ti_apo(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            int index1 = 0;
            int option1 = (int) options[0];
            int option2 = (int) options[1];
            int num1;
            if (option1 < 1)
            {
                num1 = 1;
            }
            else if (option2 < 2)
            {
                num1 = 1;
            }
            else if (option2 < option1)
            {
                num1 = 1;
            }
            else if (size <= ti_apo_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = 2.0 / (option1 + 1.0);
                double num3 = 2.0 / (option2 + 1.0);
                double num4 = input[0];
                double num5 = input[0];
                for (int index2 = 1; index2 < size; ++index2)
                {
                    num4 = (input[index2] - num4) * num2 + num4;
                    num5 = (input[index2] - num5) * num3 + num5;
                    double num6 = num4 - num5;
                    output[index1] = num6;
                    ++index1;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_aroon_start(double[] options)
        {
            return (int) options[0];
        }

        internal static int ti_aroon(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] output1 = outputs[0];
            int index1 = 0;
            double[] output2 = outputs[1];
            int index2 = 0;
            int option = (int) options[0];
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_aroon_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = 100.0 / option;
                int num3 = 0;
                int index3 = -1;
                int index4 = -1;
                double num4 = input1[0];
                double num5 = input2[0];
                int index5 = option;
                while (index5 < size)
                {
                    double num6 = input1[index5];
                    if (index3 < num3)
                    {
                        index3 = num3;
                        num4 = input1[index3];
                        int index6 = num3;
                        while (true)
                        {
                            double num7;
                            do
                            {
                                ++index6;
                                if (index6 <= index5)
                                {
                                    num7 = input1[index6];
                                }
                                else
                                {
                                    goto label_13;
                                }
                            } while (num7 < num4);

                            num4 = num7;
                            index3 = index6;
                        }
                    }

                    if (num6 >= num4)
                    {
                        index3 = index5;
                        num4 = num6;
                    }

                    label_13:
                    double num8 = input2[index5];
                    if (index4 < num3)
                    {
                        index4 = num3;
                        num5 = input2[index4];
                        int index6 = num3;
                        while (true)
                        {
                            double num7;
                            do
                            {
                                ++index6;
                                if (index6 <= index5)
                                {
                                    num7 = input2[index6];
                                }
                                else
                                {
                                    goto label_20;
                                }
                            } while (num7 > num5);

                            num5 = num7;
                            index4 = index6;
                        }
                    }

                    if (num8 <= num5)
                    {
                        index4 = index5;
                        num5 = num8;
                    }

                    label_20:
                    output1[index1] = (option - (double) (index5 - index4)) * num2;
                    ++index1;
                    output2[index2] = (option - (double) (index5 - index3)) * num2;
                    ++index2;
                    ++index5;
                    ++num3;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_aroonosc_start(double[] options)
        {
            return (int) options[0];
        }

        internal static int ti_aroonosc(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] output = outputs[0];
            int index1 = 0;
            int option = (int) options[0];
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_aroon_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = 100.0 / option;
                int num3 = 0;
                int index2 = -1;
                int index3 = -1;
                double num4 = input1[0];
                double num5 = input2[0];
                int index4 = option;
                while (index4 < size)
                {
                    double num6 = input1[index4];
                    if (index2 < num3)
                    {
                        index2 = num3;
                        num4 = input1[index2];
                        int index5 = num3;
                        while (true)
                        {
                            double num7;
                            do
                            {
                                ++index5;
                                if (index5 <= index4)
                                {
                                    num7 = input1[index5];
                                }
                                else
                                {
                                    goto label_13;
                                }
                            } while (num7 < num4);

                            num4 = num7;
                            index2 = index5;
                        }
                    }

                    if (num6 >= num4)
                    {
                        index2 = index4;
                        num4 = num6;
                    }

                    label_13:
                    double num8 = input2[index4];
                    if (index3 < num3)
                    {
                        index3 = num3;
                        num5 = input2[index3];
                        int index5 = num3;
                        while (true)
                        {
                            double num7;
                            do
                            {
                                ++index5;
                                if (index5 <= index4)
                                {
                                    num7 = input2[index5];
                                }
                                else
                                {
                                    goto label_20;
                                }
                            } while (num7 > num5);

                            num5 = num7;
                            index3 = index5;
                        }
                    }

                    if (num8 <= num5)
                    {
                        index3 = index4;
                        num5 = num8;
                    }

                    label_20:
                    output[index1] = (index2 - index3) * num2;
                    ++index1;
                    ++index4;
                    ++num3;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_asin_start(double[] options)
        {
            return 0;
        }

        internal static int ti_asin(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = Math.Asin(input[index]);
            }

            return 0;
        }

        internal static int ti_atan_start(double[] options)
        {
            return 0;
        }

        internal static int ti_atan(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = Math.Atan(input[index]);
            }

            return 0;
        }

        internal static int ti_atr_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_atr(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] input3 = inputs[2];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_atr_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = 1.0 / option;
                double num3 = 0.0 + (input1[0] - input2[0]);
                for (int index2 = 1; index2 < option; ++index2)
                {
                    double num4;
                    do
                    {
                        double num5 = input2[index2];
                        double num6 = input1[index2];
                        double num7 = input3[index2 - 1];
                        double num8 = Math.Abs(num6 - num7);
                        double num9 = Math.Abs(num5 - num7);
                        double num10 = num6 - num5;
                        if (num8 > num10)
                        {
                            num10 = num8;
                        }

                        if (num9 > num10)
                        {
                            num10 = num9;
                        }

                        num4 = num10;
                    } while (false);

                    num3 += num4;
                }

                double num11 = num3 / option;
                output[index1] = num11;
                int index3 = index1 + 1;
                for (int index2 = option; index2 < size; ++index2)
                {
                    double num4;
                    do
                    {
                        double num5 = input2[index2];
                        double num6 = input1[index2];
                        double num7 = input3[index2 - 1];
                        double num8 = Math.Abs(num6 - num7);
                        double num9 = Math.Abs(num5 - num7);
                        double num10 = num6 - num5;
                        if (num8 > num10)
                        {
                            num10 = num8;
                        }

                        if (num9 > num10)
                        {
                            num10 = num9;
                        }

                        num4 = num10;
                    } while (false);

                    num11 = (num4 - num11) * num2 + num11;
                    output[index3] = num11;
                    ++index3;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_avgprice_start(double[] options)
        {
            return 0;
        }

        internal static int ti_avgprice(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] input3 = inputs[2];
            double[] input4 = inputs[3];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = (input1[index] + input2[index] + input3[index] + input4[index]) * 0.25;
            }

            return 0;
        }

        internal static int ti_bbands_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_bbands(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output1 = outputs[0];
            int index1 = 0;
            double[] output2 = outputs[1];
            int index2 = 0;
            double[] output3 = outputs[2];
            int index3 = 0;
            int option1 = (int) options[0];
            double option2 = options[1];
            double num1 = 1.0 / option1;
            int num2;
            if (option1 < 1)
            {
                num2 = 1;
            }
            else if (size <= ti_bbands_start(options))
            {
                num2 = 0;
            }
            else
            {
                double num3 = 0.0;
                double num4 = 0.0;
                for (int index4 = 0; index4 < option1; ++index4)
                {
                    num3 += input[index4];
                    num4 += input[index4] * input[index4];
                }

                double num5 = Math.Sqrt(num4 * num1 - num3 * num1 * (num3 * num1));
                output2[index2] = num3 * num1;
                output1[index1] = output2[index2] - option2 * num5;
                int index5 = index1 + 1;
                output3[index3] = output2[index2] + option2 * num5;
                int index6 = index3 + 1;
                int index7 = index2 + 1;
                for (int index4 = option1; index4 < size; ++index4)
                {
                    double num6 = num3 + input[index4];
                    double num7 = num4 + input[index4] * input[index4];
                    num3 = num6 - input[index4 - option1];
                    num4 = num7 - input[index4 - option1] * input[index4 - option1];
                    double num8 = Math.Sqrt(num4 * num1 - num3 * num1 * (num3 * num1));
                    output2[index7] = num3 * num1;
                    output3[index6] = output2[index7] + option2 * num8;
                    ++index6;
                    output1[index5] = output2[index7] - option2 * num8;
                    ++index5;
                    ++index7;
                }

                num2 = 0;
            }

            return num2;
        }

        internal static int ti_bop_start(double[] options)
        {
            return 0;
        }

        internal static int ti_bop(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] input3 = inputs[2];
            double[] input4 = inputs[3];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                double num = input2[index] - input3[index];
                output[index] = num > 0.0 ? (input4[index] - input1[index]) / num : 0.0;
            }

            return 0;
        }

        internal static int ti_cci_start(double[] options)
        {
            return ((int) options[0] - 1) * 2;
        }

        internal static int ti_cci(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] input3 = inputs[2];
            int option = (int) options[0];
            double num1 = 1.0 / option;
            int num2;
            if (option < 1)
            {
                num2 = 1;
            }
            else if (size <= ti_cci_start(options))
            {
                num2 = 0;
            }
            else
            {
                double[] output = outputs[0];
                int index1 = 0;
                var buffer = ti_buffer_new(option);
                for (int index2 = 0; index2 < size; ++index2)
                {
                    double num3 = (input1[index2] + input2[index2] + input3[index2]) * (1.0 / 3.0);
                    do
                    {
                        if (buffer.pushes >= buffer.size)
                        {
                            buffer.sum -= buffer.vals[buffer.index];
                        }

                        buffer.sum += num3;
                        buffer.vals[buffer.index] = num3;
                        ++buffer.pushes;
                        ++buffer.index;
                        if (buffer.index >= buffer.size)
                        {
                            buffer.index = 0;
                        }
                    } while (false);

                    double num4 = buffer.sum * num1;
                    if (index2 < option * 2 - 2)
                    {
                        continue;
                    }

                    double num5 = 0.0;
                    for (int index3 = 0; index3 < option; ++index3)
                    {
                        num5 += Math.Abs(num4 - buffer.vals[index3]);
                    }

                    double num6 = num5 * num1 * 0.015;
                    double num7 = (num3 - num4) / num6;
                    output[index1] = num7;
                    ++index1;
                }

                num2 = 0;
            }

            return num2;
        }

        internal static int ti_ceil_start(double[] options)
        {
            return 0;
        }

        internal static int ti_ceil(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = Math.Ceiling(input[index]);
            }

            return 0;
        }

        internal static int ti_cmo_start(double[] options)
        {
            return (int) options[0];
        }

        internal static int ti_cmo(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            int index1 = 0;
            int option = (int) options[0];
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_cmo_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = 0.0;
                double num3 = 0.0;
                for (int index2 = 1; index2 <= option; ++index2)
                {
                    double num4 = input[index2] <= input[index2 - 1] ? 0.0 : input[index2] - input[index2 - 1];
                    num2 += num4;
                    double num5 = input[index2] >= input[index2 - 1] ? 0.0 : input[index2 - 1] - input[index2];
                    num3 += num5;
                }

                output[index1] = 100.0 * (num2 - num3) / (num2 + num3);
                int index3 = index1 + 1;
                for (int index2 = option + 1; index2 < size; ++index2)
                {
                    double num4 = input[index2 - option] <= input[index2 - option - 1]
                        ? 0.0
                        : input[index2 - option] - input[index2 - option - 1];
                    double num5 = num2 - num4;
                    double num6 = input[index2 - option] >= input[index2 - option - 1]
                        ? 0.0
                        : input[index2 - option - 1] - input[index2 - option];
                    double num7 = num3 - num6;
                    double num8 = input[index2] <= input[index2 - 1] ? 0.0 : input[index2] - input[index2 - 1];
                    num2 = num5 + num8;
                    double num9 = input[index2] >= input[index2 - 1] ? 0.0 : input[index2 - 1] - input[index2];
                    num3 = num7 + num9;
                    output[index3] = 100.0 * (num2 - num3) / (num2 + num3);
                    ++index3;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_cos_start(double[] options)
        {
            return 0;
        }

        internal static int ti_cos(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = Math.Cos(input[index]);
            }

            return 0;
        }

        internal static int ti_cosh_start(double[] options)
        {
            return 0;
        }

        internal static int ti_cosh(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = Math.Cosh(input[index]);
            }

            return 0;
        }

        internal static int ti_crossany_start(double[] options)
        {
            return 1;
        }

        internal static int ti_crossany(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] output = outputs[0];
            int index1 = 0;
            for (int index2 = 1; index2 < size; ++index2)
            {
                int num = input1[index2] > input2[index2] && input1[index2 - 1] <= input2[index2 - 1] ||
                          input1[index2] < input2[index2] && input1[index2 - 1] >= input2[index2 - 1]
                    ? 1
                    : 0;
                output[index1] = num;
                ++index1;
            }

            return 0;
        }

        internal static int ti_crossover_start(double[] options)
        {
            return 1;
        }

        internal static int ti_crossover(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] output = outputs[0];
            int index1 = 0;
            for (int index2 = 1; index2 < size; ++index2)
            {
                int num = input1[index2] <= input2[index2] || input1[index2 - 1] > input2[index2 - 1] ? 0 : 1;
                output[index1] = num;
                ++index1;
            }

            return 0;
        }

        internal static int ti_cvi_start(double[] options)
        {
            return (int) options[0] * 2 - 1;
        }

        internal static int ti_cvi(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_cvi_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = 2.0 / (option + 1.0);
                var buffer = ti_buffer_new(option);
                double num3 = input1[0] - input2[0];
                for (int index2 = 1; index2 < option * 2 - 1; ++index2)
                {
                    num3 = (input1[index2] - input2[index2] - num3) * num2 + num3;
                    do
                    {
                        buffer.vals[buffer.index] = num3;
                        ++buffer.index;
                        if (buffer.index >= buffer.size)
                        {
                            buffer.index = 0;
                        }
                    } while (false);
                }

                for (int index2 = option * 2 - 1; index2 < size; ++index2)
                {
                    num3 = (input1[index2] - input2[index2] - num3) * num2 + num3;
                    double val = buffer.vals[buffer.index];
                    output[index1] = 100.0 * (num3 - val) / val;
                    ++index1;
                    do
                    {
                        buffer.vals[buffer.index] = num3;
                        ++buffer.index;
                        if (buffer.index >= buffer.size)
                        {
                            buffer.index = 0;
                        }
                    } while (false);
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_decay_start(double[] options)
        {
            return 0;
        }

        internal static int ti_decay(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            int index1 = 0;
            double num1 = 1.0 / (int) options[0];
            output[index1] = input[0];
            int index2 = index1 + 1;
            for (int index3 = 1; index3 < size; ++index3)
            {
                double num2 = output[-1] - num1;
                double num3 = input[index3] <= num2 ? num2 : input[index3];
                output[index2] = num3;
                ++index2;
            }

            return 0;
        }

        internal static int ti_dema_start(double[] options)
        {
            return ((int) options[0] - 1) * 2;
        }

        internal static int ti_dema(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_dema_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = 2.0 / (option + 1.0);
                double num3 = 1.0 - num2;
                double num4 = input[0];
                double num5 = num4;
                for (int index2 = 0; index2 < size; ++index2)
                {
                    num4 = num4 * num3 + input[index2] * num2;
                    if (index2 == option - 1)
                    {
                        num5 = num4;
                    }

                    if (index2 < option - 1)
                    {
                        continue;
                    }

                    num5 = num5 * num3 + num4 * num2;
                    if (index2 >= (option - 1) * 2)
                    {
                        output[index1] = num4 * 2.0 - num5;
                        ++index1;
                    }
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_di_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_di(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] input3 = inputs[2];
            int option = (int) options[0];
            double[] output1 = outputs[0];
            int index1 = 0;
            double[] output2 = outputs[1];
            int index2 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_di_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = (option - 1.0) / option;
                double num3 = 0.0;
                double num4 = 0.0;
                double num5 = 0.0;
                for (int index3 = 1; index3 < option; ++index3)
                {
                    double num6;
                    do
                    {
                        double num7 = input2[index3];
                        double num8 = input1[index3];
                        double num9 = input3[index3 - 1];
                        double num10 = Math.Abs(num8 - num9);
                        double num11 = Math.Abs(num7 - num9);
                        double num12 = num8 - num7;
                        if (num10 > num12)
                        {
                            num12 = num10;
                        }

                        if (num11 > num12)
                        {
                            num12 = num11;
                        }

                        num6 = num12;
                    } while (false);

                    num3 += num6;
                    double num13;
                    double num14;
                    do
                    {
                        num13 = input1[index3] - input1[index3 - 1];
                        num14 = input2[index3 - 1] - input2[index3];
                        if (num13 < 0.0)
                        {
                            num13 = 0.0;
                        }
                        else if (num13 > num14)
                        {
                            num14 = 0.0;
                        }

                        if (num14 < 0.0)
                        {
                            num14 = 0.0;
                        }
                        else if (num14 > num13)
                        {
                            num13 = 0.0;
                        }
                    } while (false);

                    num4 += num13;
                    num5 += num14;
                }

                output1[index1] = 100.0 * num4 / num3;
                int index4 = index1 + 1;
                output2[index2] = 100.0 * num5 / num3;
                int index5 = index2 + 1;
                for (int index3 = option; index3 < size; ++index3)
                {
                    double num6;
                    do
                    {
                        double num7 = input2[index3];
                        double num8 = input1[index3];
                        double num9 = input3[index3 - 1];
                        double num10 = Math.Abs(num8 - num9);
                        double num11 = Math.Abs(num7 - num9);
                        double num12 = num8 - num7;
                        if (num10 > num12)
                        {
                            num12 = num10;
                        }

                        if (num11 > num12)
                        {
                            num12 = num11;
                        }

                        num6 = num12;
                    } while (false);

                    num3 = num3 * num2 + num6;
                    double num13;
                    double num14;
                    do
                    {
                        num13 = input1[index3] - input1[index3 - 1];
                        num14 = input2[index3 - 1] - input2[index3];
                        if (num13 < 0.0)
                        {
                            num13 = 0.0;
                        }
                        else if (num13 > num14)
                        {
                            num14 = 0.0;
                        }

                        if (num14 < 0.0)
                        {
                            num14 = 0.0;
                        }
                        else if (num14 > num13)
                        {
                            num13 = 0.0;
                        }
                    } while (false);

                    num4 = num4 * num2 + num13;
                    num5 = num5 * num2 + num14;
                    output1[index4] = 100.0 * num4 / num3;
                    ++index4;
                    output2[index5] = 100.0 * num5 / num3;
                    ++index5;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_div_start(double[] options)
        {
            return 0;
        }

        internal static int ti_div(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = input1[index] / input2[index];
            }

            return 0;
        }

        internal static int ti_dm_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_dm(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            int option = (int) options[0];
            double[] output1 = outputs[0];
            int index1 = 0;
            double[] output2 = outputs[1];
            int index2 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_dm_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = (option - 1.0) / option;
                double num3 = 0.0;
                double num4 = 0.0;
                for (int index3 = 1; index3 < option; ++index3)
                {
                    double num5;
                    double num6;
                    do
                    {
                        num5 = input1[index3] - input1[index3 - 1];
                        num6 = input2[index3 - 1] - input2[index3];
                        if (num5 < 0.0)
                        {
                            num5 = 0.0;
                        }
                        else if (num5 > num6)
                        {
                            num6 = 0.0;
                        }

                        if (num6 < 0.0)
                        {
                            num6 = 0.0;
                        }
                        else if (num6 > num5)
                        {
                            num5 = 0.0;
                        }
                    } while (false);

                    num3 += num5;
                    num4 += num6;
                }

                output1[index1] = num3;
                int index4 = index1 + 1;
                output2[index2] = num4;
                int index5 = index2 + 1;
                for (int index3 = option; index3 < size; ++index3)
                {
                    double num5;
                    double num6;
                    do
                    {
                        num5 = input1[index3] - input1[index3 - 1];
                        num6 = input2[index3 - 1] - input2[index3];
                        if (num5 < 0.0)
                        {
                            num5 = 0.0;
                        }
                        else if (num5 > num6)
                        {
                            num6 = 0.0;
                        }

                        if (num6 < 0.0)
                        {
                            num6 = 0.0;
                        }
                        else if (num6 > num5)
                        {
                            num5 = 0.0;
                        }
                    } while (false);

                    num3 = num3 * num2 + num5;
                    num4 = num4 * num2 + num6;
                    output1[index4] = num3;
                    ++index4;
                    output2[index5] = num4;
                    ++index5;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_dpo_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_dpo(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            int num1 = option / 2 + 1;
            double[] output = outputs[0];
            int index1 = 0;
            double num2 = 1.0 / option;
            int num3;
            if (option < 1)
            {
                num3 = 1;
            }
            else if (size <= ti_dpo_start(options))
            {
                num3 = 0;
            }
            else
            {
                double num4 = 0.0;
                for (int index2 = 0; index2 < option; ++index2)
                {
                    num4 += input[index2];
                }

                output[index1] = input[option - 1 - num1] - num4 * num2;
                int index3 = index1 + 1;
                for (int index2 = option; index2 < size; ++index2)
                {
                    num4 = num4 + input[index2] - input[index2 - option];
                    output[index3] = input[index2 - num1] - num4 * num2;
                    ++index3;
                }

                num3 = 0;
            }

            return num3;
        }

        internal static int ti_dx_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_dx(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] input3 = inputs[2];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_dx_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = (option - 1.0) / option;
                double num3 = 0.0;
                double num4 = 0.0;
                double num5 = 0.0;
                for (int index2 = 1; index2 < option; ++index2)
                {
                    double num6;
                    do
                    {
                        double num7 = input2[index2];
                        double num8 = input1[index2];
                        double num9 = input3[index2 - 1];
                        double num10 = Math.Abs(num8 - num9);
                        double num11 = Math.Abs(num7 - num9);
                        double num12 = num8 - num7;
                        if (num10 > num12)
                        {
                            num12 = num10;
                        }

                        if (num11 > num12)
                        {
                            num12 = num11;
                        }

                        num6 = num12;
                    } while (false);

                    num3 += num6;
                    double num13;
                    double num14;
                    do
                    {
                        num13 = input1[index2] - input1[index2 - 1];
                        num14 = input2[index2 - 1] - input2[index2];
                        if (num13 < 0.0)
                        {
                            num13 = 0.0;
                        }
                        else if (num13 > num14)
                        {
                            num14 = 0.0;
                        }

                        if (num14 < 0.0)
                        {
                            num14 = 0.0;
                        }
                        else if (num14 > num13)
                        {
                            num13 = 0.0;
                        }
                    } while (false);

                    num4 += num13;
                    num5 += num14;
                }

                double num15 = num4 / num3;
                double num16 = num5 / num3;
                double num17 = Math.Abs(num15 - num16) / (num15 + num16) * 100.0;
                output[index1] = num17;
                int index3 = index1 + 1;
                for (int index2 = option; index2 < size; ++index2)
                {
                    double num6;
                    do
                    {
                        double num7 = input2[index2];
                        double num8 = input1[index2];
                        double num9 = input3[index2 - 1];
                        double num10 = Math.Abs(num8 - num9);
                        double num11 = Math.Abs(num7 - num9);
                        double num12 = num8 - num7;
                        if (num10 > num12)
                        {
                            num12 = num10;
                        }

                        if (num11 > num12)
                        {
                            num12 = num11;
                        }

                        num6 = num12;
                    } while (false);

                    num3 = num3 * num2 + num6;
                    double num13;
                    double num14;
                    do
                    {
                        num13 = input1[index2] - input1[index2 - 1];
                        num14 = input2[index2 - 1] - input2[index2];
                        if (num13 < 0.0)
                        {
                            num13 = 0.0;
                        }
                        else if (num13 > num14)
                        {
                            num14 = 0.0;
                        }

                        if (num14 < 0.0)
                        {
                            num14 = 0.0;
                        }
                        else if (num14 > num13)
                        {
                            num13 = 0.0;
                        }
                    } while (false);

                    num4 = num4 * num2 + num13;
                    num5 = num5 * num2 + num14;
                    double num18 = num4 / num3;
                    double num19 = num5 / num3;
                    double num20 = Math.Abs(num18 - num19) / (num18 + num19) * 100.0;
                    output[index3] = num20;
                    ++index3;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_edecay_start(double[] options)
        {
            return 0;
        }

        internal static int ti_edecay(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            double num1 = 1.0 - 1.0 / option;
            output[index1] = input[0];
            int index2 = index1 + 1;
            for (int index3 = 1; index3 < size; ++index3)
            {
                double num2 = output[-1] * num1;
                double num3 = input[index3] <= num2 ? num2 : input[index3];
                output[index2] = num3;
                ++index2;
            }

            return 0;
        }

        internal static int ti_ema_start(double[] options)
        {
            return 0;
        }

        internal static int ti_ema(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_ema_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = 2.0 / (option + 1.0);
                double num3 = input[0];
                output[index1] = num3;
                int index2 = index1 + 1;
                for (int index3 = 1; index3 < size; ++index3)
                {
                    num3 = (input[index3] - num3) * num2 + num3;
                    output[index2] = num3;
                    ++index2;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_emv_start(double[] options)
        {
            return 1;
        }

        internal static int ti_emv(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] input3 = inputs[2];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (size <= ti_emv_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = (input1[0] + input2[0]) * 0.5;
                for (int index2 = 1; index2 < size; ++index2)
                {
                    double num3 = (input1[index2] + input2[index2]) * 0.5;
                    double num4 = input3[index2] / 10000.0 / (input1[index2] - input2[index2]);
                    output[index1] = (num3 - num2) / num4;
                    ++index1;
                    num2 = num3;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_exp_start(double[] options)
        {
            return 0;
        }

        internal static int ti_exp(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = Math.Exp(input[index]);
            }

            return 0;
        }

        internal static int ti_fisher_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_fisher(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] output1 = outputs[0];
            int index1 = 0;
            double[] output2 = outputs[1];
            int index2 = 0;
            int option = (int) options[0];
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_fisher_start(options))
            {
                num1 = 0;
            }
            else
            {
                int num2 = 0;
                int index3 = -1;
                int index4 = -1;
                double num3 = 0.5 * (input1[0] + input2[0]);
                double num4 = 0.5 * (input1[0] + input2[0]);
                double num5 = 0.0;
                double num6 = 0.0;
                int index5 = option - 1;
                while (index5 < size)
                {
                    double num7 = 0.5 * (input1[index5] + input2[index5]);
                    if (index3 < num2)
                    {
                        index3 = num2;
                        num3 = 0.5 * (input1[index3] + input2[index3]);
                        int index6 = num2;
                        while (true)
                        {
                            double num8;
                            do
                            {
                                ++index6;
                                if (index6 <= index5)
                                {
                                    num8 = 0.5 * (input1[index6] + input2[index6]);
                                }
                                else
                                {
                                    goto label_13;
                                }
                            } while (num8 < num3);

                            num3 = num8;
                            index3 = index6;
                        }
                    }

                    if (num7 >= num3)
                    {
                        index3 = index5;
                        num3 = num7;
                    }

                    label_13:
                    double num9 = 0.5 * (input1[index5] + input2[index5]);
                    if (index4 < num2)
                    {
                        index4 = num2;
                        num4 = 0.5 * (input1[index4] + input2[index4]);
                        int index6 = num2;
                        while (true)
                        {
                            double num8;
                            do
                            {
                                ++index6;
                                if (index6 <= index5)
                                {
                                    num8 = 0.5 * (input1[index6] + input2[index6]);
                                }
                                else
                                {
                                    goto label_20;
                                }
                            } while (num8 > num4);

                            num4 = num8;
                            index4 = index6;
                        }
                    }

                    if (num9 <= num4)
                    {
                        index4 = index5;
                        num4 = num9;
                    }

                    label_20:
                    double num10 = num3 - num4;
                    if (num10 == 0.0)
                    {
                        num10 = 0.001;
                    }

                    num5 = 0.66 * ((0.5 * (input1[index5] + input2[index5]) - num4) / num10 - 0.5) + 0.67 * num5;
                    if (num5 > 0.99)
                    {
                        num5 = 0.999;
                    }

                    if (num5 < -0.99)
                    {
                        num5 = -0.999;
                    }

                    output2[index2] = num6;
                    ++index2;
                    num6 = 0.5 * Math.Log((1.0 + num5) / (1.0 - num5)) + 0.5 * num6;
                    output1[index1] = num6;
                    ++index1;
                    ++index5;
                    ++num2;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_floor_start(double[] options)
        {
            return 0;
        }

        internal static int ti_floor(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = Math.Floor(input[index]);
            }

            return 0;
        }

        internal static int ti_fosc_start(double[] options)
        {
            return (int) options[0];
        }

        internal static int ti_fosc(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_fosc_start(options))
            {
                num1 = 0;
            }
            else
            {
                do
                {
                    double num2 = 0.0;
                    double num3 = 0.0;
                    double num4 = 0.0;
                    double num5 = 0.0;
                    double num6 = 1.0 / option;
                    double num7 = 0.0;
                    for (int index2 = 0; index2 < option - 1; ++index2)
                    {
                        num2 += index2 + 1;
                        num3 += (index2 + 1) * (index2 + 1);
                        num5 += input[index2] * (index2 + 1);
                        num4 += input[index2];
                    }

                    double num8 = num2 + option;
                    double num9 = num3;
                    int num10 = option;
                    double num11 = num10 * num10;
                    double num12 = num9 + num11;
                    double num13 = option * num12;
                    double num14 = num8;
                    double num15 = num14 * num14;
                    double num16 = 1.0 / (num13 - num15);
                    for (int index2 = option - 1; index2 < size; ++index2)
                    {
                        double num17 = num5 + input[index2] * option;
                        double num18 = num4 + input[index2];
                        double num19 = (option * num17 - num8 * num18) * num16;
                        do
                        {
                            double num20 = (num18 - num19 * num8) * num6;
                            if (index2 >= option)
                            {
                                output[index1] = 100.0 * (input[index2] - num7) / input[index2];
                                ++index1;
                            }

                            num7 = num20 + num19 * (option + 1);
                        } while (false);

                        num5 = num17 - num18;
                        num4 = num18 - input[index2 - option + 1];
                    }
                } while (false);

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_hma_start(double[] options)
        {
            int option = (int) options[0];
            int num = (int) Math.Sqrt(option);
            return option + num - 2;
        }

        internal static int ti_hma(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_hma_start(options))
            {
                num1 = 0;
            }
            else
            {
                int num2 = option / 2;
                int size1 = (int) Math.Sqrt(option);
                int num3 = option;
                double num4 = num3 * (num3 + 1) / 2;
                int num5 = num2;
                double num6 = num5 * (num5 + 1) / 2;
                int num7 = size1;
                double num8 = num7 * (num7 + 1) / 2;
                double num9 = 0.0;
                double num10 = 0.0;
                double num11 = 0.0;
                double num12 = 0.0;
                double num13 = 0.0;
                double num14 = 0.0;
                for (int index2 = 0; index2 < option - 1; ++index2)
                {
                    num10 += input[index2] * (index2 + 1);
                    num9 += input[index2];
                    if (index2 < option - num2)
                    {
                        continue;
                    }

                    num12 += input[index2] * (index2 + 1 - (option - num2));
                    num11 += input[index2];
                }

                var buffer = ti_buffer_new(size1);
                for (int index2 = option - 1; index2 < size; ++index2)
                {
                    double num15 = num10 + input[index2] * option;
                    double num16 = num9 + input[index2];
                    double num17 = num12 + input[index2] * num2;
                    double num18 = num11 + input[index2];
                    double num19 = num15 / num4;
                    double num20 = 2.0 * (num17 / num6) - num19;
                    double num21 = num14 + num20 * size1;
                    num13 += num20;
                    do
                    {
                        buffer.vals[buffer.index] = num20;
                        ++buffer.index;
                        if (buffer.index >= buffer.size)
                        {
                            buffer.index = 0;
                        }
                    } while (false);

                    if (index2 >= option - 1 + (size1 - 1))
                    {
                        output[index1] = num21 / num8;
                        ++index1;
                        num14 = num21 - num13;
                        num13 -= buffer.vals[(buffer.index + buffer.size - 1 + 1) % buffer.size];
                    }
                    else
                    {
                        num14 = num21 - num13;
                    }

                    num10 = num15 - num16;
                    num9 = num16 - input[index2 - option + 1];
                    num12 = num17 - num18;
                    num11 = num18 - input[index2 - num2 + 1];
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_kama_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_kama(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_kama_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = 0.0;
                for (int index2 = 1; index2 < option; ++index2)
                {
                    num2 += Math.Abs(input[index2] - input[index2 - 1]);
                }

                double num3 = input[option - 1];
                output[index1] = num3;
                int index3 = index1 + 1;
                for (int index2 = option; index2 < size; ++index2)
                {
                    num2 += Math.Abs(input[index2] - input[index2 - 1]);
                    if (index2 > option)
                    {
                        num2 -= Math.Abs(input[index2 - option] - input[index2 - option - 1]);
                    }

                    double num4 = Math.Pow(
                        (num2 == 0.0 ? 1.0 : Math.Abs(input[index2] - input[index2 - option]) / num2) * (56.0 / 93.0) + 2.0 / 31.0, 2.0);
                    num3 += num4 * (input[index2] - num3);
                    output[index3] = num3;
                    ++index3;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_kvo_start(double[] options)
        {
            return 1;
        }

        internal static int ti_kvo(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] input3 = inputs[2];
            double[] input4 = inputs[3];
            int option1 = (int) options[0];
            int option2 = (int) options[1];
            int num1;
            if (option1 < 1)
            {
                num1 = 1;
            }
            else if (option2 < option1)
            {
                num1 = 1;
            }
            else if (size <= ti_kvo_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = 2.0 / (option1 + 1.0);
                double num3 = 2.0 / (option2 + 1.0);
                double[] output = outputs[0];
                int index1 = 0;
                double num4 = 0.0;
                double num5 = input1[0] + input2[0] + input3[0];
                int num6 = -1;
                double num7 = 0.0;
                double num8 = 0.0;
                for (int index2 = 1; index2 < size; ++index2)
                {
                    double num9 = input1[index2] + input2[index2] + input3[index2];
                    double num10 = input1[index2] - input2[index2];
                    if (num9 > num5 && num6 != 1)
                    {
                        num6 = 1;
                        num4 = input1[index2 - 1] - input2[index2 - 1];
                    }
                    else if (num9 < num5 && num6 != 0)
                    {
                        num6 = 0;
                        num4 = input1[index2 - 1] - input2[index2 - 1];
                    }

                    num4 += num10;
                    double num11 = num6 == 0 ? -1.0 : 1.0;
                    double num12 = input4[index2] * Math.Abs(num10 / num4 * 2.0 - 1.0) * 100.0 * num11;
                    if (index2 == 1)
                    {
                        num7 = num12;
                        num8 = num12;
                    }
                    else
                    {
                        num7 = (num12 - num7) * num2 + num7;
                        num8 = (num12 - num8) * num3 + num8;
                    }

                    output[index1] = num7 - num8;
                    ++index1;
                    num5 = num9;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_lag_start(double[] options)
        {
            return (int) options[0];
        }

        internal static int ti_lag(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num;
            if (option < 0)
            {
                num = 1;
            }
            else if (size <= ti_lag_start(options))
            {
                num = 0;
            }
            else
            {
                for (int index2 = option; index2 < size; ++index2)
                {
                    output[index1] = input[index2 - option];
                    ++index1;
                }

                num = 0;
            }

            return num;
        }

        internal static int ti_linreg_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_linreg(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_linreg_start(options))
            {
                num1 = 0;
            }
            else
            {
                do
                {
                    double num2 = 0.0;
                    double num3 = 0.0;
                    double num4 = 0.0;
                    double num5 = 0.0;
                    double num6 = 1.0 / option;
                    for (int index2 = 0; index2 < option - 1; ++index2)
                    {
                        num2 += index2 + 1;
                        num3 += (index2 + 1) * (index2 + 1);
                        num5 += input[index2] * (index2 + 1);
                        num4 += input[index2];
                    }

                    double num7 = num2 + option;
                    double num8 = num3;
                    int num9 = option;
                    double num10 = num9 * num9;
                    double num11 = num8 + num10;
                    double num12 = option * num11;
                    double num13 = num7;
                    double num14 = num13 * num13;
                    double num15 = 1.0 / (num12 - num14);
                    for (int index2 = option - 1; index2 < size; ++index2)
                    {
                        double num16 = num5 + input[index2] * option;
                        double num17 = num4 + input[index2];
                        double num18 = (option * num16 - num7 * num17) * num15;
                        do
                        {
                            double num19 = (num17 - num18 * num7) * num6;
                            output[index1] = num19 + num18 * option;
                            ++index1;
                        } while (false);

                        num5 = num16 - num17;
                        num4 = num17 - input[index2 - option + 1];
                    }
                } while (false);

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_linregintercept_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_linregintercept(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_linregintercept_start(options))
            {
                num1 = 0;
            }
            else
            {
                do
                {
                    double num2 = 0.0;
                    double num3 = 0.0;
                    double num4 = 0.0;
                    double num5 = 0.0;
                    double num6 = 1.0 / option;
                    for (int index2 = 0; index2 < option - 1; ++index2)
                    {
                        num2 += index2 + 1;
                        num3 += (index2 + 1) * (index2 + 1);
                        num5 += input[index2] * (index2 + 1);
                        num4 += input[index2];
                    }

                    double num7 = num2 + option;
                    double num8 = num3;
                    int num9 = option;
                    double num10 = num9 * num9;
                    double num11 = num8 + num10;
                    double num12 = option * num11;
                    double num13 = num7;
                    double num14 = num13 * num13;
                    double num15 = 1.0 / (num12 - num14);
                    for (int index2 = option - 1; index2 < size; ++index2)
                    {
                        double num16 = num5 + input[index2] * option;
                        double num17 = num4 + input[index2];
                        double num18 = (option * num16 - num7 * num17) * num15;
                        do
                        {
                            double num19 = (num17 - num18 * num7) * num6;
                            output[index1] = num19 + num18 * 1.0;
                            ++index1;
                        } while (false);

                        num5 = num16 - num17;
                        num4 = num17 - input[index2 - option + 1];
                    }
                } while (false);

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_linregslope_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_linregslope(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_linregslope_start(options))
            {
                num1 = 0;
            }
            else
            {
                do
                {
                    double num2 = 0.0;
                    double num3 = 0.0;
                    double num4 = 0.0;
                    double num5 = 0.0;
                    do
                    {
                        ;
                    } while (false);

                    for (int index2 = 0; index2 < option - 1; ++index2)
                    {
                        num2 += index2 + 1;
                        num3 += (index2 + 1) * (index2 + 1);
                        num5 += input[index2] * (index2 + 1);
                        num4 += input[index2];
                    }

                    double num6 = num2 + option;
                    double num7 = num3;
                    int num8 = option;
                    double num9 = num8 * num8;
                    double num10 = num7 + num9;
                    double num11 = option * num10;
                    double num12 = num6;
                    double num13 = num12 * num12;
                    double num14 = 1.0 / (num11 - num13);
                    for (int index2 = option - 1; index2 < size; ++index2)
                    {
                        double num15 = num5 + input[index2] * option;
                        double num16 = num4 + input[index2];
                        double num17 = (option * num15 - num6 * num16) * num14;
                        do
                        {
                            output[index1] = num17;
                            ++index1;
                        } while (false);

                        num5 = num15 - num16;
                        num4 = num16 - input[index2 - option + 1];
                    }
                } while (false);

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_ln_start(double[] options)
        {
            return 0;
        }

        internal static int ti_ln(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = Math.Log(input[index]);
            }

            return 0;
        }

        internal static int ti_log10_start(double[] options)
        {
            return 0;
        }

        internal static int ti_log10(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = Math.Log10(input[index]);
            }

            return 0;
        }

        internal static int ti_macd_start(double[] options)
        {
            return (int) options[1] - 1;
        }

        internal static int ti_macd(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output1 = outputs[0];
            int index1 = 0;
            double[] output2 = outputs[1];
            int index2 = 0;
            double[] output3 = outputs[2];
            int index3 = 0;
            int option1 = (int) options[0];
            int option2 = (int) options[1];
            int option3 = (int) options[2];
            int num1;
            if (option1 < 1)
            {
                num1 = 1;
            }
            else if (option2 < 2)
            {
                num1 = 1;
            }
            else if (option2 < option1)
            {
                num1 = 1;
            }
            else if (option3 < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_macd_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = 2.0 / (option1 + 1.0);
                double num3 = 2.0 / (option2 + 1.0);
                double num4 = 2.0 / (option3 + 1.0);
                if (option1 == 12 && option2 == 26)
                {
                    num2 = 0.15;
                    num3 = 0.075;
                }

                double num5 = input[0];
                double num6 = input[0];
                double num7 = 0.0;
                for (int index4 = 1; index4 < size; ++index4)
                {
                    num5 = (input[index4] - num5) * num2 + num5;
                    num6 = (input[index4] - num6) * num3 + num6;
                    double num8 = num5 - num6;
                    if (index4 == option2 - 1)
                    {
                        num7 = num8;
                    }

                    if (index4 < option2 - 1)
                    {
                        continue;
                    }

                    num7 = (num8 - num7) * num4 + num7;
                    output1[index1] = num8;
                    ++index1;
                    output2[index2] = num7;
                    ++index2;
                    output3[index3] = num8 - num7;
                    ++index3;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_marketfi_start(double[] options)
        {
            return 0;
        }

        internal static int ti_marketfi(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] input3 = inputs[2];
            double[] output = outputs[0];
            int index1 = 0;
            int num;
            if (size <= ti_marketfi_start(options))
            {
                num = 0;
            }
            else
            {
                for (int index2 = 0; index2 < size; ++index2)
                {
                    output[index1] = (input1[index2] - input2[index2]) / input3[index2];
                    ++index1;
                }

                num = 0;
            }

            return num;
        }

        internal static int ti_mass_start(double[] options)
        {
            return (int) options[0] - 1 + 16;
        }

        internal static int ti_mass(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_mass_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = input1[0] - input2[0];
                double num3 = num2;
                var buffer = ti_buffer_new(option);
                for (int index2 = 0; index2 < size; ++index2)
                {
                    double num4 = input1[index2] - input2[index2];
                    num2 = num2 * 0.8 + num4 * 0.2;
                    if (index2 == 8)
                    {
                        num3 = num2;
                    }

                    if (index2 < 8)
                    {
                        continue;
                    }

                    num3 = num3 * 0.8 + num2 * 0.2;
                    if (index2 >= 16)
                    {
                        do
                        {
                            if (buffer.pushes >= buffer.size)
                            {
                                buffer.sum -= buffer.vals[buffer.index];
                            }

                            buffer.sum += num2 / num3;
                            buffer.vals[buffer.index] = num2 / num3;
                            ++buffer.pushes;
                            ++buffer.index;
                            if (buffer.index >= buffer.size)
                            {
                                buffer.index = 0;
                            }
                        } while (false);

                        if (index2 >= option + 16 - 1)
                        {
                            output[index1] = buffer.sum;
                            ++index1;
                        }
                    }
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_max_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_max(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_max_start(options))
            {
                num1 = 0;
            }
            else
            {
                int num2 = 0;
                int index2 = -1;
                double num3 = input[0];
                int index3 = option - 1;
                while (index3 < size)
                {
                    double num4 = input[index3];
                    if (index2 < num2)
                    {
                        index2 = num2;
                        num3 = input[index2];
                        int index4 = num2;
                        while (true)
                        {
                            double num5;
                            do
                            {
                                ++index4;
                                if (index4 <= index3)
                                {
                                    num5 = input[index4];
                                }
                                else
                                {
                                    goto label_13;
                                }
                            } while (num5 < num3);

                            num3 = num5;
                            index2 = index4;
                        }
                    }

                    if (num4 >= num3)
                    {
                        index2 = index3;
                        num3 = num4;
                    }

                    label_13:
                    output[index1] = num3;
                    ++index1;
                    ++index3;
                    ++num2;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_md_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_md(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            double num1 = 1.0 / option;
            int num2;
            if (option < 1)
            {
                num2 = 1;
            }
            else if (size <= ti_md_start(options))
            {
                num2 = 0;
            }
            else
            {
                double num3 = 0.0;
                for (int index2 = 0; index2 < size; ++index2)
                {
                    double num4 = input[index2];
                    num3 += num4;
                    if (index2 >= option)
                    {
                        num3 -= input[index2 - option];
                    }

                    double num5 = num3 * num1;
                    if (index2 < option - 1)
                    {
                        continue;
                    }

                    double num6 = 0.0;
                    for (int index3 = 0; index3 < option; ++index3)
                    {
                        num6 += Math.Abs(num5 - input[index2 - index3]);
                    }

                    output[index1] = num6 * num1;
                    ++index1;
                }

                num2 = 0;
            }

            return num2;
        }

        internal static int ti_medprice_start(double[] options)
        {
            return 0;
        }

        internal static int ti_medprice(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = (input1[index] + input2[index]) * 0.5;
            }

            return 0;
        }

        internal static int ti_mfi_start(double[] options)
        {
            return (int) options[0];
        }

        internal static int ti_mfi(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] input3 = inputs[2];
            double[] input4 = inputs[3];
            int option = (int) options[0];
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_mfi_start(options))
            {
                num1 = 0;
            }
            else
            {
                double[] output = outputs[0];
                int index1 = 0;
                double num2 = (input1[0] + input2[0] + input3[0]) * (1.0 / 3.0);
                var buffer1 = ti_buffer_new(option);
                var buffer2 = ti_buffer_new(option);
                for (int index2 = 1; index2 < size; ++index2)
                {
                    double num3 = (input1[index2] + input2[index2] + input3[index2]) * (1.0 / 3.0);
                    double num4 = num3 * input4[index2];
                    if (num3 > num2)
                    {
                        do
                        {
                            if (buffer1.pushes >= buffer1.size)
                            {
                                buffer1.sum -= buffer1.vals[buffer1.index];
                            }

                            buffer1.sum += num4;
                            buffer1.vals[buffer1.index] = num4;
                            ++buffer1.pushes;
                            ++buffer1.index;
                            if (buffer1.index >= buffer1.size)
                            {
                                buffer1.index = 0;
                            }
                        } while (false);

                        do
                        {
                            if (buffer2.pushes >= buffer2.size)
                            {
                                buffer2.sum -= buffer2.vals[buffer2.index];
                            }

                            buffer2.sum += 0.0;
                            buffer2.vals[buffer2.index] = 0.0;
                            ++buffer2.pushes;
                            ++buffer2.index;
                            if (buffer2.index >= buffer2.size)
                            {
                                buffer2.index = 0;
                            }
                        } while (false);
                    }
                    else if (num3 < num2)
                    {
                        do
                        {
                            if (buffer2.pushes >= buffer2.size)
                            {
                                buffer2.sum -= buffer2.vals[buffer2.index];
                            }

                            buffer2.sum += num4;
                            buffer2.vals[buffer2.index] = num4;
                            ++buffer2.pushes;
                            ++buffer2.index;
                            if (buffer2.index >= buffer2.size)
                            {
                                buffer2.index = 0;
                            }
                        } while (false);

                        do
                        {
                            if (buffer1.pushes >= buffer1.size)
                            {
                                buffer1.sum -= buffer1.vals[buffer1.index];
                            }

                            buffer1.sum += 0.0;
                            buffer1.vals[buffer1.index] = 0.0;
                            ++buffer1.pushes;
                            ++buffer1.index;
                            if (buffer1.index >= buffer1.size)
                            {
                                buffer1.index = 0;
                            }
                        } while (false);
                    }
                    else
                    {
                        do
                        {
                            if (buffer1.pushes >= buffer1.size)
                            {
                                buffer1.sum -= buffer1.vals[buffer1.index];
                            }

                            buffer1.sum += 0.0;
                            buffer1.vals[buffer1.index] = 0.0;
                            ++buffer1.pushes;
                            ++buffer1.index;
                            if (buffer1.index >= buffer1.size)
                            {
                                buffer1.index = 0;
                            }
                        } while (false);

                        do
                        {
                            if (buffer2.pushes >= buffer2.size)
                            {
                                buffer2.sum -= buffer2.vals[buffer2.index];
                            }

                            buffer2.sum += 0.0;
                            buffer2.vals[buffer2.index] = 0.0;
                            ++buffer2.pushes;
                            ++buffer2.index;
                            if (buffer2.index >= buffer2.size)
                            {
                                buffer2.index = 0;
                            }
                        } while (false);
                    }

                    num2 = num3;
                    if (index2 < option)
                    {
                        continue;
                    }

                    output[index1] = buffer1.sum / (buffer1.sum + buffer2.sum) * 100.0;
                    ++index1;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_min_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_min(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_min_start(options))
            {
                num1 = 0;
            }
            else
            {
                int num2 = 0;
                int index2 = -1;
                double num3 = input[0];
                int index3 = option - 1;
                while (index3 < size)
                {
                    double num4 = input[index3];
                    if (index2 < num2)
                    {
                        index2 = num2;
                        num3 = input[index2];
                        int index4 = num2;
                        while (true)
                        {
                            double num5;
                            do
                            {
                                ++index4;
                                if (index4 <= index3)
                                {
                                    num5 = input[index4];
                                }
                                else
                                {
                                    goto label_13;
                                }
                            } while (num5 > num3);

                            num3 = num5;
                            index2 = index4;
                        }
                    }

                    if (num4 <= num3)
                    {
                        index2 = index3;
                        num3 = num4;
                    }

                    label_13:
                    output[index1] = num3;
                    ++index1;
                    ++index3;
                    ++num2;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_mom_start(double[] options)
        {
            return (int) options[0];
        }

        internal static int ti_mom(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num;
            if (option < 1)
            {
                num = 1;
            }
            else if (size <= ti_mom_start(options))
            {
                num = 0;
            }
            else
            {
                for (int index2 = option; index2 < size; ++index2)
                {
                    output[index1] = input[index2] - input[index2 - option];
                    ++index1;
                }

                num = 0;
            }

            return num;
        }

        internal static int ti_msw_start(double[] options)
        {
            return (int) options[0];
        }

        internal static int ti_msw(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output1 = outputs[0];
            int index1 = 0;
            double[] output2 = outputs[1];
            int index2 = 0;
            int option = (int) options[0];
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_msw_start(options))
            {
                num1 = 0;
            }
            else
            {
                for (int index3 = option; index3 < size; ++index3)
                {
                    double num2 = 0.0;
                    double num3 = 0.0;
                    for (int index4 = 0; index4 < option; ++index4)
                    {
                        double num4 = input[index3 - index4];
                        num2 += Math.Cos(6.2831852 * index4 / option) * num4;
                        num3 += Math.Abs(6.2831852 * index4 / option) * num4;
                    }

                    double num5 = Math.Abs(num2) <= 0.001 ? 3.1415926 * (num3 >= 0.0 ? 1.0 : -1.0) : Math.Atan(num3 / num2);
                    if (num2 < 0.0)
                    {
                        num5 += 3.1415926;
                    }

                    double num6 = num5 + 1.5707963;
                    if (num6 < 0.0)
                    {
                        num6 += 6.2831852;
                    }

                    if (num6 > 6.2831852)
                    {
                        num6 -= 6.2831852;
                    }

                    output1[index1] = Math.Abs(num6);
                    ++index1;
                    output2[index2] = Math.Abs(num6 + 0.78539815);
                    ++index2;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_mul_start(double[] options)
        {
            return 0;
        }

        internal static int ti_mul(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = input1[index] * input2[index];
            }

            return 0;
        }

        internal static int ti_natr_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_natr(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] input3 = inputs[2];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_natr_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = 1.0 / option;
                double num3 = 0.0 + (input1[0] - input2[0]);
                for (int index2 = 1; index2 < option; ++index2)
                {
                    double num4;
                    do
                    {
                        double num5 = input2[index2];
                        double num6 = input1[index2];
                        double num7 = input3[index2 - 1];
                        double num8 = Math.Abs(num6 - num7);
                        double num9 = Math.Abs(num5 - num7);
                        double num10 = num6 - num5;
                        if (num8 > num10)
                        {
                            num10 = num8;
                        }

                        if (num9 > num10)
                        {
                            num10 = num9;
                        }

                        num4 = num10;
                    } while (false);

                    num3 += num4;
                }

                double num11 = num3 / option;
                output[index1] = 100.0 * num11 / input3[option - 1];
                int index3 = index1 + 1;
                for (int index2 = option; index2 < size; ++index2)
                {
                    double num4;
                    do
                    {
                        double num5 = input2[index2];
                        double num6 = input1[index2];
                        double num7 = input3[index2 - 1];
                        double num8 = Math.Abs(num6 - num7);
                        double num9 = Math.Abs(num5 - num7);
                        double num10 = num6 - num5;
                        if (num8 > num10)
                        {
                            num10 = num8;
                        }

                        if (num9 > num10)
                        {
                            num10 = num9;
                        }

                        num4 = num10;
                    } while (false);

                    num11 = (num4 - num11) * num2 + num11;
                    output[index3] = 100.0 * num11 / input3[index2];
                    ++index3;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_nvi_start(double[] options)
        {
            return 0;
        }

        internal static int ti_nvi(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (size <= ti_nvi_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = 1000.0;
                output[index1] = num2;
                int index2 = index1 + 1;
                for (int index3 = 1; index3 < size; ++index3)
                {
                    if (input2[index3] < input2[index3 - 1])
                    {
                        num2 += (input1[index3] - input1[index3 - 1]) / input1[index3 - 1] * num2;
                    }

                    output[index2] = num2;
                    ++index2;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_obv_start(double[] options)
        {
            return 0;
        }

        internal static int ti_obv(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] output = outputs[0];
            int index1 = 0;
            double num1 = 0.0;
            output[index1] = num1;
            int index2 = index1 + 1;
            double num2 = input1[0];
            for (int index3 = 1; index3 < size; ++index3)
            {
                if (input1[index3] > num2)
                {
                    num1 += input2[index3];
                }
                else if (input1[index3] < num2)
                {
                    num1 -= input2[index3];
                }

                num2 = input1[index3];
                output[index2] = num1;
                ++index2;
            }

            return 0;
        }

        internal static int ti_ppo_start(double[] options)
        {
            return 1;
        }

        internal static int ti_ppo(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            int index1 = 0;
            int option1 = (int) options[0];
            int option2 = (int) options[1];
            int num1;
            if (option1 < 1)
            {
                num1 = 1;
            }
            else if (option2 < 2)
            {
                num1 = 1;
            }
            else if (option2 < option1)
            {
                num1 = 1;
            }
            else if (size <= ti_ppo_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = 2.0 / (option1 + 1.0);
                double num3 = 2.0 / (option2 + 1.0);
                double num4 = input[0];
                double num5 = input[0];
                for (int index2 = 1; index2 < size; ++index2)
                {
                    num4 = (input[index2] - num4) * num2 + num4;
                    num5 = (input[index2] - num5) * num3 + num5;
                    double num6 = 100.0 * (num4 - num5) / num5;
                    output[index1] = num6;
                    ++index1;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_psar_start(double[] options)
        {
            return 1;
        }

        internal static int ti_psar(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double option1 = options[0];
            double option2 = options[1];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option1 <= 0.0)
            {
                num1 = 1;
            }
            else if (option2 <= option1)
            {
                num1 = 1;
            }
            else if (size < 2)
            {
                num1 = 0;
            }
            else
            {
                int num2 = input1[0] + input2[0] > input1[1] + input2[1] ? 0 : 1;
                double num3;
                double num4;
                if (num2 != 0)
                {
                    num3 = input1[0];
                    num4 = input2[0];
                }
                else
                {
                    num3 = input2[0];
                    num4 = input1[0];
                }

                double num5 = option1;
                for (int index2 = 1; index2 < size; ++index2)
                {
                    num4 = (num3 - num4) * num5 + num4;
                    if (num2 != 0)
                    {
                        if (index2 >= 2 && num4 > input2[index2 - 2])
                        {
                            num4 = input2[index2 - 2];
                        }

                        if (num4 > input2[index2 - 1])
                        {
                            num4 = input2[index2 - 1];
                        }

                        if (num5 < option2 && input1[index2] > num3)
                        {
                            num5 += option1;
                            if (num5 > option2)
                            {
                                num5 = option2;
                            }
                        }

                        if (input1[index2] > num3)
                        {
                            num3 = input1[index2];
                        }
                    }
                    else
                    {
                        if (index2 >= 2 && num4 < input1[index2 - 2])
                        {
                            num4 = input1[index2 - 2];
                        }

                        if (num4 < input1[index2 - 1])
                        {
                            num4 = input1[index2 - 1];
                        }

                        if (num5 < option2 && input2[index2] < num3)
                        {
                            num5 += option1;
                            if (num5 > option2)
                            {
                                num5 = option2;
                            }
                        }

                        if (input2[index2] < num3)
                        {
                            num3 = input2[index2];
                        }
                    }

                    if (num2 != 0 && input2[index2] < num4 || num2 == 0 && input1[index2] > num4)
                    {
                        num5 = option1;
                        num4 = num3;
                        num2 = num2 != 0 ? 0 : 1;
                        num3 = num2 != 0 ? input1[index2] : input2[index2];
                    }

                    output[index1] = num4;
                    ++index1;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_pvi_start(double[] options)
        {
            return 0;
        }

        internal static int ti_pvi(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (size <= ti_pvi_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = 1000.0;
                output[index1] = num2;
                int index2 = index1 + 1;
                for (int index3 = 1; index3 < size; ++index3)
                {
                    if (input2[index3] > input2[index3 - 1])
                    {
                        num2 += (input1[index3] - input1[index3 - 1]) / input1[index3 - 1] * num2;
                    }

                    output[index2] = num2;
                    ++index2;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_qstick_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_qstick(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] output = outputs[0];
            int index1 = 0;
            int option = (int) options[0];
            double num1 = 1.0 / option;
            int num2;
            if (option < 1)
            {
                num2 = 1;
            }
            else if (size <= ti_qstick_start(options))
            {
                num2 = 0;
            }
            else
            {
                double num3 = 0.0;
                for (int index2 = 0; index2 < option; ++index2)
                {
                    num3 += input2[index2] - input1[index2];
                }

                output[index1] = num3 * num1;
                int index3 = index1 + 1;
                for (int index2 = option; index2 < size; ++index2)
                {
                    num3 = num3 + (input2[index2] - input1[index2]) - (input2[index2 - option] - input1[index2 - option]);
                    output[index3] = num3 * num1;
                    ++index3;
                }

                num2 = 0;
            }

            return num2;
        }

        internal static int ti_roc_start(double[] options)
        {
            return (int) options[0];
        }

        internal static int ti_roc(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num;
            if (option < 1)
            {
                num = 1;
            }
            else if (size <= ti_roc_start(options))
            {
                num = 0;
            }
            else
            {
                for (int index2 = option; index2 < size; ++index2)
                {
                    output[index1] = (input[index2] - input[index2 - option]) / input[index2 - option];
                    ++index1;
                }

                num = 0;
            }

            return num;
        }

        internal static int ti_rocr_start(double[] options)
        {
            return (int) options[0];
        }

        internal static int ti_rocr(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num;
            if (option < 1)
            {
                num = 1;
            }
            else if (size <= ti_rocr_start(options))
            {
                num = 0;
            }
            else
            {
                for (int index2 = option; index2 < size; ++index2)
                {
                    output[index1] = input[index2] / input[index2 - option];
                    ++index1;
                }

                num = 0;
            }

            return num;
        }

        internal static int ti_round_start(double[] options)
        {
            return 0;
        }

        internal static int ti_round(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = Math.Floor(input[index] + 0.5);
            }

            return 0;
        }

        internal static int ti_rsi_start(double[] options)
        {
            return (int) options[0];
        }

        internal static int ti_rsi(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int num1 = 0;
            double num2 = 1.0 / option;
            int num3;
            if (option < 1)
            {
                num3 = 1;
            }
            else if (size <= ti_rsi_start(options))
            {
                num3 = 0;
            }
            else
            {
                double num4 = 0.0;
                double num5 = 0.0;
                for (int index = 1; index <= option; ++index)
                {
                    double num6 = input[index] <= input[index - 1] ? 0.0 : input[index] - input[index - 1];
                    double num7 = input[index] >= input[index - 1] ? 0.0 : input[index - 1] - input[index];
                    num4 += num6;
                    num5 += num7;
                }

                double num8 = num4 / option;
                double num9 = num5 / option;
                double[] numArray1 = output;
                int index1 = num1;
                double num10 = num8;
                double num11 = 100.0 * (num10 / (num10 + num9));
                numArray1[index1] = num11;
                int num12 = num1 + 1;
                for (int index2 = option + 1; index2 < size; ++index2)
                {
                    double num6 = input[index2] <= input[index2 - 1] ? 0.0 : input[index2] - input[index2 - 1];
                    double num7 = input[index2] >= input[index2 - 1] ? 0.0 : input[index2 - 1] - input[index2];
                    num8 = (num6 - num8) * num2 + num8;
                    num9 = (num7 - num9) * num2 + num9;
                    double[] numArray2 = output;
                    int index3 = num12;
                    double num13 = num8;
                    double num14 = 100.0 * (num13 / (num13 + num9));
                    numArray2[index3] = num14;
                    ++num12;
                }

                num3 = 0;
            }

            return num3;
        }

        internal static int ti_sin_start(double[] options)
        {
            return 0;
        }

        internal static int ti_sin(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = Math.Abs(input[index]);
            }

            return 0;
        }

        internal static int ti_sinh_start(double[] options)
        {
            return 0;
        }

        internal static int ti_sinh(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = Math.Abs(input[index]);
            }

            return 0;
        }

        internal static int ti_sma_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_sma(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            double num1 = 1.0 / option;
            int num2;
            if (option < 1)
            {
                num2 = 1;
            }
            else if (size <= ti_sma_start(options))
            {
                num2 = 0;
            }
            else
            {
                double num3 = 0.0;
                for (int index2 = 0; index2 < option; ++index2)
                {
                    num3 += input[index2];
                }

                output[index1] = num3 * num1;
                int index3 = index1 + 1;
                for (int index2 = option; index2 < size; ++index2)
                {
                    num3 = num3 + input[index2] - input[index2 - option];
                    output[index3] = num3 * num1;
                    ++index3;
                }

                num2 = 0;
            }

            return num2;
        }

        internal static int ti_sqrt_start(double[] options)
        {
            return 0;
        }

        internal static int ti_sqrt(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = Math.Sqrt(input[index]);
            }

            return 0;
        }

        internal static int ti_stddev_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_stddev(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            double num1 = 1.0 / option;
            int num2;
            if (option < 1)
            {
                num2 = 1;
            }
            else if (size <= ti_stddev_start(options))
            {
                num2 = 0;
            }
            else
            {
                double num3 = 0.0;
                double num4 = 0.0;
                for (int index2 = 0; index2 < option; ++index2)
                {
                    num3 += input[index2];
                    num4 += input[index2] * input[index2];
                }

                double d1 = num4 * num1 - num3 * num1 * (num3 * num1);
                if (d1 > 0.0)
                {
                    d1 = Math.Sqrt(d1);
                }

                output[index1] = d1;
                int index3 = index1 + 1;
                for (int index2 = option; index2 < size; ++index2)
                {
                    double num5 = num3 + input[index2];
                    double num6 = num4 + input[index2] * input[index2];
                    num3 = num5 - input[index2 - option];
                    num4 = num6 - input[index2 - option] * input[index2 - option];
                    double d2 = num4 * num1 - num3 * num1 * (num3 * num1);
                    if (d2 > 0.0)
                    {
                        d2 = Math.Sqrt(d2);
                    }

                    output[index3] = d2;
                    ++index3;
                }

                num2 = 0;
            }

            return num2;
        }

        internal static int ti_stderr_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_stderr(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            double num1 = 1.0 / option;
            int num2;
            if (option < 1)
            {
                num2 = 1;
            }
            else if (size <= ti_stderr_start(options))
            {
                num2 = 0;
            }
            else
            {
                double num3 = 0.0;
                double num4 = 0.0;
                double num5 = 1.0 / Math.Sqrt(option);
                for (int index2 = 0; index2 < option; ++index2)
                {
                    num3 += input[index2];
                    num4 += input[index2] * input[index2];
                }

                double d1 = num4 * num1 - num3 * num1 * (num3 * num1);
                if (d1 > 0.0)
                {
                    d1 = Math.Sqrt(d1);
                }

                output[index1] = num5 * d1;
                int index3 = index1 + 1;
                for (int index2 = option; index2 < size; ++index2)
                {
                    double num6 = num3 + input[index2];
                    double num7 = num4 + input[index2] * input[index2];
                    num3 = num6 - input[index2 - option];
                    num4 = num7 - input[index2 - option] * input[index2 - option];
                    double d2 = num4 * num1 - num3 * num1 * (num3 * num1);
                    if (d2 > 0.0)
                    {
                        d2 = Math.Sqrt(d2);
                    }

                    output[index3] = num5 * d2;
                    ++index3;
                }

                num2 = 0;
            }

            return num2;
        }

        internal static int ti_stoch_start(double[] options)
        {
            return (int) options[0] + (int) options[1] + (int) options[2] - 3;
        }

        internal static int ti_stoch(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] input3 = inputs[2];
            int option1 = (int) options[0];
            int option2 = (int) options[1];
            int option3 = (int) options[2];
            double num1 = 1.0 / option2;
            double num2 = 1.0 / option3;
            double[] output1 = outputs[0];
            int index1 = 0;
            double[] output2 = outputs[1];
            int index2 = 0;
            int num3;
            if (option1 < 1)
            {
                num3 = 1;
            }
            else if (option2 < 1)
            {
                num3 = 1;
            }
            else if (option3 < 1)
            {
                num3 = 1;
            }
            else if (size <= ti_stoch_start(options))
            {
                num3 = 0;
            }
            else
            {
                int num4 = 0;
                int index3 = -1;
                int index4 = -1;
                double num5 = input1[0];
                double num6 = input2[0];
                var buffer1 = ti_buffer_new(option2);
                var buffer2 = ti_buffer_new(option3);
                for (int index5 = 0; index5 < size; ++index5)
                {
                    if (index5 >= option1)
                    {
                        ++num4;
                    }

                    double num7 = input1[index5];
                    if (index3 < num4)
                    {
                        index3 = num4;
                        num5 = input1[index3];
                        int index6 = num4;
                        while (true)
                        {
                            double num8;
                            do
                            {
                                ++index6;
                                if (index6 <= index5)
                                {
                                    num8 = input1[index6];
                                }
                                else
                                {
                                    goto label_20;
                                }
                            } while (num8 < num5);

                            num5 = num8;
                            index3 = index6;
                        }
                    }

                    if (num7 >= num5)
                    {
                        index3 = index5;
                        num5 = num7;
                    }

                    label_20:
                    double num9 = input2[index5];
                    if (index4 < num4)
                    {
                        index4 = num4;
                        num6 = input2[index4];
                        int index6 = num4;
                        while (true)
                        {
                            double num8;
                            do
                            {
                                ++index6;
                                if (index6 <= index5)
                                {
                                    num8 = input2[index6];
                                }
                                else
                                {
                                    goto label_27;
                                }
                            } while (num8 > num6);

                            num6 = num8;
                            index4 = index6;
                        }
                    }

                    if (num9 <= num6)
                    {
                        index4 = index5;
                        num6 = num9;
                    }

                    label_27:
                    double num10 = num5 - num6;
                    double num11 = num10 != 0.0 ? 100.0 * ((input3[index5] - num6) / num10) : 0.0;
                    do
                    {
                        if (buffer1.pushes >= buffer1.size)
                        {
                            buffer1.sum -= buffer1.vals[buffer1.index];
                        }

                        buffer1.sum += num11;
                        buffer1.vals[buffer1.index] = num11;
                        ++buffer1.pushes;
                        ++buffer1.index;
                        if (buffer1.index >= buffer1.size)
                        {
                            buffer1.index = 0;
                        }
                    } while (false);

                    if (index5 < option1 - 1 + option2 - 1)
                    {
                        continue;
                    }

                    double num12 = buffer1.sum * num1;
                    do
                    {
                        if (buffer2.pushes >= buffer2.size)
                        {
                            buffer2.sum -= buffer2.vals[buffer2.index];
                        }

                        buffer2.sum += num12;
                        buffer2.vals[buffer2.index] = num12;
                        ++buffer2.pushes;
                        ++buffer2.index;
                        if (buffer2.index >= buffer2.size)
                        {
                            buffer2.index = 0;
                        }
                    } while (false);

                    if (index5 >= option1 - 1 + option2 - 1 + option3 - 1)
                    {
                        output1[index1] = num12;
                        ++index1;
                        output2[index2] = buffer2.sum * num2;
                        ++index2;
                    }
                }

                num3 = 0;
            }

            return num3;
        }

        internal static int ti_sub_start(double[] options)
        {
            return 0;
        }

        internal static int ti_sub(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = input1[index] - input2[index];
            }

            return 0;
        }

        internal static int ti_sum_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_sum(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_sum_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = 0.0;
                for (int index2 = 0; index2 < option; ++index2)
                {
                    num2 += input[index2];
                }

                output[index1] = num2;
                int index3 = index1 + 1;
                for (int index2 = option; index2 < size; ++index2)
                {
                    num2 = num2 + input[index2] - input[index2 - option];
                    output[index3] = num2;
                    ++index3;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_tan_start(double[] options)
        {
            return 0;
        }

        internal static int ti_tan(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = Math.Abs(input[index]);
            }

            return 0;
        }

        internal static int ti_tanh_start(double[] options)
        {
            return 0;
        }

        internal static int ti_tanh(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = Math.Abs(input[index]);
            }

            return 0;
        }

        internal static int ti_tema_start(double[] options)
        {
            return ((int) options[0] - 1) * 3;
        }

        internal static int ti_tema(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_tema_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = 2.0 / (option + 1.0);
                double num3 = 1.0 - num2;
                double num4 = input[0];
                double num5 = 0.0;
                double num6 = 0.0;
                for (int index2 = 0; index2 < size; ++index2)
                {
                    num4 = num4 * num3 + input[index2] * num2;
                    if (index2 == option - 1)
                    {
                        num5 = num4;
                    }

                    if (index2 < option - 1)
                    {
                        continue;
                    }

                    num5 = num5 * num3 + num4 * num2;
                    if (index2 == (option - 1) * 2)
                    {
                        num6 = num5;
                    }

                    if (index2 >= (option - 1) * 2)
                    {
                        num6 = num6 * num3 + num5 * num2;
                        if (index2 >= (option - 1) * 3)
                        {
                            output[index1] = 3.0 * num4 - 3.0 * num5 + num6;
                            ++index1;
                        }
                    }
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_todeg_start(double[] options)
        {
            return 0;
        }

        internal static int ti_todeg(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = input[index] * (180.0 / Math.PI);
            }

            return 0;
        }

        internal static int ti_torad_start(double[] options)
        {
            return 0;
        }

        internal static int ti_torad(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = input[index] * (Math.PI / 180.0);
            }

            return 0;
        }

        internal static int ti_tr_start(double[] options)
        {
            return 0;
        }

        internal static int ti_tr(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] input3 = inputs[2];
            double[] output = outputs[0];
            output[0] = input1[0] - input2[0];
            for (int index = 1; index < size; ++index)
            {
                double num1;
                do
                {
                    double num2 = input2[index];
                    double num3 = input1[index];
                    double num4 = input3[index - 1];
                    double num5 = Math.Abs(num3 - num4);
                    double num6 = Math.Abs(num2 - num4);
                    double num7 = num3 - num2;
                    if (num5 > num7)
                    {
                        num7 = num5;
                    }

                    if (num6 > num7)
                    {
                        num7 = num6;
                    }

                    num1 = num7;
                } while (false);

                output[index] = num1;
            }

            return 0;
        }

        internal static int ti_trima_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_trima(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_trima_start(options))
            {
                num1 = 0;
            }
            else if (option <= 2)
            {
                num1 = ti_sma(size, inputs, options, outputs);
            }
            else
            {
                double num2 = 1.0 / (option % 2 == 0 ? (option / 2 + 1) * (option / 2) : (double) ((option / 2 + 1) * (option / 2 + 1)));
                double num3 = 0.0;
                double num4 = 0.0;
                double num5 = 0.0;
                int num6 = option % 2 == 0 ? option / 2 - 1 : option / 2;
                int num7 = num6 + 1;
                int num8 = 1;
                for (int index2 = 0; index2 < option - 1; ++index2)
                {
                    num3 += input[index2] * num8;
                    if (index2 + 1 > option - num6)
                    {
                        num4 += input[index2];
                    }

                    if (index2 + 1 <= num7)
                    {
                        num5 += input[index2];
                    }

                    if (index2 + 1 < num7)
                    {
                        ++num8;
                    }

                    if (index2 + 1 < option - num6)
                    {
                        continue;
                    }

                    --num8;
                }

                int index3 = option - 1 - num6 + 1;
                int index4 = option - 1 - option + 1 + num7;
                int index5 = option - 1 - option + 1;
                for (int index2 = option - 1; index2 < size; ++index2)
                {
                    double num9 = num3 + input[index2];
                    output[index1] = num9 * num2;
                    ++index1;
                    double num10 = num4 + input[index2];
                    num3 = num9 + num10 - num5;
                    num4 = num10 - input[index3];
                    ++index3;
                    double num11 = num5 + input[index4];
                    ++index4;
                    num5 = num11 - input[index5];
                    ++index5;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_trix_start(double[] options)
        {
            return ((int) options[0] - 1) * 3 + 1;
        }

        internal static int ti_trix(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_trix_start(options))
            {
                num1 = 0;
            }
            else
            {
                int num2 = option * 3 - 2;
                double num3 = 2.0 / (option + 1.0);
                double num4 = input[0];
                double num5 = 0.0;
                double num6 = 0.0;
                for (int index2 = 1; index2 < num2; ++index2)
                {
                    num4 = (input[index2] - num4) * num3 + num4;
                    if (index2 != option - 1)
                    {
                        goto label_9;
                    }

                    num5 = num4;
                    continue;
                    label_9:
                    if (index2 > option - 1)
                    {
                        num5 = (num4 - num5) * num3 + num5;
                        if (index2 == option * 2 - 2)
                        {
                            num6 = num5;
                        }
                        else if (index2 > option * 2 - 2)
                        {
                            num6 = (num5 - num6) * num3 + num6;
                        }
                    }
                }

                for (int index2 = num2; index2 < size; ++index2)
                {
                    num4 = (input[index2] - num4) * num3 + num4;
                    num5 = (num4 - num5) * num3 + num5;
                    double num7 = num6;
                    num6 = (num5 - num6) * num3 + num6;
                    output[index1] = (num6 - num7) / num6 * 100.0;
                    ++index1;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_trunc_start(double[] options)
        {
            return 0;
        }

        internal static int ti_trunc(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = (int) input[index];
            }

            return 0;
        }

        internal static int ti_tsf_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_tsf(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_tsf_start(options))
            {
                num1 = 0;
            }
            else
            {
                do
                {
                    double num2 = 0.0;
                    double num3 = 0.0;
                    double num4 = 0.0;
                    double num5 = 0.0;
                    double num6 = 1.0 / option;
                    for (int index2 = 0; index2 < option - 1; ++index2)
                    {
                        num2 += index2 + 1;
                        num3 += (index2 + 1) * (index2 + 1);
                        num5 += input[index2] * (index2 + 1);
                        num4 += input[index2];
                    }

                    double num7 = num2 + option;
                    double num8 = num3;
                    int num9 = option;
                    double num10 = num9 * num9;
                    double num11 = num8 + num10;
                    double num12 = option * num11;
                    double num13 = num7;
                    double num14 = num13 * num13;
                    double num15 = 1.0 / (num12 - num14);
                    for (int index2 = option - 1; index2 < size; ++index2)
                    {
                        double num16 = num5 + input[index2] * option;
                        double num17 = num4 + input[index2];
                        double num18 = (option * num16 - num7 * num17) * num15;
                        do
                        {
                            double num19 = (num17 - num18 * num7) * num6;
                            output[index1] = num19 + num18 * (option + 1);
                            ++index1;
                        } while (false);

                        num5 = num16 - num17;
                        num4 = num17 - input[index2 - option + 1];
                    }
                } while (false);

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_typprice_start(double[] options)
        {
            return 0;
        }

        internal static int ti_typprice(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] input3 = inputs[2];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = (input1[index] + input2[index] + input3[index]) * (1.0 / 3.0);
            }

            return 0;
        }

        internal static int ti_ultosc_start(double[] options)
        {
            return (int) options[2];
        }

        internal static int ti_ultosc(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] input3 = inputs[2];
            int option1 = (int) options[0];
            int option2 = (int) options[1];
            int option3 = (int) options[2];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option1 < 1)
            {
                num1 = 1;
            }
            else if (option2 < option1)
            {
                num1 = 1;
            }
            else if (option3 < option2)
            {
                num1 = 1;
            }
            else if (size <= ti_ultosc_start(options))
            {
                num1 = 0;
            }
            else
            {
                var buffer1 = ti_buffer_new(option3);
                var buffer2 = ti_buffer_new(option3);
                double num2 = 0.0;
                double num3 = 0.0;
                double num4 = 0.0;
                double num5 = 0.0;
                for (int index2 = 1; index2 < size; ++index2)
                {
                    double num6 = input2[index2] >= input3[index2 - 1] ? input3[index2 - 1] : input2[index2];
                    double num7 = input1[index2] <= input3[index2 - 1] ? input3[index2 - 1] : input1[index2];
                    double num8 = input3[index2] - num6;
                    double num9 = num7 - num6;
                    num2 += num8;
                    num3 += num8;
                    num4 += num9;
                    num5 += num9;
                    do
                    {
                        if (buffer1.pushes >= buffer1.size)
                        {
                            buffer1.sum -= buffer1.vals[buffer1.index];
                        }

                        buffer1.sum += num8;
                        buffer1.vals[buffer1.index] = num8;
                        ++buffer1.pushes;
                        ++buffer1.index;
                        if (buffer1.index >= buffer1.size)
                        {
                            buffer1.index = 0;
                        }
                    } while (false);

                    do
                    {
                        if (buffer2.pushes >= buffer2.size)
                        {
                            buffer2.sum -= buffer2.vals[buffer2.index];
                        }

                        buffer2.sum += num9;
                        buffer2.vals[buffer2.index] = num9;
                        ++buffer2.pushes;
                        ++buffer2.index;
                        if (buffer2.index >= buffer2.size)
                        {
                            buffer2.index = 0;
                        }
                    } while (false);

                    if (index2 > option1)
                    {
                        int index3 = buffer1.index - option1 - 1;
                        if (index3 < 0)
                        {
                            index3 += option3;
                        }

                        num2 -= buffer1.vals[index3];
                        num4 -= buffer2.vals[index3];
                        if (index2 > option2)
                        {
                            int index4 = buffer1.index - option2 - 1;
                            if (index4 < 0)
                            {
                                index4 += option3;
                            }

                            num3 -= buffer1.vals[index4];
                            num5 -= buffer2.vals[index4];
                        }
                    }

                    if (index2 < option3)
                    {
                        continue;
                    }

                    double num10 = (4.0 * num2 / num4 + 2.0 * num3 / num5 + 1.0 * buffer1.sum / buffer2.sum) * 100.0 / 7.0;
                    output[index1] = num10;
                    ++index1;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_var_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_var(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            double num1 = 1.0 / option;
            int num2;
            if (option < 1)
            {
                num2 = 1;
            }
            else if (size <= ti_var_start(options))
            {
                num2 = 0;
            }
            else
            {
                double num3 = 0.0;
                double num4 = 0.0;
                for (int index2 = 0; index2 < option; ++index2)
                {
                    num3 += input[index2];
                    num4 += input[index2] * input[index2];
                }

                output[index1] = num4 * num1 - num3 * num1 * (num3 * num1);
                int index3 = index1 + 1;
                for (int index2 = option; index2 < size; ++index2)
                {
                    double num5 = num3 + input[index2];
                    double num6 = num4 + input[index2] * input[index2];
                    num3 = num5 - input[index2 - option];
                    num4 = num6 - input[index2 - option] * input[index2 - option];
                    output[index3] = num4 * num1 - num3 * num1 * (num3 * num1);
                    ++index3;
                }

                num2 = 0;
            }

            return num2;
        }

        internal static int ti_vhf_start(double[] options)
        {
            return (int) options[0];
        }

        internal static int ti_vhf(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_vhf_start(options))
            {
                num1 = 0;
            }
            else
            {
                int num2 = 1;
                int index2 = -1;
                int index3 = -1;
                double num3 = input[0];
                double num4 = input[0];
                double num5 = 0.0;
                double num6 = input[0];
                for (int index4 = 1; index4 < option; ++index4)
                {
                    double num7 = input[index4];
                    num5 += Math.Abs(num7 - num6);
                    num6 = num7;
                }

                int index5 = option;
                while (index5 < size)
                {
                    double num7 = input[index5];
                    num5 += Math.Abs(num7 - num6);
                    num6 = num7;
                    if (index5 > option)
                    {
                        num5 -= Math.Abs(input[index5 - option] - input[index5 - option - 1]);
                    }

                    double num8 = num7;
                    if (index2 < num2)
                    {
                        index2 = num2;
                        num3 = input[index2];
                        int index4 = num2;
                        while (true)
                        {
                            double num9;
                            do
                            {
                                ++index4;
                                if (index4 <= index5)
                                {
                                    num9 = input[index4];
                                }
                                else
                                {
                                    goto label_18;
                                }
                            } while (num9 < num3);

                            num3 = num9;
                            index2 = index4;
                        }
                    }

                    if (num8 >= num3)
                    {
                        index2 = index5;
                        num3 = num8;
                    }

                    label_18:
                    double num10 = num7;
                    if (index3 < num2)
                    {
                        index3 = num2;
                        num4 = input[index3];
                        int index4 = num2;
                        while (true)
                        {
                            double num9;
                            do
                            {
                                ++index4;
                                if (index4 <= index5)
                                {
                                    num9 = input[index4];
                                }
                                else
                                {
                                    goto label_25;
                                }
                            } while (num9 > num4);

                            num4 = num9;
                            index3 = index4;
                        }
                    }

                    if (num10 <= num4)
                    {
                        index3 = index5;
                        num4 = num10;
                    }

                    label_25:
                    output[index1] = Math.Abs(num3 - num4) / num5;
                    ++index1;
                    ++index5;
                    ++num2;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_vidya_start(double[] options)
        {
            return (int) options[1] - 2;
        }

        internal static int ti_vidya(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option1 = (int) options[0];
            int option2 = (int) options[1];
            double option3 = options[2];
            double[] output = outputs[0];
            int index1 = 0;
            double num1 = 1.0 / option1;
            double num2 = 1.0 / option2;
            int num3;
            if (option1 < 1)
            {
                num3 = 1;
            }
            else if (option2 < option1)
            {
                num3 = 1;
            }
            else if (option2 < 2)
            {
                num3 = 1;
            }
            else if (option3 < 0.0 || option3 > 1.0)
            {
                num3 = 1;
            }
            else if (size <= ti_vidya_start(options))
            {
                num3 = 0;
            }
            else
            {
                double num4 = 0.0;
                double num5 = 0.0;
                double num6 = 0.0;
                double num7 = 0.0;
                for (int index2 = 0; index2 < option2; ++index2)
                {
                    num6 += input[index2];
                    num7 += input[index2] * input[index2];
                    if (index2 < option2 - option1)
                    {
                        continue;
                    }

                    num4 += input[index2];
                    num5 += input[index2] * input[index2];
                }

                double num8 = input[option2 - 2];
                output[index1] = num8;
                int index3 = index1 + 1;
                if (option2 - 1 < size)
                {
                    double num9 = Math.Sqrt(num5 * num1 - num4 * num1 * (num4 * num1)) /
                                  Math.Sqrt(num7 * num2 - num6 * num2 * (num6 * num2));
                    double num10 = num9;
                    if (num10 != num10)
                    {
                        num9 = 0.0;
                    }

                    double num11 = num9 * option3;
                    num8 = (input[option2 - 1] - num8) * num11 + num8;
                    output[index3] = num8;
                    ++index3;
                }

                for (int index2 = option2; index2 < size; ++index2)
                {
                    double num9 = num6 + input[index2];
                    double num10 = num7 + input[index2] * input[index2];
                    double num11 = num4 + input[index2];
                    double num12 = num5 + input[index2] * input[index2];
                    num6 = num9 - input[index2 - option2];
                    num7 = num10 - input[index2 - option2] * input[index2 - option2];
                    num4 = num11 - input[index2 - option1];
                    num5 = num12 - input[index2 - option1] * input[index2 - option1];
                    double num13 = Math.Sqrt(num5 * num1 - num4 * num1 * (num4 * num1)) /
                                   Math.Sqrt(num7 * num2 - num6 * num2 * (num6 * num2));
                    double num14 = num13;
                    if (num14 != num14)
                    {
                        num13 = 0.0;
                    }

                    double num15 = num13 * option3;
                    num8 = (input[index2] - num8) * num15 + num8;
                    output[index3] = num8;
                    ++index3;
                }

                num3 = 0;
            }

            return num3;
        }

        internal static int ti_volatility_start(double[] options)
        {
            return (int) options[0];
        }

        internal static int ti_volatility(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            int index1 = 0;
            int option = (int) options[0];
            double num1 = 1.0 / option;
            double num2 = Math.Sqrt(252.0);
            int num3;
            if (option < 1)
            {
                num3 = 1;
            }
            else if (size <= ti_volatility_start(options))
            {
                num3 = 0;
            }
            else
            {
                double num4 = 0.0;
                double num5 = 0.0;
                for (int index2 = 1; index2 <= option; ++index2)
                {
                    double num6 = input[index2] / input[index2 - 1] - 1.0;
                    num4 += num6;
                    double num7 = num5;
                    double num8 = num6;
                    double num9 = num8 * num8;
                    num5 = num7 + num9;
                }

                output[index1] = Math.Sqrt(num5 * num1 - num4 * num1 * (num4 * num1)) * num2;
                int index3 = index1 + 1;
                for (int index2 = option + 1; index2 < size; ++index2)
                {
                    double num6 = input[index2] / input[index2 - 1] - 1.0;
                    double num7 = num4 + num6;
                    double num8 = num5;
                    double num9 = num6;
                    double num10 = num9 * num9;
                    double num11 = num8 + num10;
                    double num12 = input[index2 - option] / input[index2 - option - 1] - 1.0;
                    num4 = num7 - num12;
                    double num13 = num11;
                    double num14 = num12;
                    double num15 = num14 * num14;
                    num5 = num13 - num15;
                    output[index3] = Math.Sqrt(num5 * num1 - num4 * num1 * (num4 * num1)) * num2;
                    ++index3;
                }

                num3 = 0;
            }

            return num3;
        }

        internal static int ti_vosc_start(double[] options)
        {
            return (int) options[1] - 1;
        }

        internal static int ti_vosc(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            int index1 = 0;
            int option1 = (int) options[0];
            int option2 = (int) options[1];
            double num1 = 1.0 / option1;
            double num2 = 1.0 / option2;
            int num3;
            if (option1 < 1)
            {
                num3 = 1;
            }
            else if (option2 < option1)
            {
                num3 = 1;
            }
            else if (size <= ti_vosc_start(options))
            {
                num3 = 0;
            }
            else
            {
                double num4 = 0.0;
                double num5 = 0.0;
                for (int index2 = 0; index2 < option2; ++index2)
                {
                    if (index2 >= option2 - option1)
                    {
                        num4 += input[index2];
                    }

                    num5 += input[index2];
                }

                double num6 = num4 * num1;
                double num7 = num5 * num2;
                output[index1] = 100.0 * (num6 - num7) / num7;
                int index3 = index1 + 1;
                for (int index2 = option2; index2 < size; ++index2)
                {
                    num4 = num4 + input[index2] - input[index2 - option1];
                    num5 = num5 + input[index2] - input[index2 - option2];
                    double num8 = num4 * num1;
                    double num9 = num5 * num2;
                    output[index3] = 100.0 * (num8 - num9) / num9;
                    ++index3;
                }

                num3 = 0;
            }

            return num3;
        }

        internal static int ti_vwma_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_vwma(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_vwma_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = 0.0;
                double num3 = 0.0;
                for (int index2 = 0; index2 < option; ++index2)
                {
                    num2 += input1[index2] * input2[index2];
                    num3 += input2[index2];
                }

                output[index1] = num2 / num3;
                int index3 = index1 + 1;
                for (int index2 = option; index2 < size; ++index2)
                {
                    num2 = num2 + input1[index2] * input2[index2] - input1[index2 - option] * input2[index2 - option];
                    num3 = num3 + input2[index2] - input2[index2 - option];
                    output[index3] = num2 / num3;
                    ++index3;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_wad_start(double[] options)
        {
            return 1;
        }

        internal static int ti_wad(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] input3 = inputs[2];
            int num1;
            if (size <= ti_wad_start(options))
            {
                num1 = 0;
            }
            else
            {
                double[] output = outputs[0];
                int index1 = 0;
                double num2 = 0.0;
                double num3 = input3[0];
                for (int index2 = 1; index2 < size; ++index2)
                {
                    double num4 = input3[index2];
                    if (num4 > num3)
                    {
                        double num5 = num3 >= input2[index2] ? input2[index2] : num3;
                        num2 += num4 - num5;
                    }
                    else if (num4 < num3)
                    {
                        double num5 = num3 <= input1[index2] ? input1[index2] : num3;
                        num2 += num4 - num5;
                    }

                    output[index1] = num2;
                    ++index1;
                    num3 = input3[index2];
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_wcprice_start(double[] options)
        {
            return 0;
        }

        internal static int ti_wcprice(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] input3 = inputs[2];
            double[] output = outputs[0];
            for (int index = 0; index < size; ++index)
            {
                output[index] = (input1[index] + input2[index] + input3[index] + input3[index]) * 0.25;
            }

            return 0;
        }

        internal static int ti_wilders_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_wilders(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_wilders_start(options))
            {
                num1 = 0;
            }
            else
            {
                double num2 = 1.0 / option;
                double num3 = 0.0;
                for (int index2 = 0; index2 < option; ++index2)
                {
                    num3 += input[index2];
                }

                double num4 = num3 / option;
                output[index1] = num4;
                int index3 = index1 + 1;
                for (int index2 = option; index2 < size; ++index2)
                {
                    num4 = (input[index2] - num4) * num2 + num4;
                    output[index3] = num4;
                    ++index3;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_willr_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_willr(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input1 = inputs[0];
            double[] input2 = inputs[1];
            double[] input3 = inputs[2];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_willr_start(options))
            {
                num1 = 0;
            }
            else
            {
                int num2 = 0;
                int index2 = -1;
                int index3 = -1;
                double num3 = input1[0];
                double num4 = input2[0];
                int index4 = option - 1;
                while (index4 < size)
                {
                    double num5 = input1[index4];
                    if (index2 < num2)
                    {
                        index2 = num2;
                        num3 = input1[index2];
                        int index5 = num2;
                        while (true)
                        {
                            double num6;
                            do
                            {
                                ++index5;
                                if (index5 <= index4)
                                {
                                    num6 = input1[index5];
                                }
                                else
                                {
                                    goto label_13;
                                }
                            } while (num6 < num3);

                            num3 = num6;
                            index2 = index5;
                        }
                    }

                    if (num5 >= num3)
                    {
                        index2 = index4;
                        num3 = num5;
                    }

                    label_13:
                    double num7 = input2[index4];
                    if (index3 < num2)
                    {
                        index3 = num2;
                        num4 = input2[index3];
                        int index5 = num2;
                        while (true)
                        {
                            double num6;
                            do
                            {
                                ++index5;
                                if (index5 <= index4)
                                {
                                    num6 = input2[index5];
                                }
                                else
                                {
                                    goto label_20;
                                }
                            } while (num6 > num4);

                            num4 = num6;
                            index3 = index5;
                        }
                    }

                    if (num7 <= num4)
                    {
                        index3 = index4;
                        num4 = num7;
                    }

                    label_20:
                    double num8 = num3 - num4;
                    double num9 = num8 != 0.0 ? -100.0 * ((num3 - input3[index4]) / num8) : 0.0;
                    output[index1] = num9;
                    ++index1;
                    ++index4;
                    ++num2;
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_wma_start(double[] options)
        {
            return (int) options[0] - 1;
        }

        internal static int ti_wma(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            double[] output = outputs[0];
            int index1 = 0;
            int num1;
            if (option < 1)
            {
                num1 = 1;
            }
            else if (size <= ti_wma_start(options))
            {
                num1 = 0;
            }
            else
            {
                int num2 = option;
                double num3 = num2 * (num2 + 1) / 2;
                double num4 = 0.0;
                double num5 = 0.0;
                for (int index2 = 0; index2 < option - 1; ++index2)
                {
                    num5 += input[index2] * (index2 + 1);
                    num4 += input[index2];
                }

                for (int index2 = option - 1; index2 < size; ++index2)
                {
                    double num6 = num5 + input[index2] * option;
                    double num7 = num4 + input[index2];
                    output[index1] = num6 / num3;
                    ++index1;
                    num5 = num6 - num7;
                    num4 = num7 - input[index2 - option + 1];
                }

                num1 = 0;
            }

            return num1;
        }

        internal static int ti_zlema_start(double[] options)
        {
            return ((int) options[0] - 1) / 2 - 1;
        }

        internal static int ti_zlema(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int option = (int) options[0];
            int num1 = (option - 1) / 2;
            double[] output = outputs[0];
            int index1 = 0;
            int num2;
            if (option < 1)
            {
                num2 = 1;
            }
            else if (size <= ti_zlema_start(options))
            {
                num2 = 0;
            }
            else
            {
                double num3 = 2.0 / (option + 1.0);
                double num4 = input[num1 - 1];
                output[index1] = num4;
                int index2 = index1 + 1;
                for (int index3 = num1; index3 < size; ++index3)
                {
                    double num5 = input[index3];
                    double num6 = input[index3 - num1];
                    double num7 = num5;
                    num4 = (num7 + (num7 - num6) - num4) * num3 + num4;
                    output[index2] = num4;
                    ++index2;
                }

                num2 = 0;
            }

            return num2;
        }

        internal static (int size, int pushes, int index, double sum, double[] vals) ti_buffer_new(int size) =>
            (size, 0, 0, 0.0, new double[size]);

        internal static int indicator_run(int index, double[][] inputs, double[] options, double[][] outputs)
        {
            int length = inputs[0].Length;
            var num = index switch
            {
                0 => ti_abs(length, inputs, options, outputs),
                1 => ti_acos(length, inputs, options, outputs),
                2 => ti_ad(length, inputs, options, outputs),
                3 => ti_add(length, inputs, options, outputs),
                4 => ti_adosc(length, inputs, options, outputs),
                5 => ti_adx(length, inputs, options, outputs),
                6 => ti_adxr(length, inputs, options, outputs),
                7 => ti_ao(length, inputs, options, outputs),
                8 => ti_apo(length, inputs, options, outputs),
                9 => ti_aroon(length, inputs, options, outputs),
                10 => ti_aroonosc(length, inputs, options, outputs),
                11 => ti_asin(length, inputs, options, outputs),
                12 => ti_atan(length, inputs, options, outputs),
                13 => ti_atr(length, inputs, options, outputs),
                14 => ti_avgprice(length, inputs, options, outputs),
                15 => ti_bbands(length, inputs, options, outputs),
                16 => ti_bop(length, inputs, options, outputs),
                17 => ti_cci(length, inputs, options, outputs),
                18 => ti_ceil(length, inputs, options, outputs),
                19 => ti_cmo(length, inputs, options, outputs),
                20 => ti_cos(length, inputs, options, outputs),
                21 => ti_cosh(length, inputs, options, outputs),
                22 => ti_crossany(length, inputs, options, outputs),
                23 => ti_crossover(length, inputs, options, outputs),
                24 => ti_cvi(length, inputs, options, outputs),
                25 => ti_decay(length, inputs, options, outputs),
                26 => ti_dema(length, inputs, options, outputs),
                27 => ti_di(length, inputs, options, outputs),
                28 => ti_div(length, inputs, options, outputs),
                29 => ti_dm(length, inputs, options, outputs),
                30 => ti_dpo(length, inputs, options, outputs),
                31 => ti_dx(length, inputs, options, outputs),
                32 => ti_edecay(length, inputs, options, outputs),
                33 => ti_ema(length, inputs, options, outputs),
                34 => ti_emv(length, inputs, options, outputs),
                35 => ti_exp(length, inputs, options, outputs),
                36 => ti_fisher(length, inputs, options, outputs),
                37 => ti_floor(length, inputs, options, outputs),
                38 => ti_fosc(length, inputs, options, outputs),
                39 => ti_hma(length, inputs, options, outputs),
                40 => ti_kama(length, inputs, options, outputs),
                41 => ti_kvo(length, inputs, options, outputs),
                42 => ti_lag(length, inputs, options, outputs),
                43 => ti_linreg(length, inputs, options, outputs),
                44 => ti_linregintercept(length, inputs, options, outputs),
                45 => ti_linregslope(length, inputs, options, outputs),
                46 => ti_ln(length, inputs, options, outputs),
                47 => ti_log10(length, inputs, options, outputs),
                48 => ti_macd(length, inputs, options, outputs),
                49 => ti_marketfi(length, inputs, options, outputs),
                50 => ti_mass(length, inputs, options, outputs),
                51 => ti_max(length, inputs, options, outputs),
                52 => ti_md(length, inputs, options, outputs),
                53 => ti_medprice(length, inputs, options, outputs),
                54 => ti_mfi(length, inputs, options, outputs),
                55 => ti_min(length, inputs, options, outputs),
                56 => ti_mom(length, inputs, options, outputs),
                57 => ti_msw(length, inputs, options, outputs),
                58 => ti_mul(length, inputs, options, outputs),
                59 => ti_natr(length, inputs, options, outputs),
                60 => ti_nvi(length, inputs, options, outputs),
                61 => ti_obv(length, inputs, options, outputs),
                62 => ti_ppo(length, inputs, options, outputs),
                63 => ti_psar(length, inputs, options, outputs),
                64 => ti_pvi(length, inputs, options, outputs),
                65 => ti_qstick(length, inputs, options, outputs),
                66 => ti_roc(length, inputs, options, outputs),
                67 => ti_rocr(length, inputs, options, outputs),
                68 => ti_round(length, inputs, options, outputs),
                69 => ti_rsi(length, inputs, options, outputs),
                70 => ti_sin(length, inputs, options, outputs),
                71 => ti_sinh(length, inputs, options, outputs),
                72 => ti_sma(length, inputs, options, outputs),
                73 => ti_sqrt(length, inputs, options, outputs),
                74 => ti_stddev(length, inputs, options, outputs),
                75 => ti_stderr(length, inputs, options, outputs),
                76 => ti_stoch(length, inputs, options, outputs),
                77 => ti_sub(length, inputs, options, outputs),
                78 => ti_sum(length, inputs, options, outputs),
                79 => ti_tan(length, inputs, options, outputs),
                80 => ti_tanh(length, inputs, options, outputs),
                81 => ti_tema(length, inputs, options, outputs),
                82 => ti_todeg(length, inputs, options, outputs),
                83 => ti_torad(length, inputs, options, outputs),
                84 => ti_tr(length, inputs, options, outputs),
                85 => ti_trima(length, inputs, options, outputs),
                86 => ti_trix(length, inputs, options, outputs),
                87 => ti_trunc(length, inputs, options, outputs),
                88 => ti_tsf(length, inputs, options, outputs),
                89 => ti_typprice(length, inputs, options, outputs),
                90 => ti_ultosc(length, inputs, options, outputs),
                91 => ti_var(length, inputs, options, outputs),
                92 => ti_vhf(length, inputs, options, outputs),
                93 => ti_vidya(length, inputs, options, outputs),
                94 => ti_volatility(length, inputs, options, outputs),
                95 => ti_vosc(length, inputs, options, outputs),
                96 => ti_vwma(length, inputs, options, outputs),
                97 => ti_wad(length, inputs, options, outputs),
                98 => ti_wcprice(length, inputs, options, outputs),
                99 => ti_wilders(length, inputs, options, outputs),
                100 => ti_willr(length, inputs, options, outputs),
                101 => ti_wma(length, inputs, options, outputs),
                102 => ti_zlema(length, inputs, options, outputs),
                _ => 1
            };

            return num;
        }

        internal static int indicator_start(int index, double[] options)
        {
            var num = index switch
            {
                0 => ti_abs_start(options),
                1 => ti_acos_start(options),
                2 => ti_ad_start(options),
                3 => ti_add_start(options),
                4 => ti_adosc_start(options),
                5 => ti_adx_start(options),
                6 => ti_adxr_start(options),
                7 => ti_ao_start(options),
                8 => ti_apo_start(options),
                9 => ti_aroon_start(options),
                10 => ti_aroonosc_start(options),
                11 => ti_asin_start(options),
                12 => ti_atan_start(options),
                13 => ti_atr_start(options),
                14 => ti_avgprice_start(options),
                15 => ti_bbands_start(options),
                16 => ti_bop_start(options),
                17 => ti_cci_start(options),
                18 => ti_ceil_start(options),
                19 => ti_cmo_start(options),
                20 => ti_cos_start(options),
                21 => ti_cosh_start(options),
                22 => ti_crossany_start(options),
                23 => ti_crossover_start(options),
                24 => ti_cvi_start(options),
                25 => ti_decay_start(options),
                26 => ti_dema_start(options),
                27 => ti_di_start(options),
                28 => ti_div_start(options),
                29 => ti_dm_start(options),
                30 => ti_dpo_start(options),
                31 => ti_dx_start(options),
                32 => ti_edecay_start(options),
                33 => ti_ema_start(options),
                34 => ti_emv_start(options),
                35 => ti_exp_start(options),
                36 => ti_fisher_start(options),
                37 => ti_floor_start(options),
                38 => ti_fosc_start(options),
                39 => ti_hma_start(options),
                40 => ti_kama_start(options),
                41 => ti_kvo_start(options),
                42 => ti_lag_start(options),
                43 => ti_linreg_start(options),
                44 => ti_linregintercept_start(options),
                45 => ti_linregslope_start(options),
                46 => ti_ln_start(options),
                47 => ti_log10_start(options),
                48 => ti_macd_start(options),
                49 => ti_marketfi_start(options),
                50 => ti_mass_start(options),
                51 => ti_max_start(options),
                52 => ti_md_start(options),
                53 => ti_medprice_start(options),
                54 => ti_mfi_start(options),
                55 => ti_min_start(options),
                56 => ti_mom_start(options),
                57 => ti_msw_start(options),
                58 => ti_mul_start(options),
                59 => ti_natr_start(options),
                60 => ti_nvi_start(options),
                61 => ti_obv_start(options),
                62 => ti_ppo_start(options),
                63 => ti_psar_start(options),
                64 => ti_pvi_start(options),
                65 => ti_qstick_start(options),
                66 => ti_roc_start(options),
                67 => ti_rocr_start(options),
                68 => ti_round_start(options),
                69 => ti_rsi_start(options),
                70 => ti_sin_start(options),
                71 => ti_sinh_start(options),
                72 => ti_sma_start(options),
                73 => ti_sqrt_start(options),
                74 => ti_stddev_start(options),
                75 => ti_stderr_start(options),
                76 => ti_stoch_start(options),
                77 => ti_sub_start(options),
                78 => ti_sum_start(options),
                79 => ti_tan_start(options),
                80 => ti_tanh_start(options),
                81 => ti_tema_start(options),
                82 => ti_todeg_start(options),
                83 => ti_torad_start(options),
                84 => ti_tr_start(options),
                85 => ti_trima_start(options),
                86 => ti_trix_start(options),
                87 => ti_trunc_start(options),
                88 => ti_tsf_start(options),
                89 => ti_typprice_start(options),
                90 => ti_ultosc_start(options),
                91 => ti_var_start(options),
                92 => ti_vhf_start(options),
                93 => ti_vidya_start(options),
                94 => ti_volatility_start(options),
                95 => ti_vosc_start(options),
                96 => ti_vwma_start(options),
                97 => ti_wad_start(options),
                98 => ti_wcprice_start(options),
                99 => ti_wilders_start(options),
                100 => ti_willr_start(options),
                101 => ti_wma_start(options),
                102 => ti_zlema_start(options),
                _ => 1
            };

            return num;
        }
    }
}

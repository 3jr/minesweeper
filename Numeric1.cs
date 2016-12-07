
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JRapp
{
    public static partial class Numeric
    {
        public static void MinMax(out byte min, out byte max, params byte[] values)
        {
            min = Min(values);
            max = Max(values);
        }

        public static byte Clamp(byte value, byte bound1, byte bound2)
        {
            var lowLimit = bound1 < bound2 ? bound1 : bound2;
            var hightLimit = bound1 > bound2 ? bound1 : bound2;

            if (value < lowLimit)
                value = lowLimit;
            if (value > hightLimit)
                value = hightLimit;

            return value;
        }

        public static byte Max(params byte[] values)
        {
            byte max = values[0];

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max)
                    max = values[i];
            }

            return max;
        }

        public static bool UpdateToMax(ref byte update, params byte[] values)
        {
            bool changed = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > update)
                {
                    changed = true;
                    update = values[i];
                }
            }

            return changed;
        }

        public static bool UpdateToMin(ref byte update, params byte[] values)
        {
            bool changed = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < update)
                {
                    changed = true;
                    update = values[i];
                }
            }

            return changed;
        }

        public static byte Min(params byte[] values)
        {
            byte min = values[0];

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < min)
                    min = values[i];
            }

            return min;
        }


        public static void MinMax(out sbyte min, out sbyte max, params sbyte[] values)
        {
            min = Min(values);
            max = Max(values);
        }

        public static sbyte Clamp(sbyte value, sbyte bound1, sbyte bound2)
        {
            var lowLimit = bound1 < bound2 ? bound1 : bound2;
            var hightLimit = bound1 > bound2 ? bound1 : bound2;

            if (value < lowLimit)
                value = lowLimit;
            if (value > hightLimit)
                value = hightLimit;

            return value;
        }

        public static sbyte Max(params sbyte[] values)
        {
            sbyte max = values[0];

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max)
                    max = values[i];
            }

            return max;
        }

        public static bool UpdateToMax(ref sbyte update, params sbyte[] values)
        {
            bool changed = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > update)
                {
                    changed = true;
                    update = values[i];
                }
            }

            return changed;
        }

        public static bool UpdateToMin(ref sbyte update, params sbyte[] values)
        {
            bool changed = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < update)
                {
                    changed = true;
                    update = values[i];
                }
            }

            return changed;
        }

        public static sbyte Min(params sbyte[] values)
        {
            sbyte min = values[0];

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < min)
                    min = values[i];
            }

            return min;
        }


        public static void MinMax(out decimal min, out decimal max, params decimal[] values)
        {
            min = Min(values);
            max = Max(values);
        }

        public static decimal Clamp(decimal value, decimal bound1, decimal bound2)
        {
            var lowLimit = bound1 < bound2 ? bound1 : bound2;
            var hightLimit = bound1 > bound2 ? bound1 : bound2;

            if (value < lowLimit)
                value = lowLimit;
            if (value > hightLimit)
                value = hightLimit;

            return value;
        }

        public static decimal Max(params decimal[] values)
        {
            decimal max = values[0];

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max)
                    max = values[i];
            }

            return max;
        }

        public static bool UpdateToMax(ref decimal update, params decimal[] values)
        {
            bool changed = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > update)
                {
                    changed = true;
                    update = values[i];
                }
            }

            return changed;
        }

        public static bool UpdateToMin(ref decimal update, params decimal[] values)
        {
            bool changed = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < update)
                {
                    changed = true;
                    update = values[i];
                }
            }

            return changed;
        }

        public static decimal Min(params decimal[] values)
        {
            decimal min = values[0];

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < min)
                    min = values[i];
            }

            return min;
        }


        public static void MinMax(out double min, out double max, params double[] values)
        {
            min = Min(values);
            max = Max(values);
        }

        public static double Clamp(double value, double bound1, double bound2)
        {
            var lowLimit = bound1 < bound2 ? bound1 : bound2;
            var hightLimit = bound1 > bound2 ? bound1 : bound2;

            if (value < lowLimit)
                value = lowLimit;
            if (value > hightLimit)
                value = hightLimit;

            return value;
        }

        public static double Max(params double[] values)
        {
            double max = values[0];

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max)
                    max = values[i];
            }

            return max;
        }

        public static bool UpdateToMax(ref double update, params double[] values)
        {
            bool changed = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > update)
                {
                    changed = true;
                    update = values[i];
                }
            }

            return changed;
        }

        public static bool UpdateToMin(ref double update, params double[] values)
        {
            bool changed = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < update)
                {
                    changed = true;
                    update = values[i];
                }
            }

            return changed;
        }

        public static double Min(params double[] values)
        {
            double min = values[0];

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < min)
                    min = values[i];
            }

            return min;
        }


        public static void MinMax(out float min, out float max, params float[] values)
        {
            min = Min(values);
            max = Max(values);
        }

        public static float Clamp(float value, float bound1, float bound2)
        {
            var lowLimit = bound1 < bound2 ? bound1 : bound2;
            var hightLimit = bound1 > bound2 ? bound1 : bound2;

            if (value < lowLimit)
                value = lowLimit;
            if (value > hightLimit)
                value = hightLimit;

            return value;
        }

        public static float Max(params float[] values)
        {
            float max = values[0];

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max)
                    max = values[i];
            }

            return max;
        }

        public static bool UpdateToMax(ref float update, params float[] values)
        {
            bool changed = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > update)
                {
                    changed = true;
                    update = values[i];
                }
            }

            return changed;
        }

        public static bool UpdateToMin(ref float update, params float[] values)
        {
            bool changed = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < update)
                {
                    changed = true;
                    update = values[i];
                }
            }

            return changed;
        }

        public static float Min(params float[] values)
        {
            float min = values[0];

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < min)
                    min = values[i];
            }

            return min;
        }


        public static void MinMax(out int min, out int max, params int[] values)
        {
            min = Min(values);
            max = Max(values);
        }

        public static int Clamp(int value, int bound1, int bound2)
        {
            var lowLimit = bound1 < bound2 ? bound1 : bound2;
            var hightLimit = bound1 > bound2 ? bound1 : bound2;

            if (value < lowLimit)
                value = lowLimit;
            if (value > hightLimit)
                value = hightLimit;

            return value;
        }

        public static int Max(params int[] values)
        {
            int max = values[0];

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max)
                    max = values[i];
            }

            return max;
        }

        public static bool UpdateToMax(ref int update, params int[] values)
        {
            bool changed = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > update)
                {
                    changed = true;
                    update = values[i];
                }
            }

            return changed;
        }

        public static bool UpdateToMin(ref int update, params int[] values)
        {
            bool changed = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < update)
                {
                    changed = true;
                    update = values[i];
                }
            }

            return changed;
        }

        public static int Min(params int[] values)
        {
            int min = values[0];

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < min)
                    min = values[i];
            }

            return min;
        }


        public static void MinMax(out uint min, out uint max, params uint[] values)
        {
            min = Min(values);
            max = Max(values);
        }

        public static uint Clamp(uint value, uint bound1, uint bound2)
        {
            var lowLimit = bound1 < bound2 ? bound1 : bound2;
            var hightLimit = bound1 > bound2 ? bound1 : bound2;

            if (value < lowLimit)
                value = lowLimit;
            if (value > hightLimit)
                value = hightLimit;

            return value;
        }

        public static uint Max(params uint[] values)
        {
            uint max = values[0];

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max)
                    max = values[i];
            }

            return max;
        }

        public static bool UpdateToMax(ref uint update, params uint[] values)
        {
            bool changed = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > update)
                {
                    changed = true;
                    update = values[i];
                }
            }

            return changed;
        }

        public static bool UpdateToMin(ref uint update, params uint[] values)
        {
            bool changed = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < update)
                {
                    changed = true;
                    update = values[i];
                }
            }

            return changed;
        }

        public static uint Min(params uint[] values)
        {
            uint min = values[0];

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < min)
                    min = values[i];
            }

            return min;
        }


        public static void MinMax(out long min, out long max, params long[] values)
        {
            min = Min(values);
            max = Max(values);
        }

        public static long Clamp(long value, long bound1, long bound2)
        {
            var lowLimit = bound1 < bound2 ? bound1 : bound2;
            var hightLimit = bound1 > bound2 ? bound1 : bound2;

            if (value < lowLimit)
                value = lowLimit;
            if (value > hightLimit)
                value = hightLimit;

            return value;
        }

        public static long Max(params long[] values)
        {
            long max = values[0];

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max)
                    max = values[i];
            }

            return max;
        }

        public static bool UpdateToMax(ref long update, params long[] values)
        {
            bool changed = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > update)
                {
                    changed = true;
                    update = values[i];
                }
            }

            return changed;
        }

        public static bool UpdateToMin(ref long update, params long[] values)
        {
            bool changed = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < update)
                {
                    changed = true;
                    update = values[i];
                }
            }

            return changed;
        }

        public static long Min(params long[] values)
        {
            long min = values[0];

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < min)
                    min = values[i];
            }

            return min;
        }


        public static void MinMax(out ulong min, out ulong max, params ulong[] values)
        {
            min = Min(values);
            max = Max(values);
        }

        public static ulong Clamp(ulong value, ulong bound1, ulong bound2)
        {
            var lowLimit = bound1 < bound2 ? bound1 : bound2;
            var hightLimit = bound1 > bound2 ? bound1 : bound2;

            if (value < lowLimit)
                value = lowLimit;
            if (value > hightLimit)
                value = hightLimit;

            return value;
        }

        public static ulong Max(params ulong[] values)
        {
            ulong max = values[0];

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max)
                    max = values[i];
            }

            return max;
        }

        public static bool UpdateToMax(ref ulong update, params ulong[] values)
        {
            bool changed = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > update)
                {
                    changed = true;
                    update = values[i];
                }
            }

            return changed;
        }

        public static bool UpdateToMin(ref ulong update, params ulong[] values)
        {
            bool changed = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < update)
                {
                    changed = true;
                    update = values[i];
                }
            }

            return changed;
        }

        public static ulong Min(params ulong[] values)
        {
            ulong min = values[0];

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < min)
                    min = values[i];
            }

            return min;
        }


        public static void MinMax(out short min, out short max, params short[] values)
        {
            min = Min(values);
            max = Max(values);
        }

        public static short Clamp(short value, short bound1, short bound2)
        {
            var lowLimit = bound1 < bound2 ? bound1 : bound2;
            var hightLimit = bound1 > bound2 ? bound1 : bound2;

            if (value < lowLimit)
                value = lowLimit;
            if (value > hightLimit)
                value = hightLimit;

            return value;
        }

        public static short Max(params short[] values)
        {
            short max = values[0];

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max)
                    max = values[i];
            }

            return max;
        }

        public static bool UpdateToMax(ref short update, params short[] values)
        {
            bool changed = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > update)
                {
                    changed = true;
                    update = values[i];
                }
            }

            return changed;
        }

        public static bool UpdateToMin(ref short update, params short[] values)
        {
            bool changed = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < update)
                {
                    changed = true;
                    update = values[i];
                }
            }

            return changed;
        }

        public static short Min(params short[] values)
        {
            short min = values[0];

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < min)
                    min = values[i];
            }

            return min;
        }


        public static void MinMax(out ushort min, out ushort max, params ushort[] values)
        {
            min = Min(values);
            max = Max(values);
        }

        public static ushort Clamp(ushort value, ushort bound1, ushort bound2)
        {
            var lowLimit = bound1 < bound2 ? bound1 : bound2;
            var hightLimit = bound1 > bound2 ? bound1 : bound2;

            if (value < lowLimit)
                value = lowLimit;
            if (value > hightLimit)
                value = hightLimit;

            return value;
        }

        public static ushort Max(params ushort[] values)
        {
            ushort max = values[0];

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max)
                    max = values[i];
            }

            return max;
        }

        public static bool UpdateToMax(ref ushort update, params ushort[] values)
        {
            bool changed = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > update)
                {
                    changed = true;
                    update = values[i];
                }
            }

            return changed;
        }

        public static bool UpdateToMin(ref ushort update, params ushort[] values)
        {
            bool changed = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < update)
                {
                    changed = true;
                    update = values[i];
                }
            }

            return changed;
        }

        public static ushort Min(params ushort[] values)
        {
            ushort min = values[0];

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < min)
                    min = values[i];
            }

            return min;
        }


    }
}

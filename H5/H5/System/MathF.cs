namespace System
{
    [H5.Convention(Member = H5.ConventionMember.Field | H5.ConventionMember.Method, Notation = H5.Notation.CamelCase)]
    [H5.External]
    [H5.Name("Math")]
    public static class MathF
    {
        [H5.Convention]
        public const float E = 2.71828183f;

        [H5.Convention]
        public const float PI = 3.14159265f;

        public static extern float Abs(float x);
        public static extern float Acos(float x);
        public static extern float Asin(float x);
        public static extern float Atan(float x);
        public static extern float Atan2(float y, float x);

        [H5.Name("ceil")]
        public static extern float Ceiling(float x);

        public static extern float Cos(float x);

        [H5.Template("H5.Math.cosh({value})")]
        public static extern float Cosh(float value);

        public static extern float Exp(float x);

        [H5.Name("floor")]
        public static extern float Floor(float x);

        [H5.Template("H5.Math.IEEERemainder({x}, {y})")]
        public static extern float IEEERemainder(float x, float y);

        [H5.Template("H5.Math.log({x})")]
        public static extern float Log(float x);

        [H5.Template("H5.Math.logWithBase({x}, {y})")]
        public static extern float Log(float x, float y);

        [H5.Template("H5.Math.logWithBase({x}, 10.0)")]
        public static extern float Log10(float x);

        [H5.Template("H5.Math.logWithBase({x}, 2.0)")]
        public static extern float Log2(float x);

        public static extern float Max(float x, float y);
        public static extern float Min(float x, float y);

        public static extern float Pow(float x, float y);

        [H5.Template("H5.Math.round({x}, 0, 6)")]
        public static extern float Round(float x);

        [H5.Template("H5.Math.round({x}, {digits}, 6)")]
        public static extern float Round(float x, int digits);

        [H5.Template("H5.Math.round({x}, 0, {mode})")]
        public static extern float Round(float x, MidpointRounding mode);

        [H5.Template("H5.Math.round({x}, {digits}, {mode})")]
        public static extern float Round(float x, int digits, MidpointRounding mode);

        [H5.Template("H5.Int.sign({value})")]
        public static extern int Sign(float value);

        public static extern float Sin(float x);

        [H5.Template("H5.Math.sinh({value})")]
        public static extern float Sinh(float value);

        public static extern float Sqrt(float x);
        public static extern float Tan(float x);

        [H5.Template("H5.Math.tanh({value})")]
        public static extern float Tanh(float value);

        [H5.Template("H5.Int.trunc({d})")]
        public static extern float Truncate(float d);

        [H5.Template("((1.0 / {y}) < 0 ? -1.0 : 1.0) * System.Math.abs({x})")]
        public static extern float CopySign(float x, float y);

        public static float MaxMagnitude(float x, float y)
        {
            return (float)Math.MaxMagnitude(x, y);
        }

        public static float MinMagnitude(float x, float y)
        {
            return (float)Math.MinMagnitude(x, y);
        }

        [H5.Template("({x} * {y}) + {z}")]
        public static extern float FusedMultiplyAdd(float x, float y, float z);

        [H5.Template("1.0 / {x}")]
        public static extern float ReciprocalEstimate(float x);

        [H5.Template("1.0 / System.Math.sqrt({x})")]
        public static extern float ReciprocalSqrtEstimate(float x);

        public static float BitIncrement(float x)
        {
            if (float.IsNaN(x) || x == float.PositiveInfinity)
            {
                return x;
            }

            if (x == float.NegativeInfinity)
            {
                return float.MinValue;
            }

            if (x == 0.0f)
            {
                return float.Epsilon;
            }

            int bits = BitConverter.SingleToInt32Bits(x);

            if (bits < 0)
            {
                bits--;
            }
            else
            {
                bits++;
            }

            return BitConverter.Int32BitsToSingle(bits);
        }

        public static float BitDecrement(float x)
        {
            return -BitIncrement(-x);
        }

        public static float Clamp(float value, float min, float max)
        {
            return Math.Clamp(value, min, max);
        }
    }
}

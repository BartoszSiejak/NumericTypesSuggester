using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NumericTypesSuggester.NumericType
{

    public class NumericTypeFinder : INumericTypeFinder
    {
        public string FindOptimalNumericType(BigInteger min, BigInteger max, bool onlyIntegers = true, bool mustBePrecise = false)
        {
            string result;

            if (onlyIntegers)
            {
                result = GetIntegerType(min, max);
            }
            else
            {
                if (mustBePrecise)
                {
                    result = GetFloatingPreciseType(min, max);
                }
                else
                {
                    result = GetFloatingType(min, max);
                }

            }
            return result;
        }

        static string GetFloatingPreciseType(BigInteger min, BigInteger max)
        {
            var minDecimal = new BigInteger(decimal.MinValue);
            var maxDecimal = new BigInteger(decimal.MaxValue);

            if (min >= minDecimal && max <= maxDecimal)
            {
                return "decimal";
            }
            return "Impossible representation";
        }

        static string GetIntegerType(BigInteger min, BigInteger max)
        {

            if (min >= 0)
            {
                if (max <= byte.MaxValue)
                {
                    return "byte";
                }
                if (max <= ushort.MaxValue)
                {
                    return "ushort";
                }
                if (max <= uint.MaxValue)
                {
                    return "uint";
                }
                if (max <= ulong.MaxValue)
                {
                    return "ulong";
                }
            }

            if (min >= sbyte.MinValue && max <= sbyte.MaxValue)
            {
                return "sbyte";
            }
            if (min >= short.MinValue && max <= short.MaxValue)
            {
                return "short";
            }
            if (min >= int.MinValue && max <= int.MaxValue)
            {
                return "int";
            }
            if (min >= long.MinValue && max <= long.MaxValue)
            {
                return "long";
            }

            return "BigInteger";

        }

        static string GetFloatingType(BigInteger min, BigInteger max)
        {
            var minFloat = new BigInteger(float.MinValue);
            var maxFloat = new BigInteger(float.MaxValue);
            if (min >= minFloat && max <= maxFloat)
            {
                return "float";
            }

            var minDouble = new BigInteger(double.MinValue);
            var maxDouble = new BigInteger(double.MaxValue);
            if (min >= minDouble && max <= maxDouble)
            {
                return "double";
            }


            return "Impossible representation";

        }
    }
}

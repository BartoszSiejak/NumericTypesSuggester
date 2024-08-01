using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NumericTypesSuggester.Mapping
{
    public class RangeOfNumericTypesMapping
    {
        public readonly Dictionary<string, (BigInteger Min, BigInteger Max)> MinMaxValueOfTypes = new() {
            {"byte", (new BigInteger(byte.MinValue), new BigInteger(byte.MaxValue)) },
            {"ushort", (new BigInteger(ushort.MinValue), new BigInteger(ushort.MaxValue)) },
            {"uint", (new BigInteger(uint.MinValue), new BigInteger(uint.MaxValue)) },
            {"ulong", (new BigInteger(ulong.MinValue), new BigInteger(ulong.MaxValue)) },
            {"sbyte", (new BigInteger(sbyte.MinValue), new BigInteger(sbyte.MaxValue)) },
            {"short", (new BigInteger(short.MinValue), new BigInteger(short.MaxValue)) },
            {"int", (new BigInteger(int.MinValue), new BigInteger(int.MaxValue)) },
            {"long", (new BigInteger(long.MinValue), new BigInteger(long.MaxValue)) },
            {"float", (new BigInteger(float.MinValue), new BigInteger(float.MaxValue)) },
            {"double", (new BigInteger(double.MinValue), new BigInteger(double.MaxValue)) },
            {"decimal", (new BigInteger(decimal.MinValue), new BigInteger(decimal.MaxValue)) }
        };
    }
}

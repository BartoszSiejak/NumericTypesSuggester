using System.Numerics;

namespace NumericTypesSuggester.NumericType
{
    public interface INumericTypeFinder
    {
        string FindOptimalNumericType(BigInteger min, BigInteger max, bool onlyIntegers = true, bool mustBePrecise = false);
    }
}

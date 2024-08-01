using NumericTypesSuggester.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NumericTypesSuggester.NumericType
{
    public class NumericTypeFinder() : INumericTypeFinder
    {
        private readonly RangeOfNumericTypesMapping _mapOfNumericTypes = new();

        public string FindOptimalNumericType(BigInteger min, BigInteger max, bool onlyIntegers = true, bool mustBePrecise = false)
        {
            return onlyIntegers ? GetIntegerType(min, max) : GetFloatingType(min, max, mustBePrecise);
        }

        string GetIntegerType(BigInteger min, BigInteger max)
        {

            List<string> integerTypes = min >= 0 ? ["byte", "ushort", "uint", "ulong"] : ["sbyte", "short", "int", "long"];

            return GetOptimalTypeFromCollectionOrCustomString(integerTypes, min, max, "BigInteger");
        }


        string GetFloatingType(BigInteger min, BigInteger max, bool mustBePrecise)
        {
            if (mustBePrecise)
            {
                return GetOptimalTypeFromCollectionOrCustomString(["decimal"], min, max);
            }
            else
            {
                List<string> floatingTypes = ["float", "double"];
                return GetOptimalTypeFromCollectionOrCustomString(floatingTypes, min, max);
            }
        }

        string GetOptimalTypeFromCollectionOrCustomString(IEnumerable<string> types, BigInteger min, BigInteger max, string valueIfNothingMatch = "Impossible representation")
        {
            string? typeName = null;

            foreach (var type in types)
            {
                typeName = IsNumberInRange(min, max, type) ? type : null;

                if (typeName is not null)
                {
                    break;
                }
            }
            return typeName ?? valueIfNothingMatch;
        }

        bool IsNumberInRange(BigInteger minNumber, BigInteger maxNumber, string nameOfType)
        {
            if (minNumber > maxNumber)
            {
                throw new ArgumentException($"{nameof(maxNumber)} number must be larger than {nameof(minNumber)} !");
            }
            if (!_mapOfNumericTypes.MinMaxValueOfTypes.ContainsKey(nameOfType))
            {
                throw new ArgumentException($"Invalid {nameof(nameOfType)} argument.");
            }

            if (minNumber >= _mapOfNumericTypes.MinMaxValueOfTypes[nameOfType].Min && maxNumber <= _mapOfNumericTypes.MinMaxValueOfTypes[nameOfType].Max)
            {
                return true;
            }

            return false;
        }
    }
}
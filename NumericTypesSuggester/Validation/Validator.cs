﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NumericTypesSuggester.Validation
{

    public class Validator : IValidator
    {
        public bool IsValidInputChar(char keyChar, TextBox textBox)
        {
            {
                return char.IsControl(keyChar) ||
                    char.IsDigit(keyChar) ||
                    (char.Equals(keyChar, '-') && textBox.SelectionStart == 0);
            }
        }

        public bool IsValidNumberToConvert(string number)
        {
            return number != string.Empty && BigInteger.TryParse(number, out _);
        }
    }
}

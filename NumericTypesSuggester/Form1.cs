using System.CodeDom;
using System.Numerics;

namespace NumericTypesSuggester
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ChangeValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsValidValue(e.KeyChar, (TextBox)sender))
            {
                e.Handled = true;
            }
        }

        private bool IsValidValue(char keyChar, TextBox textBox)
        {
            {
                return char.IsControl(keyChar) ||
                    char.IsDigit(keyChar) ||
                    (char.Equals(keyChar, '-') && textBox.Text == string.Empty);
            }
        }

        private void ValueTextBox_TextChanged(object sender, EventArgs e)
        {
            GraphicalUserCommunicator.SetDefaultTextBoxColor(MaxValueTextBox);

            if (CanICompare())
            {
                var min = BigInteger.Parse(MinValueTextBox.Text);
                var max = BigInteger.Parse(MaxValueTextBox.Text);

                if (min > max)
                {
                    GraphicalUserCommunicator.SetWarningTextBoxColor(MaxValueTextBox);
                }
                else
                {
                    Compare(min, max, IntegralOnlyCheckBox.Checked, MustBePreciseCheckBox.Checked);
                }
            }
        }

        private bool CanICompare()
        {
            return MinValueTextBox.Text != string.Empty &&
                MinValueTextBox.Text != "-" &&
                MaxValueTextBox.Text != string.Empty &&
                MaxValueTextBox.Text != "-";
        }

        private void Compare(BigInteger min, BigInteger max, bool onlyIntegers, bool mustBePrecise)
        {
            var result = "";

            if (onlyIntegers)
            {
                result = TypesInfo.GetIntegerType(min, max);
            }
            else
            {
                if (mustBePrecise)
                {
                    result = TypesInfo.GetFloatingPreciseType(min, max);
                }
                else
                {
                    result = TypesInfo.GetFloatingType(min, max);
                }

            }

            ResultLabel.Text = $"Suggested type: {result}";
        }

        private void IntegralOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            if (IntegralOnlyCheckBox.Checked is false)
            {
                MustBePreciseCheckBox.Visible = true;
            }
            else
            {
                MustBePreciseCheckBox.Visible = false;
            }
        }
    }


}

public static class GraphicalUserCommunicator
{
    public static void SetDefaultTextBoxColor(TextBox textBox)
    {
        textBox.BackColor = Color.White;
    }

    public static void SetWarningTextBoxColor(TextBox textBox)
    {
        textBox.BackColor = Color.Red;
    }
}

public class TypesInfo
{
    public static string GetFloatingPreciseType(BigInteger min, BigInteger max)
    {
        var minDecimal = new BigInteger(decimal.MinValue);
        var maxDecimal = new BigInteger(decimal.MaxValue);
       
        if(min > minDecimal && max < maxDecimal )
        {
        return "decimal";
        }
            return "Impossible representation";
    }

    public static string GetIntegerType(BigInteger min, BigInteger max)
    {

        if (min >= 0)
        {
            if (max < byte.MaxValue)
            {
                return "byte";
            }
            if (max < ushort.MaxValue)
            {
                return "ushort";
            }
            if (max < uint.MaxValue)
            {
                return "uint";
            }
            if (max < ulong.MaxValue)
            {
                return "ulong";
            }
        }

        if (min > sbyte.MinValue && max < sbyte.MaxValue)
        {
            return "sbyte";
        }
        if (min > short.MinValue && max < short.MaxValue)
        {
            return "short";
        }
        if (min > int.MinValue && max < int.MaxValue)
        {
            return "int";
        }
        if (min > long.MinValue && max < long.MaxValue)
        {
            return "long";
        }

        return "BigInteger";

    }

    internal static string GetFloatingType(BigInteger min, BigInteger max)
    {
        var minFloat = new BigInteger(float.MinValue);
        var maxFloat = new BigInteger(float.MaxValue);
        if (min > minFloat && max < maxFloat)
        {
            return "float";
        }
        
        var minDouble = new BigInteger(double.MinValue);
        var maxDouble = new BigInteger(double.MaxValue);
        if (min > minDouble && max < maxDouble)
        {
            return "double";
        }


        return "Impossible representation";

    }
}
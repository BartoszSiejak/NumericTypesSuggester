using NumericTypesSuggester.NumericType;
using NumericTypesSuggester.UserCommunication;
using NumericTypesSuggester.Validation;
using System.CodeDom;
using System.Numerics;

namespace NumericTypesSuggester
{
    public partial class MainForm : Form
    {
        private readonly IUserCommunication _userCommunicator;
        private readonly IValidator _formValidation;
        private readonly INumericTypeFinder _numericTypeFinder;

        private BigInteger _minValue;
        private BigInteger _maxValue;

        public MainForm(IUserCommunication userCommunicator, IValidator formValidation, INumericTypeFinder numericTypeFinder)
        {
            InitializeComponent();
            _userCommunicator = userCommunicator;
            _formValidation = formValidation;
            _numericTypeFinder = numericTypeFinder;
        }

        private void ChangeValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!_formValidation.IsValidInputChar(e.KeyChar, (TextBox)sender))
            {
                e.Handled = true;
            }
            _userCommunicator.SetDefaultTextBoxColor(MaxValueTextBox);
        }

        private void ValueTextBox_TextChanged(object sender, EventArgs e)
        {
            LookTypeAfterChange();
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

            LookTypeAfterChange();
        }

        private void MustBePreciseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LookTypeAfterChange();
        }

        private void LookTypeAfterChange()
        {
            if (_formValidation.IsValidNumberToConvert(MinValueTextBox.Text) && _formValidation.IsValidNumberToConvert(MaxValueTextBox.Text))
            {
                _minValue = BigInteger.Parse(MinValueTextBox.Text);
                _maxValue = BigInteger.Parse(MaxValueTextBox.Text);

                if (_minValue > _maxValue)
                {
                    _userCommunicator.SetWarningTextBoxColor(MaxValueTextBox);
                    _userCommunicator.PrintMessage("not enough data", ResultLabel);
                }
                else
                {
                    var result = _numericTypeFinder.FindOptimalNumericType(_minValue, _maxValue, IntegralOnlyCheckBox.Checked, MustBePreciseCheckBox.Checked);
                    _userCommunicator.PrintMessage(result, ResultLabel);
                }
            }
            else
            {
                _userCommunicator.PrintMessage("not enough data", ResultLabel);
            }
        }
    }
}
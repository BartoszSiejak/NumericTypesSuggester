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
        }

        private void ValueTextBox_TextChanged(object sender, EventArgs e)
        {
            OnChangeNumber();
        }

        private void IntegralOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MustBePreciseCheckBox.Visible = !IntegralOnlyCheckBox.Checked;
            OnChangeNumber();
        }

        private void MustBePreciseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            OnChangeNumber();
        }

        private void OnChangeNumber()
        {
            if (_formValidation.IsValidNumberToConvert(MinValueTextBox.Text) && _formValidation.IsValidNumberToConvert(MaxValueTextBox.Text))
            {
                var minValue = BigInteger.Parse(MinValueTextBox.Text);
                var maxValue = BigInteger.Parse(MaxValueTextBox.Text);

                if (minValue > maxValue)
                {
                    _userCommunicator.SetWarningTextBoxColor(MaxValueTextBox);
                }
                else
                {
                    var result = _numericTypeFinder.FindOptimalNumericType(minValue, maxValue, IntegralOnlyCheckBox.Checked, MustBePreciseCheckBox.Checked);
                    _userCommunicator.PrintMessage(result, ResultLabel);
                    _userCommunicator.SetDefaultTextBoxColor(MaxValueTextBox);
                    return;
                }
            }

                _userCommunicator.PrintMessage("not enough data", ResultLabel);          
        }
    }
}
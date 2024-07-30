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
    }
}

namespace NumericTypesSuggester.UserCommunication
{
    public interface IUserCommunication
    {
        void PrintMessage(string message, Label label);
        void SetDefaultTextBoxColor(TextBox textBox);
        void SetWarningTextBoxColor(TextBox textBox);
    }
}

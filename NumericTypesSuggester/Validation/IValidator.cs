namespace NumericTypesSuggester.Validation
{
    public interface IValidator
    {
        bool IsValidInputChar(char keyChar, TextBox textBox);
        bool IsValidNumberToConvert(string number);
    }
}

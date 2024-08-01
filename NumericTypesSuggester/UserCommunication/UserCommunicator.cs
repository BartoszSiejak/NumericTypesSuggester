using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericTypesSuggester.UserCommunication
{

    public class UserCommunicator : IUserCommunication
    {
        public void SetDefaultTextBoxColor(TextBox textBox)
        {
            textBox.BackColor = Color.White;
        }

        public void SetWarningTextBoxColor(TextBox textBox)
        {
            textBox.BackColor = Color.Red;
        }

        public void PrintMessage(string message, Label label)
        {
            label.Text = "Suggested type: " + message;
        }

    }
}

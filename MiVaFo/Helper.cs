namespace MiVaFo
{
    public static class Helper
    {
        public static bool ShowUserQuestion(string question, string title, MessageBoxButtons buttons, MessageBoxIcon icon, bool isQuestion = true)
        {
            if (isQuestion)
            {
                DialogResult result = MessageBox.Show(
                    question,
                    title,
                    buttons,
                    icon);
                if (result == DialogResult.Yes)
                {
                    return true;
                }
                return false;
            }
            MessageBox.Show(question,
                    title,
                    buttons,
                    icon);
            return true;
        }
    }
}

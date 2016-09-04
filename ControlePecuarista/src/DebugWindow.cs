using System;
using System.Drawing;
using System.Windows.Forms;

namespace ControlePecuarista
{
    public partial class Debug : Form
    {

        private static Debug _instance = null;

        public static Debug instace
        {

            get
            {

                if (_instance == null)
                {
                    _instance = new Debug();
#if DEBUG
                    _instance.Visible = true;
#endif
                }
                return _instance;
            }
        }

        private Debug()
        {
            InitializeComponent();
        }

        private void appendText(string text, Color color, bool addNewLine = true)
        {

            if (addNewLine)
            {
                text += Environment.NewLine;
            }

            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.SelectionLength = 0;

            richTextBox1.SelectionColor = color;
            richTextBox1.AppendText(text);
            richTextBox1.SelectionColor = richTextBox1.ForeColor;
        }

        public void error(string text)
        {
            appendText("Error: " +text, Color.DarkRed);
        }

        public void danger(string text)
        {
            appendText("Danger: " + text, Color.DarkOrange);
        }

        public void nice(string text)
        {
            appendText("Nice: " + text, Color.DarkGreen);
        }

        public void log(string text)
        {
            appendText("Log: " + text, Color.Black);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }


}

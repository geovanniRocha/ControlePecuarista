using System;
using System.Drawing;
using System.Windows.Forms;


public partial class Debug : Form
{

    private static Debug _instance = null;

    public static Debug instance
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

    private static void appendText(string text, Color color, bool addNewLine = true)
    {
        if (addNewLine)
        {
            text += Environment.NewLine;
        }

        instance.richTextBox1.SelectionStart = instance.richTextBox1.TextLength;
        instance.richTextBox1.SelectionLength = 0;

        instance.richTextBox1.SelectionColor = color;
        instance.richTextBox1.AppendText(text);
        instance.richTextBox1.SelectionColor = instance.richTextBox1.ForeColor;
    }

    [System.Diagnostics.Conditional("DEBUG")]
    public static void error(string text)
    {
        Debug.appendText("Error: " + text, Color.DarkRed);
    }

    [System.Diagnostics.Conditional("DEBUG")]
    public static void danger(string text)
    {
        appendText("Danger: " + text, Color.DarkOrange);
    }

    [System.Diagnostics.Conditional("DEBUG")]
    public static void nice(string text)
    {
        appendText("Nice: " + text, Color.DarkGreen);
    }

    [System.Diagnostics.Conditional("DEBUG")]
    public static void log(string text)
    {
        appendText("Log: " + text, Color.Black);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        instance.richTextBox1.Clear();
    }
}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator2
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (screen.Text.Contains("="))
            {
                screen.Text = "";
            }
            screen.Text = screen.Text + btn.Content;
        }
        
        public void Equals_Click(object sender, EventArgs e)
        {
            try
            {
                Calculate();
            }
            catch (Exception)
            {
                screen.Text = "Syntax Error";
            }
        }
        public void Backspace_Click(object sender, EventArgs e)
        {
            if (screen.Text != "")
            {
                screen.Text = screen.Text.Remove(screen.Text.Length - 1);
            }
            if (screen.Text.Contains("=")) {
                screen.Text = "";
            }
            if (screen.Text.Contains('E'))//so backspace clears after error messages
            {
                screen.Text = "";
            }
        }
        public void Clear_Click(object sender, EventArgs e)
        {
            screen.Text = "";
        }

        private void Calculate()
        {
            String op;
            int iOp = 0;
            if (screen.Text.Contains("+"))
            {
                iOp = screen.Text.IndexOf("+");
            }
            else if (screen.Text.Contains("-"))
            {
                iOp = screen.Text.IndexOf("-");
            }
            else if (screen.Text.Contains("*"))
            {
                iOp = screen.Text.IndexOf("*");
            }
            else if (screen.Text.Contains("/"))
            {
                iOp = screen.Text.IndexOf("/");
            }
            else
            {
                screen.Text = "Error";
            }

            op = screen.Text.Substring(iOp, 1);
            double op1 = Convert.ToDouble(screen.Text.Substring(0, iOp));
            double op2 = Convert.ToDouble(screen.Text.Substring(iOp + 1, screen.Text.Length - iOp -1));

            if (op == "+") //can only do math between one operator and two numbers
            {
                screen.Text += "=" + (op1 +op2);
            }
            else if (op == "-")
            {
                screen.Text += "=" + (op1 - op2);
            }
            else if (op == "*")
            {
                screen.Text += "=" + (op1 * op2);
            }
            else if (op == "/")
            {
                screen.Text += "=" + (op1 / op2);
            }
        }
    }
}





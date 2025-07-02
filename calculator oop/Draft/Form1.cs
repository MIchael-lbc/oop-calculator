using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Draft
{
    public partial class Form1 : Form
    {
            public Form1()
            {
                InitializeComponent();
            }

            // Handles number and decimal buttons
            private void pressed(object sender, EventArgs e)
            {
                Button button = (Button)sender;
                if (textBox1.Text == "0") textBox1.Text = ""; // Avoid starting with 0
                textBox1.Text += button.Text;
            }

            // Handles operator buttons (+, -, x, /)
            private void operation(object sender, EventArgs e)
            {
                Button button = (Button)sender;
                string op = button.Text;
                if (op == "x") op = "*"; // Replace 'x' with '*' for Compute
                textBox1.Text += op;
            }

        // Evaluate the full expression
        private void clickequal(object sender, EventArgs e)
        {
            try
            {
                string expression = textBox1.Text.Replace("x", "*"); // Just in case
                var result = new DataTable().Compute(expression, null);
                textBox1.Text = result.ToString();
            }
            catch
            {
                MessageBox.Show("Invalid expression!");
            }
        }
        

        // Clear all
        private void zerovalue(object sender, EventArgs e)
            {
                textBox1.Text = "";
            }

            // Backspace
            private void backspace(object sender, EventArgs e)
            {
                if (textBox1.Text.Length > 0)
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);

                if (textBox1.Text == "")
                    textBox1.Text = "0";
            }

            // Pi button
            private void PI(object sender, EventArgs e)
            {
                textBox1.Text += Math.PI.ToString();
            }
            // Sin function (input in radians)
            private void sinfunction(object sender, EventArgs e)
            {
                try
                {
                    double value = double.Parse(textBox1.Text);
                    textBox1.Text = Math.Sin(value).ToString();
                }
                catch
                {
                    MessageBox.Show("Please enter a valid number first.");
                }
            }

            // Cos function (input in radians)
            private void cosfunction(object sender, EventArgs e)
            {
                try
                {
                    double value = double.Parse(textBox1.Text);
                    textBox1.Text = Math.Cos(value).ToString();
                }
                catch
                {
                    MessageBox.Show("Please enter a valid number first.");
                }
            }

            // Tan function (input in radians)
            private void tanfunction(object sender, EventArgs e)
            {
                try
                {
                    double value = double.Parse(textBox1.Text);
                    textBox1.Text = Math.Tan(value).ToString();
                }
                catch
                {
                    MessageBox.Show("Please enter a valid number first.");
                }
            }
        
    }
}





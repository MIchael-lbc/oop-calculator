using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Final_calc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //adds buttons, textbox, event handlers to make the desgin of the calc
            InitializeComponent();
        }

        // Handles number and decimal buttons
        //this function is Called when a number or decimal point is pressed or click on it
        private void pressed(object sender, EventArgs e)
        //sender: the object that make the event
        //EventArgs: the data that is sent with the event or for any extra informations
        //e: carries event data
        {
            Button button = (Button)sender;
            if (textBox1.Text == "0") textBox1.Text = ""; // when textBox1 has "0", it’s cleared to avoid something like "02".
            textBox1.Text += button.Text; //+:used for concatenation 
        }

        // Handles operator buttons (+, -, x, /)
        private void operation(object sender, EventArgs e)
        {
            Button button = (Button)sender; // cast sender to Button
            string op = button.Text; // take or get the text from button
            if (op == "x") op = "*"; // Replace 'x' with '*' for Compute
            textBox1.Text += op;
        }

        private void clickequal(object sender, EventArgs e)
        {
            try
            {
                string expression = textBox1.Text.Replace("x", "*"); // Just in case
                var result = new DataTable().Compute(expression, null); // we use this expression (DataTable.Compute()) to evaluate math expressions as strings.
                //var:it is used to declare a variable,we used it as it automaticly knows the data type of the variable as integer or double 
                //new:to make or create object 
                textBox1.Text = result.ToString();
            }
            catch
            {
                MessageBox.Show("Invalid expression!");
            }
        }
        // Clear all Actions
        private void zerovalue(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        // Backspace
        private void backspace(object sender, EventArgs e)
        {
            //textBox1.Text: it is used to get or set the text in the textbox
            if (textBox1.Text.Length > 0) //textBox1.Text.Length:tells how many characters are in the current string.
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1); // It removes only the last character from the string.
            //(textBox1.Text.Length - 1) gives me the index of the last character.

            if (textBox1.Text == "") //Deletes the last character from the textbox.
                textBox1.Text = "0"; // If the textbox is empty, it sets the text to "0".
        }

        // Pi button
        private void PI(object sender, EventArgs e)
        {
            textBox1.Text += Math.PI.ToString(); // Adds the value of pi to the textbox.
        }
        // Sin function (the output values in radians)
        private void sinfunction(object sender, EventArgs e)
        {
            try
            {
                //	double.Parse(textBox1.Text):This converts a string from the text box (for example"3.14") into a real number of type double,it is built in function
                double value = double.Parse(textBox1.Text);
                textBox1.Text = Math.Sin(value).ToString();
                //ToString(): convert the number to a string

            }
            catch
            {
                MessageBox.Show("Please enter a valid number first.");
            }
        }

        // Cos function (the output values in radians)
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

        // Tan function (the output values in radians)
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
        //it connects the calculator to a graphing feature.
        private void graph_Click(object sender, EventArgs e)
        {
            GraphForm graphForm = new GraphForm();  //WE Create the new graph window
            graphForm.Show();                       //then after that Show it
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

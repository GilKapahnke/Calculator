using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        char last_operator = ' ';
        double solution = 0;
        double number_input = 0;

        public Form1()
        {
            InitializeComponent();
            DisableOperators();
        }

        #region Enable/Disable Operators
        public void DisableOperators()
        {
            button_add.Enabled = false;
            button_subtract.Enabled = false;
            button_multiply.Enabled = false;
            button_divide.Enabled = false;
            button_point.Enabled = false;
        }

        public void EnableOperators()
        {
            button_add.Enabled = true;
            button_subtract.Enabled = true;
            button_multiply.Enabled = true;
            button_divide.Enabled = true;
            button_point.Enabled = true;
        }
        #endregion

        #region ButtonsClicks
        private void NumberClick(object sender, EventArgs e)
        {
            input_text.Text += (sender as Button).Text;
            EnableOperators();
        }

        private void OperatorClick(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(input_text.Text))) //if there is a number inside input_text
            {
                number_input = Convert.ToDouble(input_text.Text);
                last_operator = Convert.ToChar((sender as Button).Text);
                DisableOperators();
                Evaluate();
            }
        }
        #endregion

        private void button_equals_Click(object sender, EventArgs e)
        {
            Evaluate();
        }

        private void Evaluate()
        {
            switch (last_operator)
            {
                case '+':
                    solution += Convert.ToDouble(number_input);
                    label_result.Text = Convert.ToString(solution);
                    break;

                case '-':
                    solution -= Convert.ToDouble(number_input);
                    label_result.Text = Convert.ToString(solution);
                    break;

                case '*':
                    solution *= Convert.ToDouble(number_input);
                    label_result.Text = Convert.ToString(solution);
                    break;

                case '/':
                    solution /= Convert.ToDouble(number_input);
                    label_result.Text = Convert.ToString(solution);
                    break;
            }
            input_text.Clear();
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            input_text.Clear();
            solution = 0;
        }

        private void button_clear_entire_Click(object sender, EventArgs e)
        {
            input_text.Clear();
            label_result.Text = "0";
            solution = 0;
        }

        private void button_faculty_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(input_text.Text)))
            {
                int faculty = 1;
                for (int i = 1; i <= Convert.ToInt32(input_text.Text); i++)
                {
                    faculty *= i;
                }
                label_result.Text = Convert.ToString(faculty);
            }
        }

        private void button_squareroot_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(input_text.Text)))
            {
                label_result.Text = Convert.ToString(Math.Sqrt(Convert.ToInt32(input_text.Text)));
            }
        }

        private void button_square_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(input_text.Text)))
            {
                int square = Convert.ToInt32(input_text.Text);
                label_result.Text = Convert.ToString(square * square);
            }
        }

        private void button_pow_three_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(input_text.Text)))
            {
                int tripple = Convert.ToInt32(input_text.Text);
                label_result.Text = Convert.ToString(tripple * tripple * tripple);
            }
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            input_text.Text = input_text.Text.Remove(input_text.Text.Length - 1);
        }
    }
}

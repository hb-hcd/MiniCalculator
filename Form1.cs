using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniCalculator
{
    public partial class Form1 : Form
    {

        Double resultValue = 0;
        String operationPerformed = "";
        bool isPerformed = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if ( textBox_Result.Text == "0" || isPerformed )
            {
                textBox_Result.Clear();

            }
            isPerformed = false;
            if ( btn.Text == "." )
            {
                if ( !textBox_Result.Text.Contains(".") )
                {
                    textBox_Result.Text += btn.Text;
                }
            }
            else
            {
                textBox_Result.Text += btn.Text;
            }

        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if ( resultValue != 0 )
            {
                btnEql.PerformClick();
            }
            operationPerformed = btn.Text;
            resultValue = Double.Parse(textBox_Result.Text);
            CurrentOperation.Text = resultValue + " " + operationPerformed;
            isPerformed = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            resultValue = 0;
            CurrentOperation.Text = "";
        }

        private void btnEql_Click(object sender, EventArgs e)
        {
            CurrentOperation.Text += " " + textBox_Result.Text;
            switch ( operationPerformed )
            {
                case "+":
                    textBox_Result.Text = ( resultValue + Double.Parse(textBox_Result.Text) ).ToString();
                    break;
                case "-":
                    textBox_Result.Text = ( resultValue - Double.Parse(textBox_Result.Text) ).ToString();
                    break;
                case "x":
                    textBox_Result.Text = ( resultValue * Double.Parse(textBox_Result.Text) ).ToString();
                    break;
                case "/":
                    textBox_Result.Text = ( resultValue / Double.Parse(textBox_Result.Text) ).ToString();
                    break;
                default:
                    break;
            }
            resultValue = Double.Parse(textBox_Result.Text);
            operationPerformed = "";
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            CurrentOperation.Text = "";
            resultValue = 0;
        }

        private void btnBIN_Click(object sender, EventArgs e)
        {
            try
            {
                int value = int.Parse(textBox_Result.Text);
                if ( value > Int32.MinValue && value < Int32.MaxValue )
                {
                    textBox_Result.Text = Convert.ToString(value, 2).ToString();
                }
            }
            catch ( Exception ex )
            {
                MessageBox.Show("The input value is too large");
            }

        }

        private void btnDEC_Click(object sender, EventArgs e)
        {
            try
            {
                textBox_Result.Text = Convert.ToInt32(textBox_Result.Text, 2).ToString();
            }
            catch ( Exception ex )
            {
                MessageBox.Show("The input number can only contain '0' or '1'");
            }

        }
    }
}

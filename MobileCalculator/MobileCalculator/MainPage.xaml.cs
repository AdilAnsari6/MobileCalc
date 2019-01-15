using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileCalculator
{
    public enum Operator
    {
        PLUS,
        MINUS,
        MULTIPLY,
        DIVIDE,
        NONE,
    }
    public partial class MainPage : ContentPage
    {
        private double sum = 0;
        private Operator op = Operator.NONE;
        private double num1, num2;
        private bool operating = false;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if ("0123456789".Contains(b.Text))
            {
                if("+-*/".Contains(display.Text))
                {
                    display.Text = "";
                }
                display.Text += b.Text;
            }
            else if ("+-*/".Contains(b.Text))
            {
                if (display.Text != "")
                {
                    if(!operating)
                    {
                        num1 = Convert.ToInt32(display.Text);
                    }
                    else if (operating)
                    {
                        SumUp();
                        num1 = sum;
                    }
                    display.Text = "";
                    if (b.Text.Equals("+"))
                    {
                        op = Operator.PLUS;
                    }
                    if (b.Text.Equals("-"))
                    {
                        op = Operator.MINUS;
                    }
                    if (b.Text.Equals("*"))
                    {
                        op = Operator.MULTIPLY;
                    }
                    if (b.Text.Equals("/"))
                    {
                        op = Operator.DIVIDE;
                    }
                    operating = true;
                    display.Text = b.Text;
                }
            }
            else if (b.Text.Equals("Del"))
            {
                if (display.Text != "")
                {
                    display.Text = display.Text.Substring(0, display.Text.Length - 1);
                }

            }
            else if (b.Text.Equals("C"))
            {
                num1 = 0;
                num2 = 0;
                sum = 0;
                display.Text = "";
            }
            else if (b.Text.Equals("="))
            {
                if (display.Text != "")
                {
                    SumUp();
                    display.Text = sum + "";
                    operating = false;
                }
            }
        }
        public void SumUp()
        {
            num2 = Convert.ToInt32(display.Text);
            switch (op)
            {
                case Operator.PLUS:
                    {
                        sum = num1 + num2;
                        return;
                    }
                case Operator.MINUS:
                    {
                        sum = num1 - num2;
                        return;
                    }
                case Operator.MULTIPLY:
                    {
                        sum = num1 * num2;
                        return;
                    }
                case Operator.DIVIDE:
                    {
                        sum = num1 / num2;
                        return;
                    }
                case Operator.NONE:
                    {
                        return;
                    }
            }
            num1 = 0;
            num2 = 0;
        }
    }
}

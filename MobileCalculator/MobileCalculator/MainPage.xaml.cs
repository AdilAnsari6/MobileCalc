using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileCalculator
{
    public partial class MainPage : ContentPage
    {
        int num = 0;
        int sum;
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if ("0123456789".Contains(b.Text))
            {
                display.Text += b.Text;
            }
            else if ("+-*/".Contains(b.Text))
            {
                if(b.Text.Equals("+"))
                {
                    sum += Convert.ToInt32(display.Text);
                    display.Text = b.Text;
                }
                if (b.Text.Equals("-"))
                {
                    sum -= Convert.ToInt32(display.Text);
                }
                if (b.Text.Equals("*"))
                {
                    sum *= Convert.ToInt32(display.Text);
                }
                if (b.Text.Equals("/"))
                {
                    sum /= Convert.ToInt32(display.Text);
                }
            }
            else if (b.Text.Equals("Del"))
            {
                if(display.Text!="")
                display.Text = display.Text.Substring(0, display.Text.Length - 1);
            }
        }
    }
}

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
    public enum State
    {
        WaitingForFirstNumber,
        WaitingForSecondNumber,
        WaitingForOperation,
        WaitingForResult,
    }
    public enum Operation
    {
        None,
        Plus,
        Minus,
        Divide,
        Product,
        Sqrt,


    }

    public partial class Form1 : Form
    {
        Model.BaseCalculator caclulator = new Model.BaseCalculator();

        public Form1()
        {
            InitializeComponent();
        }

        private void pad_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch (caclulator.currentState)
            {
                case State.WaitingForFirstNumber:
                    caclulator.currentState = State.WaitingForOperation;
                    break;
                case State.WaitingForSecondNumber:
                    caclulator.currentState = State.WaitingForResult;
                    display.Text = "";
                    break;
            }

            display.Text += btn.Text;

        }

        private void operation_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;


            caclulator.firstNumber = double.Parse(display.Text);
            caclulator.currentState = State.WaitingForSecondNumber;

            switch (btn.Text)
            {
                case "+":
                    caclulator.operation = Operation.Plus;
                    break;
                case "-":
                    caclulator.operation = Operation.Minus;
                    break;
                case "*":
                    caclulator.operation = Operation.Product;
                    break;
                case "sqrt":
                    caclulator.operation = Operation.Sqrt;
                    break;




            }
        }

        private void result_Click(object sender, EventArgs e)
        {
            display.Text = caclulator.Evaluate(display.Text);
        }
    }
}


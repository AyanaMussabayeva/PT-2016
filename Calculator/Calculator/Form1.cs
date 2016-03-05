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
        Percent,
        Inverse,
        C,
        CE,

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
            if (display.Text == "0")
                display.Clear();

          
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
            if (btn.Text == ",")
            {
                if (!display.Text.Contains(","))
                    display.Text += btn.Text;
            }
            else
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
                case "%":
                    caclulator.operation = Operation.Percent;
                    break;
                case "1/x":
                    caclulator.operation = Operation.Inverse;
                    break;
                case "C":
                    caclulator.operation = Operation.C;
                    break;


            }
        }

        private void operationClear_Click(object sender, EventArgs e)
        {
            Button operationClearButton = sender as Button;
            string operationClear = operationClearButton.Text;

            switch (operationClear)
            {
                case "C":
                    caclulator.operation = Operation.C;
                    display.Text = "0";
                    break;
                case "CE":
                    display.Text = "0";
                    break;
            }
        }
        private void operationMemory_Click(object sender, EventArgs e)
        {
            Button operationMemoryButton = sender as Button;
            string operationMemory = operationMemoryButton.Text;
            double memoryNumber = 0;

            switch (operationMemory)
            {
                case "MC":
                    memoryNumber = 0;
                    break;
                case "MR":
                    display.Text = memoryNumber.ToString();
                    break;
                case "MS":
                    memoryNumber = double.Parse(display.Text);
                    break;
                case "M+":
                    memoryNumber = memoryNumber + Double.Parse(display.Text);
                    break;
            }
            memoryBox.Text = memoryNumber.ToString();
        }
        private void memory_TextChanged(object sender, EventArgs e)
        {

        }

        private void result_Click(object sender, EventArgs e)
        {
            display.Text = caclulator.Evaluate(display.Text);
        }

        private void display_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}


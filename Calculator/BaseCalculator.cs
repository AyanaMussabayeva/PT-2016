using System;

namespace Calculator.Model
{
    public class BaseCalculator
    {
        public double firstNumber = 0;
        public double secondNumber = 0;
        public double resultNumber = 0;
        public State currentState = State.WaitingForFirstNumber;
        public Operation operation = Operation.None;

        public string Evaluate(string text)
        {
            secondNumber = double.Parse(text);
            currentState = State.WaitingForFirstNumber;

            switch (operation)
            {
                case Operation.None:
                    break;
                case Operation.Plus:
                    resultNumber = firstNumber + secondNumber;
                    break;
                case Operation.Minus:
                    resultNumber = firstNumber - secondNumber;
                    break;
                case Operation.Divide:
                    break;
                default:
                    break;
            }

            return resultNumber.ToString();
        }
    }
}


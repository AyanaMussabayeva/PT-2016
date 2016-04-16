using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
        public class BaseCalculator
        {
            public double firstNumber = 0;
            public double secondNumber = 0;
            public double resultNumber = 0;
            public State currentState = State.WaitingForFirstNumber;
            public Operation operation = Operation.None;
            //public OperationClear operationclear = OperationClear.None;

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
                        resultNumber = firstNumber / secondNumber;
                        break;
                    case Operation.Product:
                        resultNumber = firstNumber * secondNumber;
                        break;
                    case Operation.Plusminus:
                        resultNumber = -resultNumber;
                         break;
                       
                       
                     default:
                        break;
                case Operation.C:
                    resultNumber = 0;
                    firstNumber = 0;
                    secondNumber = 0;
                    break;

                  

            }


            return resultNumber.ToString();
            }
        }
    
}
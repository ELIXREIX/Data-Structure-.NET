using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackTest
{
    public class Program
    {
        public static double EvaluatePostfix(string postfixExpression)
        {
            ArrayStack stack = new ArrayStack(postfixExpression.Length);

            foreach (char c in postfixExpression)
            {
                if (char.IsDigit(c))
                {
                    // If the character is a digit, push it onto the stack
                    stack.push(double.Parse(c.ToString()));
                }
                else if (c == '+')
                {
                    // If it's a '+', pop the top two numbers, add them, and push the result back onto the stack
                    double operand2 = (double)stack.pop();
                    double operand1 = (double)stack.pop();
                    stack.push(operand1 + operand2);
                }
                else if (c == '-')
                {
                    // If it's a '-', pop the top two numbers, subtract them, and push the result back onto the stack
                    double operand2 = (double)stack.pop();
                    double operand1 = (double)stack.pop();
                    stack.push(operand1 - operand2);
                }
                // You can add support for '*' and '/' here in a similar fashion
            }

            // At the end, the result will be at the top of the stack
            return (double)stack.pop();
        }

        public static void Main(string[] args)
        {
            string postfixExpression = "12+3+4-"; // Postfix notation of {(1+2)+3-4}
            double result = EvaluatePostfix(postfixExpression);
            Console.WriteLine($"Result of the expression: {result}");
        }
    }
}


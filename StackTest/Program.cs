using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackTest
{
    public class Program
    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        static void Main()
        {
            Console.Write("Enter an infix expression: ");
            string infixExpression = Console.ReadLine();

            if (IsExpressionValid(infixExpression))
            {
                string postfixExpression = InfixToPostfix(infixExpression);
                Console.WriteLine("Infix Expression: " + infixExpression);
                Console.WriteLine("Postfix Expression: " + postfixExpression);
            }
            else
            {
                Console.WriteLine("Mismatched or incorrectly ordered parentheses or curly braces in the input expression. Skipping conversion.");
            }
        }

        static bool IsExpressionValid(string expression)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in expression)
            {
                if (c == '(' || c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == '}')
                {
                    if (stack.Count == 0)
                    {
                        return false; // Mismatched closing parentheses or curly braces
                    }
                    char top = stack.Pop();
                    if ((c == ')' && top != '(') || (c == '}' && top != '{'))
                    {
                        return false; // Incorrectly ordered parentheses or curly braces
                    }
                }
            }

            return stack.Count == 0; // Ensure all parentheses and curly braces are balanced and correctly ordered
        }

        static string InfixToPostfix(string infixExpression)
        {
            string postfixExpression = "";
            ArrayStack operatorStack = new ArrayStack(infixExpression.Length);

            foreach (char c in infixExpression)
            {
                if (char.IsDigit(c))
                {
                    postfixExpression += c;
                }
                else if (c == '+' || c == '-')
                {
                    while (!operatorStack.isEmpty() && ((char)operatorStack.peek() == '+' || (char)operatorStack.peek() == '-'))
                    {
                        postfixExpression += operatorStack.pop();
                    }
                    operatorStack.push(c);
                }
                else if (c == '(')
                {
                    operatorStack.push(c);
                }
                else if (c == ')')
                {
                    while (!operatorStack.isEmpty() && (char)operatorStack.peek() != '(')
                    {
                        postfixExpression += operatorStack.pop();
                    }
                    if (!operatorStack.isEmpty() && (char)operatorStack.peek() == '(')
                    {
                        operatorStack.pop(); // Pop the '('
                    }
                    else
                    {
                        throw new Exception("Mismatched parentheses.");
                    }
                }
            }

            while (!operatorStack.isEmpty())
            {
                if ((char)operatorStack.peek() == '(' || (char)operatorStack.peek() == ')')
                {
                    throw new Exception("Mismatched parentheses.");
                }
                postfixExpression += operatorStack.pop();
            }

            return postfixExpression;
=======
=======
>>>>>>> 97e79c2991e63628b49768c9ab34c954d7982446
=======
>>>>>>> 97e79c2991e63628b49768c9ab34c954d7982446
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
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> 97e79c2991e63628b49768c9ab34c954d7982446
=======
>>>>>>> 97e79c2991e63628b49768c9ab34c954d7982446
=======
>>>>>>> 97e79c2991e63628b49768c9ab34c954d7982446
        }
    }
}

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> 97e79c2991e63628b49768c9ab34c954d7982446
=======
>>>>>>> 97e79c2991e63628b49768c9ab34c954d7982446
=======
>>>>>>> 97e79c2991e63628b49768c9ab34c954d7982446

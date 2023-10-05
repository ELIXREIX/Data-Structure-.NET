using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackTest
{
    public class Program
    {
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
        }
    }
}



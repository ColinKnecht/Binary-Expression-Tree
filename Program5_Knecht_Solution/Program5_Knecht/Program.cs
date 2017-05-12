using System;

namespace BinaryTreeDemo
{
    class Program
    {
        //Colin Knecht -- Program 5
        static void Main(string[] args)
        {
            string expression = "((3 * (8 - 2)) - (1 + 9))";
            //string expr1 = "((3+4)*(8+2))";
 
            string MENU = "Please Type in an expression to evaluate (Please include parentheses!!)\n" +
                "Press (q) to quit";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(MENU);
            string expressionKey = Console.ReadLine();
            
            while (expressionKey != "q" && expressionKey != "Q")
            {
                BinaryExpressionTree bet = new BinaryExpressionTree(expressionKey);
                Console.Write("Infix: ");
                bet.DisplayInOrder();
                bet.Eval();
                Console.Write("Postfix: ");
                bet.DisplayPostOrder();
                Console.Write("Prefix: ");
                bet.DisplayPreOrder();
                Console.WriteLine("{0} = {1}", bet.Expression, bet.Eval());


                Console.WriteLine(MENU);
                expressionKey = Console.ReadLine();
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("==========Program Terminated=============");
            Console.ReadLine();
        }
    }
}

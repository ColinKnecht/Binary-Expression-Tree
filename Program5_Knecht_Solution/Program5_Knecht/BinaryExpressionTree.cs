using System;
using System.Collections.Generic;

namespace BinaryTreeDemo
{
    class BinaryExpressionTree
    {
        //Colin Knecht -- Program 5
        public int Count { get; set; }
        public BinaryNode<char> RootNode;
        public string Expression { get; private set; }

        public BinaryExpressionTree(String expression)
        {
            this.Expression = expression;
            // get rid of the pesky spaces
            expression = expression.Replace(" ", "");
            Console.WriteLine(expression);
            Queue<char> expr = new Queue<char>(expression.ToCharArray());
            //RootNode = Parse(expr);
            RootNode = ParseWhile(expr);
        }

        public BinaryNode<char> Parse(Queue<char> expressionQueue)
        {
            BinaryNode<char> myNode = new BinaryNode<char>();
            char nextChar;

            // consume the paren, throw it away
            expressionQueue.Dequeue();
            // get the next character
            nextChar = expressionQueue.Dequeue();//peek
            // possibilities are left paren or value
            if (nextChar == '(')
            {
                // TODO -- action if left side is an expression
                //parse
                nextChar = expressionQueue.Dequeue(); //colin
            }
            else
            {
                // TODO -- action if left side is a value
                //numbersQ.Enqueue(nextChar);
                // TODO -- don't forget to consume the value
                nextChar = expressionQueue.Dequeue();
            }

            // should be at operand
            // TODO -- deal with the operand
            //operatorStk.Push(nextChar);
            

            // TODO -- consume the operator
            nextChar = expressionQueue.Dequeue();
            // possibilities are left paren or value
            // TODO -- get nextChar
            if (nextChar == '(')
            {
                // TODO -- action if left side is an expression
                expressionQueue.Dequeue();
            }
            else
            {
                // TODO -- action if left side is a value
                //numbersQ.Enqueue(nextChar);
                // TODO -- don't forget to consume the value
                nextChar = expressionQueue.Dequeue();
            }
            // consume the right paren, throw it away
            myNode.item = expressionQueue.Dequeue();
            //myNode = expressionQueue.Dequeue(); //colin
            //char c = expressionQueue.Dequeue();
            

            //expressionQueue.Dequeue(); //orig
            return myNode;
        }

        public BinaryNode<char> ParseLoop(Queue<char> expressionQueue)
        {
            BinaryNode<char> myNode = new BinaryNode<char>();
            char nextChar;

            return myNode;
        }

        public BinaryNode<char> ParseWhile(Queue<char> expressionQueue)
        {
            Stack<BinaryNode<char>> nodeStack = new Stack<BinaryNode<char>>();
            BinaryNode<char> currentNode = null;
            BinaryNode<char> childNode = null;
            BinaryNode<char> rootNode = null;

            while (expressionQueue.Count > 0)
            {
                char token = expressionQueue.Dequeue();
                switch (token)
                {
                    case ('('):
                        if (currentNode != null)
                        {
                            //currentNode.push
                            nodeStack.Push(currentNode);
                        }
                        //current node = new node
                        currentNode = new BinaryNode<char>();
                        break;
                    case (')'):
                        if (nodeStack.Count > 0)
                        {
                            childNode = currentNode;
                            currentNode = nodeStack.Pop();
                            if (currentNode.left == null)
                            {
                                currentNode.left = childNode;
                            }
                            else if (currentNode.right == null)
                            {
                                currentNode.right = childNode;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Expression");
                            }
                        }
                        break;
                    case ('+'):
                    case ('*'):
                    case ('-'):
                    case ('/'):
                    case ('^'):
                        currentNode.item = token;
                        break;
                    default:
                        BinaryNode<char> newLeafNode = new BinaryNode<char>();
                        newLeafNode.item = token;

                        if (currentNode.left == null)
                        {
                            currentNode.left = newLeafNode;
                        }
                        else if (currentNode.right == null)
                        {
                            currentNode.right = newLeafNode;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Expression!!");
                        }
                        break;
                }//endSwitch
            }//endWhile
            rootNode = currentNode;
            return rootNode;
        }
        public void DisplayPreOrder()
        {
            if (RootNode != null)
            {
                DisplayPreOrder(RootNode);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Tree is empty.");
            }
        }

        private void DisplayPreOrder(BinaryNode<char> node)
        {
            Console.Write(node.item);
            if (node.left != null)
            {
                DisplayPreOrder(node.left);
            }
            if (node.right != null)
            {
                DisplayPreOrder(node.right);
            }
        }

        public void DisplayPostOrder()
        {
            if (RootNode != null)
            {
                DisplayPostOrder(RootNode);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Tree is empty.");
            }
        }

        private void DisplayPostOrder(BinaryNode<char> node)
        {
            if (node.left != null)
            {
                DisplayPostOrder(node.left);
            }
            if (node.right != null)
            {
                DisplayPostOrder(node.right);
            }
            Console.Write(node.item);
        }

        public double Eval()
        {
            return Eval(RootNode);
        }

        private double Eval(BinaryNode<char> node)
        {
            double value = 0;
            if (node.isLeaf())
            {
                value = node.item - '0';
            }
            else
            {
                switch (node.item)
                {
                    case '+':
                        value = Eval(node.left) + Eval(node.right);
                        break;
                    case '-':
                        value = Eval(node.left) - Eval(node.right);
                        break;
                    case '*':
                        value = Eval(node.left) * Eval(node.right);
                        break;
                    case '/':
                        value = Eval(node.left) / Eval(node.right);
                        break;
                    case '^':
                        value = Math.Pow(Eval(node.left), Eval(node.right));
                        break;
                    default:
                        Console.WriteLine("Invalid OP {0}", node.item);
                        value = 0;
                        break;
                }
            }

            return value;
        }

        private double EvalTest(BinaryNode<char> node)
        {
            double value = 0;

            return value;
        }

        public void DisplayInOrder()
        {
            if (RootNode != null)
            {
                DisplayInOrder(RootNode);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Tree is empty.");
            }
        }

        private void DisplayInOrder(BinaryNode<char> node)
        {
            if (node.left != null)
            {
                Console.Write('(');
                DisplayInOrder(node.left);
            }
            Console.Write(node.item);
            if (node.right != null)
            {
                DisplayInOrder(node.right);
                Console.Write(')');
            }
        }

    }
}

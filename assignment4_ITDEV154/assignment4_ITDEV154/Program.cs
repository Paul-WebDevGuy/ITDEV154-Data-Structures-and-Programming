using System;
using System.Collections;
using System.Collections.Generic;

namespace assignment4_ITDEV154
{
    public class Program
    {

        public static Stack<string> stack = new Stack<string>();
        public static Queue<int> queue = new Queue<int>();

        static void Main(string[] args)
        {
            StackWords();
            ViewFirstWord();
            QueueNumbers();
            ViewQueueNumbers();

            Console.ReadLine();
        }

        //method to add words to the stack
        public static void StackWords()
        {
            string stackAnswer;
            bool moreWords = true;

            Console.WriteLine("First we will create a Stack.  Please enter a word: ");
            stack.Push(Console.ReadLine());

            while (moreWords)
            {
                Console.WriteLine();
                Console.WriteLine("Would you like to enter another word? Enter y for YES or n for NO");
                stackAnswer = Console.ReadLine();

                if(stackAnswer == "y")
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter word here: ");
                    stack.Push(Console.ReadLine());
                }
                else if(stackAnswer == "n")
                {
                    moreWords = false;
                }
            }

        }

        //view words in stack
        public static void ViewFirstWord()
        {
            string viewAnswer;
            bool viewWords = true;

            Console.WriteLine("The first word in the stack is " + stack.Peek());
            while (viewWords)
            {
                Console.WriteLine("Would you like to remove this word and view the next word in the stack? "
                    + "Enter y for YES or n for NO");
                viewAnswer = Console.ReadLine();
                
                
                if(viewAnswer == "y")
                {
                    stack.Pop();
                    Console.WriteLine(stack.Peek());
                }
                else if(viewAnswer == "n")
                {
                    viewWords = false;
                }

            }
        }

        public static void QueueNumbers()
        {
            string queueAnswer;
            bool moreNumbers = true;
            int input;

            Console.WriteLine("Next we will create a Queue.  Please enter a number: ");
            input = Convert.ToInt32(Console.ReadLine());
            queue.Enqueue(input);

            while (moreNumbers)
            {
                Console.WriteLine();
                Console.WriteLine("Would you like to enter another number? Enter y for YES or n for NO");
                queueAnswer = Console.ReadLine();

                if (queueAnswer == "y")
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter number here: ");
                    input = Convert.ToInt32(Console.ReadLine());
                    queue.Enqueue(input);
                }
                else if (queueAnswer == "n")
                {
                    moreNumbers = false;
                }
            }
        }

        public static void ViewQueueNumbers()
        {
            string viewAnswer;
            bool viewQueue = true;

            Console.WriteLine("The first number in the queue is " + queue.Peek());
            while (viewQueue)
            {
                Console.WriteLine();
                Console.WriteLine("Would you like to remove this number and view the next number in the queue? "
                    + "Enter y for YES or n for NO");
                viewAnswer = Console.ReadLine();


                if (viewAnswer == "y")
                {
                    queue.Dequeue();
                    Console.WriteLine(queue.Peek());
                }
                else if (viewAnswer == "n")
                {
                    viewQueue = false;
                }

            }
        }
    }
}

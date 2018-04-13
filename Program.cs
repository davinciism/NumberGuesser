using System;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            appInfo();
            greetUser();
            game();
        }

        static void printColorMessage(ConsoleColor color, String message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        static void appInfo()
        {
            String appName = "Number Guesser";
            String appVersion = "1.0.0";
            String author = "Pratik Kuril";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("{0}:- Version : {1} by {2}", appName, appVersion, author);
            Console.ResetColor();

        }
        static void greetUser()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("What is your name?");
            String userName = Console.ReadLine();
            Console.WriteLine("Hello {0}! Let's play a game!", userName);
            Console.ResetColor();
        }
        static void rules()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("You have to guess a number which lies in the range of 1-100.");
            Console.WriteLine("You have 10 chances and we will give you a hint after every chance.");
            Console.ResetColor();
        }

        static void game()
        {
            String answer = "";
            rules();


            do
            {


                Random random = new Random();
                int correctNumber = random.Next(1, 100);
                int guess = 0;
                printColorMessage(ConsoleColor.DarkGreen, "Guess the number.");

                for (int i = 0; i < 10; i++)
                {
                    String input = Console.ReadLine();
                    if (!int.TryParse(input, out guess)) //If input is not in integer format then =>....
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(input + " is not a number. Please enter an actual number.");
                        Console.ResetColor();
                        continue;
                    }

                    //guess = Int32.Parse(input);
                    if (guess == correctNumber)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        printColorMessage(ConsoleColor.Green, "Your guess is correct. You won!");
                        break;
                    }
                    if (guess < correctNumber)
                    {
                        printColorMessage(ConsoleColor.DarkYellow, "Your guess is smaller than the correct answer.");
                    }
                    if (guess > correctNumber)
                    {
                        printColorMessage(ConsoleColor.DarkYellow, "Your guess is larger than the correct answer.");
                    }
                }

                Console.BackgroundColor = ConsoleColor.DarkGray;
                printColorMessage(ConsoleColor.Red, "You lost. Sorry!");
                Console.WriteLine("Play again?[Y or N]");
                answer = Console.ReadLine().ToUpper();
            } while (answer == "Y");
        }

    }
}

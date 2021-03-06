﻿using System;

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
            String appName = "NUMBER GUESSER";
            String appVersion = "1.1.0";
            String author = "Pratik Kuril";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(appName);
            Console.ResetColor();
            printColorMessage(ConsoleColor.DarkCyan,"  Version : "+appVersion );
            Console.ResetColor();
            printColorMessage(ConsoleColor.DarkCyan, "Made with Love and Coffee by "+author+"!");
            Console.WriteLine();

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
            Console.WriteLine("We have stored a secret number in the range of 1-100. Your task is to guess it!");
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
                printColorMessage(ConsoleColor.Yellow, "Guess the number.");
                int i;
                for (i = 1; i <= 10; i++)
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
                        printColorMessage(ConsoleColor.Green, "Your guess is correct. You won!");
                        break;
                    }
                    if (guess < correctNumber)
                    {
                        printColorMessage(ConsoleColor.DarkYellow, "The secret number is greater than "+guess +" .");
                    }
                    if (guess > correctNumber)
                    {
                        printColorMessage(ConsoleColor.DarkYellow, "The secret number is smaller than "+guess+" .");
                    }
                }
                printColorMessage(ConsoleColor.DarkGreen, "You took " + i + " chances!");

                if (guess != correctNumber)
                {
                    printColorMessage(ConsoleColor.Red, "You ran out of chances. Sorry!!");
                }

                printColorMessage(ConsoleColor.Yellow, "Play again?[Y or N]");
                answer = Console.ReadLine().ToUpper();
            } while (answer == "Y");
        }

    }
}

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace Labs_game
{
    class Program
    {
        static void Main(string[] args)
        {
            //User customisability
            Console.WriteLine("Input name of player 1: ");
            string Player1 = Console.ReadLine();
            Console.WriteLine("Input name of player 2: ");
            string Player2 = Console.ReadLine();
            Console.WriteLine($"{Player1}: Pick which word to guess");
            //input word as a password so as not to apppear on screen
            string alpha = "abcdefghijklmnopqrstuvwxyz";
            string word = Password(alpha);
            //input graphics
            var hangman = new string[] {"      _______\n      |     |\n      |      \n      |      \n      |      \n      |      \n      |      \n______|_______\n",
            "      _______\n      |     |\n      |     O\n      |      \n      |      \n      |      \n      |      \n______|_______\n",
            "      _______\n      |     |\n      |     O\n      |     |      \n      |     |\n      |      \n      |      \n______|_______\n",
            "      _______\n      |     |\n      |     O\n      |     |_     \n      |     |\n      |      \n      |      \n______|_______\n",
            "      _______\n      |     |\n      |     O\n      |    _|_     \n      |     |\n      |      \n      |      \n______|_______\n",
            "      _______\n      |     |\n      |     O\n      |    _|_     \n      |     |\n      |    / \n      |      \n______|_______\n",
            "      _______\n      |     |\n      |     O\n      |    _|_     \n      |     |\n      |    / \\\n      |      \n______|_______\n",
            "      _______\n      |     |\n      |     O\n      |    _|_     \n      |     |\n      |    / \\\n      |      \n______|_______\n"};
            StringBuilder letter = new StringBuilder();
            StringBuilder fail = new StringBuilder();
            StringBuilder success = new StringBuilder();
            StringBuilder output = new StringBuilder();
            //build database of letters
            foreach(char c in alpha)
            {
                if (word.Contains(c))
                {
                    letter.Append(c);
                }
            }
            //building word to be guessed graphics
            for(int i=0; i<=word.Length-1; i++)
            {
                output.Append("_");
                output.Append(" ");
            }

            int counter = 0;
            while(counter<7)
            {
                Console.WriteLine($"{Player2}: Pick a letter");
                char c = Console.ReadKey().KeyChar;
                //check c in alpha
                while (!alpha.Contains(c))
                {
                    Console.WriteLine(" is not a valid letter");
                    c = Console.ReadKey().KeyChar;
                }
                Console.Clear();
                if (!word.Contains(c))
                {
                    counter++;
                    fail.Append(c);
                    fail.Append(", ");
                    //print graphics
                    Console.WriteLine(hangman[counter]);
                    //print guessed letters
                    Console.WriteLine($"Wrong letters: {fail.ToString()}\n");
                    Console.WriteLine($"Correct letters: {success.ToString()}\n");
                    Console.WriteLine($"{output}\n");
                }
                //remove guessed letters
                if (word.Contains(c))
                {
                    if(!success.ToString().Contains(c))
                        letter.Remove(letter.ToString().IndexOf(c),1);
                    else
                        Console.WriteLine("Letter already successful");
                    success.Append(c);
                    success.Append(", ");
                    for (int i=0; i<=word.Length-1; i++)
                    {
                        if (word[i] == c) { output[i*2] = c; }
                    }
                    //print graphics
                    Console.WriteLine(hangman[counter]);
                    //print guessed letters
                    Console.WriteLine($"Wrong letters: {fail.ToString()}\n");
                    Console.WriteLine($"Correct letters: {success.ToString()}\n");
                    Console.WriteLine($"{output}\n");
                }
                //check word guessed
                if(letter.Length==0)
                {
                    Console.WriteLine($"{Player2} wins");
                    break;
                }
            }
            //print game over if counter=7
            if (counter == 7)
            {
                Console.WriteLine($"{Player1} wins");
            }
        }

        static string Password(string alpha)
        {
            ConsoleKeyInfo key;
            SecureString pass = new SecureString();
            do
            {
                key = Console.ReadKey(true);
                while(!alpha.Contains(key.KeyChar) && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                {
                    key = Console.ReadKey(true);
                }
                // Backspace Should Not Work
                if (!char.IsControl(key.KeyChar))
                {
                    pass.AppendChar(key.KeyChar);
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass.RemoveAt(pass.Length - 1);
                        Console.Write("\b \b");
                    }
                }
            }
            // Stops Receving Keys Once Enter is Pressed
            while (key.Key != ConsoleKey.Enter);
            Console.WriteLine("\n");
            string word = new System.Net.NetworkCredential(string.Empty, pass).Password;
            return word;
        }
    }
}

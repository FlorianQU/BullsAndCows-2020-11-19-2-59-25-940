using System;
using BullsAndCows;
using static System.String;

namespace BullsAndCowsRunner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SecretGenerator secretGenerator = new SecretGenerator();
            BullsAndCowsGame game = new BullsAndCowsGame(secretGenerator);
            InputCheck inputCheck = new InputCheck();
            while (game.CanContinue)
            {
                var input = Console.ReadLine();
                input = inputCheck.CheckInput(input);
                if (!IsNullOrEmpty(input))
                {
                    var output = game.Guess(input);
                    Console.WriteLine(output);
                }
            }

            Console.WriteLine("Game Over");
        }
    }
}
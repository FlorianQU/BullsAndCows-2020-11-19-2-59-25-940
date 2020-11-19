using System;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private readonly string secret = string.Empty;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            var guessWithoutSpace = guess.Replace(" ", string.Empty);
            return this.Compare(this.secret, guessWithoutSpace);
        }

        private string Compare(string secret, string guess)
        {
            if (secret == guess)
            {
                return "4A0B";
            }

            // exchange guess with secret in Contains
            var numberOfExisting = guess.Where(secret.Contains).ToList().Count;
            var numberOfMatch = secret.Where((charElement, index) => charElement == guess[index]).ToList().Count;

            return $"{numberOfMatch}A{numberOfExisting - numberOfMatch}B";
            //if (secret.Where(guess.Contains).ToList().Count == 4)
            //{
            //    return "0A4B";
            //}

            //return "0A0B";
        }
    }
}
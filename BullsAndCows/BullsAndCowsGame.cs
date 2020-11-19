using System;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private readonly string secret = string.Empty;
        private int chances = 6;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => this.chances > 0;

        public string Guess(string guess)
        {
            var guessWithoutSpace = guess.Replace(" ", string.Empty);
            return this.Compare(this.secret, guessWithoutSpace);
        }

        private string Compare(string secret, string guess)
        {
            // exchange guess with secret in Contains
            var numberOfExisting = guess.Where(secret.Contains).ToList().Count;
            var numberOfMatch = secret.Where((charElement, index) => charElement == guess[index]).ToList().Count;
            //if (numberOfMatch == 4)
            //{
            //    this.chances = 0;
            //}
            //else
            //{
            //    this.chances -= 1;
            //}

            this.chances -= numberOfMatch == 4 ? this.chances : 1;

            return $"{numberOfMatch}A{numberOfExisting - numberOfMatch}B";
        }
    }
}
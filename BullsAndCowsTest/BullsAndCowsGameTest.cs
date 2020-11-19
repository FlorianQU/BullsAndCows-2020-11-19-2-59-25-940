using BullsAndCows;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        [Fact]
        public void Should_create_BullsAndCowsGame()
        {
            var testSecretGenerator = new TestSecretGenerator();
            //var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(testSecretGenerator);
            Assert.NotNull(game);
            Assert.True(game.CanContinue);
        }

        [Fact]
        public void Should_Return_0A0B_when_all_digit_and_position_wrong()
        {
            //given
            var testSecretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(testSecretGenerator);
            //when
            string answer = game.Guess("5 6 7 8");
            //then
            Assert.Equal("0A0B", answer);
        }

        [Fact]
        public void Should_Return_4A0B_when_all_digit_and_position_correct()
        {
            //given
            var testSecretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(testSecretGenerator);
            //when
            string answer = game.Guess("1 2 3 4");
            //then
            Assert.Equal("4A0B", answer);
        }

        [Fact]
        public void Should_Return_0A4B_when_all_digit_correct_all_position_wrong()
        {
            //given
            var testSecretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(testSecretGenerator);
            //when
            string answer = game.Guess("4 3 2 1");
            //then
            Assert.Equal("0A4B", answer);
        }

        public class TestSecretGenerator : SecretGenerator
        {
            public override string GenerateSecret()
            {
                return "1234";
            }
        }
    }
}

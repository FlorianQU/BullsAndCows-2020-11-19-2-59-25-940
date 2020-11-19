using BullsAndCows;
using Moq;
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

        [Theory]
        [InlineData("1 2 3 4", "1234")]
        [InlineData("5 6 7 8", "5678")]
        public void Should_Return_4A0B_when_all_digit_and_position_correct(string guess, string secrete)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(mock => mock.GenerateSecret()).Returns(secrete);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            //when
            string answer = game.Guess(guess);
            //then
            Assert.Equal("4A0B", answer);
        }

        [Theory]
        [InlineData("4 3 2 1")]
        [InlineData("3 4 2 1")]
        [InlineData("4 3 1 2")]
        public void Should_Return_0A4B_when_all_digit_correct_all_position_wrong(string guess)
        {
            //given
            var testSecretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(testSecretGenerator);
            //when
            string answer = game.Guess(guess);
            //then
            Assert.Equal("0A4B", answer);
        }

        [Theory]
        [InlineData("1 4 3 2", "1234")]
        [InlineData("5 8 7 6", "5678")]
        public void Should_Return_2A2B_when_all_digit_correct_position_partly_wrong(string guess, string secrete)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(mock => mock.GenerateSecret()).Returns(secrete);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            //when
            string answer = game.Guess(guess);
            //then
            Assert.Equal("2A2B", answer);
        }

        [Theory]
        [InlineData("1 4 3 5", "1234")]
        [InlineData("5 9 7 6", "5678")]
        public void Should_Return_2A1B_when_digit_partly_correct_position_partly_wrong(string guess, string secrete)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(mock => mock.GenerateSecret()).Returns(secrete);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            //when
            string answer = game.Guess(guess);
            //then
            Assert.Equal("2A1B", answer);
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

using AlphabetChecker.Controllers;
using Core.Services;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace AlphabetTest
{
    public class AlphabetTest
    {

        //private readonly Mock<IAlphabetService> _mockAlphabetService;
        private readonly AlphabetService _alphabetService;
        private readonly AlphabetController _alphabetController;

        public AlphabetTest()
        {
            //Ideally we use mock
            //_mockAlphabetService = new Mock<IAlphabetService>();

            _alphabetService = new AlphabetService();
            _alphabetController = new AlphabetController(_alphabetService);
        }

        public static IEnumerable<object[]> AlphabetTestData =>
        new List<object[]>
        {
            new object[] { "abcdefghijklmnopqrstuvwxyz", true },
            new object[] { "apqrstuvwxyzcdef%#&^@%ghijklmnoiewbiowbfuwbefuijwbiufwiks^%@$%^#vnk", true },
            new object[] { "abcde12334545", false },
            new object[] { "hellooooo", false },
            new object[] { "ABCDEFGHIJKLMNOPQRSTUVWXYZ", true },
            new object[] { "1234567890", false },
            new object[] { "", false }
        };


        [Theory]
        [MemberData(nameof(AlphabetTestData))]
        public void CheckAlphabet_ShouldReturnExpectedResult(string input, bool expected)
        {
            // Arrange
            //_mockAlphabetService.Setup(s => s.CheckAlphabet(It.IsAny<string>())).Returns(true);// To be Used with Return to Mock Actual Services,
            // since this is a logical operation not needed

            // Act
            var result = _alphabetController.CheckAlphabet(new AlphabetCheck() { Input = input });
            var value = (result.Result as OkObjectResult)?.Value as bool?;

            // Assert
            Assert.Equal(expected, value);
        }

    }
}
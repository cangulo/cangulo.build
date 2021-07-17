using cangulo.build.abstractions.Models;
using FluentAssertions;
using System;
using Xunit;

namespace cangulo.build.domain.UT.Services
{
    public class VersionServiceShould
    {
        [Theory]
        [InlineData("1.1.2", 1, 1, 2, "")]
        [InlineData("1.1.2beta", 1, 1, 2, "beta")]
        [InlineData("1.1.2-beta", 1, 1, 2, "-beta")]
        public void ParseVersion_WhenValidInput(string input, int expectedMajor, int expectedMinor, int expectedPatch, string expectedExtra)
        {
            // Arrange
            var sut = new VersionParserService();
            var expectedResult = new ReleaseNumber
            {
                Major = expectedMajor,
                Minor = expectedMinor,
                Patch = expectedPatch,
                Extra = expectedExtra
            };

            // Act
            var result = sut.ParseReleaseNumber(input);

            // Assert
            result
                .Should()
                .BeEquivalentTo(expectedResult);
        }

        [Theory]
        [InlineData("1.a.2")]
        [InlineData("1.1")]
        public void ThrowException_WhenInvalidInput(string input)
        {
            // Arrange
            var sut = new VersionParserService();

            // Act
            Action act = () => sut.ParseReleaseNumber(input);

            // Assert
            act.Should().Throw<Exception>();
        }
    }
}

using Xunit;
using Cameron_Brett_TechOne_Technical_Test.UtilMethods;

public class UtilsTests
{
    [Theory]
    [InlineData("100.01", "100", "01")]
    [InlineData(".99", "", "99")]
    [InlineData("129.99", "129", "99")]
    public void SplitUserInputIfDecimal_ReturnsExpectedParts(string input, string expectedBefore, string expectedAfter)
    {
        var (before, after) = Utils.SplitUserInputIfDecimal(input);
        Assert.Equal(expectedBefore, before);
        Assert.Equal(expectedAfter, after);
    }

    [Theory]
    [InlineData("123.45", true)]
    [InlineData("678", false)]
    [InlineData(".99", true)]
    [InlineData("", false)] // Assuming handling for empty string
    public void CheckIfUserInputIsDecimal_IdentifiesCorrectly(string input, bool expected)
    {
        bool result = Utils.CheckIfUserInputIsDecimal(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(true, "TWO", "AND ONE", "TWO DOLLARS AND ONE CENT")]
    [InlineData(false, "THREE", "", "THREE DOLLARS")]
    [InlineData(true, "FOUR", "05", "FOUR DOLLARS AND 05 CENTS")]
    [InlineData(true, "FIVE", "AND TWO", "FIVE DOLLARS AND TWO CENTS")]
    public void GenerateAndFillTemplate_GeneratesCorrectTemplate(bool isDecimal, string beforeDecimal, string afterDecimal, string expected)
    {
        string result = Utils.GenerateAndFillTemplate(isDecimal, beforeDecimal, afterDecimal);
        Assert.Equal(expected, result);
    }
}

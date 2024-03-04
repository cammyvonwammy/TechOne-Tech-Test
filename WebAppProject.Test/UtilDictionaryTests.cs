namespace WebAppProject.Test;
using Cameron_Brett_TechOne_Technical_Test.Dictionary;

public class UtilDictionaryTests
{
    [Theory]
    [InlineData("0", "ZERO")]
    [InlineData("1", "ONE")]
    [InlineData("12", "TWELVE")]
    [InlineData("123", "ONE HUNDRED AND TWENTY-THREE")]
    [InlineData("1234", "ONE THOUSAND TWO HUNDRED AND THIRTY-FOUR")]
    [InlineData("12345", "TWELVE THOUSAND THREE HUNDRED AND FORTY-FIVE")]
    [InlineData("123456", "ONE HUNDRED AND TWENTY-THREE THOUSAND FOUR HUNDRED AND FIFTY-SIX")]
    [InlineData("1234567", "ONE MILLION TWO HUNDRED AND THIRTY-FOUR THOUSAND FIVE HUNDRED AND SIXTY-SEVEN")]
    [InlineData("12345678", "TWELVE MILLION THREE HUNDRED AND FORTY-FIVE THOUSAND SIX HUNDRED AND SEVENTY-EIGHT")]
    [InlineData("123456789", "ONE HUNDRED AND TWENTY-THREE MILLION FOUR HUNDRED AND FIFTY-SIX THOUSAND SEVEN HUNDRED AND EIGHTY-NINE")]
    [InlineData("1234567890", "ONE BILLION TWO HUNDRED AND THIRTY-FOUR MILLION FIVE HUNDRED AND SIXTY-SEVEN THOUSAND EIGHT HUNDRED AND NINETY")]
    [InlineData("123456789012", "ONE HUNDRED AND TWENTY-THREE BILLION FOUR HUNDRED AND FIFTY-SIX MILLION SEVEN HUNDRED AND EIGHTY-NINE THOUSAND AND TWELVE")]
    [InlineData("1234567890123", "ONE TRILLION TWO HUNDRED AND THIRTY-FOUR BILLION FIVE HUNDRED AND SIXTY-SEVEN MILLION EIGHT HUNDRED AND NINETY THOUSAND ONE HUNDRED AND TWENTY-THREE")]
    [InlineData("999999999999999", "NINE HUNDRED AND NINETY-NINE TRILLION NINE HUNDRED AND NINETY-NINE BILLION NINE HUNDRED AND NINETY-NINE MILLION NINE HUNDRED AND NINETY-NINE THOUSAND NINE HUNDRED AND NINETY-NINE")]
    public void ConvertNumberStringToWords_GivenNumber_ReturnsExpectedWords(string input, string expected)
    {
        var result = UtilDictionary.ConvertNumberStringToWords(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1001", "ONE THOUSAND AND ONE")]
    [InlineData("1000001", "ONE MILLION AND ONE")]
    public void ConvertNumberStringToWords_NumberWithZerosInside_ReturnsCorrectWords(string input, string expected)
    {
        var result = UtilDictionary.ConvertNumberStringToWords(input);
        Assert.Equal(expected, result);
    }
}
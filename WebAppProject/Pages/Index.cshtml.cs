using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Cameron_Brett_TechOne_Technical_Test.Dictionary;
using Cameron_Brett_TechOne_Technical_Test.UtilMethods;

namespace Cameron_Brett_TechOne_Technical_Test.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public string NumberInput { get; set; } = "";

    public string? ConversionResult { get; set; }

    public void OnGet()
    {

    }

    public void OnPost()
    {
        string result;
        if (Utils.CheckIfUserInputIsDecimal(NumberInput))
        {
            var (partBeforeDecimal, partAfterDecimal) = Utils.SplitUserInputIfDecimal(NumberInput);
            string processedPartBeforeDecimal = UtilDictionary.ConvertNumberStringToWords(partBeforeDecimal);
            string processedPartAfterDecimal = UtilDictionary.ConvertNumberStringToWords(partAfterDecimal);
            result = Utils.GenerateAndFillTemplate(true, processedPartBeforeDecimal, processedPartAfterDecimal);

        }
        else
        {
            string processedPartBeforeDecimal = UtilDictionary.ConvertNumberStringToWords(NumberInput);
            result = Utils.GenerateAndFillTemplate(true, processedPartBeforeDecimal, "");
        }
        ConversionResult = result;
    }
}

using System.Text.RegularExpressions;

namespace Cameron_Brett_TechOne_Technical_Test.UtilMethods
{
    public class Utils
    {
        public static (string, string) SplitUserInputIfDecimal(string UserInput)
        {
            string[] parts = UserInput.Split('.');

            string partBeforeDecimal = parts[0];
            string partAfterDecimal = parts[1];

            return (partBeforeDecimal, partAfterDecimal);
        }

        public static bool CheckIfUserInputIsDecimal(string userInput)
        {
            if (userInput.Contains('.'))
            {
                return true;
            }
            else return false;
        }

        public static string GenerateAndFillTemplate(bool isDecimal, string processedPartBeforeDecimal, string processedPartAfterDecimal)
        {
            string pattern = @"AND ONE|AND TWO|AND THREE|AND FOUR|AND FIVE|AND SIX|AND SEVEN|AND EIGHT|AND NINE";
            Match match = Regex.Match(processedPartAfterDecimal, pattern);
            string template;
            if (isDecimal)
            {
                if (processedPartAfterDecimal != "" && match.Success && match.Value == processedPartAfterDecimal)
                {
                    if (processedPartAfterDecimal == "AND ONE")
                    {
                        template = $"{processedPartBeforeDecimal} DOLLARS {processedPartAfterDecimal} CENT";
                    }
                    else
                    {
                        template = $"{processedPartBeforeDecimal} DOLLARS {processedPartAfterDecimal} CENTS";
                    }
                }
                else if (processedPartAfterDecimal != "")
                {
                    template = $"{processedPartBeforeDecimal} DOLLARS AND {processedPartAfterDecimal} CENTS";
                }
                else
                {
                    template = $"{processedPartBeforeDecimal} DOLLARS";
                }
            }
            else
            {
                if (processedPartBeforeDecimal != "ONE")
                {
                    template = $"{processedPartBeforeDecimal} DOLLARS";
                }
                else
                {
                    template = $"{processedPartBeforeDecimal} DOLLAR";
                }

            }
            return template;
        }

    }
}
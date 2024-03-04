using System.Text;

namespace Cameron_Brett_TechOne_Technical_Test.Dictionary
{
    public class UtilDictionary
    {
        private static readonly Dictionary<int, string> numberWords = new()
        {
            {0, "ZERO"}, {1, "ONE"}, {2, "TWO"}, {3, "THREE"}, {4, "FOUR"},
            {5, "FIVE"}, {6, "SIX"}, {7, "SEVEN"}, {8, "EIGHT"}, {9, "NINE"},
            {10, "TEN"}, {11, "ELEVEN"}, {12, "TWELVE"}, {13, "THIRTEEN"}, {14, "FOURTEEN"},
            {15, "FIFTEEN"}, {16, "SIXTEEN"}, {17, "SEVENTEEN"}, {18, "EIGHTEEN"}, {19, "NINETEEN"},
            {20, "TWENTY"}, {30, "THIRTY"}, {40, "FORTY"}, {50, "FIFTY"},
            {60, "SIXTY"}, {70, "SEVENTY"}, {80, "EIGHTY"}, {90, "NINETY"}
        };
        private static readonly List<string> positionWords =
        [
            "", " THOUSAND ", " MILLION ", " BILLION ", " TRILLION " // Note: First position is empty for numbers less than 1000
        ];

        public static string ConvertNumberStringToWords(string userInput)
        {
            if (userInput == "0") return "ZERO";
            int count = 0;
            List<(string Text, int Position)> parts = [];
            for (int i = userInput.Length, position = 0; i > 0; i -= 3, position++)
            {
                int start = Math.Max(i - 3, 0);
                string chunk = userInput.Substring(start, i - start);
                int chunkNumber = int.Parse(chunk);
                string chunkResult;
                if (chunk.StartsWith("0") && chunkNumber > 0 && count == 0)
                {
                    chunkResult = ProcessChunk(chunk, true);
                    count++;
                }
                else
                {
                    chunkResult = ProcessChunk(chunk);
                }
                if (chunkResult != "ZERO")
                {
                    parts.Add((chunkResult + positionWords[position], position));
                }
            }

            StringBuilder result = new();
            for (int i = parts.Count - 1; i >= 0; i--)
            {
                result.Append(parts[i].Text);
            }
            return result.ToString().Trim();

        }

        private static string ProcessChunk(string chunk, bool isLastSignificantChunk = false)
        {
            int chunkNumber = int.Parse(chunk);

            if (chunkNumber == 0 && (chunk == "000" || chunk == "00" || chunk == "0"))
            {
                return "ZERO";
            }

            StringBuilder chunkResult = new();

            // Check for leading zeros and decide if "AND" should be prepended
            if (chunk.StartsWith("0") && chunkNumber > 0 && isLastSignificantChunk)
            {
                chunkResult.Append("AND ");
            }

            // Hundreds
            if (chunkNumber >= 100)
            {
                int hundreds = chunkNumber / 100;
                chunkResult.Append(numberWords[hundreds] + " HUNDRED");

                chunkNumber %= 100; // Remove hundreds place

                if (chunkNumber > 0)
                {
                    chunkResult.Append(" AND ");
                }
            }

            // Tens and Ones
            if (chunkNumber > 0)
            {
                if (numberWords.TryGetValue(chunkNumber, out string? value))
                {
                    // Direct match (like 10, 11, ..., 19, 20, 30, ..., 90)
                    chunkResult.Append(value);

                }
                else
                {
                    int tens = (chunkNumber / 10) * 10;
                    int ones = chunkNumber % 10;

                    if (tens > 0)
                    {
                        chunkResult.Append(numberWords[tens]);
                    }
                    if (ones > 0)
                    {
                        if (tens > 0) chunkResult.Append('-');
                        chunkResult.Append(numberWords[ones]);
                    }
                }
            }
            return chunkResult.ToString().Trim();
        }
    }
}
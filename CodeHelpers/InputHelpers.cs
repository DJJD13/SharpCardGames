namespace CodeHelpers;

public static class InputHelpers
{
    
    public static char GetAllowedCharsFromConsole(List<char> acceptableChars)
    {
        while (true)
        {
            var charToReturn = char.ToUpper(Console.ReadKey(true).KeyChar);
            if (acceptableChars.Count == 0)
            {
                return charToReturn;
            }

            if (acceptableChars.Contains(charToReturn))
            {
                return charToReturn;
            }
            
            Console.Write($"Invalid command. The following are allowed characters: {string.Join(',', acceptableChars)}");
            Console.WriteLine();
        }
    }
    
}
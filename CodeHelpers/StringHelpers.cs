namespace CodeHelpers;

public static class StringHelpers
{
    public static bool HasValue(this string? value)
    {
        if (value is null)
        {
            return false;
        }
        return !string.IsNullOrWhiteSpace(value);
    }
}
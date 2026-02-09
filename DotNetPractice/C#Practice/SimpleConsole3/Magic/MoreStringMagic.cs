namespace Magic;

public class MoreStringMagic
{
    public int GetStringLength(string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }
        return input.Length;
    }
}
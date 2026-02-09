namespace ConsoleApp.Utils;

public class StringMagic
{
    public static string Reverse(string input)
    {
        if (input == null) return null;
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
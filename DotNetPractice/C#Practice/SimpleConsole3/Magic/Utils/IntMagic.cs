namespace Magic.Utils;

public class IntMagic
{
    // Add methods and properties here
public int Factorial(int number)
{
    if (number < 0)
        throw new ArgumentException("Number must be non-negative.");
    if (number == 0 || number == 1)
        return 1;
    int result = 1;
    for (int i = 2; i <= number; i++)
    {
        result *= i;
    }
    return result;
}
}
using Magic;
using Magic.Utils;
using Newtonsoft.Json;

namespace ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine(Utils.StringMagic.Reverse("Hello, World!"));
        Console.WriteLine(new MoreStringMagic().GetStringLength("Yo Yo"));
        Console.WriteLine(new IntMagic().Factorial(23));
        Console.WriteLine(JsonConvert.SerializeObject(new {Name = "John Doe", Age = 23}));
    }
}
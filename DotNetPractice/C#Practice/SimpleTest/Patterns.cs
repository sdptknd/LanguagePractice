namespace SimpleTest;

public static class Patterns
{
    public static void nXn(int n)
    {
        for (var i = 0; i < n; i++)
        {
            var row = "";
            for(var j = 0; j < n; j++) row += '*';
            Console.WriteLine(row);
        }
    }

    public static void LeftTree(int n)
    {
        for (var i = 0; i < n; i++)
        {
            for(var j = 0; j <= i; j++) Console.Write('*');
            Console.WriteLine();
        }
    }
    
    public static void NumberedLeftTree(int n)
    {
        for (var i = 0; i < n; i++)
        {
            for(var j = 0; j <= i; j++) Console.Write(j + 1);
            Console.WriteLine();
        }
    }
    
    public static void RowNumberedLeftTree(int n)
    {
        for (var i = 0; i < n; i++)
        {
            for(var j = 0; j <= i; j++) Console.Write(i + 1);
            Console.WriteLine();
        }
    }
    
    public static void ReverseLeftTree(int n)
    {
        for (var i = n; i > 0; i--)
        {
            for(var j = 0; j < i; j++) Console.Write('*');
            Console.WriteLine();
        }
    }
    
    public static void ReverseNumberedLeftTree(int n)
    {
        for (var i = n; i > 0; i--)
        {
            for(var j = 0; j < i; j++) Console.Write(j+1);
            Console.WriteLine();
        }
    }
    
    public static void Tree(int n)
    {
        for (var i = 0; i < n; i++)
        {
            for(var j = 0; j < n - i - 1; j++) Console.Write(' ');
            for(var j = n - i - 1; j < n; j++) Console.Write('*');
            for(var j = n - i; j < n; j++) Console.Write('*');
            Console.WriteLine();
        }
    }
    
    public static void ReverseTree(int n)
    {
        for (var i = 0; i < n; i++)
        {
            for(var j = 0; j < i; j++) Console.Write(' ');
            for(var j = i; j < n; j++) Console.Write('*');
            for(var j = i; j < n - 1; j++) Console.Write('*');
            Console.WriteLine();
        }
    }

    public static void Diamond(int n)
    {
        for (var i = 0; i < n; i++)
        {
            for(var j = 0; j < n - i - 1; j++) Console.Write(' ');
            for(var j = n - i - 1; j < n; j++) Console.Write('*');
            for(var j = n - i; j < n; j++) Console.Write('*');
            Console.WriteLine();
        }
        for (var i = 1; i < n; i++)
        {
            for(var j = 0; j < i; j++) Console.Write(' ');
            for(var j = i; j < n; j++) Console.Write('*');
            for(var j = i; j < n - 1; j++) Console.Write('*');
            Console.WriteLine();
        }
    }
    
    public static void RightDiamond(int n)
    {
        for (var i = 0; i < n; i++)
        {
            for(var j = 0; j <= i; j++) Console.Write('*');
            Console.WriteLine();
        }
        for (var i = n-1; i > 0; i--)
        {
            for(var j = 0; j < i; j++) Console.Write('*');
            Console.WriteLine();
        }
    }

    public static void BitStep(int n)
    {
        for (int i = 0; i < n; i++)
        {
            var bit = 1 - (i & 1);
            for (var j = 0; j <= i; j++)
            {
                Console.Write(bit);
                bit = 1 - bit;
            }
            Console.WriteLine();
        }
    }
    
    public static void BitStep2(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (var j = 0; j <= i; j++) Console.Write(1 - ((i+j) & 1));
            Console.WriteLine();
        }
    }

    public static void NumberedTwinTower(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for(var j = 0; j <= i; j++) Console.Write(j + 1);
            for(var j = i+1; j < n; j++) Console.Write(' ');
            for(var j = n-1; j > i; j--) Console.Write(' ');
            for(var j = i; j >= 0; j--) Console.Write(j + 1);
            Console.WriteLine();
        }
    }
    
    public static void NumberedIncreasingLeftTree(int n)
    {
        var number = 1;
        for (int i = 0; i < n; i++)
        {
            for(var j = 0; j <= i; j++) Console.Write(number++);
            Console.WriteLine();
        }
    }
    
    public static void AlphabetLeftTree(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for(var j = 0; j <= i; j++) Console.Write((char)('A' + j));
            Console.WriteLine();
        }
    }
    
    public static void AlphabetReverseLeftTree(int n)
    {
        for (int i = n-1; i >= 0; i--)
        {
            for(var j = 0; j <= i; j++) Console.Write((char)('A' + j));
            Console.WriteLine();
        }
    }
    
    public static void SameLetterRowLeftTree(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for(var j = 0; j <= i; j++) Console.Write((char)('A' + i));
            Console.WriteLine();
        }
    }
    
    public static void AlphabetSymetricTree(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for(var j = 0; j < n-i-1; j++) Console.Write(' ');
            for(var j = 0; j <= i; j++) Console.Write((char)('A' + j));
            for(var j = i - 1; j >= 0; j--) Console.Write((char)('A' + j));
            Console.WriteLine();
        }
    }
    
    public static void DescendingAlphabetLeftTree(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for(var j = 0; j <= i; j++) Console.Write((char)('A' + n - j - 1));
            Console.WriteLine();
        }
    }
    
    public static void HollowDiamond(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for(var j = 0; j < n - i; j++) Console.Write('*');
            for(var j = n - i; j < n; j++) Console.Write(' ');
            for(var j = n - i; j < n; j++) Console.Write(' ');
            for(var j = 0; j < n - i; j++) Console.Write('*');
            Console.WriteLine();
        }
        for (int i = n-1; i >= 0; i--)
        {
            for(var j = 0; j < n - i; j++) Console.Write('*');
            for(var j = n - i; j < n; j++) Console.Write(' ');
            for(var j = n - i; j < n; j++) Console.Write(' ');
            for(var j = 0; j < n - i; j++) Console.Write('*');
            Console.WriteLine();
        }
    }
    
    public static void HalfHollowDiamonds(int n)
    {
        for (int i = n-1; i >= 0; i--)
        {
            for(var j = 0; j < n - i; j++) Console.Write('*');
            for(var j = n - i; j < n; j++) Console.Write(' ');
            for(var j = n - i; j < n; j++) Console.Write(' ');
            for(var j = 0; j < n - i; j++) Console.Write('*');
            Console.WriteLine();
        }
        for (int i = 1; i < n; i++)
        {
            for(var j = 0; j < n - i; j++) Console.Write('*');
            for(var j = n - i; j < n; j++) Console.Write(' ');
            for(var j = n - i; j < n; j++) Console.Write(' ');
            for(var j = 0; j < n - i; j++) Console.Write('*');
            Console.WriteLine();
        }
    }
    
    public static void HollowRect(int n)
    {
        for (int j = 0; j < n; j++) Console.Write('*');
        Console.WriteLine();
        for (int i = 0; i < n-2; i++)
        {
            Console.Write('*');
            for(var j = 0; j < n-2; j++) Console.Write(' ');
            Console.Write('*');
            Console.WriteLine();
        }
        for (int j = 0; j < n; j++) Console.Write('*');
    }
    
    public static void NumberLayeredBox(int n)
    {
        for (int i = 0; i < n; i++)
        {
            var rowNum = n - i;
            for(var j = n; j > n - i; j--) Console.Write(j);
            for(var j = n - i; j > 0; j--) Console.Write(n-i);
            for(var j = 2; j <= n-i; j++) Console.Write(n-i);
            for(var j = n - i + 1; j <= n; j++) Console.Write(j);
            Console.WriteLine();
        }
        for (int i = n-2; i >= 0; i--)
        {
            var rowNum = n - i;
            for(var j = n; j > n - i; j--) Console.Write(j);
            for(var j = n - i; j > 0; j--) Console.Write(n-i);
            for(var j = 2; j <= n-i; j++) Console.Write(n-i);
            for(var j = n - i + 1; j <= n; j++) Console.Write(j);
            Console.WriteLine();
        }
    }
}
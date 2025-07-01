using System.Text;

// Задача 1
// -----------------------------------

string resultOne = Compress("aaabbcccdde");
Console.WriteLine(resultOne);
string resultTwo = Decompress(resultOne);
Console.WriteLine(resultTwo);

// -----------------------------------
string Compress(string str)
{
    StringBuilder compressed = new StringBuilder();
    int count = 1;
    char currentChar = str[0];

    for (int i = 1; i < str.Length; i++)
    {
        if (str[i] == currentChar)
        {
            count++;
        }
        else
        {
            compressed.Append(currentChar);
            if (count > 1)
                compressed.Append(count);
            currentChar = str[i];
            count = 1;
        }
    }

    compressed.Append(currentChar);
    if (count > 1)
        compressed.Append(count);

    return compressed.ToString();
}

string Decompress(string compressedStr)
{
    StringBuilder decompressed = new StringBuilder();
    int i = 0;

    while (i < compressedStr.Length)
    {
        char symbol = compressedStr[i];
        i++;

        StringBuilder countBuilder = new StringBuilder();
        while (i < compressedStr.Length && char.IsDigit(compressedStr[i]))
        {
            countBuilder.Append(compressedStr[i]);
            i++;
        }

        int count = countBuilder.Length > 0 ? int.Parse(countBuilder.ToString()) : 1;
        decompressed.Append(symbol, count);
    }

    return decompressed.ToString();
}

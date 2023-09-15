using System.Security.Cryptography.X509Certificates;

var alphabetPath = "Resources/Alphabet.txt";

var strings = File.ReadAllLines(alphabetPath);

List<char> alphabet = new List<char>();
foreach (var item in strings[0])
    alphabet.Add(item);

var exit = false;
int swit;
while(!exit)
{
    Console.WriteLine("Choose option: 0 - exit; 1 - Polybius Square; 2 - Encryption tables with a single key permutation;");
    try
    {
        swit = Int32.Parse(Console.ReadLine());
    }
    catch(Exception ex)
    { Console.WriteLine("Type some number!"); continue; }
    switch(swit)
    {
        case 0: exit = true; break;
        default: Console.WriteLine("Type correct number!"); break;
        case 1: PolybiusSquare(alphabet); break;
        case 2: Encryptiontables(alphabet); break;

    }
}



void Echo(List<char> str)
{
    foreach (var item in str)
        Console.Write(item);
    Console.Write("\r\n");
}

bool CheckText(string text, List<char> alphabet)
{
    bool result = false;
    foreach(var charText in text)
    {
        result = false;
        foreach(var charAlphabet in alphabet)
        {
            if (charText == charAlphabet)
            {
                result = true; break;
            }
        }
        if (!result)
            break;
    }
    return result;
}

string Text(string textTo)
{
    string text = "";
    bool exit = false;
    while (!exit)
    {
        Echo(alphabet);
        Console.Write($"Type text to {textTo}: ");
        text = Console.ReadLine();
        if (CheckText(text, alphabet))
            exit = true;
        else
            Console.WriteLine("Enter the characters that are contained in the alphabet!");
    }
    return text;
}

void EchoTable(List<List<char>> table, int rows, int cols, string keyWord)
{
    foreach (var symbol in keyWord)
        Console.Write($"{symbol}\t");
    Console.Write("\r\n");
    for (int i = 0; i < keyWord.Length; i++)
        Console.Write("~\t");
    Console.Write("\r\n");

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            Console.Write($"{table[j][i]}\t");
        }
        Console.Write("\r\n");
    }
}

string SortByAlphabet(List<char> alphabet, string str)
{
    for (int i = 0; i < str.Length; i++)
    {
        for (int j = i + 1; j < str.Length; j++)
        {
            if (alphabet.IndexOf(str[i]) > alphabet.IndexOf(str[j]))
            {
                str = Swap(str, i, j);
            }
        }
    }
    return str;
}

string Swap(string keyWord, int i, int j)
{
    var arr = keyWord.ToCharArray();
    string result = "";
    char tmp = arr[i];
    arr[i] = arr[j];
    arr[j] = tmp;
    foreach (var symbol in arr)
        result += symbol;
    return result;
}

void PolybiusSquare(List<char> alphabet)
{
    string encryptedText = "";
    string decryptedText = "";
    int key = 5;
    string text = Text("encryption");

    Console.WriteLine("Table 5x6\r\n");
    var tmp = 0;
    for(int i = 0; i < 6; i++)
    {
        for(int j = 0; j < 5; j++)
        {
            Console.Write($"{alphabet[tmp]}\t");
            tmp++;
        }
        Console.Write("\r\n");
    }
    Console.Write("\r\n");

    Console.WriteLine("Encryption...");

    for(int i = 0; i < text.Count(); i++)
    {
        for(int j = 0; j < alphabet.Count; j++)
        {
            if (text[i] == alphabet[j])
            {
                if((j+key) <= alphabet.Count)
                    encryptedText += alphabet[j+key];
                else
                {
                    encryptedText += alphabet[j % key];
                }
            }
        }
        Console.WriteLine($"{text[i]} -> {encryptedText[i]}");
    }
    Console.WriteLine($"Encrypted text: {encryptedText}");

    Console.WriteLine("Decryption...");

    for(int i = 0; i < encryptedText.Count(); i++)
    {
        for(int j = 0; j < alphabet.Count; j++)
        {
            if (encryptedText[i] == alphabet[j])
            {
                if ((j - key) >= (alphabet.Count - alphabet.Count))
                    decryptedText += alphabet[j - key];
                else
                {
                    decryptedText += alphabet[alphabet.Count - (key - j)];
                }
            }
        }
        Console.WriteLine($"{encryptedText[i]} -> {decryptedText[i]}");
    }
    Console.WriteLine($"Decrypted text: {decryptedText}");
}

void Encryptiontables(List<char> alphabet)
{
    string text = Text("encryption");
    string keyWord = Text("key word");

    int rows = 3;
    int cols = 4;

    List<List<char>> table = new List<List<char>>();
    foreach (var symbol in keyWord)
        table.Add(new List<char>());

    if (cols != keyWord.Length)
        cols = keyWord.Length;

    if (rows * cols < text.Length)
        rows += text.Length / cols;

    bool checker = true;
    for (int i = 0; i < text.Length; i++)
    {
        checker = true;
        for (int j = 0; j < cols; j++)
        {
            if (i + (rows * j) < text.Length)
                table[j].Add(text[i + (rows * j)]);
            else
                table[j].Add('_');
        }

        foreach (var item in table)
        {
            if (item.Count < rows)
            {
                checker = false;
                break;
            }

        }

        if (checker)
            break;
    }

    EchoTable(table, rows, cols, keyWord);

    Console.Write("\r\n");
    Console.WriteLine("Encryption...");

    List<List<char>> encryptedTable = new List<List<char>>();
    var encryptedKeyWord = keyWord;
    var encryptedText = "";

    encryptedKeyWord = SortByAlphabet(alphabet, encryptedKeyWord);


    foreach (var symbol in encryptedKeyWord)
    {
        for (int i = 0; i < keyWord.Length; i++)
        {
            if (symbol == keyWord[i])
            {
                if (table[i].Count > 0)
                {
                    encryptedTable.Add(table[i]);
                    table[i] = new List<char>();
                }

            }

        }
    }

    EchoTable(encryptedTable, rows, cols, encryptedKeyWord);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            encryptedText += encryptedTable[j][i];
        }
    }
    Console.WriteLine($"\r\nEncrypted text: {encryptedText}");

    Console.WriteLine("Decryption...");
    Console.Write("\r\n");

    List<List<char>> decryptedTable = new List<List<char>>();
    var decryptedText = "";

    foreach (var symbol in keyWord)
    {
        for (int i = 0; i < encryptedKeyWord.Length; i++)
        {
            if (symbol == encryptedKeyWord[i])
            {
                if (encryptedTable[i].Count > 0)
                {
                    decryptedTable.Add(encryptedTable[i]);
                    encryptedTable[i] = new List<char>();
                    break;
                }
            }
               
        }
    }

    EchoTable(decryptedTable, rows, cols, keyWord);

    for (int i = 0; i < cols; i++)
    {
        for (int j = 0; j < rows; j++)
            decryptedText += decryptedTable[i][j];
    }

    Console.WriteLine($"\r\nDecrypted text: {decryptedText}");
    Console.Write("\r\n");
}
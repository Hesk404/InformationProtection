using Lab3;
using System.Net.WebSockets;
using System.Text;
using System.Xml.Linq;

List<Pair> alphabet = new List<Pair>();
var file = File.ReadAllLines("Resources/Alphabet.txt");


var probabilitysStrings =  file[1].Split(';');
//float[] probabilitys = new float[probabilitysStrings.Length];

//for (int i = 0; i < probabilitys.Count(); i++)
//{
//    probabilitys[i] = float.Parse(probabilitysStrings[i]);
//}

for(int i = 0; i < file[0].Length; i++)
{
    alphabet.Add(new Pair ( file[0][i], float.Parse(probabilitysStrings[i])));
}
int tab = 1;
foreach(var item in alphabet)
{
    if(tab == alphabet.Count() / 4)
    {
        Console.WriteLine();
        tab = 1;
    }

    Console.Write($"{item.Key}({item.Value}) \t");
    tab++;
}

Console.WriteLine();


int swit = -1;
while(true)
{
    Console.WriteLine("Choose option: 0 - exit; 1 - Polybius encrypt/decrypt");
    try
    {
        swit = Int32.Parse(Console.ReadLine());
    }
    catch (Exception ex)
    {
        Console.WriteLine("Type some number!");
    }

    switch(swit)
    {
        case 0: break;
        case -1: break;
        default: Console.WriteLine("Type some correct number!"); break;
        case 1: PolybiusEncryptDecrypt(); break;
    }
    if (swit == 0)
        break;
    swit = -1;
}


bool CheckText(string text, List<Pair> alphabet)
{
    bool result = false;

    foreach(var symbolText in text)
    {
        result = false;
        foreach(var symbolAlphabet in alphabet)
        {
            if (symbolText == symbolAlphabet.Key)
                result = true;
        }
        if (!result)
            break;
    }

    return result;
}


string Text(string textTo)
{
    string text = "";
    while(true)
    {
        Console.Write($"Type text to {textTo}");
        text = Console.ReadLine();
        if (CheckText(text, alphabet))
            break;
        else
            Console.WriteLine("Enter the characters that are contained in the alphabet!");
    }

    return text;

}

string TextFromFile()
{
    string text = "";
    while(true)
    {
        text = File.ReadAllText("Resources/Text.txt");
        if (CheckText(text, alphabet))
            break;
        else
            Console.WriteLine("Symbols in file do not eq to alphabet!");
    }

    return text;
}

List<Pair> GenRandomAlphabet()
{
    var rand = new Random();
    int next = 0;

    List<Pair> alph = alphabet.ToList();

    for(int i = 0; i < alph.Count; i++)
    {
        int j = rand.Next(i + 1);
        var tmp = alph[j];
        alph[j] = alph[i];
        alph[i] = tmp;
    }

    return alph;
}


static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
{
    if (length == 1) return list.Select(t => new T[] { t });

    return GetPermutations(list, length - 1)
        .SelectMany(t => list.Where(e => !t.Contains(e)),
            (t1, t2) => t1.Concat(new T[] { t2 }));
}

void EchoAlphabetTable(List<Pair> alph, int key)
{
    int tmp = 0;
    for (int i = 0; i < alph.Count / key; i++)
    {
        for (int j = 0; j < key; j++)
        {
            Console.Write($"{alph[tmp].Key}\t");
            tmp++;
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

void PolybiusEncryptDecrypt()
{
    string text = TextFromFile();
    string encryptedText = "";
    string decryptedText = "";

    int key = 4;
    int shift = 1;

    int offset = 7;


    List<Pair> randomizedAlphabet = GenRandomAlphabet();

    Console.WriteLine($"Table {key}x{alphabet.Count / key}\r\n");

    EchoAlphabetTable(randomizedAlphabet, key);

    Console.WriteLine("Encryption...");

    var alph = randomizedAlphabet;

    for(int i = 0; i < text.Length; i++)
    {
        for(int j = 0; j < alph.Count; j++)
        {
            if (text[i] == alph[j].Key)
            {
                if ((j + key*shift) <= alph.Count - 1)
                    encryptedText += alph[j + key*shift].Key;
                else
                    encryptedText += alph[j % key*shift].Key;
            }
        }
        //Console.WriteLine($"{text[i]} -> {encryptedText[i]}");
    }
    Console.WriteLine($"Encrypted text: {encryptedText}");

    //Console.WriteLine("Decryption...");

    StringBuilder sb = new StringBuilder();


    var thread = new Thread(() =>
    {

        List<Pair> tmps = new List<Pair>();
        for (int i = randomizedAlphabet.Count - offset; i < randomizedAlphabet.Count; i++)
            tmps.Add(randomizedAlphabet[i]);

        //var perm = GeneratePermutations(tmps);
        var perm = GetPermutations(tmps, tmps.Count);

        List<Pair> tmpsAlphabet = randomizedAlphabet.ToList();
        int tmp = 0;
        List<Pair> tmpItem = null;

        List<float> differences = new List<float>();
        List<string> decryptedTexts = new List<string>();

        foreach (var item in perm)
        {
            //var tmpList = tmpsAlphabet.ToList();
            tmpItem = item.ToList();
            for (int i = tmpsAlphabet.Count - offset; i < tmpsAlphabet.Count; i++)
            {
                tmpsAlphabet[i] = item.ElementAt(tmp);
                tmp++;
            }
            //EchoAlphabetTable(tmpsAlphabet, key);
            //Console.WriteLine();

            for (int i = 0; i < encryptedText.Count(); i++)
            {
                for (int j = 0; j < tmpsAlphabet.Count; j++)
                {
                    if (encryptedText[i] == tmpsAlphabet[j].Key)
                    {
                        if ((j - key) >= (tmpsAlphabet.Count - tmpsAlphabet.Count))
                            decryptedText += tmpsAlphabet[j - key].Key;
                        else
                        {
                            decryptedText += tmpsAlphabet[tmpsAlphabet.Count - (key - j)].Key;
                        }
                    }
                }
                //Console.WriteLine($"{encryptedText[i]} -> {decryptedText[i]}");
            }

            //Console.WriteLine($"Decrypted text: {decryptedText}");

            List<Pair> symbolCounts = new List<Pair>();
            //for (int i = 0; i < decryptedText.Length; i++)
            //{
            //    for (int j = 0; j < alphabet.Count; j++)
            //    {
            //        if (symbolCounts.Count() < alphabet.Count)
            //            symbolCounts.Add(new Pair(alphabet[j].Key, 0.0f));
            //        if (decryptedText[i] == alphabet[j].Key)
            //        {
            //            symbolCounts[j].Value++;
            //        }
            //    }
            //}


            for(int i = 0; i < alphabet.Count; i++)
            {
                symbolCounts.Add(new Pair(alphabet[i].Key, decryptedText.Where(x => x == alphabet[i].Key).Count()));
            }
            //var counts = decryptedText.Where(x => x == alphabet[0].Key).Count();




            //List<Pair> symbolProbability = new List<Pair>();
            float difference = 0.0f;
            for (int i = 0; i < symbolCounts.Count; i++)
            {
                //symbolProbability.Add(new Pair(symbolCounts[i].Key, MathF.Round(symbolCounts[i].Value / decryptedText.Length, 3)));
                difference += MathF.Pow(MathF.Round(symbolCounts[i].Value / decryptedText.Length, 3) - alphabet[i].Value, 2);

            }

            differences.Add(difference);

            decryptedTexts.Add(decryptedText);

            decryptedText = "";
            tmp = 0;
        }



        Console.WriteLine();
        Console.WriteLine("Alphabet:");
        EchoAlphabetTable(randomizedAlphabet, key);
        Console.WriteLine();
        Console.WriteLine($"Decrypted text: {decryptedTexts[differences.IndexOf(differences.Min())]}");
        Console.WriteLine();
        Console.WriteLine($"Min W: {differences.Min()}\r\nSequence:{ToText(perm.ElementAt(differences.IndexOf(differences.Min())).ToList())}");
        Console.WriteLine();

    });

    thread.Start();

    int tmp = 0;
    while(thread.IsAlive)
    {
        
        //Console.Write("Decryption");

        do { Console.Write("\b \b"); } while (Console.CursorLeft > 0);
        
        
        Console.Write("Decryption" + new string('.', tmp));
        

        tmp++;

        if (tmp == 4)
            tmp = 0;
        Thread.Sleep(1500);
    }
}

string ToText(List<Pair> seq)
{
    string text = "";
    foreach (var item in seq)
        text += item.Key;

    return text;

}
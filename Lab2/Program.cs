using System.Globalization;
using System.Text;

List<int> controls = new List<int>();
for (int i = 0; i < 32; i++)
    controls.Add(i);
controls.Add(127);

List<char> alphabet = new List<char>();

Console.WriteLine("Fixed alphabet");
for (int i = 0; i < 127; i++)
{
    var tmp = controls.Where(x => x == i);
    if (tmp != null && tmp.Count() != 0)
        continue;
    else
    {
        Console.Write((char)i);
        alphabet.Add((char)i);
    } 
}
Console.WriteLine();

List<char> randomizedAlphabet = new List<char>(alphabet);
string alphabetToFile = "";
Random rand = new Random();

Console.WriteLine("Moving alphabet");
for(int i = 0; i < randomizedAlphabet.Count; i++)
{
    int j = rand.Next(i + 1);
    var tmp = randomizedAlphabet[j];
    randomizedAlphabet[j] = randomizedAlphabet[i];
    randomizedAlphabet[i] = tmp;
}

foreach(var item in randomizedAlphabet)
{
    Console.Write(item);
    alphabetToFile += item;
}

//Console.WriteLine("Number\t->\tFixed\t->\tMoving");
//for(int i = 0; i < alphabet.Count; i++)
//{
//    Console.WriteLine($"{i}\t->\t{alphabet[i]}\t->\t{randomizedAlphabet[i]}");
//}


Console.WriteLine();

File.WriteAllText("Resources/Alphabet.txt", alphabetToFile, Encoding.ASCII);

int swit = -1;
while(true)
{
    Console.WriteLine("Choose option: 0 - exit; 1 - encrypt -> decrypt");
    try
    {
        swit = Int32.Parse(Console.ReadLine());
    }
    catch(Exception ex)
    {
        Console.WriteLine("Type some number!"); 
    }

    switch(swit)
    {
        case -1: break;
        case 0: break;
        default: Console.WriteLine("Type some correct number!"); break;
        case 1: EncryptDecrypt(alphabet, randomizedAlphabet); break;
    }

    if (swit == 0)
        break;
}

int InputNumber(string text)
{
    int number = 0;
    while (true)
    {
        try
        {
            Console.Write(text);
            number = Int32.Parse(Console.ReadLine());
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Type some number!");
        }
    }
    return number;
}

bool CheckText(string text, List<char> alphabet)
{
    bool checker = false; ;
    foreach(var symbol in text)
    {
        checker = false;
        foreach(var letter in alphabet)
        {
            if (symbol == letter)
            {
                checker = true;
                break;
            }
        }
    }
    return checker;
}

void EncryptDecrypt(List<char> alphabet, List<char> randomizedAlphabet)
{
    int initialShift = InputNumber("Initial shift: ");
    int periodicIncrement = InputNumber("Periodic increment: ");
    int periods = 0;
    
    string text = "";
    while(true)
    {
        Console.Write("Text to encrypt: ");
        text = Console.ReadLine();
        if (!CheckText(text, alphabet))
            Console.WriteLine("Enter the text whose characters are contained in the alphabet!");
        else
            break;
    }

    Console.WriteLine("Encryption...");

    string encryptedText = "";
    var tmp = 0;
    for(int i = 0; i < text.Length; i++)
    {
        for(int j = 0; j < alphabet.Count; j++)
        {
            if (text[i] == alphabet[j])
            {
                if((j+initialShift + (periodicIncrement * periods)) > randomizedAlphabet.Count - 1)
                {
                    //encryptedText += randomizedAlphabet[j%(initialShift + (periodicIncrement * periods))];
                    tmp = randomizedAlphabet.Count  - j;
                    encryptedText += randomizedAlphabet[initialShift + (periods * periodicIncrement) - tmp];
                    //Console.WriteLine($"{alphabet[j]}[{j}] -> {randomizedAlphabet[j % (initialShift  + (periodicIncrement * periods))]}[{j % (initialShift + (periodicIncrement * periods))}]; Period: {periods}; Shift: {initialShift + ((periodicIncrement * periods))}");
                    Console.WriteLine($"{alphabet[j]}[{j}]\t ->\t {randomizedAlphabet[initialShift + (periods * periodicIncrement) - tmp]}[{initialShift + (periods * periodicIncrement) - tmp}];\t Period: {periods};\t Shift: {initialShift + ((periodicIncrement * periods))}");

                }
                else
                {
                    encryptedText += randomizedAlphabet[j + initialShift + (periodicIncrement * periods)];
                    Console.WriteLine($"{alphabet[j]}[{j}]\t ->\t {randomizedAlphabet[j + initialShift + (periodicIncrement * periods)]}[{j + initialShift + (periodicIncrement * periods)}];\t Period: {periods};\t Shift: {initialShift + ((periodicIncrement * periods))}");

                }


                periods++;
            }
        }
    }

    Console.WriteLine(encryptedText);

    Console.WriteLine("Decryption...");

    var decryptedText = "";
    tmp = 0;
    periods = 0;

    for (int i = 0; i < text.Length; i++)
    {
        for (int j = 0; j < alphabet.Count; j++)
        {
            if (encryptedText[i] == randomizedAlphabet[j])
            {
                if ((j - initialShift - (periodicIncrement * periods)) < alphabet.Count - alphabet.Count)
                {
                    //encryptedText += randomizedAlphabet[j%(initialShift + (periodicIncrement * periods))];
                    //tmp = alphabet.Count - j;s
                    //decryptedText += alphabet[initialShift + (periods * periodicIncrement) - tmp];
                    //Console.WriteLine($"{alphabet[j]}[{j}] -> {randomizedAlphabet[j % (initialShift  + (periodicIncrement * periods))]}[{j % (initialShift + (periodicIncrement * periods))}]; Period: {periods}; Shift: {initialShift + ((periodicIncrement * periods))}");
                    tmp = initialShift + (periods * periodicIncrement) - j;
                    decryptedText += alphabet[alphabet.Count - tmp];
                    Console.WriteLine($"{randomizedAlphabet[j]}[{j}]\t ->\t {alphabet[alphabet.Count - tmp]}[{alphabet.Count - tmp}];\t Period: {periods};\t Shift: {initialShift + ((periodicIncrement * periods))}");

                }
                else
                {
                    decryptedText += alphabet[j - initialShift - (periodicIncrement * periods)];
                    Console.WriteLine($"{randomizedAlphabet[j]}[{j}]\t ->\t {alphabet[j - initialShift - (periodicIncrement * periods)]}[{j - initialShift - (periodicIncrement * periods)}];\t Period: {periods};\t Shift: {initialShift + ((periodicIncrement * periods))}");

                }


                periods++;
            }
        }
    }

    Console.WriteLine(decryptedText);

}



﻿

using Lab4;
using System.Text;

int bitDepth1 = 13;
int bitDepth2 = 19;

int ticks1 = 19;
int ticks2 = 32;

int block = 32;

LinearFeedbackShiftRegister LFSR1 = new LinearFeedbackShiftRegister(bitDepth1, true);
LinearFeedbackShiftRegister LFSR2 = new LinearFeedbackShiftRegister(bitDepth2, false);

List<int> sequence1 = new List<int>();
List<int> sequence2 = new List<int>();


List<int> TextToBinary(string text)
{
    var binaries = new List<int>();

    foreach (var s in text)
    {
        var tmp = Convert.ToString(s, 2);
        tmp = "0" + tmp;
        if (tmp.Length < 8)
            tmp = "0" + tmp;
        foreach (var item in tmp)
            binaries.Add(Int32.Parse(item.ToString()));

    }

    return binaries;
}

string BinaryToText(List<int> binaries)
{
    string str = "";
    string tmp = "";

    for(int i = 0; i < binaries.Count + 1; i++)
    {
        if (i % 8 == 0 && i != 0)
        {
            str += (char)Convert.ToInt32(tmp, 2);
            tmp = "";
        }
        if(i < binaries.Count)
            tmp += binaries[i];
    }

    return str;
}

List<int> NextSequence(List<int> sequence, LinearFeedbackShiftRegister LFSR, int ticks, bool isClear)
{
    if(isClear)
        sequence.Clear();
    for (int i = 0; i < ticks; i++)
    {
        sequence.Add(LFSR.Tick());
    }
    return sequence;
}

int Xor(int a, int b)
{
    if ((a == 0 && b == 1) || (a == 1 && b == 0)) return 1;
    else return 0;
}


//while (true)
//{
//    for (int i = 0; i < ticks1; i++)
//    {
//        tmp1.Add(LFSR1.Tick());
//    }

//    foreach (var item in tmp1)
//        Console.Write(item);
//    Console.WriteLine();
//    tmp1.Clear();
//}


//for (int i = 0; i < ticks2; i++)
//{
//    tmp2.Add(LFSR2.Tick());
//}

void EncryptDecrypt()
{
    string text = "";

    Console.Write("Enter text to decrypt/encrypt: ");
    text = Console.ReadLine();

    List<int> textBinary = TextToBinary(text);
    Console.WriteLine("Iteration of the first LFSR: ");
    for (int i = 0; i < (int)Math.Floor((double)textBinary.Count / block) + 1; i++)
    {
        NextSequence(sequence1, LFSR1, ticks1, true);

        LFSR2.SetCondition(sequence1);

        NextSequence(sequence2, LFSR2, ticks2, false);

        foreach (var item in sequence1)
            Console.Write(item);
        Console.WriteLine();
    }



    Console.Write("Gamma of the text: ");
    foreach (var item in sequence2)
        Console.Write(item);
    Console.WriteLine();

    Console.Write("Text in binary code: ");
    foreach (var t in textBinary)
        Console.Write(t);
    Console.WriteLine();

    List<int> encryptedTextBinary = new List<int>();
    for (int i = 0; i < textBinary.Count; i++)
    {
        encryptedTextBinary.Add(Xor(textBinary[i], sequence2[i]));
    }

    Console.Write("Encrypted text in binary code: ");
    foreach (var item in encryptedTextBinary)
        Console.Write(item);
    Console.WriteLine();

    Console.Write("Encrypted text: ");
    string encryptedText = BinaryToText(encryptedTextBinary);
    Console.WriteLine(encryptedText);

    List<int> decryptedTextBinary = new List<int>();
    for (int i = 0; i < encryptedTextBinary.Count; i++)
    {
        decryptedTextBinary.Add(Xor(encryptedTextBinary[i], sequence2[i]));
    }

    Console.Write("Decrypted text in binary code: ");
    foreach (var item in decryptedTextBinary)
        Console.Write(item);
    Console.WriteLine();

    Console.Write("Decrypted text: ");
    string decryptedText = BinaryToText(decryptedTextBinary);
    Console.WriteLine(decryptedText);
    Console.WriteLine();
}

int swit = -1;

while (swit != 0)
{
    swit = -1;
    try
    {
        Console.WriteLine("Choose option: 0 - exit; 1 - encrypt/decrypt");
        swit = Int32.Parse(Console.ReadLine());
    }
    catch (Exception ex)
    { Console.WriteLine("Type some number!"); }

    switch (swit)
    {
        case 0: break;
        case -1: break;
        default: Console.WriteLine("Type some correct number!"); break;
        case 1: EncryptDecrypt(); break;
    }

    if (swit == 0) break;
}
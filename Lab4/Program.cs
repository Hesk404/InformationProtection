

using Lab4;
using System.Text;

int bitDepth1 = 13;
int bitDepth2 = 19;

int ticks1 = 19;
int ticks2 = 32;

LinearFeedbackShiftRegister LFSR1 = new LinearFeedbackShiftRegister(bitDepth1, true);
LinearFeedbackShiftRegister LFSR2 = new LinearFeedbackShiftRegister(bitDepth2, false);

List<int> tmp1 = new List<int>();
List<int> tmp2 = new List<int>();
//while (true)
//{
    for (int i = 0; i < ticks1; i++)
    {
        tmp1.Add(LFSR1.Tick());
    }

//    foreach (var item in tmp1)
//        Console.Write(item);
//    Console.WriteLine();
//    tmp1.Clear();
//}

LFSR2.SetCondition(tmp1);
for (int i = 0; i < ticks2; i++)
{
    tmp2.Add(LFSR2.Tick());
}


foreach (var item in tmp1)
    Console.Write(item);
Console.WriteLine();
foreach (var item in tmp2)
    Console.Write(item);
Console.WriteLine();

string str = "test";
List<string> text = new List<string>();

foreach (var s in str)
{
    var tmp = Convert.ToString(s, 2);
    text.Add("0");
    foreach (var symbol in tmp)
        text.Add(symbol.ToString());
    //tmp = "0" + tmp;
    //text.Add(tmp);
}

if(text.Count < tmp2.Count)
{
    text.Add("1");
    while(text.Count != tmp2.Count)
    {
        text.Add("0");
    }
}

foreach(var t in text)
    Console.Write(t);
Console.WriteLine();

List<string> encryptedText = new List<string>();
for(int i = 0; i < tmp2.Count; i++)
{
    encryptedText.Add(Xor(tmp2[i], Convert.ToInt32(text[i])).ToString());
}


List<string> encryptedStrings = new List<string>();
string tmpStr = "";
for(int i = 0; i < encryptedText.Count; i++)
{
    Console.Write(encryptedText[i]);
    tmpStr += encryptedText[i];
    if((i+1)%8 == 0)
    {
        Console.Write(" ");
        encryptedStrings.Add(tmpStr);
        tmpStr = "";
    }
        
}

Console.WriteLine();

string resultEncrypt = BinaryToText(encryptedStrings);
Console.WriteLine(resultEncrypt);

List<string> decryptedText = new List<string>();
for (int i = 0; i < tmp2.Count; i++)
{
    decryptedText.Add(Xor(tmp2[i], Convert.ToInt32(encryptedText[i])).ToString());
}

List<string> decryptedStrings = new List<string>();
tmpStr = "";
for (int i = 0; i < decryptedText.Count; i++)
{ 
    Console.Write(decryptedText[i]);
    tmpStr += decryptedText[i];
    if((i+1)%8 == 0)
    {
        Console.Write(" ");
        decryptedStrings.Add(tmpStr);
        tmpStr = "";
    }

}

Console.WriteLine();

string resultDecrypt = BinaryToText(decryptedStrings);

Console.WriteLine(resultDecrypt);

string BinaryToText(List<string> strings)
{
    return new string(strings.Select(x => x).Select(c => (char)(Convert.ToInt32(c, 2))).ToArray());
}

int Xor(int a, int b)
{
    if ((a == 1 && b == 0) || (a == 0 && b == 1)) return 1;
    else return 0;
}
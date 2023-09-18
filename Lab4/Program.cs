

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
    tmp2.Add(LFSR2.TickFromCondition());
}


foreach (var item in tmp1)
    Console.Write(item);
Console.WriteLine();
foreach (var item in tmp2)
    Console.Write(item);
Console.WriteLine();

string str = "test";
List<int> text = new List<int>();

foreach (var s in str)
{
    var tmp = Convert.ToString(s, 2);
    tmp = "0" + tmp;
    text.Add(Convert.ToInt32(tmp));
}

foreach(var t in text)
    Console.Write(t);
Console.WriteLine();


*
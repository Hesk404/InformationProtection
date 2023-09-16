

using Lab4;


int bitDepth1 = 13;
int bitDepth2 = 19;

LinearFeedbackShiftRegister LFSR = new LinearFeedbackShiftRegister(bitDepth1);
List<int> tmp = new List<int>();
while (true)
{
    for (int i = 0; i < 20; i++)
    {
        tmp.Add(LFSR.Tick());
    }

    foreach (var item in tmp)
        Console.Write(item);
    Console.WriteLine();
    tmp.Clear();
}


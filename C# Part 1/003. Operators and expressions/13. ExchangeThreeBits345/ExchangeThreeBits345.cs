using System;

class ExchangeThreeBits345
{
    /*Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.
    */
    static void Main()
    {
        //integer input (appropriate number to easily test the program is 50389032)
        uint num;
        do
        {
            Console.Write("Please enter an integer: ");
        }
        while (!uint.TryParse(Console.ReadLine(), out num));

        //extract initial bits
        uint juniorMask = 7 << 3;
        uint juniorThreeBits = num & juniorMask;

        uint seniorMask = 7 << 23;
        uint seniorThreeBits = num & seniorMask;

        //set bits 3, 4, 5, 24, 25, 26 to zero values
        uint zeroMask = (7 << 3) | (7 << 23);
        uint zeroNum = num & ~zeroMask;

        //exchange bits
        uint result = zeroNum | juniorThreeBits << 21;
        result |= seniorThreeBits >> 21;

        //output
        Console.WriteLine("{0}  Initial number = {1}", Convert.ToString(num, 2).PadLeft(32, '0'), num);
        Console.WriteLine("{0}  Exchanged bits number = {1}", Convert.ToString(result, 2).PadLeft(32, '0'), result);
    }
}


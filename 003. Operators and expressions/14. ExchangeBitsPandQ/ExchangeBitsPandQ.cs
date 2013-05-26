using System;

class ExchangeBitsPandQ
{
    /** Write a program that exchanges bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.
    */
    static void Main()
    {
        //integer input (appropriate number to easily test the program is 50389032 with k = 3, p = 3, q = 24)
        uint num;
        do
        {
            Console.WriteLine("Please enter an integer: ");
        }
        while (!uint.TryParse(Console.ReadLine(), out num));

        //k input (the number of bits in a set to exchange)
        uint bitCount;
        do
        {
            Console.WriteLine("Please enter the number \"k\" of bits in \na set to exchange [0..31]: ");
        }
        while (!uint.TryParse(Console.ReadLine(), out bitCount) || bitCount < 0 || bitCount > 31);
        
        //p input (junior start position)
        int pPos;
        do
        {
            Console.WriteLine("Please enter a position \"p\" for junior set of bits \nto start from [0 ..31-(number in a set)]: ");
        }
        while (!int.TryParse(Console.ReadLine(), out pPos) || (bitCount + pPos) > 31);

        //q input (senior start position)
        int qPos;
        do
        {
            Console.WriteLine("Please enter a position \"q\" for senior set of bits \nto start from [p ..31-(number in a set)]: ");
        }
        while (!int.TryParse(Console.ReadLine(), out qPos) || qPos < pPos || (bitCount + qPos) > 31);

        //extract junior initial set of bits
        uint juniorSetOfBits = 0;
        for (int i = pPos; i < pPos + bitCount; i++)
        {
            uint juniorMask = 1U << i;
            uint tempJuniorBit = num & juniorMask;
            juniorSetOfBits |= tempJuniorBit;
        }

        //extract senior initial set of bits
        uint seniorSetOfBits = 0;
        for (int i = qPos; i < qPos + bitCount; i++)
        {
            uint seniorMask = 1U << i;
            uint tempSeniorBit = num & seniorMask;
            seniorSetOfBits |= tempSeniorBit;
        }

        //set bits due to be exchanged to zero values
        uint zeroMask = 0;
        for (int i = pPos; i < pPos + bitCount; i++)
        {
            zeroMask = zeroMask | 1U << i;
        }

        for (int i = qPos; i < qPos + bitCount; i++)
        {
            zeroMask |= 1U << i;
        }

        uint zeroNum = num & ~zeroMask;
       
        //exchange bits
        uint result = zeroNum | juniorSetOfBits << (qPos - pPos);
        result |= seniorSetOfBits >> (qPos - pPos);

        //output
        Console.WriteLine("{0}  Initial number = {1}", Convert.ToString(num, 2).PadLeft(32, '0'), num);
        Console.WriteLine("{0}  Exchanged bits number = {1}", Convert.ToString(result, 2).PadLeft(32, '0'), result);
    }
}


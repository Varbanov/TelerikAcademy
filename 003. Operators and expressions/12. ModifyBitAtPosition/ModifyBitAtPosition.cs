using System;

class ModifyBitAtPosition
{
    /*We are given integer number n, value v (v=0 or 1) and a position p. Write a sequence of operators that
     * modifies n to hold the value v at the position p from the binary representation of n.
    */
    static void Main()
    {
        //integer input
        int num;
        do
        {
            Console.Write("Please enter an integer: ");
        } 
        while (!int.TryParse(Console.ReadLine(), out num));

        //value input
        int value;
        do
        {
            Console.Write("Please enter a bit value ( 0 or 1): ");
        }
        while (!int.TryParse(Console.ReadLine(), out value) || (value != 0 && value != 1));

        //position input
        int position;
        do
        {
            Console.Write("Please enter a bit position[0.. 31]): ");
        }
        while (!int.TryParse(Console.ReadLine(), out position) || position > 31 || position < 0);

        //solution
        int result;
        if (value == 0)
        {
            int mask = ~(1 << position);
            result = num & mask;
        }
        else
        {
            int mask = 1 << position;
            result = num | mask;
        }
        
        //output
        Console.WriteLine("{0}  Initial number = {1}", Convert.ToString(num, 2).PadLeft(32, '0'), num);
        Console.WriteLine("{0}  Number after modification = {1}", Convert.ToString(result, 2).PadLeft(32, '0'), result);
    }
}


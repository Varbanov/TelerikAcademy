using System;
using System.Text;

class CovertFloatToBin
{
    // 09.*Write a program that shows the internal binary representation of given 32-bit signed floating-point number in 
    //IEEE 754 format (the C# type float). Example: -27,25  sign = 1, exponent = 10000011, mantissa = 101 1010 0000 0000 0000 0000.
    //converts floating point number to hex 

    public static string ExtractBytesAsArray(float num)
    {
      //A method to extract the bytes of a float in a hex format
        byte[] arr = BitConverter.GetBytes(num);
        //The order of bytes in the array returned by the GetBytes method depends on whether
        //the computer architecture is little-endian or big-endian. (Google it or MSDN it)
        Array.Reverse(arr);
        //convert to hex
        string result = BitConverter.ToString(arr);
        return result;
    }

    public static void Main()
    {
        //data input
        Console.Write("Enter 32-bit floating point number: ");
        float num = float.Parse(Console.ReadLine());
        //extract hex bytes
        string hexResult = ExtractBytesAsArray(num);
        StringBuilder binResult = new StringBuilder();

        //convert hex to bin
        for (int i = 0; i < hexResult.Length; i++)
        {
            switch (hexResult[i])
            {
                case '0':
                    binResult.Append("0000");
                    break;
                case '1':
                    binResult.Append("0001");
                    break;
                case '2':
                    binResult.Append("0010");
                    break;
                case '3':
                    binResult.Append("0011");
                    break;
                case '4':
                    binResult.Append("0100");
                    break;
                case '5':
                    binResult.Append("0101");
                    break;
                case '6':
                    binResult.Append("0110");
                    break;
                case '7':
                    binResult.Append("0111");
                    break;
                case '8':
                    binResult.Append("1000");
                    break;
                case '9':
                    binResult.Append("1001");
                    break;
                case 'A':
                case 'a':
                    binResult.Append("1010");
                    break;
                case 'B':
                case 'b':
                    binResult.Append("1011");
                    break;
                case 'C':
                case 'c':
                    binResult.Append("1100");
                    break;
                case 'D':
                case 'd':
                    binResult.Append("1101");
                    break;
                case 'E':
                case 'e':
                    binResult.Append("1110");
                    break;
                case 'F':
                case 'f':
                    binResult.Append("1111");
                    break;
            }
        }

        //data output
        Console.Write("Result: ");
        Console.Write(binResult[0] + " ");
        for (int i = 1; i <= 8; i++)
        {
            Console.Write(binResult[i]);
        }
        Console.Write(" ");
        for (int i = 9; i < binResult.Length; i++)
		{
			 Console.Write(binResult[i]);
		}
        Console.WriteLine();
    }
}
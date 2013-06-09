using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 class DancingBits
 {
     static void Main()
     {
         int k = int.Parse(Console.ReadLine());
         int n = int.Parse(Console.ReadLine());
         int[] nums = new int[n];
         for (int i = 0; i < n; i++)
         {
             nums[i] = int.Parse(Console.ReadLine());
         }

         StringBuilder concat = new StringBuilder();
         
         for (int i = 0; i < n; i++)
         {
             int bitCheckMask = 1 << 30;
             while ((bitCheckMask & nums[i]) == 0)
             {
                 bitCheckMask >>= 1;
             }

             while (bitCheckMask >= 1)
             {
                 int tempBit = bitCheckMask & nums[i];
                 while (tempBit != 0 && tempBit != 1)
                 {
                     tempBit >>= 1;
                 }
                 concat.Append(tempBit.ToString());
                 bitCheckMask >>= 1;
             } 
         }

         int danceCounter = 0;
         for (int i = 0; i <= concat.Length - k; i++)
         {
             int maxLimit = i + k;
             bool isDancing = true;
             for (int j = i + 1; j < maxLimit; j++)
             {
                 if (concat[i] != concat[j])
                 {
                     isDancing = false;
                     break;
                 }
             }
             //beginning
             if (i > 0 && concat[i - 1] == concat[i] && k != concat.Length)
             {
                 isDancing = false;
             }
             //end
             if (maxLimit < concat.Length && concat[maxLimit] == concat[i] && k != concat.Length)
             {
                 isDancing = false;
             }
             // all 1111... and k = concat.length

             if (isDancing)
             {
                 danceCounter += 1;
             }

         }
         if (k == 1 && concat[concat.Length - 1] != concat[concat.Length - 2])
         {
             danceCounter += 1;
         }

         //Console.WriteLine(concat);
         Console.WriteLine(danceCounter);
     }
 }


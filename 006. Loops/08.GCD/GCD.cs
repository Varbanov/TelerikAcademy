using System;

   class GCD
   {
       //Write a program that calculates the greatest common divisor (GCD) of given two numbers.
       //Use the Euclidean algorithm (find it in Internet).

       /*Subtracting a small positive number from a big number enough times until what is left is
        * less than the original smaller number can be replaced by finding the remainder in long division.
        * Thus the division form of Euclid's algorithm starts with a pair of positive integers and forms a
        * new pair that consists of the smaller number and the remainder obtained by dividing the larger number
        * by the smaller number. The process repeats until one number is zero. The other number then is the greatest
        * common divisor of the original pair.
        */ 
       static void Main()
       {
           //input
           int firstNum;
           int secondNum;
           do
           {
               Console.Write("Please enter first integer [1...]: ");
           } while (!int.TryParse(Console.ReadLine(), out firstNum) || firstNum < 1);

           do
           {
               Console.Write("Please enter second integer [1...]: ");
           } while (!int.TryParse(Console.ReadLine(), out secondNum) || secondNum < 1);

           //ensure firstNum is always the bigger to start with
           if (firstNum < secondNum)
           {
               int temp;
               temp = firstNum;
               firstNum = secondNum;
               secondNum = temp;
           }
           //solution
           int result;
           while (firstNum != 0 && secondNum != 0)
           {
               firstNum = firstNum % secondNum;
               if (firstNum != 0)
               {
                   secondNum = secondNum % firstNum;
               }
           }
           result = firstNum == 0 ? secondNum : firstNum;
           Console.WriteLine("The greatest common divisor is: {0}", result);
       }
   }


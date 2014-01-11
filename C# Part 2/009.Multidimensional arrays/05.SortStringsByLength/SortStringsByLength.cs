using System;

class SortStringsByLength
{
    //You are given an array of strings. Write a method that sorts the array
    //by the length of its elements (the number of characters composing them).

    static void Main()
    {
        string[] arr = { "esf", "df", "fdftf", "ffff" };
        //use reg ex to change comparisson criteria
        Array.Sort(arr, (x, y) => (x.Length.CompareTo(y.Length)));
        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
    }
}

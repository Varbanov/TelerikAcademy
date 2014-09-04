namespace _11.LinkedListImplementation
{
    using System;
    class LinkedListEntryPoint
    {
        //11.Implement the data structure linked list. Define a class ListItem<T>that has two fields: 
        //value(of type T) and NextItem(of type ListItem<T>). Define additionally a class LinkedList<T>
        //with a single field FirstElement(of type ListItem<T>).

        static void Main()
        {
            LinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < 20; i++)
            {
                list.AddLast(i);
            }

            list.AddFirst(-100);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}

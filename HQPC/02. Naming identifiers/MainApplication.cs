using System;

class MainApplication
{
    const int MAX_COUNT = 6;
	
    class NestedClass
    {
        public void WriteBoolValueInConsole(bool value)
        {
            string valueAsString = value.ToString();
            Console.WriteLine(value);
        }
    }
	
    //public static void Main()
    //{
    //    MainApplication.NestedClass nestedClass =
    //      new MainApplication.NestedClass();
    //    nestedClass.WriteBoolValueInConsole(true);
    //}
}

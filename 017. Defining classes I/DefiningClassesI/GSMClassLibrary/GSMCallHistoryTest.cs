using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMClassLibrary
{
    public class GSMCallHistoryTest
    {
        /*Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
        Create an instance of the GSM class.
        Add few calls.
        Display the information about the calls.
        Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
        Remove the longest call from the history and calculate the total price again.
        Finally clear the call history and print it.
         * */
        public static void Test()
        {
            GSM gsm = new GSM("nokia", "lumia");
            gsm.AddCall(new Call(DateTime.Now, "+359 898 898 898", 56));
            gsm.AddCall(new Call(DateTime.Now, "+359 898 898 898", 44));

            decimal price = gsm.CalcPrice(0.37m);
            Console.WriteLine(price);

            //remove longest

            //clear history
            //gsm.ClearCallHistory();
            foreach (var item in gsm.CallHistory)
            {
                Console.WriteLine(item.ToString());
            }

        }


    }
}

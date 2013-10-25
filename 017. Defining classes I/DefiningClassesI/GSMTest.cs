using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSMClassLibrary;

class GSMTest
{
    static void Main()
    {
        GSM gsm = new GSM("nokia", "nokiaman");
        GSM gsm1 = new GSM("nokia", "nok", 9.5m);
        Battery bat = new Battery("monbat", 500, 100, BatteryType.NiMH);
        Display dis = new Display(null, 256);

        GSM gsm2 = new GSM("erik", "erik", bat);
        GSM gsm3 = new GSM("koko", "ka", dis);

        Console.WriteLine(gsm.ToString());
        Console.WriteLine("-----");
        Console.WriteLine(gsm1.ToString());
        Console.WriteLine("-----");
        Console.WriteLine(gsm2.ToString());
        Console.WriteLine("-----");
        Console.WriteLine(gsm3.ToString());

        Console.WriteLine("---------------------------");

        GSM p = GSM.IPhone4S;
        p.Owner = "pesho";
        p.Battery = bat;
        Console.WriteLine(p.ToString());

        GSMCallHistoryTest.Test();




    }
}


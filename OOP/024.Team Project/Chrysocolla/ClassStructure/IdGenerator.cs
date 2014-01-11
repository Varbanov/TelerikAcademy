using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimberYardSoft.ClassStructure
{
    public static class IdGenerator
    {
        //false == unoccupied
        private static Dictionary<int, bool> id = new Dictionary<int,bool>();

        static IdGenerator()
        {
            for (int i = 1; i < 10000; i++)
            {
                id.Add(i, false);
            }
        }

        public static int GetId()
        {
            //find first unoccupied number, set it to occupied and return it
            for (int i = 1; i < int.MaxValue; i++)
            {
                if (id[i] == false)
                {
                    id[i] = true;
                    return i;
                }
            }

            throw new OverflowException("All possible unique id numbers are in use! Please first dispose an item off");
        }

        public static void DisposeId(int idNum)
        {
            //call the method to set an id to unoccupied, when the object which holds it is disposed.
            id[idNum] = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesII.Generics
{
    class GenericListMinMax
    {
        //Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element 
        //in the  GenericList<T>. You may need to add a generic constraints for the type T.

        public static T Min<T>(GenericList<T> genericList)
            where T: IComparable<T> //in order to use object.CompareTo(T)
        {
            T min = genericList[0];
            for (int i = 1; i < genericList.Count; i++)
            {
                if (genericList[i].CompareTo(min) < 0)
                {
                    min = genericList[i];
                }
            }
            return min;
        }

        public static T Max<T>(GenericList<T> genericList)
            where T : IComparable<T> //in order to use object.CompareTo(T)
        {
            T max = genericList[0];
            for (int i = 1; i < genericList.Count; i++)
            {
                if (genericList[i].CompareTo(max) > 0)
                {
                    max = genericList[i];
                }
            }
            return max;
        }


    }
}

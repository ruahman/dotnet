using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class SelectionSort
    {
        public static int[] Sort(int[] arr)
        {
            int unsortedIdx;
            int minIndex;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                minIndex = i;
                for (unsortedIdx = i + 1; unsortedIdx < arr.Length; unsortedIdx++)
                {
                    // found new minValue from unsorted side
                    if (arr[unsortedIdx] < arr[minIndex])
                    {
                        minIndex = unsortedIdx;
                    }
                }
                // swap new minimum, otherwise leave it as it
                if (minIndex != i)
                {
                    int temp = arr[minIndex];
                    arr[minIndex] = arr[i];
                    arr[i] = temp;
                }
            }
            return arr;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmBasicLearn
{
    public class BasicSearch
    {
        public static int SeqSearch(int[] s, int n, int key) 
        {
            int i;
            for (i = 0; i < n && s[i] != key; i++) 
            {

            }
            if (i < n) { return i; }
            else { return -1; }
        }

        public static int  BinarySearch(int[] s,int n,int key)
        {
            int low, high, mid;
            low = 0;
            high = n - 1;
            while (low <= high) 
            {
                mid = (low + high) / 2;
                if (s[mid] == key) 
                {
                    return mid;
                }
                else if (s[mid] > key)
                {
                    high = mid - 1;
                }
                else 
                {
                    low = mid + 1;
                }
            }
            return -1;
        }
    }
}

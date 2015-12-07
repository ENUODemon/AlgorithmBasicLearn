using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmBasicLearn
{
    public static class BasicSort
    {
        //冒泡排序,注释部分为改进算法
        public static int[] BubbleSort(int[] lists)
        {

            int length = lists.Length;
            int temp = 0;
            for (int i = 0; i < length; i++)
            {
                // bool flag = false;
                for (int j = length - 1; j > 0; j--)
                {
                    if (lists[j] < lists[j - 1])
                    {
                        temp = lists[j - 1];
                        lists[j - 1] = lists[j];
                        lists[j] = temp;

                        //    flag = true;
                    }
                }
                //if (flag == false)
                //{
                //    return lists;
                //}
            }

            return lists;
        }

        //简单选择排序
        public static int[] SelectSort(int[] a)
        {
            int n = a.Length;
            int min = 0;
            int temp = 0;
            for (int i = 0; i < n; i++)
            {
                min = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (a[j] < a[min])
                    {
                        temp = a[min];
                        a[min] = a[j];
                        a[j] = temp;
                    }
                }

            }
            return a;

        }
        //直接插入排序
        public static int[] StrainghtInsertSort(int[] a)
        {
            int n = a.Length;
            for (int i = 1; i < n; i++)
            {
                int temp = a[i];
                int j = 0;
                for (j = i - 1; a[j] > temp; j--)
                { 
                    a[j + 1] = a[j];
                }
                a[j + 1] = temp;
            }

            return a;
        }


        //快速排序
        public static int[] QuickSort(int[] arr, int left, int right) 
        {
            if (left < right) 
            {
                int i = Division(arr, left, right);

                QuickSort(arr, left, i - 1);
                QuickSort(arr, i + 1, right);
            }
            return arr;
        }

        private static int Division(int[] arr, int left, int right) 
        {
            int baseNum=arr[left];
            while(left<right)
            {
                while (left < right &&arr[right] >= baseNum) 
                {
                    right--;
                }
                arr[left] = arr[right];

                while (left < right && arr[left] <= baseNum) 
                {
                    left++;
                }
                arr[right] = arr[left];
            }
            arr[left] = baseNum;
            return left;
        }

        private static void swap(int[] arr, int pos, int offset)
        {
            int temp = arr[pos];
            arr[pos] = arr[offset];
            arr[offset] = temp;
        }
    }
}

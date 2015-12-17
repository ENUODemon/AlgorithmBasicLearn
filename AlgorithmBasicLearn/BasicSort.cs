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

        public  static int[] HeapSort(int[] a)
        {
            int t, i;
            int j;
            for (i = a.Length / 2 - 1; i >= 0; i--) 
            {
                HeapAdjust(a, i,a.Length);
            }
            for (i = a.Length - 1; i >= 0; i--) 
            {
                t = a[0];
                a[0] = a[i];
                a[i] = t;
                HeapAdjust(a, 0,i);
            }
            return a;
        }
        public static int[] ShellSort(int[] a, int n)
        {
            int d, i, j, x;
            d = n / 2;
            while (d >= 1)
            {
                for (i = d; i < n; i++)
                {
                    x = a[i];
                    j = i - d;
                    while (j >= 0 && a[j] > x)
                    {
                        a[j + d] = a[j];
                        j = j - d;
                    }
                    a[j + d] = x;
                }
                d /= 2;
            }
            return a;

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
        private static void HeapAdjust(int[] a, int s,int n) 
        {
            int j, t;
            while (2 * s + 1 < n) 
            {
                j=2*s+1;
                if ((j + 1) < n) 
                {
                    if (a[j] < a[j + 1]) 
                    {
                        j++;
                    }
                  
                }
                if (a[s] < a[j])
                {
                    t = a[s];
                    a[s] = a[j];
                    a[j] = t;
                    s = j;
                }
                else 
                {
                    break;
                }
            }
        }

        private static void MergeStep(int[] a, int[] r, int s, int m, int n) 
        {
            int i, j, k;
            k = s;
            i = s;
            j = m + 1;
            while (i <= m && j <= n) 
            {
                if (a[i] <= a[j])
                {
                    r[k++] = a[i++];
                }
                else 
                {
                    r[k++] = a[j++];
                }
            }
            while (i <=m) 
            {
                r[k++] = a[i++];
            }
            while(j<=n)
            
            {
                r[k++]=a[j++];
            }

        }
        private static void MergePass(int[] a,int[] r,int n,int len)
        {
            int s,e;;
            s=0;
            while(s+len<n)
            {
                e=s+2*len-1;
                if(e>=n)
                {
                    e=n-1;
                }
                MergeStep(a,r,s,s+len-1,e);
                s=e+1;
            }
            if(s<n)
            {
                for(;s<n;s++)
                {
                    r[s]=a[s];
                }
            }
        }

        public static int[] MergeSort(int[] a,int n)
        {
            int[] p=new int[n];
            int len=1;
            int f=0;
            while(len<n)
            {
                if (f == 0)
                {
                    MergePass(p, a, n, len);

                }
                else 
                {
                    MergePass(a, p, n, len);
                }
                len *= 2;
                f = 1 - f;

            }
            if (f == 0) 
            {
                for (f = 0; f < n; f++) 
                {
                    a[f] = p[f];
                }
            }
            return a;
        }
    }
}

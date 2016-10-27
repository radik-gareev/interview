﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        /// <summary>
        /// Given an array with condition: an item is staying at most at k positions away from sorted order. Please sort
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] arr = new[] { 1, 3, 0, 2, 6, 7, 4, 5 };
            int k = 3;

            Sort(arr, 0, arr.Length-1);
            Console.WriteLine(string.Join(", ", arr));
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static void Sort(int[] arr, int k)
        {
            if (k > arr.Length/2)
                return;

            for (int i = 0;2*k + i<arr.Length;i++)
            {
                int leftIndex = i;
                int rightIndex = 2*k + i;
                Sort(arr, leftIndex, rightIndex);
            }
        }

        private static void Sort(int[] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int num = arr[start];

            int i = start, j = end;

            while (i < j)
            {
                while (i < j && arr[j] > num)
                {
                    j--;
                }

                arr[i] = arr[j];

                while (i < j && arr[i] < num)
                {
                    i++;
                }

                arr[j] = arr[i];
            }

            arr[i] = num;
            Sort(arr, start, i - 1);
            Sort(arr, i + 1, end);
        }

        private static void Sort2(int[] arr, int start, int end)
        {
            int pivot = arr[(start + end)/2];
            int left = start;
            int right = end;
            while (left <= right )
            {
                while (arr[left] < pivot)
                    left++;
                while (arr[right] > pivot)
                    right--;
                if (left <= right)
                {
                    int tmp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = tmp;
                    left++;
                    right--;
                }
            }

            if(start < right)
                Sort2(arr, start, right);
            if(end > left)
                Sort2(arr, left, end);
        }
    }
}

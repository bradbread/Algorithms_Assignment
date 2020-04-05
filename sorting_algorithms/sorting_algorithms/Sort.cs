using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace sorting_algorithms
{

    abstract class Sort
    {
        public List<int> numsToSort;

        public Sort(List<int> pNumsToSort)
        {
            numsToSort = pNumsToSort;
        }

        
        public abstract void SortNums();

        //for linar-search
        public void FindL(List<int> lookFor) 
        {
            int count = lookFor.Count;
            int result;
            //search for each element of the list one at a time
            for (int i = 0; i < count; i++)
            {
                //linarsearch returns -1 if not found, otherwise it returns the position the passed number was found at
                result = LinearSearch(lookFor[i]);
                if (result == -1)
                {
                    Console.WriteLine(lookFor[i] + " not found in list");
                }
                else 
                {
                    Console.WriteLine(lookFor[i] + " found at position " + result);
                }
            }
        }

        int LinearSearch(int find)
        {
            int length = numsToSort.Count;
            for (int i = 0; i < length; i++)
            {
                if (find == numsToSort[i])
                {
                    return i;
                }

            }

            return -1;
        }

        //data must be sorted first
        public void FindB(List<int> lookFor)
        {
            int count = lookFor.Count;
            int result;
            //search for each element of the list one at a time
            for (int i = 0; i < count; i++)
            {
                //linarsearch returns -1 if not found, otherwise it returns the position the passed number was found at
                result = BinarySearch(lookFor[i]);
                if (result == -1)
                {
                    Console.WriteLine(lookFor[i] + " not found in list");
                }
                else
                {
                    Console.WriteLine(lookFor[i] + " found at position " + result);
                }
            }
        }
        int BinarySearch(int find)
        {
            int max = numsToSort.Count - 1;
            int min = 0;
            while (min <= max)
            {    
                //calc mid point
                int mid = min + (max - min ) / 2;
                if (find == numsToSort[mid])
                {
                    return mid;
                }
                if (find > numsToSort[mid])
                {
                    //our number is bigger than all of these
                    min = mid + 1;
                }
                else
                {
                    //our number is smaller than all of these
                    max = mid - 1;
                }
            }
            //no matches
            return -1;
        }
        
        //used for easy checking of the sorting rather than console.writelining like 15000 entries lol
        //probably much better ways to do this search later
        public void WriteToFile(string fName)
        {
            using (StreamWriter file = new StreamWriter(fName))
            {
                foreach (int i in numsToSort)
                {
                    file.Write(i + "\n");
                }
            }


        }
    }
    class InsertionSort : Sort
    {
        public InsertionSort(List<int> pNumsToSort) : base (pNumsToSort) { }

        //made based on discriptions of insertion sort seems messy might be a better way
        public override void SortNums()
        {
            int length = numsToSort.Count;
            for (int i = 1; i < length; i++)
            {
                //last postion we swapped with will be used further down
                int lastPos = i;
                //number we are comparing
                int num = numsToSort[i];

                //deincrement through the numbers we have passed swapping smaler values
                for (int d = i - 1; d >= 0 && num < numsToSort[d]; d--)
                {
                        numsToSort[lastPos] = numsToSort[d];
                        numsToSort[d] = num;
                        lastPos = d;
                }

            }

        }
    }

    class ShellSort : Sort
    {
        public ShellSort(List<int> pNumsToSort) : base(pNumsToSort) { }
        //seems to be a few ways to tackle this one
        public override void SortNums()
        {
            int length = numsToSort.Count;
            
            /*
            there seem to be a few ways to create a sequence of gaps
            eg. this formula seems to be credited to tokuda
            a (n) = ceiling (9 * (9/4)^n - 4 / 5)
            which might create a list that looks like this
            { 1, 4, 9, 20, 46, 103, 233, 525, 1182, 2660, 5985, 13467});
            */

            //appears to be the original method of choosing gaps
            for (int gap = length / 2; gap > 0 ; gap /=2)
            {
                
                for (int i = gap; i < length; i++)
                {
                    int num = numsToSort[i];
                    int d;

                    for (d = i; d >= gap && num < numsToSort[d - gap]; d -= gap)
                    {
                        numsToSort[d] = numsToSort[d - gap];
                    }
                    numsToSort[d] = num;
                }
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.IO;

namespace sorting_algorithms
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> listNums = new List<int>();
            //trying a method to get an estimation execution-time
            var watch = System.Diagnostics.Stopwatch.StartNew();
            //read csv into a list csv file should be placed in the folder where the program has been compiled to
            //change the path to w/e is easiest
            using (var reader = new StreamReader(@"../unsorted_numbers.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    listNums.Add(Int32.Parse(line));
                }
            }

            watch.Stop();
            var timeTaken = watch.ElapsedMilliseconds;
            Console.WriteLine("time taken to create list " + timeTaken);


            //shell sort
            ShellSort sSort = new ShellSort(listNums);
            watch.Restart();
            sSort.SortNums();

            watch.Stop();
            Console.WriteLine("time taken to shellsort list " + watch.ElapsedMilliseconds);

            //uncomment if you want to output the sorted numbers to a file
            //sSort.WriteToFile(@"../shellSortedNums.csv");


            //insetionsort
            //passing arrays is ineficient right? assumtion that doing so with lists is too? search later as best way to do this in c#
            InsertionSort iSort = new InsertionSort(listNums);
            watch.Restart();
            iSort.SortNums();

            watch.Stop();
            timeTaken = watch.ElapsedMilliseconds;
            Console.WriteLine("time taken to insertionsort list " + watch.ElapsedMilliseconds);

            //uncomment if you want to write sorted list to a new csv file
            //iSort.WriteToFile(@"../isertionSortedNums.csv");
            


            List<int> searchNums = new List<int>();
            searchNums.AddRange(new int[]{ 575154, 182339, 17132, 773788, 296934, 991395, 303270,
            45231, 580, 629822});
            //linear search
            watch.Restart();
            iSort.FindL(searchNums);
            watch.Stop();
            timeTaken = watch.ElapsedMilliseconds;
            Console.WriteLine("time taken to linear search " + timeTaken);


            //binary search
            watch.Restart();
            iSort.FindB(searchNums);
            watch.Stop();
            timeTaken = watch.ElapsedMilliseconds;
            Console.WriteLine("time taken to binary search " + timeTaken);

            Console.ReadKey();
        }

    }
}

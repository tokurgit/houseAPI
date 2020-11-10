using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace NumArrayConsoleApp
{
    class Program
    {
        private static int[,] _numArr = new int[20, 20];
        private static HashSet<int> _index;
        private static int _biggestNum = _numArr[0, 0];
        private static int _smallestNum = _numArr[0, 0];
        private static int _smallestNumCoordX = 0;
        private static int _smallestNumCoordY = 0;
        private static int _biggestNumCoordX = 0;
        private static int _biggestNumCoordY = 0;
        private static int _rowLen = _numArr.GetLength(0);
        private static int _colLen = _numArr.GetLength(1);

        static void Main(string[] args)
        {
            PopulateArray();
            DisplayArrayOnScreen(_numArr);
            GetMaxMinNumsAndCoords();
            Console.WriteLine($"\nThe smallest number is {_smallestNum} ({_smallestNumCoordX},{_smallestNumCoordY}) " +
                              $"and the biggest number: {_biggestNum} ({_biggestNumCoordX},{_biggestNumCoordY})");
            var newArr = GetSortedByRow(_numArr);
            DisplayArrayOnScreen(newArr);


            //Sort the array in ascending order and display on screen




            Console.ReadKey();
        }

        static void PopulateArray()
        {
            for (int i = 0; i < _numArr.GetLength(0); i++)
            {
                for (int j = 0; j < _numArr.GetLength(1); j++)
                {
                    _numArr[i, j] = GetRandomInt();
                }
            }
        }

        static int GetRandomInt()
        {
            int nextRandomInt = new Random().Next(0, 400);
            if (CheckIfExists(nextRandomInt))
            {
                return GetRandomInt();
            }

            return nextRandomInt;
        }

        static bool CheckIfExists(int randomInt)
        {
            if (_index == null)
            {
                _index = new HashSet<int>();
                for (int i = 0; i < _numArr.GetLength(0); i++)
                {
                    for (int j = 0; j < _numArr.GetLength(1); j++)
                    {
                        _index.Add(_numArr[i, j]);
                    }
                }
            }

            return _index.Contains(randomInt);
        }

        static int[,] GetSortedByRow(int[,] m)
        {
            // loop for rows of matrix
            for (int i = 0;
                i < m.GetLength(0);
                i++)
            {

                // loop for column of matrix
                for (int j = 0;
                    j < m.GetLength(1);
                    j++)
                {

                    // loop for comparison and swapping
                    for (int k = 0;
                        k < m.GetLength(1) - j - 1;
                        k++)
                    {
                        if (m[i, k] > m[i, k + 1])
                        {

                            // swapping of elements
                            int t = m[i, k];
                            m[i, k] = m[i, k + 1];
                            m[i, k + 1] = t;
                        }
                    }
                }
            }

            return m;
        }

        static void DisplayArrayOnScreen(int[,] numArr)
        {
            for (int i = 0; i < _rowLen; i++)
            {
                for (int j = 0; j < _colLen; j++)
                {
                    int currentNum = numArr[i, j];
                    int currentNumLen = currentNum.ToString().Length;

                    if (currentNumLen == 1)
                        Console.Write($"{numArr[i, j]}   ");
                    if (currentNumLen == 2)
                        Console.Write($"{numArr[i, j]}  ");
                    if (currentNumLen == 3)
                        Console.Write($"{numArr[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        static void GetMaxMinNumsAndCoords()
        {
            for (int i = 0; i < _rowLen; i++)
            {
                for (int j = 0; j < _colLen; j++)
                {
                    int currentNum = _numArr[i, j];

                    if (currentNum > _biggestNum)
                    {
                        _biggestNum = currentNum;
                        _biggestNumCoordY = i;
                        _biggestNumCoordX = j;
                    }

                    if (currentNum < _smallestNum)
                    {
                        _smallestNum = currentNum;
                        _smallestNumCoordY = i;
                        _smallestNumCoordX = j;
                    }
                }
            }
        }
    }
}

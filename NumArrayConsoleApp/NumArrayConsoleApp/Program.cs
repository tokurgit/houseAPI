using System;
using System.Collections.Generic;

namespace NumArrayConsoleApp
{
    class Program
    {
        private static int[,] _numArr = new int[20, 20];
        private static int _smallestNum;
        private static int _smallestNumCoordX = 0;
        private static int _smallestNumCoordY = 0;
        private static int _biggestNum;
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
                              $"and the biggest number: {_biggestNum} ({_biggestNumCoordX},{_biggestNumCoordY})\n");
            SortArrayAscending(_numArr);
            DisplayArrayOnScreen(_numArr);

            Console.ReadKey();
        }

        static void PopulateArray()
        {
            for (int i = 0; i < _rowLen; i++)
            {
                for (int j = 0; j < _colLen; j++)
                {
                    _numArr[i, j] = GetRandomInt();
                }
            }
        }

        static int GetRandomInt()
        {
            int nextRandomInt = new Random().Next(0, 800);
            if (CheckIfNumExists(nextRandomInt))
            {
                return GetRandomInt();
            }

            return nextRandomInt;
        }

        static bool CheckIfNumExists(int randomInt)
        {
            int count = 0;

            for (int i = 0; i < _rowLen; i++)
            {
                for (int j = 0; j < _colLen; j++)
                {
                    if (_numArr[i, j] == randomInt)
                    {
                        count++;
                    }
                }
            }

            return count > 0 ? true : false;
        }

        static void SortArrayAscending(int[,] data)
        {
            int temp, t, i, j;

            for (t = 1; t < (_rowLen * _colLen); t++)
            {
                for (i = 0; i < _rowLen; i++)
                {
                    for (j = 0; j < _colLen - 1; j++)
                    {
                        if (data[i, j] > data[i, j + 1])
                        {
                            temp = data[i, j];
                            data[i, j] = data[i, j + 1];
                            data[i, j + 1] = temp;
                        }
                    }
                }

                for (i = 0; i < _rowLen - 1; i++)
                {
                    if (data[i, _colLen - 1] > data[i + 1, 0])
                    {
                        temp = data[i, _colLen - 1];
                        data[i, _colLen - 1] = data[i + 1, 0];
                        data[i + 1, 0] = temp;
                    }
                }
            }
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
            _smallestNum = _numArr[0, 0];
            _biggestNum = _numArr[0, 0];

            for (int i = 0; i < _rowLen; i++)
            {
                for (int j = 0; j < _colLen; j++)
                {
                    int currentNum = _numArr[i, j];

                    if (currentNum < _smallestNum)
                    {
                        _smallestNum = currentNum;
                        _smallestNumCoordY = i;
                        _smallestNumCoordX = j;
                    }

                    if (currentNum > _biggestNum)
                    {
                        _biggestNum = currentNum;
                        _biggestNumCoordY = i;
                        _biggestNumCoordX = j;
                    }
                }
            }
        }
    }
}
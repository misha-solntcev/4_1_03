using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Вариант 3
Дана целочисленная прямоугольная матрица. Определить:
1.количество отрицательных элементов в тех строках, которые содержат хотя бы
один нулевой элемент;
2.номера строк и столбцов всех седловых точек матрицы.
Примечание. Матрица А имеет седловую точку Аij, если является минимальным
элементом в i-й строке и максимальным в j-м столбце. */

namespace _4_1_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[,]
            {
                { 0, -2, -3, 4, -5 },
                { -4, -5, -6, 0, -8 },
                { 1, 0, 7, 8, 9 },
                { 6, 7, -8, 9, -5 },
                { 7, 0, 9, 8, 6 },
            };

            // Проверка есть ли в строке 0.
            List<int> flags = new List<int>();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                bool flag = false;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == 0)
                        flag = true;
                }
                if (flag == true)
                    flags.Add(i);
            }

            // Подсчет количества отрицательных элементов.
            List<int> counts = new List<int>();
            foreach (int flag in flags)
            {
                int count = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[flag, j] < 0)
                        count++;
                }
                counts.Add(count);
            }

            // Вывод на печать количества отрицательных элементов.
            Console.Write("Count: ");
            foreach (int count in counts)
                Console.Write($"{count}, ");
            Console.WriteLine();

            // Индексы максимумов по строкам.
            List<int> indexMax = new List<int>();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int max = array[i, 0];
                int index = 0;
                for (int j = 1; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                        index = j;
                    }                        
                }
                indexMax.Add(index);
            }
            Console.Write("indexMax: ");
            foreach (int index in indexMax)
                Console.Write($"{index}, ");
            Console.WriteLine();

            // Индексы минимумов по столбцам.
            List<int> indexMin = new List<int>();
            for (int j = 0; j < array.GetLength(1); j++)
            {
                int min = array[0, j];
                int index = 0;
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                        index = i;
                    }
                }
                indexMin.Add(index);
            }
            Console.Write("indexMin: ");
            foreach (int index in indexMin)
                Console.Write($"{index}, ");
            Console.WriteLine();

            // Вывод всего массива на печать.
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{ array[i, j]}, ");
                }
                Console.WriteLine();
            }

            // Нахождение и вывод с консоль седловой точки.
            for (int i = 0; i < indexMax.Count; i++)
            {
                for (int j = 1; j < array.GetLength(1); j++)
                {
                    if ((i == indexMax[j])&&(j == indexMin[i]))
                    {
                        Console.WriteLine($"Седловые точка: i = {indexMin[i]}, j = {indexMax[j]}");
                    }
                }                    
            }
            Console.ReadKey();
        }
    }
}
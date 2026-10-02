using System;
using System.Collections.Generic;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 0");

            Console.Write("Введите первое число: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Введите второе число: ");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine("Max = " + Max2(a, b));
            Console.WriteLine("Min = " + Min2(a, b));

            Console.WriteLine();
            Console.WriteLine("Задание 1");

            Console.WriteLine(GetStats(1, 2, 3));
            Console.WriteLine();

            Console.WriteLine(GetStats(10, 20, 30, 40, 50));
            Console.WriteLine();

            Console.WriteLine(GetStats(1.1, 2.2, -5.5));

            Console.WriteLine();
            Console.WriteLine("Задание 2.1");

            int c = 10;
            int d = 20;

            Console.WriteLine("До Swap:");
            Console.WriteLine("c = " + c);
            Console.WriteLine("d = " + d);

            Swap(ref c, ref d);

            Console.WriteLine("После Swap:");
            Console.WriteLine("c = " + c);
            Console.WriteLine("d = " + d);

            Console.WriteLine();
            Console.WriteLine("Задание 2.2");

            int[] list1 = { 1, 2, 3, 4, 5 };

            Console.Write("Массив до Reverse: ");

            for (int i = 0; i < list1.Length; i++)
            {
                Console.Write(list1[i] + " ");
            }

            Console.WriteLine();

            Reverse(list1);

            Console.Write("Массив после Reverse: ");

            for (int i = 0; i < list1.Length; i++)
            {
                Console.Write(list1[i] + " ");
            }

            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Задание 2.3");

            int[] list2 = { 1, 2, 3, 4, 5 };

            Console.Write("Исходный массив: ");

            for (int i = 0; i < list2.Length; i++)
            {
                Console.Write(list2[i] + " ");
            }

            Console.WriteLine();

            int[] result = ReverseNew(list2);

            Console.Write("Новый инвертированный массив: ");

            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i] + " ");
            }

            Console.WriteLine();

            Console.Write("Исходный массив после вызова: ");

            for (int i = 0; i < list2.Length; i++)
            {
                Console.Write(list2[i] + " ");
            }

            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Задание 3");

            int[] list3 = { 5, 10, 15, 20, 25 };
            int value1 = 15;

            if (TryFind(list3, value1, out int index1))
            {
                Console.WriteLine("Число " + value1 + " найдено. Индекс: " + index1);
            }
            else
            {
                Console.WriteLine("Число " + value1 + " не найдено. Индекс: " + index1);
            }

            int value2 = 100;

            if (TryFind(list3, value2, out int index2))
            {
                Console.WriteLine("Число " + value2 + " найдено. Индекс: " + index2);
            }
            else
            {
                Console.WriteLine("Число " + value2 + " не найдено. Индекс: " + index2);
            }

            Console.WriteLine();
            Console.WriteLine("Задание 4");

            int[] list4 = { -5, -2, 0, 1, 2, 3, 4, 5, 6, 9, 10 };

            Console.Write("Исходный массив: ");

            for (int i = 0; i < list4.Length; i++)
            {
                Console.Write(list4[i] + " ");
            }

            Console.WriteLine();

            int[] even = Filter(list4, IsEven);

            Console.Write("Чётные числа: ");

            for (int i = 0; i < even.Length; i++)
            {
                Console.Write(even[i] + " ");
            }

            Console.WriteLine();

            int[] positive = Filter(list4, IsPositive);

            Console.Write("Положительные числа: ");

            for (int i = 0; i < positive.Length; i++)
            {
                Console.Write(positive[i] + " ");
            }

            Console.WriteLine();

            int[] moreFive = Filter(list4, IsMoreFive);

            Console.Write("Числа больше 5: ");

            for (int i = 0; i < moreFive.Length; i++)
            {
                Console.Write(moreFive[i] + " ");
            }

            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Задание 5");

            int[] array = { 1, 2, 3 };

            Console.WriteLine("--- ЭКСПЕРИМЕНТ 1: БЕЗ ref ---");

            Console.Write("Массив ДО вызова: ");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Хэш-код: " + array.GetHashCode());

            BrokenSafeAppend(array, 4);

            Console.Write("Массив ПОСЛЕ вызова: ");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Хэш-код: " + array.GetHashCode());

            Console.WriteLine();

            Console.WriteLine("--- ЭКСПЕРИМЕНТ 2: С ref ---");

            Console.Write("Массив ДО вызова: ");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Хэш-код: " + array.GetHashCode());

            RefSafeAppend(ref array, 4);

            Console.Write("Массив ПОСЛЕ вызова: ");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Хэш-код: " + array.GetHashCode());
        }

        public static int Max2(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        public static int Min2(int a, int b)
        {
            if (a < b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        public static string GetStats(params int[] numbers)
        {
            if (numbers.Length == 0)
            {
                return "Массив пуст.";
            }

            int sum = 0;
            int min = numbers[0];
            int max = numbers[0];

            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];

                if (numbers[i] < min)
                {
                    min = numbers[i];
                }

                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            double average = (double)sum / numbers.Length;

            string result = "";
            result += "Кол-во: " + numbers.Length + ";\n";
            result += "Сумма: " + sum + ";\n";
            result += "Ср. ариф: " + average + ";\n";
            result += "Макс: " + max + ";\n";
            result += "Мин: " + min + ";";

            return result;
        }

        public static string GetStats(params double[] numbers)
        {
            if (numbers.Length == 0)
            {
                return "Массив пуст.";
            }

            double sum = 0;
            double min = numbers[0];
            double max = numbers[0];

            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];

                if (numbers[i] < min)
                {
                    min = numbers[i];
                }

                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            double average = sum / numbers.Length;

            string result = "";
            result += "Кол-во: " + numbers.Length + ";\n";
            result += "Сумма: " + sum + ";\n";
            result += "Ср. ариф: " + average + ";\n";
            result += "Макс: " + max + ";\n";
            result += "Мин: " + min + ";";

            return result;
        }

        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static void Reverse(int[] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                int temp = array[i];
                array[i] = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = temp;
            }
        }

        public static int[] ReverseNew(int[] array)
        {
            int[] result = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                result[i] = array[array.Length - 1 - i];
            }

            return result;
        }

        public static bool TryFind(int[] array, int value, out int index)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    index = i;
                    return true;
                }
            }

            index = -1;
            return false;
        }

        public static int[] Filter(int[] sourceArray, Func<int, bool> condition)
        {
            int count = 0;

            for (int i = 0; i < sourceArray.Length; i++)
            {
                if (condition(sourceArray[i]))
                {
                    count++;
                }
            }

            int[] result = new int[count];
            int j = 0;

            for (int i = 0; i < sourceArray.Length; i++)
            {
                if (condition(sourceArray[i]))
                {
                    result[j] = sourceArray[i];
                    j++;
                }
            }

            return result;
        }

        public static bool IsEven(int n)
        {
            if (n % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsPositive(int n)
        {
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsMoreFive(int n)
        {
            if (n > 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void RefSafeAppend(ref int[] sourceArray, int value)
        {
            int[] newArray = new int[sourceArray.Length + 1];

            for (int i = 0; i < sourceArray.Length; i++)
            {
                newArray[i] = sourceArray[i];
            }

            newArray[newArray.Length - 1] = value;
            sourceArray = newArray;
        }

        public static void BrokenSafeAppend(int[] sourceArray, int value)
        {
            int[] newArray = new int[sourceArray.Length + 1];

            for (int i = 0; i < sourceArray.Length; i++)
            {
                newArray[i] = sourceArray[i];
            }

            newArray[newArray.Length - 1] = value;
            sourceArray = newArray;
        }
    }
}
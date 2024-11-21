using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domashka
{
    class Dz_Tumak
    {
        /// <summary>
        /// Сравнивает числа и возвращает большее из них
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns> Максимальное число</returns>
        static int Maximus(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else if (a < b)
            {
                return b;
            }
            else if (a == b)
            {
                return a;
            }
            else return 0;
        }
        /// <summary>
        /// Меняет значение двух переменных местами
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        static void Obmen(ref string str1, ref string str2)
        {
            string strTest = str1;
            str1 = str2;
            str2 = strTest;

        }
        /// <summary>
        /// Преобразует заданное число в его факториал
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Возвращает True если факториал "помещается" в тип переменной, и False если нет</returns>
        static bool Fact(ref long a)
        {
            long res = 1;
            for (int i = 1; i <= a; i++)
            {
                try
                {
                    checked
                    {
                        res *= i;
                    }
                }
                catch (OverflowException)
                {
                    return false;
                }
            }
            a = res;
            return true;
        }
        /// <summary>
        /// Вычисляет факториал данного числа с помощью рекурсии
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Возвращает факториал если он не переполнил тип long, или выводит сообщение о переполнении и возвращает 0</returns>
        static long FactRecursion(long a)
        {
            try
            {
                checked
                {
                    if (a == 0)
                    {
                        return 1;
                    }
                    return a * FactRecursion(a - 1);
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Факториал получился слишком большим");
                return 0;
            }
        }
        /// <summary>
        /// Вычисляет нод двух чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Возвращает их нод</returns>
        static int Nod(int a, int b)
        {
            int res = b;
            while (!(a % b == 0))
            {
                res = a % b;
                int tes = a;
                a = b;
                b = tes % b;
            }

            return res;
        }
        /// <summary>
        /// Нод для трех чисел, используя нод двух чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns>Возвращает нод трех чисел</returns>
        static int Nod(int a, int b, int c)
        {
            return Nod(Nod(a, b), c);
        }
        /// <summary>
        /// Вычисляет n-ый член последовательности Фибоначчи
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int Fibon(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else
            {
                return Fibon(n - 1) + Fibon(n-2);
            }

        }
        static void Main()
        {
            Zadanie1();
            Zadanie2();
            Zadanie3();
            Zadanie4();
            Zadanie5();
            Zadanie6();
        }
        static void Zadanie1()
        {
            /*/*Упражнение 5.1 Написать метод, возвращающий наибольшее из двух чисел. Входные
            параметры метода – два целых числа. Протестировать метод.*/
            Console.WriteLine("\nУпражнение 5.1. Созднание метода, который возвращает большее число из двух\n");
            Console.Write("Введите первое число: ");
            bool isanum = int.TryParse(Console.ReadLine(), out int a);
            Console.Write("Введите второе число: ");
            bool isbnum = int.TryParse(Console.ReadLine(), out int b);
            if (isanum && isbnum)
            {
                Console.WriteLine("Наибольшее из чисел {0} и {1}, это {2}", a, b, Maximus(a, b));
            }
            else
            {
                Console.WriteLine("Вы ввели не числа");
            }
        }
        static void Zadanie2()
        {
            /*Упражнение 5.2 Написать метод, который меняет местами значения двух передаваемых
            параметров. Параметры передавать по ссылке. Протестировать метод.*/
            Console.WriteLine("\nУпражнение 5.2 2. Поменять местами значения двух переменных в методе\n");
            string str1 = "Значение 1 переменной";
            string str2 = "Значение 2 переменной";
            Obmen(ref str1, ref str2);
            Console.WriteLine("str1 = {0}, str2 = {1}", str1, str2);
        }
        static void Zadanie3()
        {
            /*Упражнение 5.3 Написать метод вычисления факториала числа, результат вычислений
            передавать в выходном параметре. Если метод отработал успешно, то вернуть значение true;
            если в процессе вычисления возникло переполнение, то вернуть значение false. Для
            отслеживания переполнения значения использовать блок checked.*/
            Console.WriteLine("\nУражнение 5.3. Создание метода вычисления факториала числа\n");
            Console.Write("Введите число факториал которого хотите вычислить:");
            bool isnum = long.TryParse(Console.ReadLine(), out long input);
            bool isfact = Fact(ref input);
            if (isnum)
            {
                if (isfact)
                {
                    Console.WriteLine($"Факториал заданного числа = {input}");
                }
                else
                {
                    Console.WriteLine("Факториал получился слишком большим");
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число");
            }
        }
        static void Zadanie4()
        {
            /*Упражнение 5.4 Написать рекурсивный метод вычисления факториала числа.*/
            Console.WriteLine("\nУражнение 5.4. Вычисление факториала с помощью рекурсии\n");
            Console.Write("Введите число факториал которого хотите вычислить:");
            bool isnum = long.TryParse(Console.ReadLine(), out long input);
            if (isnum)
            {
                long fact = FactRecursion(input);
                if (!(fact == 0))
                {
                    Console.WriteLine($"Факториал заданного числа = {fact}");
                }

            }

        }
        static void Zadanie5()
        {
            /*Домашнее задание 5.1 Написать метод, который вычисляет НОД двух натуральных чисел
            (алгоритм Евклида). Написать метод с тем же именем, который вычисляет НОД трех
            натуральных чисел.*/
            Console.WriteLine("\nДомашнее задание 5.1. Создание метода для вычислени НОД двух натуральный чисел, и нод трех чисел");
            // вычисление нода для двух чисел
            Console.Write("Введите первое число:");
            bool isint1 = int.TryParse(Console.ReadLine(), out int int1);
            Console.Write("Введите второе число:");
            bool isint2 = int.TryParse(Console.ReadLine(), out int int2);
            if (isint1 && isint2)
            {
                if (int1 > int2)
                {
                    Console.WriteLine("Нод этих чисел = {0}", Nod(int1, int2));
                }
                else
                {
                    Console.WriteLine("Нод этих чисел = {0}", Nod(int2, int1));
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число");
            }
            // вычисление нода для трех чисел
            Console.Write("\nВведите первое число:");
            bool isint3 = int.TryParse(Console.ReadLine(), out int int3);
            Console.Write("Введите второе число:");
            bool isint4 = int.TryParse(Console.ReadLine(), out int int4);
            Console.Write("Введите третье число:");
            bool isint5 = int.TryParse(Console.ReadLine(), out int int5);
            if (isint3 && isint4 && isint5)
            {
                int[] ints = { int3, int4, int5 };
                Array.Sort(ints);
                Console.WriteLine("Нод этих чисел = {0}", Nod(ints[0], ints[1], ints[2]));
            }
            else
            {
                Console.WriteLine("Вы ввели не число");
            }
        }
        static void Zadanie6()
        {
            /*Домашнее задание 5.2 Написать рекурсивный метод, вычисляющий значение n-го числа
            ряда Фибоначчи. Ряд Фибоначчи – последовательность натуральных чисел 1, 1, 2, 3, 5, 8,
            13... Для таких чисел верно соотношение Fk = Fk-1 + Fk-2 .*/
            Console.WriteLine("\nДомашнее задание 5.2. Создание рекурсивного метода вычисления чисел из ряда фибоначи\n");
            Console.Write("Введите индекс необходимого числа фибоначи:");
            bool isint = int.TryParse(Console.ReadLine(), out int n);
            if (isint)
            {
                Console.WriteLine("В последовательности Фибоначчи под номером {0} стоит число {1}", n, Fibon(n));
            }
            else
            {
                Console.WriteLine("Вы ввели не число");
            }

        }

    }
}
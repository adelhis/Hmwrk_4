using System;
using System.Diagnostics.CodeAnalysis;

namespace Domashka
{
    class Dz_File
    {
        /// <summary>
        /// Возвращает сумму массива, а также произведение и среднее арифметическое
        /// </summary>
        /// <param name="proizv"></param>
        /// <param name="srAriph"></param>
        /// <param name="myArray"></param>
        /// <returns>Возвращает sum, изменяет произведение ref, и инициализирует среднее арифметическое</returns>
        static int Massiv(ref int proizv, out double srAriph, params int[] myArray)
        {
            int sum = 0;
            foreach (int i in myArray)
            {
                sum += i;
                proizv *= i;
            }
            srAriph = sum/myArray.Length;
            return sum;
        }
        enum Vorch
        {
            Low,
            Medium,
            High
        }

        struct Ded
        {
            public string name;
            public Vorch vorch;
            public string[] frazi;
            public uint kolvo;
            public uint Sinyaki(Ded ded,params string[] array)
            {
                uint kolvo = 0;
                foreach (string s in ded.frazi)
                {
                    if (array.Contains(s))
                    {
                        kolvo++;
                    }
                }
                return kolvo;
            }
        }

        static void Main()
        {
            Zadanie1();
            Zadanie2();
            Zadanie3();
            Zadanie4();
        }
        static void Zadanie1()
        {
            /*1. Вывести на экран массив из 20 случайных чисел. Ввести два числа из этого массива,
            которые нужно поменять местами. Вывести на экран получившийся массив.*/
            Console.WriteLine("Задание 1. Смена двух элементов в массиве\n");
            Random rnd = new Random();
            int[] intArray = new int[20];
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = rnd.Next(1, 100);
            }
            foreach (int i in intArray)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine("\nПоменяем местами числа {0}(7 в массиве) и {1}(11 в массиве)", intArray[6], intArray[10]);
            int test = intArray[10];
            intArray[10] = intArray[6];
            intArray[6] = test;
            foreach (int i in intArray)
            {
                Console.Write($"{i} ");
            }
        }
        static void Zadanie2()
        {
            /*2. Написать метод, где в качества аргумента будет передан массив (ключевое слово
            params). Вывести сумму элементов массива (вернуть). Вывести (ref) произведение
            массива. Вывести (out) среднее арифметическое в массиве.*/
            Console.WriteLine("\nЗадание 2. Метод, вычисляющий различные характеристики массива\n");
            int proizv = 1;
            double srAriph;
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.Write("Массив: ");
            foreach (int i in array)
            {
                Console.Write($"{i} ");
            }
            int suma = Massiv(ref proizv, out srAriph, array);
            Console.WriteLine("\nСумма массива = {0}\nПроизведение массива = {1}\nСреднее арифметическое массива = {2}", suma,proizv,srAriph);
        }
        static void Zadanie3()
        {
            /*3. Пользователь вводит числа. Если числа от 0 до 9, то необходимо в консоли нарисовать
            изображение цифры в виде символа #.Если число больше 9 или меньше 0, то консоль
            должна окраситься в красный цвет на 3 секунды и вывести сообщение об ошибке. Если
            пользователь ввёл не цифру, то программа должна выпасть в исключение. Программа
            завершает работу, если пользователь введёт слово: exit или закрыть (оба варианта
            должны сработать) - консоль закроется.*/
            Console.WriteLine("\nЗадание 3.Рисование чисел, вводимых пользователем\n");
            bool flag = true;
            while (flag)
            {
                Console.Write("Введите цифру(от 0 до 9):");
                string str = Console.ReadLine();
                switch (str)
                {
                    case "0":
                        Console.WriteLine("###\n# #\n# #\n# #\n###");
                        break;
                    case "1":
                        Console.WriteLine("  #\n ##\n# #\n  #\n  #");
                        break;
                    case "2":
                        Console.WriteLine("###\n# #\n ##\n#  \n###");
                        break;
                    case "3":
                        Console.WriteLine("###\n  #\n##\n  #\n###");
                        break;
                    case "4":
                        Console.WriteLine("# #\n# #\n###\n  #\n  #");
                        break;
                    case "5":
                        Console.WriteLine("###\n#  \n###\n  #\n###");
                        break;
                    case "6":
                        Console.WriteLine("###\n#  \n###\n# #\n###");
                        break;
                    case "7":
                        Console.WriteLine("###\n  #\n  #\n  #\n  #");
                        break;
                    case "8":
                        Console.WriteLine("###\n# #\n###\n# #\n###");
                        break;
                    case "9":
                        Console.WriteLine("###\n# #\n###\n  #\n###");
                        break;
                    case "exit":
                        flag = false;
                        break;
                    default:
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Thread.Sleep(3000);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        Console.WriteLine("Ошибка, это не цифра");
                        break;
                }
            }
        }
        static void Zadanie4()
        {
            /*4. Создать структуру Дед. У деда есть имя, уровень ворчливости (перечисление), массив
            фраз для ворчания (прим.: “Проститутки!”, “Гады!”), количество синяков от ударов
            бабки = 0 по умолчанию. Создать 5 дедов. У каждого деда - разное количество фраз для
            ворчания. Напишите метод (внутри структуры), который на вход принимает деда,
            список матерных слов (params). Если дед содержит в своей лексике матерные слова из
            списка, то бабка ставит фингал за каждое слово. Вернуть количество фингалов.*/
            Console.WriteLine("\nЗадание 4. Структура Деда и его синяки\n");
            Ded ded1 = new Ded();
            Ded ded2 = new Ded();
            Ded ded3 = new Ded();
            Ded ded4 = new Ded();
            Ded ded5 = new Ded();

            ded1.name = "Ивдоким";
            ded2.name = "Анатолий";
            ded3.name = "Андрей";
            ded4.name = "Григорий";
            ded5.name = "Евгений";

            ded1.vorch = Vorch.High;
            ded2.vorch = Vorch.High;
            ded3.vorch = Vorch.Medium;
            ded4.vorch = Vorch.Medium;
            ded5.vorch = Vorch.Low;

            ded1.frazi = new string[] { "Падаль", "Твари", "Проститутки", "Гады", "Кретины", "Ахеревшие" ,"Дебилы"};
            ded2.frazi = new string[] { "Идиоты", "Огрызки", "Проститутки", "Гады", "Кретины", "Ахеревшие" , "Дебилы"};
            ded3.frazi = new string[] { "Идиоты", "Твари", "Проститутки", "Имбицилы", "Дебилы" };
            ded4.frazi = new string[] { "Дураки", "Огрызки", "Проститутки", "Гады"};
            ded5.frazi = new string[] { "Твари", "Проститутки"};

            string[] myArray = { "Проститутки", "Ахеревшие", "Гады", "Дебилы" };
            ded1.kolvo = ded1.Sinyaki(ded1,myArray);
            ded2.kolvo = ded2.Sinyaki(ded2, myArray);
            ded3.kolvo = ded3.Sinyaki(ded3, myArray);
            ded4.kolvo = ded4.Sinyaki(ded4, myArray);
            ded5.kolvo = ded5.Sinyaki(ded5, myArray);

            Console.WriteLine($"{ded1.name} получил синяков: {ded1.kolvo}\n" +
                $"{ded2.name} получил синяков: {ded2.kolvo}\n" +
                $"{ded3.name} получил синяков: {ded3.kolvo}\n" +
                $"{ded4.name} получил синяков: {ded4.kolvo}\n" +
                $"{ded5.name} получил синяков: {ded5.kolvo}\n");


        }
    }
}

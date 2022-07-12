using System;

namespace OOP_Lesson_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Number number1 = new Number(1, 2); // Тестовые дроби

            Number number2 = new Number(1, 3);

            Number numberPlus = number1 + number2; // Тестовые примеры

            Number numberMinus = number1 - number2;

            Number numberMulti = number1 * number2;

            Number numberDiv = number1 / number2;

            Number numberOst = number1 % number2;

            Console.WriteLine(numberPlus.ToString()); // Вывод на экран

            Console.WriteLine(numberMinus.ToString());

            Console.WriteLine(numberMulti.ToString());

            Console.WriteLine(numberDiv.ToString());

            Console.WriteLine(numberOst.ToString());

            int t = number1; // Тест приобразования типов
            float f = number1;
            Console.WriteLine(t);
            Console.WriteLine(f);

        }
    }
}
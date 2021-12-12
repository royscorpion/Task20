using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task20
{
    /// Научиться использовать делегаты, события и лямбды
    class Program
    {
        delegate double CalcDelegate(double rad); //создание делегата с одним аргументом типа double
        static void Main(string[] args)
        {
            //Запрос ввода радиуса с проверкой корректности введенного значения
            Console.Write("Введите радиус: ");
            InputDoubleNumber(out double rad);
            //Вариант вызова метода с помощью делегата, с проверкой делегата на равенство null
            CalcDelegate circumference = new CalcDelegate(Circumference);
            if (circumference != null)
            {
                circumference(rad);
            }
            //Вариант вызова метода с помощью делегата при помощи метода Invoke
            CalcDelegate circleArea = new CalcDelegate(CircleArea);
            circleArea?.Invoke(rad);
            //Вариант вызова метода с помощью делегата через лямбда-выражение
            CalcDelegate sphereVolume = r => 4 / 3 * Math.PI * Math.Pow(r, 3);
            double spherevolume = sphereVolume(rad);
            Console.WriteLine($"Объем шара радиусом {rad} составляет { spherevolume:f1}");

            Console.ReadKey();
        }

        static double Circumference(double rad)
        {
            double circumference = 2 * Math.PI * rad;
            Console.WriteLine($"Длина окружности радиусом {rad} составляет {circumference:f3}");
            return circumference;
        }
        static double CircleArea(double rad)
        {
            double circlearea = Math.PI * Math.Pow(rad, 2);
            Console.WriteLine($"Площадь круга радиусом {rad} составляет {circlearea:f2}");
            return circlearea;
        }

        //Проверка корректности введенных данных (integer)
        static void InputDoubleNumber(out double number)
        {
            number = 0;
            bool x;
            do
            {
                try
                {
                    number = Convert.ToDouble(Console.ReadLine());
                    x = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка! {0}\nПопробуйте еще раз\n", ex.Message);
                    Console.Write("Введите вещественное число: ");
                    x = true;
                }
            } while (x);
        }

    }
}

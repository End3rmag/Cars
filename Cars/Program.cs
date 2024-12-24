using System;
using System.Security.Cryptography;

public class Auto
{
   private string numberauto;
   private int Vmax;
   private double V;
   private double rashod;
   private double totalKilometers;
   private double lastKilometers;

    public Auto() { }

    public  Auto( string num, int vm, double ras)
    {
        numberauto = num;
        Vmax = vm;
        V = 0;
        rashod = ras;
        totalKilometers = 0; 
    }
    

    internal double CurrentFuel => V;
    internal double TotalKilometers => totalKilometers;

    internal virtual void Proverka()
    {
        if (V >= Vmax)
        {
            Console.WriteLine($"Вы не можете налить больше {Vmax} литров. Избыточное количество топлива: {V - Vmax} литров.");
        }
    }

    public virtual double Zapravka(double v)
    {
        if (V + v >= Vmax)
        {
            Console.WriteLine($"Заправка превысит максимальный объем ({Vmax})! Уменьшите количество.");
            return V;
        }

        V += v;
        Console.WriteLine($"Вы заправили {v} литров. Теперь у вас {V} литров топлива.");
        return V;
    }

    public virtual double Drive(double kilometers)
    {
        double fuelNeeded = kilometers * rashod / 100;

        if (fuelNeeded <= V)
        {
            V -= fuelNeeded;
            totalKilometers += kilometers;
            lastKilometers = 0;
            Console.WriteLine($"Поездка завершена! Вы проехали {kilometers} км. Осталось {V} литров топлива.");
            return kilometers;
        }
        else
        {
            double Kilometers = (V / rashod) * 100;
            totalKilometers += Kilometers;
            lastKilometers = kilometers - Kilometers;
            V = 0;
            Console.WriteLine($"Вы проехали {Kilometers} км. Осталось {lastKilometers}. Вам нужно дозаправиться, остаток топлива:{V}!");
            return Kilometers;
        }
    }
    internal virtual double DriveСontinuation()
    {
        if (lastKilometers > 0)
        {
            return Drive(lastKilometers);
        }
        else
        {
            Console.WriteLine("Нет оставшегося расстояния для движения.");
            return 0;
        }
    }

}


public class Sportcar : Auto
{
    private string numberauto;
    private int Vmax;
    private double V;
    private double rashod;
    private double totalKilometers;
    private double lastKilometers;

    public Sportcar()
    {
        numberauto = "AO141B";
        Vmax = 64;
        V = 0;
        rashod = 11;
        totalKilometers = 0;
    }
    internal double CurrentFuel => V;
    internal double TotalKilometers => totalKilometers;                               
    public override double Zapravka(double v)
    {
        if (V + v >= Vmax)
        {
            Console.WriteLine($"Заправка превысит максимальный объем ({Vmax})! Уменьшите количество.");
            return V;
        }

        V += v;
        Console.WriteLine($"Вы заправили {v} литров. Теперь у вас {V} литров топлива.");
        return V;
    }
    public override double Drive(double kilometers)
    {
        double fuelNeeded = kilometers * rashod / 100;

        if (fuelNeeded <= V)
        {
            V -= fuelNeeded;
            totalKilometers += kilometers;
            lastKilometers = 0;
            Console.WriteLine($"Поездка завершена! Вы проехали {kilometers} км. Осталось {V} литров топлива.");
            return kilometers;
        }
        else
        {
            double Kilometers = (V / rashod) * 100;
            totalKilometers += Kilometers;
            lastKilometers = kilometers - Kilometers;
            V = 0;
            Console.WriteLine($"Вы проехали {Kilometers} км. Осталось {lastKilometers}. Вам нужно дозаправиться!");
            return Kilometers;
        }
    }

}


public class Gryzovic : Auto
{
    private string numberauto;
    private int Vmax;
    private double V;
    private double rashod;
    private double totalKilometers;
    private double lastKilometers;
    public Gryzovic()
    {
        numberauto = "GO333D";
        Vmax = 350;
        V = 0;
        rashod = 40;
        totalKilometers = 0;
    }
    internal double CurrentFuel => V;
    internal double TotalKilometers => totalKilometers;
    public override double Zapravka(double v)
    {
        if (V + v >= Vmax)
        {
            Console.WriteLine($"Заправка превысит максимальный объем ({Vmax})! Уменьшите количество.");
            return V;
        }

        V += v;
        Console.WriteLine($"Вы заправили {v} литров. Теперь у вас {V} литров топлива.");
        return V;
    }
    public override double Drive(double kilometers)
    {
        double fuelNeeded = kilometers * rashod / 100;

        if (fuelNeeded <= V)
        {
            V -= fuelNeeded;
            totalKilometers += kilometers;
            lastKilometers = 0;
            Console.WriteLine($"Поездка завершена! Вы проехали {kilometers} км. Осталось {V} литров топлива.");
            return kilometers;
        }
        else
        {
            double Kilometers = (V / rashod) * 100;
            totalKilometers += Kilometers;
            lastKilometers = kilometers - Kilometers;
            V = 0;
            Console.WriteLine($"Вы проехали {Kilometers} км. Осталось {lastKilometers}. Вам нужно дозаправиться!");
            return Kilometers;
        }
    }
}


class Program
{
    static void Main()
    {
        Console.WriteLine("n\"Выберете транспорт:");
        Console.WriteLine("1. Личный автомабль:");
        Console.WriteLine("2. Спорткар:");
        Console.WriteLine("3. Грузовой транспорт:");

        string choce = Console.ReadLine();

        if (choce == "1")
        {

            Console.WriteLine("Введите номер автомобиля:");
            string autoNumber = Console.ReadLine();

            Console.WriteLine("Введите максимальный объем топливного бака в литрах:");
            int maxVolume;
            while (!int.TryParse(Console.ReadLine(), out maxVolume))
            {
                Console.WriteLine("Некорректное значение. Пожалуйста, введите положительное целое число для объема бака.");
            }

            Console.WriteLine("Введите расход топлива в литрах на 100 км:");
            double rashod;
            while (!double.TryParse(Console.ReadLine(), out rashod))
            {
                Console.WriteLine("Некорректное значение. Пожалуйста, введите положительное число для расхода топлива.");
            }

            Auto myAuto = new Auto(autoNumber, maxVolume, rashod);

            void Way()
            {

                Console.WriteLine("\nВыберите операцию:");
                Console.WriteLine("1. Продолжить поездку");
                Console.WriteLine("2. Начать новую поездку");
                string cho = Console.ReadLine();
                switch (cho)
                {
                    case "1":
                        Console.WriteLine("Продолжение поездки...");
                        myAuto.DriveСontinuation();
                        break;

                    case "2":
                        Console.WriteLine("Введите расстояние маршрута в км:");
                        if (double.TryParse(Console.ReadLine(), out double kilometers))
                        {
                            myAuto.Drive(kilometers);

                        }
                        else
                        {
                            Console.WriteLine("Некорректное значение расстояния.");
                        }
                        break;
                }
            }

            while (true)
            {
                Console.WriteLine("\nВыберите операцию:");
                Console.WriteLine("1. Выбрать маршрут");
                Console.WriteLine("2. Заправиться");
                Console.WriteLine("3. Узнать сколько осталось топлива");
                Console.WriteLine("4. Узнать общее расстояние");
                Console.WriteLine("5. Закончить поездку");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":

                        Way();
                        break;

                    case "2":
                        Console.WriteLine("Введите количество топлива для заправки в литрах:");
                        if (double.TryParse(Console.ReadLine(), out double fuelAmount))
                        {
                            myAuto.Zapravka(fuelAmount);
                        }
                        else
                        {
                            Console.WriteLine("Некорректное значение топлива.");
                        }
                        break;

                    case "3":
                        Console.WriteLine($"Осталось топлива: {myAuto.CurrentFuel} литров.");
                        break;

                    case "4":
                        Console.WriteLine($"Общее расстояние, проеханное автомобилем: {myAuto.TotalKilometers} км.");
                        break;

                    case "5":
                        Console.WriteLine("Поездка завершена.");
                        return;

                    default:
                        Console.WriteLine("Неверный выбор, попробуйте снова.");
                        break;
                }
            }
        }

        else if (choce == "2")
        {
            Sportcar sportcar = new Sportcar();
            void Way()
            {

                Console.WriteLine("\nВыберите операцию:");
                Console.WriteLine("1. Продолжить поездку");
                Console.WriteLine("2. Начать новую поездку");
                string cho = Console.ReadLine();
                switch (cho)
                {
                    case "1":
                        Console.WriteLine("Продолжение поездки...");
                        sportcar.DriveСontinuation();
                        break;

                    case "2":
                        Console.WriteLine("Введите расстояние маршрута в км:");
                        if (double.TryParse(Console.ReadLine(), out double kilometers))
                        {
                            sportcar.Drive(kilometers);

                        }
                        else
                        {
                            Console.WriteLine("Некорректное значение расстояния.");
                        }
                        break;
                }
            }

            while (true)
            {
                Console.WriteLine("\nВыберите операцию:");
                Console.WriteLine("1. Выбрать маршрут");
                Console.WriteLine("2. Заправиться");
                Console.WriteLine("3. Узнать сколько осталось топлива");
                Console.WriteLine("4. Узнать общее расстояние");
                Console.WriteLine("5. Закончить поездку");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":

                        Way();
                        break;

                    case "2":
                        Console.WriteLine("Введите количество топлива для заправки в литрах:");
                        if (double.TryParse(Console.ReadLine(), out double fuelAmount))
                        {
                            sportcar.Zapravka(fuelAmount);
                        }
                        else
                        {
                            Console.WriteLine("Некорректное значение топлива.");
                        }
                        break;

                    case "3":
                        Console.WriteLine($"Осталось топлива: {sportcar.CurrentFuel} литров.");
                        break;

                    case "4":
                        Console.WriteLine($"Общее расстояние, проеханное автомобилем: {sportcar.TotalKilometers} км.");
                        break;

                    case "5":
                        Console.WriteLine("Поездка завершена.");
                        return;

                    default:
                        Console.WriteLine("Неверный выбор, попробуйте снова.");
                        break;
                }
            }
        }

        else if (choce == "3")
        {
            Gryzovic gryzovic = new Gryzovic();
            void Way()
            {

                Console.WriteLine("\nВыберите операцию:");
                Console.WriteLine("1. Продолжить поездку");
                Console.WriteLine("2. Начать новую поездку");
                string cho = Console.ReadLine();
                switch (cho)
                {
                    case "1":
                        Console.WriteLine("Продолжение поездки...");
                        gryzovic.DriveСontinuation();
                        break;

                    case "2":
                        Console.WriteLine("Введите расстояние маршрута в км:");
                        if (double.TryParse(Console.ReadLine(), out double kilometers))
                        {
                            gryzovic.Drive(kilometers);

                        }
                        else
                        {
                            Console.WriteLine("Некорректное значение расстояния.");
                        }
                        break;
                }
            }

            while (true)
            {
                Console.WriteLine("\nВыберите операцию:");
                Console.WriteLine("1. Выбрать маршрут");
                Console.WriteLine("2. Заправиться");
                Console.WriteLine("3. Узнать сколько осталось топлива");
                Console.WriteLine("4. Узнать общее расстояние");
                Console.WriteLine("5. Закончить поездку");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":

                        Way();
                        break;

                    case "2":
                        Console.WriteLine("Введите количество топлива для заправки в литрах:");
                        if (double.TryParse(Console.ReadLine(), out double fuelAmount))
                        {
                            gryzovic.Zapravka(fuelAmount);
                        }
                        else
                        {
                            Console.WriteLine("Некорректное значение топлива.");
                        }
                        break;

                    case "3":
                        Console.WriteLine($"Осталось топлива: {gryzovic.CurrentFuel} литров.");
                        break;

                    case "4":
                        Console.WriteLine($"Общее расстояние, проеханное автомобилем: {gryzovic.TotalKilometers} км.");
                        break;

                    case "5":
                        Console.WriteLine("Поездка завершена.");
                        return;

                    default:
                        Console.WriteLine("Неверный выбор, попробуйте снова.");
                        break;
                }
            }
        }
    }
}
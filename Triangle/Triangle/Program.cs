using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    class Program
    {
        static void PrintInfo(ref double[] Info)
        {
            Console.Clear();
            Console.WriteLine("Стороны:\n" + Info[0] + "\n" + Info[1] + "\n" + Info[2]);
            Console.WriteLine("\nУглы:\n" + Info[3] + "\n" + Info[4] + "\n" + Info[5]);
            Console.WriteLine("\nПериметр: " + Info[6]);
            Console.WriteLine("\nПлощадь: " + Info[7]);
            Console.WriteLine("\nРадиус впис. окружности: " + Info[8]);
            Console.WriteLine("\nРадиус опис. окружности: " + Info[9]);
            Console.WriteLine("\nНажмите любую клавишу чтобы выйти в меню");
            Console.ReadKey(true);
        }
        static void DrawMenuItem(int ItemNumber, ref string MenuItem, ConsoleColor Background, ConsoleColor Foreground)
        {
            Console.SetCursorPosition(0, ItemNumber);
            Console.BackgroundColor = Background;
            Console.ForegroundColor = Foreground;
            Console.Write(MenuItem);
        }
        static void DrawMenu(int Selected, ref string[] Menuitems, ConsoleColor Bacground, ConsoleColor Foreground, ConsoleColor BackgroudSelected, ConsoleColor ForegroundSelected)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            for(int i = 0; i < Menuitems.Length; ++i)
            {
                Console.SetCursorPosition(0, i);
                if(i == Selected)
                {
                    Console.BackgroundColor = BackgroudSelected;
                    Console.ForegroundColor = ForegroundSelected;
                }
                else
                {
                    Console.BackgroundColor = Bacground;
                    Console.ForegroundColor = Foreground;
                }
                Console.Write(Menuitems[i]);
            }
        }
        static void Calc(ref double[] SidesAndCorners)
        {
            double[] Info = new double[10];
            for(int i = 0; i < 6; ++i)
            {
                Info[i] = SidesAndCorners[i];
            }
            Info[6] = Info[0] + Info[1] + Info[2];
            Info[7] = Info[0] * Info[1] / 2 * Math.Sin(Info[5]);
            Info[8] = Info[7] * 2 / Info[6];
            Info[9] = Info[0] / (2 * Math.Sin(Info[3]));
            PrintInfo(ref Info);
        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            bool Quit = false;
            int ItemNumber = 0;
            double BufVar;
            double[] SideAndCorners = new double[6];
            string[] MenuItems = { "Ввести  3 стороны", "Ввести 2 стороны и угол между ними", "Ввести сторону и 2 прилегающих угла", "Выйти"};
            DrawMenu(ItemNumber, ref MenuItems, ConsoleColor.Black, ConsoleColor.DarkYellow, ConsoleColor.DarkYellow, ConsoleColor.Black);
            ConsoleKeyInfo Button;
            while (!Quit)
            {
                Button = Console.ReadKey(true);
                switch(Button.Key)
                {
                    case ConsoleKey.Enter:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        switch (ItemNumber)
                        {
                            case 0:
                                for(int i = 0; i < 3; ++i)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Введите " + (i + 1) + " сторону:");
                                    while(!double.TryParse(Console.ReadLine(), out SideAndCorners[i]) && SideAndCorners[i] <= 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("При вводе произошла ошибка, введите " + (i + 1) + " сторону еще раз: ");
                                    }
                                }
                                for(int i = 0; i < 3; ++i)
                                {
                                    BufVar = 0;
                                    for(int j = 0; j < 3; ++j)
                                    {
                                        if(j==i)
                                        {
                                            BufVar -= SideAndCorners[j] * SideAndCorners[j];
                                        }
                                        else
                                        {
                                            BufVar += SideAndCorners[j] * SideAndCorners[j];
                                        }
                                    }
                                    BufVar /= 2;
                                   for(int j = 0; j < 3; ++j)
                                    {
                                        if (j != i)
                                        {
                                            BufVar /= SideAndCorners[j];
                                        }
                                    }
                                    SideAndCorners[i + 3] = Math.Acos(BufVar);
                                }
                                break;
                            case 1:
                                for (int i = 0; i < 2; ++i)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Введите " + (i + 1) + " сторону:");
                                    while (!double.TryParse(Console.ReadLine(), out SideAndCorners[i]) && SideAndCorners[i] <= 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("При вводе произошла ошибка, введите " + (i + 1) + " сторону еще раз: ");
                                    }
                                }
                                Console.Clear();
                                Console.WriteLine("Введите угол между ними:");
                                while (!double.TryParse(Console.ReadLine(), out SideAndCorners[5]) && SideAndCorners[5] <= 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("При вводе произошла ошибка, введите угол между двумя сторонами еще раз: ");
                                }
                                SideAndCorners[2] = Math.Sqrt(SideAndCorners[0] * SideAndCorners[0] + SideAndCorners[1] * SideAndCorners[1] - 2 * SideAndCorners[0] * SideAndCorners[1] * Math.Cos(SideAndCorners[5]));
                                SideAndCorners[3] = Math.Asin(SideAndCorners[0] * Math.Sin(SideAndCorners[5]) / SideAndCorners[2]);
                                SideAndCorners[4] = Math.Asin(SideAndCorners[1] * Math.Sin(SideAndCorners[5]) / SideAndCorners[2]);
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Введите сторону:");
                                while (!double.TryParse(Console.ReadLine(), out SideAndCorners[0]) && SideAndCorners[0] <= 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("При вводе произошла ошибка, введите сторону еще раз: ");
                                }
                                for (int i = 0; i < 2; ++i)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Введите " + (i + 1) + " угол, прилегающий к стороне:");
                                    while (!double.TryParse(Console.ReadLine(), out SideAndCorners[i + 4]) && SideAndCorners[i + 4] <= 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("При вводе произошла ошибка, введите " + (i + 1) + " угол еще раз: ");
                                    }
                                }
                                SideAndCorners[3] = Math.PI - SideAndCorners[4] - SideAndCorners[5];
                                SideAndCorners[1] = SideAndCorners[0] * Math.Sin(SideAndCorners[4]) / Math.Sin(SideAndCorners[3]);
                                SideAndCorners[2] = SideAndCorners[0] * Math.Sin(SideAndCorners[5]) / Math.Sin(SideAndCorners[3]);
                                break;
                            case 3:
                                Quit = true;
                                break;

                        }
                        if (!Quit)
                        {
                            Calc(ref SideAndCorners);
                            DrawMenu(ItemNumber, ref MenuItems, ConsoleColor.Black, ConsoleColor.DarkYellow, ConsoleColor.DarkYellow, ConsoleColor.Black);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (ItemNumber > 0)
                        {
                            DrawMenuItem(ItemNumber, ref MenuItems[ItemNumber], ConsoleColor.Black, ConsoleColor.DarkYellow);
                            ItemNumber--;
                            DrawMenuItem(ItemNumber, ref MenuItems[ItemNumber], ConsoleColor.DarkYellow, ConsoleColor.Black);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if(ItemNumber<3)
                        {
                            DrawMenuItem(ItemNumber, ref MenuItems[ItemNumber], ConsoleColor.Black, ConsoleColor.DarkYellow);
                            ItemNumber++;
                            DrawMenuItem(ItemNumber, ref MenuItems[ItemNumber], ConsoleColor.DarkYellow, ConsoleColor.Black);
                        }
                        break;
                }
            }
        }
    }
}

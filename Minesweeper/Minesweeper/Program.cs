using System;

namespace Minesweeper
{
    class Program
    {
        static char[,] Checker(char[,] Grid, int x, int y, bool[,] Bombs, bool[,] OpenedItems, int MaxValue)
        {
            int BombsAround = 0;
            OpenedItems[x, y] = true;
            
            if (x > 0 && Bombs[x - 1, y])
            {
                BombsAround++;
            }
            if (x > 0 && y > 0 && Bombs[x - 1, y - 1])
            {
                BombsAround++;
            }
            if (y > 0 && Bombs[x, y - 1])
            {
                BombsAround++;
            }
            if (x < MaxValue - 1 && y > 0 && Bombs[x + 1, y - 1])
            {
                BombsAround++;
            }
            if (x < MaxValue - 1 && Bombs[x + 1, y])
            {
                BombsAround++;
            }
            if (x < MaxValue - 1 && y < MaxValue - 1 && Bombs[x + 1, y + 1])
            {
                BombsAround++;
            }
            if (y < MaxValue - 1 && Bombs[x, y + 1])
            {
                BombsAround++;
            }
            if (x > 0 && y < MaxValue - 1 && Bombs[x - 1, y + 1])
            {
                BombsAround++;
            }
            
            if (BombsAround == 0)
            {
                Grid[x, y] = ' ';
                DrawItem(' ', y, x, ConsoleColor.White, ConsoleColor.DarkGray);
                if (x > 0 && !OpenedItems[x - 1, y] && Grid[x-1,y] != 'P')
                {
                    Grid = Checker(Grid, x - 1, y, Bombs, OpenedItems, MaxValue);
                }
                if (x > 0 && y > 0 && !OpenedItems[x - 1, y - 1] && Grid[x-1, y-1] != 'P')
                {
                    Grid = Checker(Grid, x - 1, y - 1, Bombs, OpenedItems, MaxValue);
                }
                if (y > 0 && !OpenedItems[x, y - 1] && Grid[x, y-1] != 'P')
                {
                    Grid = Checker(Grid, x, y - 1, Bombs, OpenedItems, MaxValue);
                }
                if (x < MaxValue - 1 && y > 0 && !OpenedItems[x + 1, y - 1] && Grid[x+1, y-1] != 'P')
                {
                    Grid = Checker(Grid, x + 1, y - 1, Bombs, OpenedItems, MaxValue);
                }
                if (x < MaxValue - 1 && !OpenedItems[x + 1, y] && Grid[x+1, y] != 'P')
                {
                    Grid = Checker(Grid, x + 1, y, Bombs, OpenedItems, MaxValue);
                }
                if (x < MaxValue - 1 && y < MaxValue - 1 && !OpenedItems[x + 1, y + 1] && Grid[x+1, y+1] != 'P')
                {
                    Grid = Checker(Grid, x + 1, y + 1, Bombs, OpenedItems, MaxValue);
                }
                if (y < MaxValue - 1 && !OpenedItems[x, y + 1] && Grid[x, y+1] != 'P')
                {
                    Grid = Checker(Grid, x, y + 1, Bombs, OpenedItems, MaxValue);
                }
                if (x > 0 && y < MaxValue - 1 && !OpenedItems[x - 1, y + 1] && Grid[x-1, y+1] != 'P')
                {
                    Grid = Checker(Grid, x - 1, y + 1, Bombs, OpenedItems, MaxValue);
                }
            } else
            {
                Grid[x, y] = Convert.ToChar(BombsAround + 48);
                DrawItem(Grid[x, y], y, x, ConsoleColor.Black, ConsoleColor.Gray);
            }
            return Grid;
        }
        static void DrawItem(char Item, int x, int y, ConsoleColor Foreground, ConsoleColor Background)
        {
            Console.BackgroundColor = Background;
            Console.ForegroundColor = Foreground;
            Console.SetCursorPosition(2 * x, y);
            Console.Write(" " + Item);
        }
        static void DrawGrid(int x)
        {
            Console.Clear();
            for (int i = 0; i < x; ++i)
            {
                for (int j = 0; j < x; ++j)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write(' ');
                    if (i == 0 && j == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(Convert.ToChar(183));
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }
        static void Game(int x, ref ConsoleKey[] Buttons)
        {
            ConsoleKeyInfo Button;
            Random BombGenerator = new Random();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            char[,] Grid = new char[x, x];
            bool[,] Bombs = new bool[x, x];
            bool[,] OpenedItems = new bool[x, x];
            for (int i = 0; i < x; ++i)
            {
                for (int j = 0; j < x; ++j)
                {
                    Grid[i, j] = '#';
                    Bombs[i, j] = false;
                    OpenedItems[i, j] = false;
                }
            }
            int[] ActiveItem = new int[2] { 0, 0 };
            int CountOfBombs = x * x / 10;
            DrawGrid(x);
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(x * 2 + 2, 0);
            Console.Write("Найди " + CountOfBombs + " бомб.");
            Console.SetCursorPosition(x * 2 + 2, 1);
            Console.Write("Флажки:");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(x * 2 + 11, 1);
            Console.Write(CountOfBombs);
            bool Quit = false;
            bool Lose = false;
            bool Won = true;
            bool FirstClick = true;
            while (!Quit)
            {
                Button = Console.ReadKey(true);
                switch (Grid[ActiveItem[0], ActiveItem[1]])
                {
                    case 'P':
                        DrawItem('P', ActiveItem[1], ActiveItem[0], ConsoleColor.DarkBlue, ConsoleColor.DarkGreen);
                        break;
                    case '#':
                        DrawItem(' ', ActiveItem[1], ActiveItem[0], ConsoleColor.Black, ConsoleColor.DarkGreen);
                        break;
                    case ' ':
                        DrawItem(' ', ActiveItem[1], ActiveItem[0], ConsoleColor.Black, ConsoleColor.DarkGray);
                        break;
                    default:
                        DrawItem(Grid[ActiveItem[0], ActiveItem[1]], ActiveItem[1], ActiveItem[0], ConsoleColor.Black, ConsoleColor.Gray);
                        break;
                }
                if (Button.Key == Buttons[0] && ActiveItem[0] > 0)
                {
                    ActiveItem[0]--;
                }
                if (Button.Key == Buttons[1] && ActiveItem[0] < x - 1)
                {
                    ActiveItem[0]++;
                }
                if (Button.Key == Buttons[2] && ActiveItem[1] > 0)
                {
                    ActiveItem[1]--;
                }
                if (Button.Key == Buttons[3] && ActiveItem[1] < x - 1)
                {
                    ActiveItem[1]++;
                }
                if (Button.Key == Buttons[4] && Grid[ActiveItem[0],ActiveItem[1]] != 'P')
                {
                    if (FirstClick)
                    {
                        FirstClick = false;
                        for (int i = 0; i < CountOfBombs; ++i)
                        {
                            int BombX = BombGenerator.Next(x);
                            int BombY = BombGenerator.Next(x);
                            if (Bombs[BombX, BombY] || (ActiveItem[0] == BombX && ActiveItem[1] == BombY))
                            {
                                i--;
                            }
                            else
                            {
                                Bombs[BombX, BombY] = true;
                            }
                        }
                    }
                    if (!Bombs[ActiveItem[0], ActiveItem[1]])
                    {
                        Grid = Checker(Grid, ActiveItem[0], ActiveItem[1], Bombs, OpenedItems, x);
                        for (int i = 0; i < x && Won; ++i)
                        {
                            for (int j = 0; j < x; ++j)
                            {
                                if (Grid[i, j] == '#' && !Bombs[i,j])
                                {
                                    Won = false;
                                    break;
                                }
                            }
                        }
                        if (Won)
                        {
                            Console.SetCursorPosition(0, x + 1);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Ура! У тебя получилось, все бомбы обезврежены.\nЧтобы выйти в меню нажми Escape");
                            do
                            {
                                Button = Console.ReadKey(true);
                            } while (Button.Key != ConsoleKey.Escape);
                            Quit = true;
                        }
                        Won = true;
                    }
                    else
                    {
                        Lose = true;
                    }
                }
                switch (Grid[ActiveItem[0], ActiveItem[1]])
                {
                    case 'P':
                        DrawItem('P', ActiveItem[1], ActiveItem[0], ConsoleColor.DarkYellow, ConsoleColor.DarkGreen);
                        break;
                    case '#':
                        DrawItem(Convert.ToChar(183), ActiveItem[1], ActiveItem[0], ConsoleColor.Black, ConsoleColor.DarkGreen);
                        break;
                    case ' ':
                        DrawItem(Convert.ToChar(183), ActiveItem[1], ActiveItem[0], ConsoleColor.White, ConsoleColor.DarkGray);
                        break;
                    default:
                        DrawItem(Grid[ActiveItem[0], ActiveItem[1]], ActiveItem[1], ActiveItem[0], ConsoleColor.DarkYellow, ConsoleColor.Gray);
                        break;
                }
                if (Button.Key == ConsoleKey.Escape)
                {
                    Quit = true;
                }
                if (Button.Key == Buttons[5] && ((Grid[ActiveItem[0], ActiveItem[1]] == '#' && CountOfBombs > 0) || Grid[ActiveItem[0], ActiveItem[1]] == 'P'))
                {
                    if (Grid[ActiveItem[0], ActiveItem[1]] != 'P')
                    {
                        Grid[ActiveItem[0], ActiveItem[1]] = 'P';
                        Console.SetCursorPosition(x * 2 + 11, 1);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(--CountOfBombs + " ");
                        DrawItem('P', ActiveItem[1], ActiveItem[0], ConsoleColor.DarkYellow, ConsoleColor.DarkGreen);
                    }
                    else
                    {
                        Grid[ActiveItem[0], ActiveItem[1]] = '#';
                        Console.SetCursorPosition(x * 2 + 11, 1);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(++CountOfBombs + " ");
                        DrawItem(Convert.ToChar(183), ActiveItem[1], ActiveItem[0], ConsoleColor.Black, ConsoleColor.DarkGreen);
                    }
                }
                if (Lose)
                {
                    Quit = true;
                    for (int i = 0; i < x; ++i)
                    {
                        for (int j = 0; j < x; ++j)
                        {
                            if (Bombs[i, j] && Grid[i, j] != 'P')
                            {
                                DrawItem('X', j, i, i == ActiveItem[0] && j == ActiveItem[1] ? ConsoleColor.DarkYellow : ConsoleColor.DarkRed, ConsoleColor.DarkGreen);
                            }
                        }
                    }
                    Console.SetCursorPosition(0, x);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Упс.. Подорвался...\nНажмите Escape чтобы выйти в меню.");
                    do
                    {
                        Button = Console.ReadKey(true);
                    } while (Button.Key != ConsoleKey.Escape);
                }
            }
        }
        static void SetControls(ref ConsoleKey[] Buttons)
        {
            bool Quit = false;
            int Selected = 0;
            ConsoleKeyInfo Button;
            string[] ButtonNames = { "Вверх", "Вниз", "Влево", "Вправо", "Копать", "Ставить флаг", "Сохранить и выйти" };
            DrawMenu(Selected, ButtonNames);
            Console.SetCursorPosition(Selected % 2 == 0 ? Console.BufferWidth / 2 - (ButtonNames[Selected].Length + Convert.ToString(Buttons[Selected]).Length + 5) : Console.BufferWidth / 2 + ButtonNames[Selected].Length + 3, Console.BufferHeight / 2 - Buttons.Length / 2 + Selected);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("-" + Convert.ToString(Buttons[Selected]) + "-");
            bool IsCorrect = true;
            while (!Quit)
            {
                Button = Console.ReadKey(true);
                switch (Button.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (Selected > 0)
                        {
                            DrawMenuItem(Selected, ButtonNames.Length, ButtonNames[Selected], ConsoleColor.White, ConsoleColor.Black);
                            if (Selected < Buttons.Length)
                            {
                                Console.SetCursorPosition(Selected % 2 == 0 ? Console.BufferWidth / 2 - (ButtonNames[Selected].Length + Convert.ToString(Buttons[Selected]).Length + 5) : Console.BufferWidth / 2 + ButtonNames[Selected].Length + 3, Console.BufferHeight / 2 - Buttons.Length / 2 + Selected);
                                Console.BackgroundColor = ConsoleColor.Black;
                                for (int i = 0; i < Convert.ToString(Buttons[Selected]).Length + 2; ++i)
                                {
                                    Console.Write(' ');
                                }
                            }
                            Selected--;
                            DrawMenuItem(Selected, ButtonNames.Length, ButtonNames[Selected], ConsoleColor.Black, ConsoleColor.DarkYellow);
                            Console.SetCursorPosition(Selected % 2 == 0 ? Console.BufferWidth / 2 - (ButtonNames[Selected].Length + Convert.ToString(Buttons[Selected]).Length + 5) : Console.BufferWidth / 2 + ButtonNames[Selected].Length + 3, Console.BufferHeight / 2 - Buttons.Length / 2 + Selected);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("-" + Convert.ToString(Buttons[Selected]) + "-");
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (Selected < ButtonNames.Length - 1)
                        {
                            DrawMenuItem(Selected, ButtonNames.Length, ButtonNames[Selected], ConsoleColor.White, ConsoleColor.Black);
                            Console.SetCursorPosition(Selected % 2 == 0 ? Console.BufferWidth / 2 - (ButtonNames[Selected].Length + Convert.ToString(Buttons[Selected]).Length + 5) : Console.BufferWidth / 2 + ButtonNames[Selected].Length + 3, Console.BufferHeight / 2 - Buttons.Length / 2 + Selected);
                            Console.BackgroundColor = ConsoleColor.Black;
                            for (int i = 0; i < Convert.ToString(Buttons[Selected]).Length + 2; ++i)
                            {
                                Console.Write(' ');
                            }
                            Selected++;
                            DrawMenuItem(Selected, ButtonNames.Length, ButtonNames[Selected], ConsoleColor.Black, ConsoleColor.DarkYellow);
                            if (Selected < Buttons.Length)
                            {
                                Console.SetCursorPosition(Selected % 2 == 0 ? Console.BufferWidth / 2 - (ButtonNames[Selected].Length + Convert.ToString(Buttons[Selected]).Length + 5) : Console.BufferWidth / 2 + ButtonNames[Selected].Length + 3, Console.BufferHeight / 2 - Buttons.Length / 2 + Selected);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Write("-" + Convert.ToString(Buttons[Selected]) + "-");
                            }
                        }
                        break;
                    case ConsoleKey.Enter:
                        DrawMenuItem(Selected, ButtonNames.Length, ButtonNames[Selected], ConsoleColor.Black, ConsoleColor.DarkGreen);
                        if (Selected < Buttons.Length)
                        {
                            Console.SetCursorPosition(Selected % 2 == 0 ? Console.BufferWidth / 2 - (ButtonNames[Selected].Length + Convert.ToString(Buttons[Selected]).Length + 5) : Console.BufferWidth / 2 + ButtonNames[Selected].Length + 3, Console.BufferHeight / 2 - Buttons.Length / 2 + Selected);
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.Write("-" + Convert.ToString(Buttons[Selected]) + "-");
                            Button = Console.ReadKey(true);
                            for (int i = 0; i < Buttons.Length; ++i)
                            {
                                if (Buttons[i] == Button.Key)
                                {
                                    IsCorrect = false;
                                }
                            }
                            DrawMenuItem(Selected, ButtonNames.Length, ButtonNames[Selected], ConsoleColor.Black, ConsoleColor.DarkYellow);
                            if (IsCorrect)
                            {
                                Console.SetCursorPosition(Selected % 2 == 0 ? Console.BufferWidth / 2 - (ButtonNames[Selected].Length + Convert.ToString(Buttons[Selected]).Length + 5) : Console.BufferWidth / 2 + ButtonNames[Selected].Length + 3, Console.BufferHeight / 2 - Buttons.Length / 2 + Selected);
                                Console.BackgroundColor = ConsoleColor.Black;
                                for (int i = 0; i < Convert.ToString(Buttons[Selected]).Length + 2; ++i)
                                {
                                    Console.Write(' ');
                                }
                                Buttons[Selected] = Button.Key;
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                IsCorrect = true;
                            }
                            Console.SetCursorPosition(Selected % 2 == 0 ? Console.BufferWidth / 2 - (ButtonNames[Selected].Length + Convert.ToString(Buttons[Selected]).Length + 5) : Console.BufferWidth / 2 + ButtonNames[Selected].Length + 3, Console.BufferHeight / 2 - Buttons.Length / 2 + Selected);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("-" + Convert.ToString(Buttons[Selected]) + "-");
                        } else
                        {
                            Quit = true;
                        }
                        break;
                }
            }
        }
        static void DrawMenuItem(int ActiveItem, int Length, string Item, ConsoleColor ForegroundColor, ConsoleColor BackgroundColor)
        {
            Console.SetCursorPosition((ActiveItem % 2 == 0 ? Console.BufferWidth / 2 - Item.Length : Console.BufferWidth / 2) - 2, Console.BufferHeight / 2 - Length / 2 + ActiveItem);
            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
            Console.WriteLine("  " + Item + "  ");
        }
        static void DrawMenu(int Selected, string[] ButtonNames)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            for (int i = 0; i < ButtonNames.Length; ++i)
            {
                DrawMenuItem(i, ButtonNames.Length, ButtonNames[i], i == Selected ? ConsoleColor.Black : ConsoleColor.White, i == Selected ? ConsoleColor.DarkYellow : ConsoleColor.Black);
            }
        }
        static void ChooseGridScale(ref ConsoleKey[] Buttons)
        {
            bool Quit = false;
            int Selected = 0;
            ConsoleKeyInfo Button;
            string[] ButtonNames = { "Маленькое", "Среднее", "Большое", "Назад" };
            DrawMenu(Selected, ButtonNames);
            while (!Quit)
            {
                Button = Console.ReadKey(true);
                switch (Button.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (Selected > 0)
                        {
                            DrawMenuItem(Selected, ButtonNames.Length, ButtonNames[Selected], ConsoleColor.White, ConsoleColor.Black);
                            Selected--;
                            DrawMenuItem(Selected, ButtonNames.Length, ButtonNames[Selected], ConsoleColor.Black, ConsoleColor.DarkYellow);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (Selected < ButtonNames.Length - 1)
                        {
                            DrawMenuItem(Selected, ButtonNames.Length, ButtonNames[Selected], ConsoleColor.White, ConsoleColor.Black);
                            Selected++;
                            DrawMenuItem(Selected, ButtonNames.Length, ButtonNames[Selected], ConsoleColor.Black, ConsoleColor.DarkYellow);
                        }
                        break;
                    case ConsoleKey.Enter:
                        DrawMenuItem(Selected, ButtonNames.Length, ButtonNames[Selected], ConsoleColor.Black, ConsoleColor.DarkGreen);
                        System.Threading.Thread.Sleep(50);
                        switch (Selected)
                        {
                            case 0:
                                Game(10, ref Buttons);
                                break;
                            case 1:
                                Game(15, ref Buttons);
                                break;
                            case 2:
                                Game(20, ref Buttons);
                                break;
                            case 3:
                                break;
                        }
                        Quit = true;
                        break;
                }
            }
        }
        static void HowToPlay()
        {
            ConsoleKeyInfo Button;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Сапер - это компьютерная игра головоломка, задача которой состоит в обнуружении всех бомб на поле.\nКолличество бомб зависит от размеров поля.\nПосле нажатия кнопки играть, вам нужно будет ввести длинну квадратного поля, затем\nвы сможете с помощью стрелок на клавиатуре перемещаться по полю и вскапывать его(Enter) либо ставить флажок(Space).\nУправление можно поменять в главном меню.\nЧтобы вернуться нажмите Escape или Enter.");
            do
            {
                Button = Console.ReadKey(true);
            } while (Button.Key != ConsoleKey.Escape && Button.Key != ConsoleKey.Enter);
        }
        static void Main(string[] args)
        {
            Console.Title = "Minesweeper";
            Console.SetWindowSize(100, 25);
            Console.SetBufferSize(100, 25);
            Console.CursorVisible = false;
            bool Quit = false;
            int Selected = 0;
            ConsoleKey[] Buttons = { ConsoleKey.UpArrow, ConsoleKey.DownArrow,ConsoleKey.LeftArrow, ConsoleKey.RightArrow, ConsoleKey.Enter, ConsoleKey.Spacebar};
            string[] ButtonNames = { "Играть", "Управление", "Как играть?", "Выход" };
            DrawMenu(Selected, ButtonNames);
            ConsoleKeyInfo Button;
            while (!Quit)
            {
                Button = Console.ReadKey(true);
                switch (Button.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (Selected > 0)
                        {
                            DrawMenuItem(Selected, ButtonNames.Length, ButtonNames[Selected], ConsoleColor.White, ConsoleColor.Black);
                            Selected--;
                            DrawMenuItem(Selected, ButtonNames.Length, ButtonNames[Selected], ConsoleColor.Black, ConsoleColor.DarkYellow);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (Selected < ButtonNames.Length - 1)
                        {
                            DrawMenuItem(Selected, ButtonNames.Length, ButtonNames[Selected], ConsoleColor.White, ConsoleColor.Black);
                            Selected++;
                            DrawMenuItem(Selected, ButtonNames.Length, ButtonNames[Selected], ConsoleColor.Black, ConsoleColor.DarkYellow);
                        }
                        break;
                    case ConsoleKey.Enter:
                        DrawMenuItem(Selected, ButtonNames.Length, ButtonNames[Selected], ConsoleColor.Black, ConsoleColor.DarkGreen);
                        
                        System.Threading.Thread.Sleep(50);
                        switch (Selected)
                        {
                            case 0:
                                ChooseGridScale(ref Buttons);
                                DrawMenu(Selected, ButtonNames);
                                break;
                            case 1:
                                SetControls(ref Buttons);
                                DrawMenu(Selected, ButtonNames);
                                break;
                            case 2:
                                HowToPlay();
                                DrawMenu(Selected, ButtonNames);
                                break;
                            case 3:
                                Quit = true;
                                break;
                        }
                        break;
                }
            }
        }
    }
}
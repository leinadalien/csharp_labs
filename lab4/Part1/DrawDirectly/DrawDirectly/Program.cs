using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;

namespace DrawDirectly
{
    class Program
    {
        [DllImport("User32.dll")]
        static extern IntPtr GetDC(IntPtr Hwnd);
        static void Draw(Rectangle R, Brush B, IntPtr Hwnd)
        {
            using(Graphics G = Graphics.FromHdc(Hwnd))
            {
                G.FillRectangle(B, R);
            }
        }
        static void Main(string[] args)
        {
            Random Rand = new Random();
            Console.Write("Enter command: ");
            string Command = Console.ReadLine();
            int x, y, Height, Width;
            if (Command.ToLower() == "break")
            {
                Brush[] DifferentBrushes = new Brush[]
                {
                    Brushes.Red,
                    Brushes.Orange,
                    Brushes.Yellow,
                    Brushes.Green,
                    Brushes.Cyan,
                    Brushes.Blue,
                    Brushes.Purple
                };
                Brush B;
                for(int i = 0; i < 1920; ++i)
                {
                    B = DifferentBrushes[i % 7];
                    x = i;
                    y = 0;
                    Height = 1080;
                    Width = 1;
                    Draw(new Rectangle(x, y, Width, Height), B, GetDC(IntPtr.Zero));
                }
                while(true)
                {
                    B = DifferentBrushes[Rand.Next(0,DifferentBrushes.Length)];
                    x = Rand.Next(0,1920);
                    y = Rand.Next(0, 1080);
                    Height = Rand.Next(5, 10);
                    Width = Rand.Next(5, 10);
                    Draw(new Rectangle(x, y, Height, Width), B, GetDC(IntPtr.Zero));
                }
            }
           
        }
    }
}

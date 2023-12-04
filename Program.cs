using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
namespace Project_Maze
{
    internal class Program
    {
        static int PlayerX = 0, PlayerY = 0;
        static void Loading()
        {
            Thread.Sleep(200);
            Console.WriteLine("  _                    _ _               \r\n | |    ___   __ _  __| (_)_ __   __ _   \r\n | |   / _ \\ / _` |/ _` | | '_ \\ / _` |  \r\n | |__| (_) | (_| | (_| | | | | | (_| |_ \r\n |_____\\___/ \\__,_|\\__,_|_|_| |_|\\__, (_)\r\n                                 |___/   ");
            Thread.Sleep(200);
            Console.Clear();
            Thread.Sleep(200);
            Console.WriteLine("  _                    _ _                 \r\n | |    ___   __ _  __| (_)_ __   __ _     \r\n | |   / _ \\ / _` |/ _` | | '_ \\ / _` |    \r\n | |__| (_) | (_| | (_| | | | | | (_| |_ _ \r\n |_____\\___/ \\__,_|\\__,_|_|_| |_|\\__, (_|_)\r\n                                 |___/     ");
            Thread.Sleep(200);
            Console.Clear();
            Thread.Sleep(200);
            Console.WriteLine("  _                    _ _                   \r\n | |    ___   __ _  __| (_)_ __   __ _       \r\n | |   / _ \\ / _` |/ _` | | '_ \\ / _` |      \r\n | |__| (_) | (_| | (_| | | | | | (_| |_ _ _ \r\n |_____\\___/ \\__,_|\\__,_|_|_| |_|\\__, (_|_|_)\r\n                                 |___/       ");
            Thread.Sleep(200);
            Console.Clear();
            Thread.Sleep(200);
        }
        static void Logo()
        {
            Console.WriteLine("░█▄█░█▀█░▀▀█░█▀▀\r\n░█░█░█▀█░▄▀░░█▀▀\r\n░▀░▀░▀░▀░▀▀▀░▀▀▀");
        }
        static void Main()
        {
            int FieldHeight = 15, FieldWidth = 55;
            char[,] Field = CreateField(FieldWidth, FieldHeight, 20);
            int[] PlayerCoords = PlaceCharacter(FieldHeight, FieldWidth);
            PlayerX = PlayerCoords[0];
            PlayerY = PlayerCoords[1];
            while (!EndGame())
            {
                DrawField(Field, FieldHeight, FieldWidth);
                int[] Directions = GetInput();
                int Dx = Directions[0];
                int Dy = Directions[1];
                Logic(Dx, Dy, Field, FieldHeight, FieldWidth);
            }
        }
        static char[,] CreateField(int Width, int Height, int BlockFreq)
        {

            Loading();
            Random Random = new Random();
            char[,] Field = new char[Height, Width];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    int RandNumber = Random.Next(0, 100);
                    if (RandNumber < BlockFreq) Field[i, j] = '#';
                    else Field[i, j] = ' ';
                }
            }
            return Field;
        }
        static void DrawField(char[,] Field, int Height, int Width)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Clear();
            Logo();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    char SymbolToPrint = Field[i,j];
                    if (i == PlayerY && j == PlayerX) 
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        SymbolToPrint = '■';
                    }
                    Console.Write(SymbolToPrint);
                }
                Console.WriteLine();
            }
        }
        static int[] PlaceCharacter(int FieldWidth, int FieldHeight)
        {
            Random random = new Random();
            int x = random.Next(0, FieldWidth - 1);
            int y = random.Next(0, FieldHeight - 1);
            return new int[] { x, y };
        }
        static void TryGoTo(int newX, int newY, char[,] Field, int Height, int Width)
        {
            if (CanGoTo(newX, newY, Field, Height, Width))
            {
                GoTo(newX, newY);
            }
        }
        static bool CanGoTo(int x, int y, char[,] Field, int Height, int Width)
        {
            if (!IsPointInsideField(x, y, Height, Width))
            {
                return false;
            }

            if (!IsWalkable(x, y, Field))
            {
                return false;
            }

            return true;
        }

        static bool IsPointInsideField(int x, int y, int Height, int Width)
        {
            return x >= 0 && y >= 0 && x < Width && y < Height;
        }

        static void GoTo(int NewX, int NewY)
        {
            PlayerX = NewX;
            PlayerY = NewY;
        }
        static int[] GetInput()
        {
            int Dx = 0, Dy = 0;
            ConsoleKey input = Console.ReadKey().Key;
            switch (input)
            {
                case ConsoleKey.W:
                    Dy--;
                    break;
                case ConsoleKey.S:
                    Dy++;
                    break;
                case ConsoleKey.A:
                    Dx--;
                    break;
                case ConsoleKey.D:
                    Dx++;
                    break;
            }
            return new int[] {Dx, Dy};
        }
        static bool IsWalkable(int x, int y, char[,] field)
        {
            if (field[y,x] == '#')
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static void Logic(int Dx, int Dy, char[,] Field, int FieldHeight, int FieldWidth)
        {
            TryGoTo(PlayerX + Dx, PlayerY + Dy, Field, FieldHeight, FieldWidth);
        }

        static bool EndGame()
        {
            return false;
        }

    }
}

using System.Collections;
using System.Globalization;

namespace Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rols = tokens[0];
            int cols = tokens[1];

            char[,] map = new char[rols, cols];

            int playerRol = -1;
            int playerCol = -1;

            int tryPlayerRol = -1;
            int tryPlayerCol = -1;

            int touchedOpponents = 0;
            int moves = 0;


            for (int rol = 0; rol < rols; rol++)
            {
                char[] colInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    map[rol, col] = (char)colInfo[col];
                    if (map[rol, col] == 'B')
                    {
                        tryPlayerRol = rol;
                        tryPlayerCol = col;
                        playerRol = rol;
                        playerCol = col;
                    }
                }
            }
            string comand;
            while ((comand = Console.ReadLine()) != "Finish")
            {
                //"up", " down", "right", and "left".
                switch (comand)
                {
                    case "up":
                        tryPlayerRol--;
                        break;
                    case "down":
                        tryPlayerRol++;
                        break;
                    case "right":
                        tryPlayerCol++;
                        break;
                    case "left":
                        tryPlayerCol--;
                        break;
                }

                if (tryPlayerRol >= 0 && tryPlayerCol >= 0
                    && map.GetLength(0) > tryPlayerRol && map.GetLength(1) > tryPlayerCol
                    && map[tryPlayerRol, tryPlayerCol] != 'O')
                {
                    if (map[tryPlayerRol, tryPlayerCol] == '-')
                    {
                        moves++;
                        map[playerRol, playerCol] = '-';
                        playerRol = tryPlayerRol;
                        playerCol = tryPlayerCol;
                        map[tryPlayerRol, tryPlayerCol] = 'B';
                    }
                    else if (map[tryPlayerRol, tryPlayerCol] == 'P')
                    {
                        touchedOpponents++;
                        moves++;
                        map[playerRol, playerCol] = '-';
                        playerRol = tryPlayerRol;
                        playerCol = tryPlayerCol;
                        map[tryPlayerRol, tryPlayerCol] = 'B';
                        if (touchedOpponents == 3)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    tryPlayerRol = playerRol;
                    tryPlayerCol = playerCol;
                }
                //PrinntMap(map);
            }
            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {touchedOpponents} Moves made: {moves}");
        }

        private static void PrinntMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
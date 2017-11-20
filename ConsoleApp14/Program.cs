using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] playerboard = new char[10,10];
            char[,] masterboard = new char[10,10];
            char[,] enemyboard = new char[10,10];

            Random r = new Random();

            for (int i = 1; i < 9; i++)
            {
                 
                for (int j = 1; j < 9; j++)
                {
                    playerboard[i, j] = 'O';
                    masterboard[i, j] = 'O';
                    enemyboard[i, j] = 'O';
                }
            }

            masterboard[r.Next(1, 9), r.Next(1, 9)] = 'S';
            masterboard[r.Next(1, 9), r.Next(1, 9)] = 'S';
            masterboard[r.Next(1, 9), r.Next(1, 9)] = 'S';

            PrintBoard(masterboard);



            int enemyBoats = 3;
            int playerboats = 3;
            Console.WriteLine("There are 3 enemy ships on the grid... We need to take them out before they sink the BATTLESHIPS on our grid!");
            Console.WriteLine("Below is the enemy grid... We don't know where the ships are, so we have to get lucky.");
            PrintBoard(enemyboard);

            Console.WriteLine("Below is our grid. Empty now, but you must choose where to put our 3 BATTLESHIPS!");
            PrintBoard(playerboard);

            for (int k = 0; k < 3; k++)
            {
                Console.WriteLine("Choose the 'x' coordinate to place ship number " + (k + 1));
                int v = Convert.ToInt32(Console.ReadLine());
                while(v < 1 || v > 8)
                {
                    Console.WriteLine("The grid is 8x8. You must choose again with a spot on the grid ");
                    v = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("Choose the 'y' coordinate to place ship number " + (k + 1));
                int w = Convert.ToInt32(Console.ReadLine());
                while (w < 1 || w > 8)
                {
                    Console.WriteLine("The grid is 8x8. You must choose again with a spot on the grid ");
                    w = Convert.ToInt32(Console.ReadLine());
                }

                if (playerboard[w, v] != 'S')
                {
                    playerboard[w, v] = 'S';
                }
                else
                {
                    Console.WriteLine("You already put a ship there! You wrecked one of our BATTLESHIPS!");
                    playerboard[w, v] = 'S';
                    playerboats--;
                }

                PrintBoard(playerboard);
            }
            Console.WriteLine("Below is our grid with our BATTLESHIPS placed stragtegically:");
            PrintBoard(playerboard);

            Console.WriteLine("Press enter to continue");
            Console.ReadLine();

            Console.WriteLine("Now... We BATTLE our SHIPS! Enemy grid: ");
            PrintBoard(enemyboard);

            while (enemyBoats > 0 && playerboats > 0)
            {
                Console.WriteLine("Choose 'x' coordinate for your next attack: ");
                int x = Convert.ToInt32(Console.ReadLine());
                while (x < 1 || x > 8)
                {
                    Console.WriteLine("The grid is 8x8. You must choose again with a spot on the grid ");
                    x = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("Choose 'y' coordinate for your next attack: ");
                int y = Convert.ToInt32(Console.ReadLine());
                while (y < 1 || y > 8)
                {
                    Console.WriteLine("The grid is 8x8. You must choose again with a spot on the grid ");
                    y = Convert.ToInt32(Console.ReadLine());
                }


                if (masterboard[y, x] == 'S')
                {
                    Console.WriteLine("It's a hit!");
                    enemyBoats--;
                }
                else if (masterboard[y, x] == 'O')
                {
                    Console.WriteLine("It's a miss... We'll try again later");
                    if (masterboard[y + 1, x + 1] == 'S' || masterboard[y, x + 1] == 'S' || masterboard[y - 1, x + 1] == 'S' || masterboard[y + 1, x] == 'S' ||
                        masterboard[y + 1, x - 1] == 'S' || masterboard[y - 1, x] == 'S' || masterboard[y, x - 1] == 'S' || masterboard[y - 1, x - 1] == 'S')
                    {
                        Console.WriteLine("New intel shows your coordinates were very close to an enemy ship...");
                    }
                }
                else
                {
                    Console.WriteLine("You already fired here, fool!");
                }
                enemyboard[y, x] = 'X';
                masterboard[y, x] = 'X';


                PrintBoard(enemyboard);

                if (enemyBoats == 0)
                {
                    Console.WriteLine("Game over... You win!");
                    break;
                }

                Console.WriteLine("Now it's their turn... press Enter to continue");
                Console.ReadLine();
                int f = r.Next(1, 9);
                int g = r.Next(1, 9);
                if (playerboard[f, g] == 'S')
                {
                    Console.WriteLine("FUCK!. THEY SUNK OUR BATTLESHIP!");
                    playerboats--;
                }
                else
                {
                    Console.WriteLine("Phew! They missed...");

                }
                playerboard[f, g] = 'X';
                Console.WriteLine("Our grid: ");
                PrintBoard(playerboard);
            }

            if (playerboats == 0)
            {
                Console.WriteLine("Game over... You lose!");
            }
            Console.ReadLine();
        }

        static void PrintBoard(char[,] board)
        {
            for (int i = 1; i < 9; i++)
            {

                for (int j = 1; j < 9; j++)
                {

                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine(i);
            }
            for (int i = 1; i <= 8; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}

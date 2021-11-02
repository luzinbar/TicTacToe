using System;
namespace TicTacToe
{
    class Program
    {
        public const int board_size = 3;

        public static bool[] usedSpots = new bool[board_size * board_size + 1];

        public static char[,] field = new char[board_size, board_size];

        public static int winner;

        public static int player1 = 1;

        public static int player2 = 2;
        
        public static char userSign = 'O';

        public static char computerSign = 'X';

        public static int numOfMoves;

        static void Main(string[] args)
        {
            int currentPlayer;

            do
            {
                RestartField();
                PrintBoard();
                currentPlayer = player1;

                do
                {
                    Play(currentPlayer);
                    numOfMoves++;
                    currentPlayer = currentPlayer == player1 ? player2 : player1;

                } while (!DoWeHaveAWinner() && (numOfMoves != (board_size * board_size)));

                if (numOfMoves ==  board_size * board_size)
                {
                    Console.WriteLine("IT'S A TIE!");
                }
                else
                {
                    Console.WriteLine("AND THE WINNER IS....");
                    Console.WriteLine("PLAYER {0} !!! BRAVO!", winner);
                }
                
                Console.WriteLine("-----------");
                Console.WriteLine("Press any key to restart ths game");
                Console.ReadLine();
                Console.Clear();
            }
            while (true);
        }

        public static void RestartField()
        {
            char cell_label = '1';
            for (int i=0; i < board_size; i++)
            {
                for (int j=0; j < board_size; j++)
                {
                    field[i, j] = cell_label;
                    cell_label++;
                }
            }

            for (int i=0; i< usedSpots.Length; i++)
            {
                usedSpots[i] = false;
            }

            numOfMoves = 0;
        }

        public static void PrintBoard()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", field[0, 0], field[0, 1], field[0, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", field[1, 0], field[1, 1], field[1, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", field[2, 0], field[2, 1], field[2, 2]);
            Console.WriteLine("     |     |     ");
            Console.WriteLine();
        }

        public static bool DoWeHaveAWinner()
        {
            return CheckRow() ? true : CheckColumn() ? true : CheckDiagonal() ? true : false;
        }

        public static bool CheckRow()
        {
            for (int i = 0; i < board_size; i++)
            {
                char sign = field[i, 0];
                if (field[i, 1] == sign && field[i, 2] == sign)
                {
                    winner = sign == userSign ? player1 : player2;
                    return true;
                }
            }

            return false;
        }

        public static bool CheckColumn()
        {
            for (int i=0; i<board_size; i++)
            {
                char sign = field[0, i];
                if (field[1, i] == sign && field[2, i] == sign)
                {
                    winner = sign == userSign ? player1 : player2;
                    return true;
                }
            }

            return false;
        }

        public static bool CheckDiagonal()
        {
            char sign = field[1, 1];
            if (field[0, 0] == sign && field[2, 2] == sign)
            {
                winner = sign == userSign ? player1 : player2;
                return true;
            }
            if (field[0,2] == sign && field[2,0] == sign)
            {
                winner = sign == userSign ? player1 : player2;
                return true;
            }

            return false;
        }

        public static void Play(int player)
        {
            Console.WriteLine("Player {0}: Choose your field!" , player);
            string Sspot = Console.ReadLine();
            int Ispot;
            if (!Int32.TryParse(Sspot, out Ispot)) // not an Integer
            {
                Console.WriteLine(" your input is illegal");
                Play(player);
            }
            else if (Ispot < 1 || Ispot > (board_size * board_size) || usedSpots[Ispot]) // not in range
            {
                Console.WriteLine(" your input is illegal");
                Play(player);
            }
            else
            {
                usedSpots[Ispot] = true;
                updateField(Ispot, player);
            }
            Console.Clear();
            PrintBoard();
        }

        public static void updateField(int spot, int player)
        {
            char sign = player == player1 ? userSign : computerSign;
            int row = (spot - 1) / board_size;
            int column = (spot - 1) % board_size;
            field[row, column] = sign;
        }
    }
}

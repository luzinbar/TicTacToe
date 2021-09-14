using System;

namespace TicTacToe
{
    class Program
    {
        public static bool[] usedSpots = { false, false, false, false, false, false, false, false, false, false};

        public static char[,] field =
        {
            {'1' , '2' , '3' } ,
            {'4' , '5' , '6' } ,
            {'7' , '8' , '9' }
        };

        public static int winner = 0;

        static void Main(string[] args)
        {
            do
            {
                SetField();
                Play(1);
                Play(2);
                while (!DoWeHaveAWinner())
                {
                    Play(1);
                    if (!DoWeHaveAWinner())
                    {
                        Play(2);
                    }
                }

                Console.WriteLine("AND THE WINNER IS....");
                Console.WriteLine("PLAYER {0} !!! BRAVO!", winner);
                Console.WriteLine("-----------");
                Console.WriteLine("Press any key to restart ths game");
                Console.ReadLine();
                Console.Clear();
            }
            while (true);
        }

        public static bool DoWeHaveAWinner()
        {
            return CheckRow() ? true : CheckColumn() ? true : CheckDiagonal() ? true : false;
        }

        public static bool CheckRow()
        {
            for (int i = 0; i < 3; i++)
            {
                char c = field[i, 0];
                if (field[i, 1] == c && field[i, 2] == c)
                {
                    winner = c == 'O' ? 1 : 2;
                    return true;
                }
            }

            return false;
        }

        public static bool CheckColumn()
        {
            for (int i=0; i<3; i++)
            {
                char c = field[0, i];
                if (field[1, i] == c && field[2, i] == c)
                {
                    winner = c == 'O' ? 1 : 2;
                    return true;
                }
            }

            return false;
        }

        public static bool CheckDiagonal()
        {
            char c = field[1, 1];
            if (field[0, 0] == c && field[2, 2] == c)
            {
                winner = c == 'O' ? 1 : 2;
                return true;
            }
            if (field[0,2] == c && field[2,0] == c)
            {
                winner = c == 'O' ? 1 : 2;
                return true;
            }

            return false;
        }

        public static void SetField()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  " , field[0,0] , field[0, 1], field[0, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  " , field[1, 0], field[1, 1], field[1, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  " , field[2, 0], field[2, 1], field[2, 2]);
            Console.WriteLine("     |     |     ");
        }

        public static void Play(int player)
        {
            Console.WriteLine("Player {0}: Choose your field!" , player);
            string Sspot = Console.ReadLine();
            int Ispot;
            if (!Int32.TryParse(Sspot, out Ispot))
            {
                Console.WriteLine(" your input is illegal");
                Play(player);
            }
            else if (Ispot < 1 || Ispot > 9 || usedSpots[Ispot])
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
            SetField();
        }

        public static void updateField(int spot, int player)
        {
            char c = player == 1 ? 'O' : 'X';
            switch (spot)
            {
                case 1:
                        field[0, 0] = c;
                        break;
                case 2:
                    field[0, 1] = c;
                    break;
                case 3:
                    field[0, 2] = c;
                    break;
                case 4:
                    field[1, 0] = c;
                    break;
                case 5:
                    field[1, 1] = c;
                    break;
                case 6:
                    field[1, 2] = c;
                    break;
                case 7:
                    field[2, 0] = c;
                    break;
                case 8:
                    field[2, 1] = c;
                    break;
                default: // case 9
                    field[2, 2] = c;
                    break;
            }
        }
    }
}

using System;

namespace tic_tac_toe
{
    class Program
    {
       static void Main(string[] args)
        {
            var y = UserInput();
            var matrix = Board();

            while (!Win(matrix))
            {
                if (y == "x")
                {
                    PrintBoard(matrix);
                    int n = Number();
                    while (!FindPositionAndIsValid(matrix, n))
                    {
                        Console.WriteLine("Please enter a valid number.");
                        n = Number();
                    }

                    Replace(matrix, n, 'x');

                    if (Win(matrix))
                    {
                        break;
                    }

                    if (End(matrix) && !Win(matrix))
                    {
                        Console.WriteLine("Game over.No one win!");
                        break;
                    }

                    var number = new Random();
                    var value = number.Next(1, 10);
                    while (!(FindPositionAndIsValid(matrix, value)))
                    {
                        value = number.Next(1, 10);
                    }

                    Replace(matrix, value, 'o');
                }
                else if (y == "o")
                {
                    var number = new Random();
                    var value = number.Next(1, 10);
                    while (!(FindPositionAndIsValid(matrix, value)))
                    {
                        value = number.Next(1, 10);
                    }

                    Replace(matrix, value, 'x');
                    PrintBoard(matrix);
                    if (Win(matrix))
                    {
                        break;
                    }

                    if (End(matrix) && !Win(matrix))
                    {
                        Console.WriteLine("Game over.No one win!");
                        break;
                    }

                    int n = Number();
                    while (!FindPositionAndIsValid(matrix, n))
                    {
                        Console.WriteLine("Please enter a valid number.");
                        n = Number();
                    }

                    Replace(matrix, n, 'o');
                }

                Console.WriteLine();
                Console.Clear();
            }

            PrintBoard(matrix);
           // Console.WriteLine(FindPositionAndIsValid(Board(), 7));
        }

        static string UserInput()
        {
            string input = string.Empty;
            do
            {
                Console.Write($"Please select your mark (X or O): ");
                input = Console.ReadLine();
                input = input.ToLower();
                Console.WriteLine();
            } while (!Validate(input));

            return input;
        }

        static bool Validate(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            str = str.ToLower();
            return str.Equals("x") || str.Equals("o");
        }

        static char[,] Board()
        {
            var matrix = new char[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[i, j] = '.';
                }
            }

            return matrix;
        }


        static void PrintBoard(char[,] matrix)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }


        static bool End(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == '.')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        static bool FindPositionAndIsValid(char[,] matrix, int n)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (2 * i + i + j + 1 == n)
                    {
                        if (matrix[i, j] == '.')
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }

            return false;
        }

        static void Replace(char[,] matrix, int n, char m)
        {
            if (FindPositionAndIsValid(matrix, n))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (2 * i + i + j + 1 == n)
                        {
                            matrix[i, j] = m;
                        }
                    }
                }
            }
        }


        static bool Win(char[,] matrix)
        {
            int cnt1 = 0, cnt2 = 0, cnt3 = 0, cnt4 = 0, cnt5 = 0, cnt6 = 0, cnt7 = 0, cnt8 = 0;
          
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    //check rows
                    if (matrix[i, j] == 'x')
                    {
                        cnt1++;
                    }

                    if (matrix[i, j] == 'o')
                    {
                        cnt2++;
                    }

                    //check columns
                    if (matrix[j, i] == 'x')
                    {
                        cnt3++;
                    }

                    if (matrix[j, i] == 'o')
                    {
                        cnt4++;
                    }
                }

                //check diagonals
                if (matrix[i, i] == 'x')
                {
                    cnt5++;
                }

                if (matrix[i, i] == 'o')
                {
                    cnt6++;
                }

                if (matrix[matrix.GetLength(0) - 1 - i, i] == 'x')
                {
                    cnt7++;
                }

                if (matrix[matrix.GetLength(0) - 1 - i, i] == 'o')
                {
                    cnt8++;
                }


                if (cnt1 == 3 || cnt3 == 3 || cnt5 == 3 || cnt7 == 3)
                {
                    Console.WriteLine("GAME OVER. X WON!");
                    return true;
                }

                if (cnt2 == 3 || cnt4 == 3 || cnt6 == 3 || cnt8 == 3)
                {
                    Console.WriteLine("GAME OVER. O WON!");
                    return true;
                }

                else
                {
                    cnt1 = 0;
                    cnt2 = 0;
                    cnt3 = 0;
                    cnt4 = 0;
                    cnt5 = 0;
                    cnt6 = 0;
                    cnt7 = 0;
                    cnt8 = 0;
                }
            }

            return false;
        }

        static int Number()
        {
            string str = Console.ReadLine();
            int number = 0;
            if (!int.TryParse(str, out number))
            {
                Console.WriteLine("Number is incorrect.");
                return -1;
            }

            return number;
        }
    }
}
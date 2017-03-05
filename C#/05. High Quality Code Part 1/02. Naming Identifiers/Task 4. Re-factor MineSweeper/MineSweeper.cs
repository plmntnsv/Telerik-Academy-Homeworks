using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper
{
	public class MineSweeperGame
	{
		public class GamePoints
		{
			private string name;
			private int points;
            
            public GamePoints() { }

            public GamePoints(string name, int points)
            {
                this.name = name;
                this.points = points;
            }

            public string Name
			{
				get { return name; }
				set { name = value; }
			}

			public int Points
			{
				get { return points; }
				set { points = value; }
			}
		}

		static void Main(string[] аргументи)
        {
            const int Max = 35;
            string command = string.Empty;
			char[,] gameField = CreateGameField();
			char[,] bombsField = CreateBombsField();
            int counter = 0;
            int row = 0;
			int column = 0;
			bool startGame = true;
			bool endGame = false;
            bool willDetonate = false;
            List<GamePoints> bestGames = new List<GamePoints>(6);

            do
			{
				if (startGame)
				{
					Console.WriteLine("Let's play \"Mineswepper\"!\nTest your luck and try to find the fields without bombs.\nCommands:\n'top' displays current standing;\n'restartGame' begins a new game'\n'exit' quits the game!");
					DrawField(gameField);
					startGame = false;
				}

				Console.Write("Enter rows and colums : ");
                command = Console.ReadLine().Trim();

				if (command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out row) &&
					    int.TryParse(command[2].ToString(), out column) &&
						row <= gameField.GetLength(0) && column <= gameField.GetLength(1))
					{
						command = "turn";
					}
				}

				switch (command)
				{
					case "top":
                        DisplayGamesWithBestScores(bestGames);
						break;
					case "restartGame":
                        gameField = CreateGameField();
                        bombsField = CreateBombsField();
						DrawField(gameField);
						willDetonate = false;
						startGame = false;
						break;
					case "exit":
						Console.WriteLine("Bye!");
						break;
					case "turn":
						if (bombsField[row, column] != '*')
						{
							if (bombsField[row, column] == '-')
							{
								NextMove(gameField, bombsField, row, column);
								counter++;
							}
							if (Max == counter)
							{
								endGame = true;
							}
							else
							{
								DrawField(gameField);
							}
						}
						else
						{
							willDetonate = true;
						}

						break;
					default:
						Console.WriteLine("\nError! Invalid command\n");
						break;
				}

				if (willDetonate)
				{
					DrawField(bombsField);
					Console.Write("\nBoom! You've died with {0} points.\nEnter your nickname: ", counter);
					string nickname = Console.ReadLine();

					GamePoints currentGamePoints = new GamePoints(nickname, counter);

					if (bestGames.Count < 5)
					{
                        bestGames.Add(currentGamePoints);
					}
					else
					{
						for (int i = 0; i < bestGames.Count; i++)
						{
							if (bestGames[i].Points < currentGamePoints.Points)
							{
                                bestGames.Insert(i, currentGamePoints);
                                bestGames.RemoveAt(bestGames.Count - 1);
								break;
							}
						}
					}

                    bestGames.Sort((GamePoints r1, GamePoints r2) => r2.Name.CompareTo(r1.Name));
                    bestGames.Sort((GamePoints r1, GamePoints r2) => r2.Points.CompareTo(r1.Points));
                    DisplayGamesWithBestScores(bestGames);

                    gameField = CreateGameField();
                    bombsField = CreateBombsField();
					counter = 0;
					willDetonate = false;
					startGame = true;
				}
				if (endGame)
				{
					Console.WriteLine("\nGood job! You successfully opened 35 fields without a single bomb exploding.");
					DrawField(bombsField);

					Console.WriteLine("Please enter your name: ");
					string name = Console.ReadLine();
					GamePoints currentPoints = new GamePoints(name, counter);

                    bestGames.Add(currentPoints);
                    DisplayGamesWithBestScores(bestGames);

                    gameField = CreateGameField();
                    bombsField = CreateBombsField();
					counter = 0;
					endGame = false;
					startGame = true;
				}
			}
			while (command != "exit");
			Console.WriteLine("See you soon.");
			Console.Read();
		}

		private static void DisplayGamesWithBestScores(List<GamePoints> games)
		{
			Console.WriteLine("\nGames:");

			if (games.Count > 0)
			{
				for (int i = 0; i < games.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} points", i + 1, games[i].Name, games[i].Points);
				}

				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("No best games yet!\n");
			}
		}

		private static void NextMove(char[,] gameField, char[,] bombsField, int row, int column)
		{
			char neighbouringBombsCount = DisplayNeighbouringBombsCount(bombsField, row, column);
            bombsField[row, column] = neighbouringBombsCount;
            gameField[row, column] = neighbouringBombsCount;
		}

		private static void DrawField(char[,] board)
		{
			int rows = board.GetLength(0);
			int columns = board.GetLength(1);

			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");

			for (int i = 0; i < rows; i++)
			{
				Console.Write("{0} | ", i);

				for (int j = 0; j < columns; j++)
				{
					Console.Write(string.Format("{0} ", board[i, j]));
				}

				Console.Write("|");
				Console.WriteLine();
			}

			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] CreateGameField()
		{
			int rows = 5;
			int columns = 10;
			char[,] board = new char[rows, columns];

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] CreateBombsField()
		{
			int rows = 5;
			int columns = 10;
			char[,] field = new char[rows, columns];

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
                    field[i, j] = '-';
				}
			}

			List<int> bombPositions = new List<int>();

			while (bombPositions.Count < 15)
			{
				Random randomPosition = new Random();
				int position = randomPosition.Next(50);

				if (!bombPositions.Contains(position))
				{
                    bombPositions.Add(position);
				}
			}

			foreach (int position in bombPositions)
			{
				int col = (position / columns);
				int row = (position % columns);

				if (row == 0 && position != 0)
				{
                    col--;
					row = columns;
				}
				else
				{
					row++;
				}

                field[col, row - 1] = '*';
			}

			return field;
		}

		private static void CalculateBombs(char[,] field)
		{
			int col = field.GetLength(0);
			int row = field.GetLength(1);

			for (int i = 0; i < col; i++)
			{
				for (int j = 0; j < row; j++)
				{
					if (field[i, j] != '*')
					{
						char neighbouringBombs = DisplayNeighbouringBombsCount(field, i, j);
                        field[i, j] = neighbouringBombs;
					}
				}
			}
		}

		private static char DisplayNeighbouringBombsCount(char[,] field, int row, int col)
		{
			int count = 0;
			int rows = field.GetLength(0);
			int cols = field.GetLength(1);

			if (row - 1 >= 0)
			{
				if (field[row - 1, col] == '*')
				{ 
					count++; 
				}
			}

			if (row + 1 < rows)
			{
				if (field[row + 1, col] == '*')
				{ 
					count++; 
				}
			}

			if (col - 1 >= 0)
			{
				if (field[row, col - 1] == '*')
				{ 
					count++;
				}
			}

			if (col + 1 < cols)
			{
				if (field[row, col + 1] == '*')
				{ 
					count++;
				}
			}

			if ((row - 1 >= 0) && (col - 1 >= 0))
			{
				if (field[row - 1, col - 1] == '*')
				{ 
					count++; 
				}
			}

			if ((row - 1 >= 0) && (col + 1 < cols))
			{
				if (field[row - 1, col + 1] == '*')
				{ 
					count++; 
				}
			}

			if ((row + 1 < rows) && (col - 1 >= 0))
			{
				if (field[row + 1, col - 1] == '*')
				{ 
					count++; 
				}
			}

			if ((row + 1 < rows) && (col + 1 < cols))
			{
				if (field[row + 1, col + 1] == '*')
				{ 
					count++; 
				}
			}

			return char.Parse(count.ToString());
		}
	}
}

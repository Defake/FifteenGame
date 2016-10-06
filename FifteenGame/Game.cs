using System;
using System.Linq;

namespace FifteenGame
{
	public abstract class Game
	{

		public int this[int x, int y] => GetValue(x, y);
		public int Length => (int)Math.Sqrt(NumberPosition.Length);

		protected int[][] GameField { get; set; }
		protected Point[] NumberPosition { get; set; }

		protected Game() { }

		protected Game(params int[] args) 
		{
			
			/* If args make a square, then sqrt will not be double value */
			if (Math.Abs(Math.Sqrt(args.Length) - (int)Math.Sqrt(args.Length)) > double.Epsilon)
				throw new ArgumentException("GameSimple can't make a square field with this set of values");

			int zeroValues = args.Count(i => i == 0);
			if (zeroValues == 0)
				throw new ArgumentException("There's no zero-field in set of initial values");
			else if (zeroValues > 1)
				throw new ArgumentException("Game can contain just 1 zero-field! Got " + zeroValues);

			int length = (int)Math.Sqrt(args.Length);
			GameField = new int[length][];
			for (int i = 0; i < length; i++)
				GameField[i] = new int[length];

			NumberPosition = new Point[args.Length];
			NumberPosition[0] = new Point(length - 1);

			int k = 0;
			for (int y = 0; y < length; y++) {
				for (int x = 0; x < length; x++) {
					GameField[x][y] = args[k];
					NumberPosition[args[k++]] = new Point(x, y);
				}
			}
		}

		protected virtual int GetValue(int x, int y) => GameField[x][y];

		/// <summary>
		/// Должен изменять состояние игры, передвигая фишку value на одно из соседних мест, 
		/// где должен лежать 0. В случае, если 0 не находится на соседнем месте, должно возникать исключение.
		/// </summary>
		public virtual Game Shift(int value)
		{
			CheckArgumentValue(value);

			if (value == 0)
				throw new ArgumentException("Cannot shift zero-field!");

			if (!Point.IsNextTo(GetLocation(value), GetLocation(0)))
				throw new ArgumentException("Can't find zero-value next to argument-value " + value);

			return null;
		}

		/// <summary>
		/// Позволяет определить, в какой точке находится переданное значение.
		/// должен работать за константное время.
		/// </summary>
		/// <returns>Struct Point that contains x and y coordinates of the value</returns>
		protected virtual Point GetLocation(int value)
		{
			//CheckArgumentValue(value); // Don't need to check because only Shift method uses this one
			return NumberPosition[value];
		}

		protected void CheckArgumentValue(int value) {
			if (value >= NumberPosition.Length)
				throw new ArgumentOutOfRangeException("Value " + value + " is too large. There's no such items");
			else if (value < 0)
				throw new ArgumentOutOfRangeException("Value may not be below zero! (Got " + value + ")");
		}
	}
}
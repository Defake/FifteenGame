using System;
using System.Collections.Generic;

namespace FifteenGame
{
	public class GameImmutableProductive : Game
	{

		protected override int GetValue(int x, int y)
		{
			Point[] numbers = GetUpdatedGameField();
			for (int i = 0; i < numbers.Length; i++) {
				Point p = numbers[i];
				if (p.x == x && p.y == y)
					return i;
			}

			throw new ArgumentOutOfRangeException("Can't find a number width coordinates (" + x + "; " + y + ")!");
		}

		private readonly List<int> _history;

		public GameImmutableProductive(params int[] args) : base(args)
		{
			_history = new List<int>();
		}

		public GameImmutableProductive(GameImmutableProductive old, int shiftValue) : this(old) {
			_history = old._history;
			_history.Add(shiftValue);
		}

		private GameImmutableProductive(GameImmutableProductive old) 
		{
			NumberPosition = old.NumberPosition;
			GameField = old.GameField;
		}

		protected override Point GetLocation(int value) 
		{
			CheckArgumentValue(value);

			return GetUpdatedGameField()[value];
		}

		public override Game Shift(int value)
		{
			base.Shift(value);

			return new GameImmutableProductive(this, value);
		}

		private Point[] GetUpdatedGameField() 
		{
			Point[] numbers = new Point[Length * Length];
			for (int i = 0; i < NumberPosition.Length; i++)
				numbers[i] = NumberPosition[i];

			foreach (int shiftVal in _history) {
				Point temp = numbers[0];
				numbers[0] = numbers[shiftVal];
				numbers[shiftVal] = temp;
			}

			return numbers;
		}

	}
}
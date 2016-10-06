using System;
using System.Threading;

namespace FifteenGame
{
	public class GameImmutable : Game
	{

		public GameImmutable(params int[] args) : base(args) { }

		public override Game Shift(int value)
		{
			base.Shift(value);

			int k = 0;
			var args = new int[Length*Length];
			for (int y = 0; y < Length; y++)
				for (int x = 0; x < Length; x++)
					if (this[x, y] == value)
						args[k++] = 0;
					else if (this[x, y] == 0)
						args[k++] = value;
					else args[k++] = this[x, y];

			return new GameImmutable(args);
		}

	}
}
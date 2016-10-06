using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame {

	public class GameDecorator
	{

		public int this[int x, int y] => _game[x, y];
		public int Length => _game.Length;

		private Game _game;

		public GameDecorator(Game gameClass)
		{
			_game = gameClass;
		}

		public void Shift(int value) => _game = _game.Shift(value);
	}

}

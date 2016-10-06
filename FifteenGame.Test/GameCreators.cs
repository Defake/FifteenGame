using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.Test 
{
	public interface IGameCreator
	{
		Game CreateGame(params int[] args);
	}

	public class GameImmutableProductiveCreator : IGameCreator
	{
		public Game CreateGame(params int[] args)
		{
			return new GameImmutableProductive(args);
		}
	}

	public class GameImmutableCreator : IGameCreator
	{
		public Game CreateGame(params int[] args)
		{
			return new GameImmutable(args);
		}
	}

	public class GameSimpleCreator : IGameCreator
	{
		public Game CreateGame(params int[] args)
		{
			return new GameSimple(args);
		}
	}
}

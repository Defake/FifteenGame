using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FifteenGame.Test {

	/* Я так понимаю, наследование нарушает принцип KISS, т.к. наследники не делают вообще 
		ничего нового, кроме определения поля creator. Но это надо по заданию */

	public class GameTests
	{
		protected IGameCreator creator;

		public GameTests() { }

		public virtual void TestShiftingSquare2x2() 
			=> Should_WorkFine_When_ShiftingValidSquare2x2(creator);
		public virtual void TestShiftingSquare3x3() 
			=> Should_WorkFine_When_ShiftingValidSquare3x3(creator);
		public virtual void TestShiftingSquare4x4() 
			=> Should_WorkFine_When_ShiftingValidSquare4x4(creator);

		public virtual void Should_ThrowException_When_TryToShiftTooLargeValue() 
			=> new GameDecorator(creator.CreateGame(1,2,3,0)).Shift(4);

		public virtual void Should_ThrowException_When_TryToShiftValueBelowZero() 
			=> new GameDecorator(creator.CreateGame(1, 2, 3, 0)).Shift(-2);

		public virtual void Should_ThrowException_When_TryToShiftZeroValue() 
			=> new GameDecorator(creator.CreateGame(1, 2, 3, 0)).Shift(0);

		public virtual void Should_ThrowException_When_TryToCreateNonSquareField() 
			=> creator.CreateGame(1, 2, 3, 4, 0);
		public virtual void Should_ThrowException_When_TryToCreateGameWithoutZeroField() 
			=> creator.CreateGame(1, 2, 3, 4);
		public virtual void Should_ThrowException_When_TryToCreateGameWithTwoZeroFields()
			=> creator.CreateGame(1, 2, 0, 0);

		private static void Should_WorkFine_When_ShiftingValidSquare2x2(IGameCreator creator)
		{
			var dec = new GameDecorator(creator.CreateGame(1, 2, 3, 0));
			dec.Shift(2);
			dec.Shift(1);
			dec.Shift(3);
			dec.Shift(3);

			GameAssert(dec, 0, 1, 3, 2);
		}

		private static void Should_WorkFine_When_ShiftingValidSquare3x3(IGameCreator creator) {
			var dec = new GameDecorator(creator.CreateGame(1, 2, 3, 4, 5, 6, 7, 8, 0));
			dec.Shift(8);
			dec.Shift(5);
			dec.Shift(2);
			dec.Shift(3);
			dec.Shift(6);
			dec.Shift(8);

			GameAssert(dec, 1, 3, 6, 4, 2, 8, 7, 5, 0);
		}

		private static void Should_WorkFine_When_ShiftingValidSquare4x4(IGameCreator creator)
		{
			var dec = new GameDecorator(creator.CreateGame(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0));
			dec.Shift(12);
			dec.Shift(8);
			dec.Shift(7);
			dec.Shift(3);
			dec.Shift(2);
			dec.Shift(6);
			dec.Shift(10);
			dec.Shift(9);
			dec.Shift(5);
			dec.Shift(1);
			dec.Shift(6);

			GameAssert(dec, 6, 0, 2, 4, 1, 10, 3, 7, 5, 9, 11, 8, 13, 14, 15, 12);
		}

		private static void GameAssert(GameDecorator game, params int[] args)
		{
			int k = 0;
			int length = game.Length;
			for (int y = 0; y < length; y++)
				for (int x = 0; x < length; x++)
					Assert.AreEqual(args[k++], game[x, y]);
		}

	}
}

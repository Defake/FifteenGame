using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FifteenGame.Test 
{

	[TestClass]
	public class GameSimpleTests : GameTests 
	{

		public GameSimpleTests()
		{
			creator = new GameSimpleCreator();
		}

		[TestMethod]
		public override void TestShiftingSquare2x2()
			=> base.TestShiftingSquare2x2();

		[TestMethod]
		public override void TestShiftingSquare3x3()
			=> base.TestShiftingSquare3x3();

		[TestMethod]
		public override void TestShiftingSquare4x4()
			=> base.TestShiftingSquare4x4();

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public override void Should_ThrowException_When_TryToShiftTooLargeValue() 
			=> base.Should_ThrowException_When_TryToShiftTooLargeValue();

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public override void Should_ThrowException_When_TryToShiftValueBelowZero() 
			=> base.Should_ThrowException_When_TryToShiftValueBelowZero();

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public override void Should_ThrowException_When_TryToShiftZeroValue() 
			=> base.Should_ThrowException_When_TryToShiftZeroValue();

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public override void Should_ThrowException_When_TryToCreateNonSquareField() 
			=> base.Should_ThrowException_When_TryToCreateNonSquareField();

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public override void Should_ThrowException_When_TryToCreateGameWithoutZeroField() 
			=> base.Should_ThrowException_When_TryToCreateGameWithoutZeroField();

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public override void Should_ThrowException_When_TryToCreateGameWithTwoZeroFields() 
			=> base.Should_ThrowException_When_TryToCreateGameWithTwoZeroFields();
		
	}
}
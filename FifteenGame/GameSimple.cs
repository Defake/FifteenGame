using System;

namespace FifteenGame
{
	public class GameSimple : Game
	{
		public GameSimple(params int[] args) : base(args) { }

		/// <summary>
		/// ������ �������� ��������� ����, ���������� ����� value �� ���� �� �������� ����, 
		/// ��� ������ ������ 0. � ������, ���� 0 �� ��������� �� �������� �����, ������ ��������� ����������.
		/// </summary>
		public override Game Shift(int value) 
		{
			base.Shift(value);

			Point temp = NumberPosition[0];
			NumberPosition[0] = NumberPosition[value];
			NumberPosition[value] = temp;

			// Variable temp now is equal to value-point 
			// Set new value of this field
			GameField[temp.x][temp.y] = value;

			// Then change field for zero-value
			temp = NumberPosition[0];
			GameField[temp.x][temp.y] = 0;

			return this;
		}
	}
}
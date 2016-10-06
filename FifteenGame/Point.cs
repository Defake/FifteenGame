using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame 
{

	public struct Point 
	{
		public int x 
		{
			get; private set; 
		}
		public int y 
		{
			get; private set; 
		}

		public Point(int x, int y) 
		{
			this.x = x;
			this.y = y;
		}

		public Point(int a) : this(a, a) 
		{  }

		public static bool IsNextTo(Point a, Point b) 
		{
			if (a.x == b.x) 
			{
				if (Math.Abs(a.y - b.y) <= 1)
					return true;
			} else if (a.y == b.y) 
			{
				if (Math.Abs(a.x - b.x) <= 1)
					return true;
			}

			return false;
		}

	}

}

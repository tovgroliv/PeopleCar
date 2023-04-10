using System;

namespace PeopleCar.Geometry
{
	public class Point
	{
		public static Point Zero { get => new Point(0, 0); }
		public int X { get; set; }
		public int Y { get; set; }

		public Point()
		{
			X = 0;
			Y = 0;
		}

		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public override string ToString()
		{
			return $"[{X}:{Y}]";
		}

		public float DistanceTo(Point to)
		{
			float distance = Distance(this, to);

			return distance;
		}

		public static float Distance(Point first, Point second)
		{
			float distance = (float)Math.Sqrt(Math.Pow(
				Math.Abs(first.X - second.X), 2) *
				Math.Pow(Math.Abs(first.Y - second.Y), 2)
			);

			return distance;
		}
	}
}

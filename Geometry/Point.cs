using System;

namespace PeopleCar.Geometry
{
	/// <summary>
	/// Точка координат
	/// </summary>
	public class Point
	{
		/// <summary>
		/// Нулевая точка
		/// </summary>
		public static Point Zero { get => new Point(0, 0); }
		/// <summary>
		/// X
		/// </summary>
		public int X { get; set; }
		/// <summary>
		/// Y
		/// </summary>
		public int Y { get; set; }

		/// <summary>
		/// Создание точки
		/// </summary>
		public Point()
		{
			X = 0;
			Y = 0;
		}

		/// <summary>
		/// Создание точки с указанием координат
		/// </summary>
		/// <param name="x">X</param>
		/// <param name="y">Y</param>
		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		/// <summary>
		/// Строковое описание точки
		/// </summary>
		/// <returns>Описание</returns>
		public override string ToString()
		{
			return $"[{X}:{Y}]";
		}

		/// <summary>
		/// Расстояние до другой точки
		/// </summary>
		/// <param name="to">Точка до которой вычесляется расстояние</param>
		/// <returns>Расстояние</returns>
		public float DistanceTo(Point to)
		{
			float distance = Distance(this, to);

			return distance;
		}

		/// <summary>
		/// Расстояние между двумя точек
		/// </summary>
		/// <param name="first">Первая точка</param>
		/// <param name="second">Вторая точка</param>
		/// <returns>Расстояние</returns>
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

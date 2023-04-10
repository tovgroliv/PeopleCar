using PeopleCar.Geometry;

namespace PeopleCar.Entities
{
	public class Person
	{
		public string Nickname { get; set; }
		public Point Coordinates { get; set; }

		public Person(string nickname, Point coordinates = null)
		{
			Nickname = nickname;

			if (coordinates != null)
			{
				Coordinates = Point.Zero;
			}
			else
			{
				Coordinates = coordinates;
			}
		}

		public override string ToString()
		{
			return $"{Nickname}";
		}
	}
}

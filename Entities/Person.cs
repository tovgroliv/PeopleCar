using PeopleCar.Geometry;

namespace PeopleCar.Entities
{
	public class Person
	{
		public string Nickname { get; set; }
		public Point Coordinates { get; set; }

		public Person(string nickname, Point coordinates)
		{
			Nickname = nickname;
			Coordinates = coordinates;
		}
	}
}

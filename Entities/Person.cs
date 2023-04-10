using PeopleCar.Geometry;

namespace PeopleCar.Entities
{
	/// <summary>
	/// Игрок
	/// </summary>
	public class Person
	{
		/// <summary>
		/// Ник игрока
		/// </summary>
		public string Nickname { get; set; }
		/// <summary>
		/// Координаты игрока
		/// TODO общий класс для entities
		/// </summary>
		public Point Coordinates { get; set; }

		/// <summary>
		/// Создание игрока
		/// </summary>
		/// <param name="nickname">Ник игрока</param>
		/// <param name="coordinates">Координаты игрока</param>
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

		/// <summary>
		/// Строковок описание игрока
		/// </summary>
		/// <returns>Описание</returns>
		public override string ToString()
		{
			return $"{Nickname}";
		}
	}
}

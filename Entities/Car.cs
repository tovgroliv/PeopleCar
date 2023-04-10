using PeopleCar.Geometry;

namespace PeopleCar.Entities
{
	/// <summary>
	/// Машина
	/// </summary>
	public class Car
	{
		/// <summary>
		/// Название машины
		/// </summary>
		public string Label { get; set; }
		/// <summary>
		/// Координаты машины
		/// TODO общий класс для entities
		/// </summary>
		public Point Coordinates { get; set; }
		/// <summary>
		/// Водитель машины
		/// </summary>
		public Person Driver { get; set; }

		/// <summary>
		/// Пассажиры машины
		/// </summary>
		private Person[] _passengers = new Person[3];
		/// <summary>
		/// Пассажиры машины
		/// </summary>
		public Person[] Passengers { get => _passengers; }

		/// <summary>
		/// Создание машины
		/// </summary>
		/// <param name="label">Название машины</param>
		/// <param name="coordinates">Координаты машины</param>
		public Car(string label, Point coordinates)
		{
			Label = label;
			Coordinates = coordinates;
		}

		/// <summary>
		/// Текстовое описание машины
		/// </summary>
		/// <returns>Описание</returns>
		public override string ToString()
		{
			string car = $"{Label}{Coordinates} -";
			string driver = $"водитель : {Driver}";

			string list = "";
			foreach (Person person in Passengers)
			{
				list += $"{person},";
			}

			string passengers = $"пассажиры : ({list})";

			return $"{car} {driver}, {passengers}";
		}

		/// <summary>
		/// Имеется ли место в машине
		/// </summary>
		public bool HasPlace
		{
			get
			{
				if (Driver == null)
				{
					return true;
				}

				foreach (Person person in Passengers)
				{
					if (person == null)
					{
						return true;
					}
				}

				return false;
			}
		}

		/// <summary>
		/// Сесть пассажиром
		/// TODO учитывать нахождение в машине других игроков
		/// </summary>
		/// <param name="passenger">Игрок</param>
		/// <param name="place">Место в машине, по умолчанию первое свободное</param>
		/// <returns>Если мест нет, вернет false, иначе true</returns>
		public bool SitDown(Person passenger, int place = -1)
		{
			if (place == -1)
			{
				for (int i = 0; i < _passengers.Length; i++)
				{
					if (_passengers[i] == null)
					{
						place = i;
						break;
					}
				}
			}

			if (_passengers[place] != null)
			{
				return false;
			}

			_passengers[place] = passenger;

			return true;
		}

		/// <summary>
		/// Выйти из машины
		/// </summary>
		/// <param name="passenger">Игрок</param>
		/// <returns>true если игрок находился в машине, иначе false</returns>
		public bool GetUp(Person passenger)
		{
			int place = -1;
			for (int i = 0; i < _passengers.Length; i++)
			{
				if (_passengers[i] == passenger)
				{
					place = i;
					break;
				}
			}

			if (place == -1)
			{
				return false;
			}

			_passengers[place] = null;

			return true;
		}
	}
}

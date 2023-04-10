using PeopleCar.Geometry;

namespace PeopleCar.Entities
{
	public class Car
	{
		public string Label { get; set; }
		public Point Coordinates { get; set; }
		public Person Driver { get; set; }

		public Person[] _passengers = new Person[3];
		public Person[] Passengers { get => _passengers; }

		public Car(string label, Point coordinates)
		{
			Label = label;
			Coordinates = coordinates;
		}

		public override string ToString()
		{
			string car = $"{Label}{Coordinates}";
			string driver = $"водитель : {Driver}";

			string list = "";
			foreach (Person person in Passengers)
			{
				list += $"{person},";
			}

			string passengers = $"пассажиры : ({list})";

			return $"{car} {driver}, {passengers}";
		}

		public bool HasPlace
		{
			get
			{
				for (int i = 0; i < _passengers.Length; i++)
				{
					if (_passengers[i] == null)
					{
						return true;
					}
				}

				return false;
			}
		}

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

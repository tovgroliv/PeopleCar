using PeopleCar.Entities;
using PeopleCar.Geometry;
using System.Collections.Generic;

namespace PeopleCar.Engine
{
	/// <summary>
	/// Сцена
	/// </summary>
	public class Scene
	{
		/// <summary>
		/// Машины расположенные на сцене
		/// </summary>
		public Car[] Cars;
		/// <summary>
		/// Игроки расположенные на сцене
		/// </summary>
		public Person[] People;

		/// <summary>
		/// Создание сцены, с резервированием места под машин и игроков
		/// </summary>
		/// <param name="carsCount">Количество машин</param>
		/// <param name="peopleCount">Количество игроков</param>
		public Scene(int carsCount, int peopleCount)
		{
			Cars = new Car[carsCount];
			People = new Person[peopleCount];
		}

		/// <summary>
		/// Поиск игроков вокруг вокруг машины
		/// TODO исключены все игроки внутри машины поиска
		/// </summary>
		/// <param name="car">Машина</param>
		/// <param name="distance">Расстояние, по умолчанию 15</param>
		/// <returns></returns>
		public Person[] FindPeopleAroundCar(Car car, float distance = 15)
		{
			List<Person> people = new List<Person>();

			foreach (Car findCar in Cars)
			{
				if (car == findCar)
				{
					continue;
				}

				if (findCar.Coordinates.DistanceTo(car.Coordinates) <= distance)
				{
					people.Add(findCar.Driver);

					foreach (Person person in findCar.Passengers)
					{
						people.Add(person);
					}
				}
			}

			return people.ToArray();
		}
	}
}

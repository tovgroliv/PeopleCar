using PeopleCar.Entities;
using PeopleCar.Geometry;
using System.Collections.Generic;

namespace PeopleCar.Engine
{
	public class Scene
	{
		public Car[] Cars;
		public Person[] People;

		public Scene(int carsCount, int peopleCount)
		{
			Cars = new Car[carsCount];
			People = new Person[peopleCount];
		}

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

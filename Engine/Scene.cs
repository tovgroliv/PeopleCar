using PeopleCar.Entities;

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
	}
}

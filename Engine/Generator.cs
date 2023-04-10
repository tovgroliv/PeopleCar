using PeopleCar.Entities;
using PeopleCar.Geometry;
using System;
using System.Threading;

namespace PeopleCar.Engine
{
	public  class Generator
	{
		private Scene _scene;
		private bool _filled = false;

		public Generator(Scene scene)
		{
			_scene = scene;
			_filled = false;
		}

		public void Start()
		{
			Thread thread = new Thread(new ThreadStart(Fill));
			thread.Start();

			GenerateCars();
			GeneratePeople();

			while (!_filled);

			PrintState();
		}

		public void PrintState()
		{
			int car = 0;

			Random rand = new Random();
			for (int i = 0; i < 5; i++)
			{
				car = rand.Next(0, _scene.Cars.Length);
				Console.WriteLine(_scene.Cars[car]);
			}

			car = rand.Next(0, _scene.Cars.Length);

			Person[] people = _scene.FindPeopleAroundCar(_scene.Cars[car]);

			foreach (Person person in people)
			{
				Console.WriteLine($"{person.Nickname} : {Point.Distance(person.Coordinates, _scene.Cars[car].Coordinates)}");
			}
		}

		private void Fill()
		{
			int car = 0;
			int people = 0;

			while (car < _scene.Cars.Length)
			{
				if (_scene.Cars[car] == null)
				{
					continue;
				}

				for (int person = 0; person < 4; person++)
				{
					while (_scene.People[people] == null);

					_scene.People[people].Coordinates = _scene.Cars[car].Coordinates;

					if (person == 0)
					{
						_scene.Cars[car].Driver = _scene.People[people];
					}
					else
					{
						_scene.Cars[car].SitDown(_scene.People[people]);
					}

					people++;
				}

				car++;
			}

			_filled = true;
		}

		private void GenerateCars()
		{
			Random rand = new Random();
			for (int i = 0; i < _scene.Cars.Length; i++)
			{
				_scene.Cars[i] = new Car(
					$"машина #{i}",
					new Point(rand.Next(0, 101), rand.Next(0, 101))
				);
			}
		}

		private void GeneratePeople()
		{
			for (int i = 0; i < _scene.People.Length; i++)
			{
				_scene.People[i] = new Person(
					$"человек #{i}"
				);
			}
		}
	}
}

using PeopleCar.Entities;
using PeopleCar.Geometry;
using System;
using System.Threading;

namespace PeopleCar.Engine
{
	/// <summary>
	/// Генератор сцены
	/// </summary>
	public class Generator
	{
		/// <summary>
		/// Сцена, в которой генерируются сущности
		/// </summary>
		private Scene _scene;
		/// <summary>
		/// Статус заполнения машин игроками
		/// </summary>
		private bool _filled = false;

		/// <summary>
		/// Создание экземпляра генератора
		/// </summary>
		/// <param name="scene">Сцена, в которой генерируются сущности</param>
		public Generator(Scene scene)
		{
			_scene = scene;
			_filled = false;
		}

		/// <summary>
		/// Запуск генератора
		/// </summary>
		public void Start()
		{
			Thread thread = new Thread(new ThreadStart(Fill));
			thread.Start();

			GenerateCars();
			GeneratePeople();

			while (!_filled);
		}

		/// <summary>
		/// Вывод информации генератора
		/// </summary>
		public void PrintState()
		{
			int randomCount = 5;
			int car = 0;

			Console.WriteLine($"{randomCount} случайных машин сцены");

			Random rand = new Random();
			for (int i = 0; i < randomCount; i++)
			{
				car = rand.Next(0, _scene.Cars.Length);
				Console.WriteLine(_scene.Cars[car]);
			}

			car = rand.Next(0, _scene.Cars.Length);

			Console.WriteLine($"\nИгроки вокруг машины {_scene.Cars[car]}");

			Person[] people = _scene.FindPeopleAroundCar(_scene.Cars[car]);

			foreach (Person person in people)
			{
				Console.WriteLine($"{person} : {Point.Distance(person.Coordinates, _scene.Cars[car].Coordinates)}");
			}
		}

		/// <summary>
		/// Заполнение машин игроками
		/// </summary>
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

				while (_scene.Cars[car].HasPlace)
				{
					while (_scene.People[people] == null);

					_scene.People[people].Coordinates = _scene.Cars[car].Coordinates;

					if (_scene.Cars[car].Driver == null)
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

		/// <summary>
		/// Генерация машин
		/// TODO итерации проходят быстро, ввиду чего генератор может сработать в один и тот же момент времени и выдаст одинаковые координаты
		/// </summary>
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

		/// <summary>
		/// Генерация игроков
		/// </summary>
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

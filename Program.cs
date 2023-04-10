using PeopleCar.Engine;
using System;

namespace PeopleCar
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Scene scene = new Scene(200, 1000);

			Generator generator = new Generator(scene);
			generator.Start();

			generator.PrintState();

			Console.ReadKey();
		}
	}
}

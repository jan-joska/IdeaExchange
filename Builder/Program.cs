using System;

namespace Builder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var b = new PersonBuilder("Jirka Batulka")
                .WithBirthDay(new DateTime(2020, 01, 01))
                .WithLeftEye(new EyeBuilder(ConsoleColor.Cyan).SetName("Favourite left eye"))
                .WithRithEye(ConsoleColor.Blue);

            var person = b.Build;

            Console.WriteLine(person);

            Console.ReadLine();
        }
    }
}
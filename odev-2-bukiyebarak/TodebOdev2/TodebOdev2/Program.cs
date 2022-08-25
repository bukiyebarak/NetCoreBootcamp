using Models.Concrete;
using System;

namespace TodebOdev2
{
    class Program
    {
        static void Main(string[] args)
        {
            var sheepDog = new SheepDog("Boz");
            sheepDog.Age = 10;
            sheepDog.Type = "Kangal";
            sheepDog.WriteDogName();

            var fancyDog = new FancyDog("Pati");
            fancyDog.Age = 2;
            fancyDog.Color = "Black and Orange";
            fancyDog.Type = "Pomeranian";
            fancyDog.WriteDogName();

            var fancyDog2 = new FancyDog("Maskot");
            fancyDog2.Age = 5;
            fancyDog2.Color = "White and Black";
            fancyDog2.Type = "Phalene";
            fancyDog2.WriteDogName();
        }
    }
}

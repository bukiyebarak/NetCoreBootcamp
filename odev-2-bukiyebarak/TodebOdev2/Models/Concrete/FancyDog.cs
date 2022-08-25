using Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete
{
    //süs köpeği
    public class FancyDog : Dog
    {
        public string Color { get; set; }
        public FancyDog(string dogname) : base(dogname)
        {
        }
        public override void WriteDogName()
        {
            base.WriteDogName();
            Console.WriteLine($"Breed of Dog:{Type} Age:{Age} Color:{Color}");

        }
    }
}

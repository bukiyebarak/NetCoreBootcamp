using Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete
{
    //çoban köpeği
    public class SheepDog : Dog
    {
        public SheepDog(string dogname) : base(dogname)
        {
        }

        public override void WriteDogName()
        {
            base.WriteDogName();
            Console.WriteLine($"Breed of Dog:{Type} Age:{Age}");

        }
    }
}

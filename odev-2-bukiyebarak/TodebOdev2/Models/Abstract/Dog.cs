using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Abstract
{
    public abstract class Dog
    {
        //encapsulation
        protected string _dogName { get; set; }

        //kurucu method
        public Dog(string dogname)
        {
            _dogName = dogname;
        }

        public int id { get; set; }

        public int Age { get; set; }
        public string Type { get; set; }

        //override
        public virtual void WriteDogName()
        {
            Console.WriteLine("Name: "+_dogName);
        }
    }
}

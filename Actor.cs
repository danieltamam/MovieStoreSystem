using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop
{
     public class Actor
    {
        private string _name;//private field
        public string Name
        {
            get { return this._name; }
            set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("name has to not be empty"); _name = value; }
        }

        public Actor(string name)//there is the prop in the ctor , that is allowd to keep the encapsulation and only leggal info will be able to set
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"Actor Name:{ Name}";
        }

        public override bool Equals(object obj)
        {
            return obj is Actor actor &&
                   _name == actor._name;
        }

        public override int GetHashCode()
        {
            return -1125283371 + EqualityComparer<string>.Default.GetHashCode(_name);
        }
    }
}

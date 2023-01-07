using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop
{
     public class Movie
    {
        private string _name;//private field
        public string Name
        {
            get { return this._name; }
            set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("name has to not be empty"); _name = value; }
        }
        private int _year;//private field
        public int Year
        {
            get { return this._year; }
            set { if (value < 0) throw new FieldAccessException("year has to be positive"); _year = value; }
        }
        private IList<Actor> _actors;//private field
        public IList<Actor> Actors
        {
            get { return this._actors; }
            set { if (value == null || value.Count < 0) throw new ArgumentNullException("the list of actors has to be contain least at 1 actor"); _actors = value; }
        }
        private Director _director;//private field
        public Director Director
        {
            get { return this._director; }
            set { if (string.IsNullOrEmpty(value.Name)) throw new ArgumentNullException("name has to not be empty"); _director = value; }
        }
        private Genre _genre;//private field
        public Genre Genre//dont add a conditons because it is enum that I had set
        {
            get { return _genre; }
            set { _genre = value; }
        }
        public Movie(string name, int year, IList<Actor> actors, Director director, Genre genre)
        {
            //there are the props in the ctor , that is allowd to keep the encapsulation and only leggal info will be able to set
            Name = name;
            Year = year;
            Actors = actors;
            Director = director;
            Genre = genre;
        }

        public override string ToString()
        {
            return $"Movie Name:{Name}\nYear:{Year}\nActors:{string.Join(", ",_actors)}\ndirector:{Director}\ngenre:{Genre}";
        }

        public override bool Equals(object obj)
        {
            return obj is Movie movie &&
                   _name == movie._name &&
                   _year == movie._year &&
                   EqualityComparer<IList<Actor>>.Default.Equals(_actors, movie._actors) &&
                   EqualityComparer<Director>.Default.Equals(_director, movie._director) &&
                   _genre == movie._genre;
        }

        public override int GetHashCode()
        {
            int hashCode = 268439151;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_name);
            hashCode = hashCode * -1521134295 + _year.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<Actor>>.Default.GetHashCode(_actors);
            hashCode = hashCode * -1521134295 + EqualityComparer<Director>.Default.GetHashCode(_director);
            hashCode = hashCode * -1521134295 + _genre.GetHashCode();
            return hashCode;
        }
    }
}

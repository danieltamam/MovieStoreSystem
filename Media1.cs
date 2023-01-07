using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop
{
     public class Media
    {
        private double _pricePerDay;//private field
        public double PricePerDay
        {
            get { return _pricePerDay; }
            set { if (value < 0) throw new FieldAccessException("the price has to be more than 0"); _pricePerDay = value; }
        }
        private Movie _movie;//private field
        public Movie Movie
        {
            get { return _movie; }
            set { if (string.IsNullOrEmpty(value.Name) || value == null) throw new ArgumentNullException("movie has to contain a name or could'nt be null"); _movie = value; }
        }
        private MediaType _type;//private field
        public MediaType Type { get { return _type; } set { _type = value; } }//dont add a conditons because it is enum that I had set

        public Media(double pricePerDay, Movie movie, MediaType type)//there are the props in the ctor , that is allowd to keep the encapsulation and only leggal info will be able to set
        {
            PricePerDay = pricePerDay;
            Movie = movie;
            Type = type;        
        }

        public override string ToString()
        {
            return $"Movie:{Movie}\n Type:{Type}\nprice per day{PricePerDay}";
        }

        public override bool Equals(object obj)
        {
            return obj is Media media &&
                   _pricePerDay == media._pricePerDay &&
                   EqualityComparer<Movie>.Default.Equals(_movie, media._movie) &&
                   _type == media._type;
        }

        public override int GetHashCode()
        {
            int hashCode = -1239920456;
            hashCode = hashCode * -1521134295 + _pricePerDay.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Movie>.Default.GetHashCode(_movie);
            hashCode = hashCode * -1521134295 + _type.GetHashCode();
            return hashCode;
        }
    }
}

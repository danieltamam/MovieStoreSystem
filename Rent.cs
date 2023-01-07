using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop
{
     public class Rent
    {
        private Customer _customer;//private field
        public Customer Customer
        {
            get { return _customer; }
            set { if (string.IsNullOrEmpty(value.Name)) throw new ArgumentNullException("name has to not be empty");_customer = value; }
        }
        private DateTime _rentTime;//private field
        public DateTime RentTime
        {
            get { return _rentTime; }
            set { if(value==null)throw new ArgumentNullException("time couldn't be null");_rentTime = value; }
        }

        public Rent(Customer customer, DateTime rentTime)//there are the props in the ctor , that is allowd to keep the encapsulation and only leggal info will be able to set
        {
            Customer = customer;
            RentTime = rentTime;
        }

        public override string ToString()
        {
            return $"customer:{Customer}\nrent time:{RentTime}";
        }

        public override bool Equals(object obj)
        {
            return obj is Rent rent &&
                   EqualityComparer<Customer>.Default.Equals(_customer, rent._customer) &&
                   _rentTime == rent._rentTime;
        }

        public override int GetHashCode()
        {
            int hashCode = -1077422346;
            hashCode = hashCode * -1521134295 + EqualityComparer<Customer>.Default.GetHashCode(_customer);
            hashCode = hashCode * -1521134295 + _rentTime.GetHashCode();
            return hashCode;
        }
    }
}

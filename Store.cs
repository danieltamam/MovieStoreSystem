using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop
{
     public class Store
    {
        private IList<Media> _medias;//private field
        public IList<Media> Medias
        {
            get { return this._medias; }
            set { if (value == null) throw new ArgumentNullException("the list of medias has to be contain list at least");_medias = value; }

        }
        private IList<Customer> _customers;//private field
        public IList<Customer> Customers
        {
            get { return this._customers; }
            set { if (value == null) throw new ArgumentNullException("the list of customers has to be contain list at least"); _customers = value; }
        }
        private IDictionary<Media, Rent> _rents;//private field
        public IDictionary<Media,Rent>Rents { get { return this._rents; } set { if (value == null) throw new ArgumentNullException("it is possible to add a empty dictionary but not null"); _rents = value; } }

        public Store(IList<Media> medias, IList<Customer> customers)
        {
            //there are the props in the ctor , that is allowd to keep the encapsulation and only leggal info will be able to set
            Medias = medias;
            Customers = customers;
            Rents = new Dictionary<Media, Rent>(); 
        }
        public void RentMedia(Customer customer,Media media,DateTime renttime)
        {
            this.Rents[media] = new Rent(customer, renttime);
        }
        public double ReturnMedia(Media media,DateTime endRentTime)
        {
            double price = (endRentTime - Rents[media].RentTime).TotalDays * media.PricePerDay;
            Rents.Remove(media);
            return price;
        }
        public List<Customer> GetAllTheCustomersThatRentMovieMoreThanXdays(double X)
        {
            List<Customer> customers = new List<Customer>();
            foreach (var i in _rents.Values)
            {
                if ((DateTime.Now - i.RentTime).TotalDays > X)
                {
                    customers.Add(i.Customer);
                }
            }
            return customers;
           

        }
        public override string ToString()
        {
            //option 1 is to do a foreach loop one every list or dictionary:

           // string medias = "";
           // //string customers="";
           //foreach(var media in _medias)
           // {
           //     medias += media;
           // }
           //foreach(var customer in Customers)
           // {
           //     customers += customer;
           // }

           //optin 2 is to use  string.Join function

            return $"medias:{string.Join(", ",_medias)}\ncustomers:{string.Join("\n",this.Customers)}\nrents:{string.Join("\n",Rents)}";
        }

        public override bool Equals(object obj)
        {
            return obj is Store store &&
                   EqualityComparer<IList<Media>>.Default.Equals(_medias, store._medias) &&
                   EqualityComparer<IList<Customer>>.Default.Equals(_customers, store._customers) &&
                   EqualityComparer<IDictionary<Media, Rent>>.Default.Equals(_rents, store._rents);
        }

        public override int GetHashCode()
        {
            int hashCode = -159984244;
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<Media>>.Default.GetHashCode(_medias);
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<Customer>>.Default.GetHashCode(_customers);
            hashCode = hashCode * -1521134295 + EqualityComparer<IDictionary<Media, Rent>>.Default.GetHashCode(_rents);
            return hashCode;
        }
    }
}

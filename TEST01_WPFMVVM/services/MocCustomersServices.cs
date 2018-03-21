using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST01_WPFMVVM.interfaces;
using TEST01_WPFMVVM.model;

namespace TEST01_WPFMVVM.services
{
    public class MocCustomersServices : ICustomersService
    {
        private ICollection<CustomerModel> customers;

        public MocCustomersServices()
        {
            customers = new List<CustomerModel>
            {
                //new CustomerModel {Id=1, Name = "Name01" },
                //new CustomerModel {Id=2, Name = "Name02" },
            };
        }
       
        public void Add(CustomerModel customer)
        {
            throw new NotImplementedException();
        }

        public ICollection<CustomerModel> Get()
        {
            throw new NotImplementedException();
        }

        public CustomerModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public CustomerModel Get(string name)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerModel customer)
        {
            throw new NotImplementedException();
        }
    }
}

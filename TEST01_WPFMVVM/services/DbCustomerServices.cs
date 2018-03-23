using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST01_WPFMVVM.interfaces;
using TEST01_WPFMVVM.model;

namespace TEST01_WPFMVVM.services
{
    public class DbCustomerServices : ICustomersService
    {
        public DbCustomerServices()
        {
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

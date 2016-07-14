using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticalLINQ
{
    public class CustomerTypeRepository
    {
        public List<CustomerType> Retrieve()
        {
            return new List<CustomerType>() {
                new CustomerType() { TypeId = 1, TypeName = "Corporate", DisplayOrder = 2 },
                new CustomerType() { TypeId = 2, TypeName = "Individual", DisplayOrder = 1 },
                new CustomerType() { TypeId = 3, TypeName = "Educator", DisplayOrder = 4 },
                new CustomerType() { TypeId = 4, TypeName = "Government", DisplayOrder = 3 }};
        }
    }
}

using PraticalLINQ.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticalLINQ
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? TypeId { get; set; }
        public string Email { get; set; }

        public List<Invoice> InvoiceList { get; set; }
    }
}

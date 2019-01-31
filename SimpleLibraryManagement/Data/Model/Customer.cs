using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleLibraryManagement.Data.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string  Name { get; set; }
        public object Books { get; internal set; }
    }
}

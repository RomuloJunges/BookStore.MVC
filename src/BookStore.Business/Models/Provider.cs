using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.MVC.Models
{
    public class Provider : Entity
    {
        public string Name { get; set; }

        public string Document { get; set; }

        public ProviderType ProviderType { get; set; }

        public Address Address { get; set; }

        public bool Active { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.MVC.Models
{
    public class Address : Entity
    {
        /* ADDRESS IN BRAZILIAN FORMAT */

        public Guid ProviderId { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string CEP { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public Provider Provider { get; set; }
    }
}

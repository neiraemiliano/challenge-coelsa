using System;
using System.Collections.Generic;
using System.Text;

namespace Coelsa.Domain.Entities
{
    public class Contacts : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}

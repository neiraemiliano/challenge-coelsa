using System;
using System.Collections.Generic;
using System.Text;

namespace Coelsa.Domain.QueryFilters
{
    public class ContactsQueryFilter
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}

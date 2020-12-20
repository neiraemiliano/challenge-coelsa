using Coelsa.Domain.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coelsa.Infra.Data.Interfaces
{
    public interface IUriService
    {
        Uri GetContactsPaginationUri(ContactsQueryFilter filter, string actionUrl);
    }
}

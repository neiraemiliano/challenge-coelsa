
using Coelsa.Domain.QueryFilters;
using Coelsa.Infra.Data.Interfaces;
using System;

namespace Coelsa.Infra.Data.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetContactsPaginationUri(ContactsQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }
    }
}

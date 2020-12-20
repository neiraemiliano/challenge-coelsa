using AutoMapper;
using Coelsa.Domain.Dtos;
using Coelsa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coelsa.Infra.Data.Mappings
{
    public class AutomapperProfile : Profile
    {

        public AutomapperProfile()
        {
            CreateMap<Contacts, ContactsDto>();
            CreateMap<ContactsDto, Contacts>();

        }

    }
}

using AutoMapper;
using Coelsa.API.Response;
using Coelsa.Domain.CustomEntitites;
using Coelsa.Domain.Dtos;
using Coelsa.Domain.Interfaces.Services;
using Coelsa.Domain.QueryFilters;
using Coelsa.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Coelsa.Infra.Data.Interfaces;

namespace Coelsa.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsService _ContactsService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public ContactsController(IContactsService ContactsService, IMapper mapper, IUriService uriService)
        {
            _ContactsService = ContactsService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Recuperar todos los contactos
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetAll))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ContactsDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetAll([FromQuery] ContactsQueryFilter filters)
        {
            var Contacts = _ContactsService.GetAllContacts(filters);
            var ContactsDtos = _mapper.Map<IEnumerable<ContactsDto>>(Contacts);

            var metadata = new Metadata
            {
                TotalCount = Contacts.TotalCount,
                PageSize = Contacts.PageSize,
                CurrentPage = Contacts.CurrentPage,
                TotalPages = Contacts.TotalPages,
                HasNextPage = Contacts.HasNextPage,
                HasPreviousPage = Contacts.HasPreviousPage,
                NextPageUrl = _uriService.GetContactsPaginationUri(filters, Url.RouteUrl(nameof(GetAll))).ToString(),
                PreviousPageUrl = _uriService.GetContactsPaginationUri(filters, Url.RouteUrl(nameof(GetAll))).ToString()
            };

            var response = new ApiResponse<IEnumerable<ContactsDto>>(ContactsDtos)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }

        /// <summary>
        /// Recuperar contacto por Id
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var Contacts = await _ContactsService.GetContacts(id);
            var ContactsDto = _mapper.Map<ContactsDto>(Contacts);
            var response = new ApiResponse<ContactsDto>(ContactsDto);
            return Ok(response);
        }

        /// <summary>
        /// Insertar nuevo contacto
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SaveNewEntity(ContactsDto ContactsDto)
        {
            var Contacts = _mapper.Map<Contacts>(ContactsDto);

            await _ContactsService.InsertContacts(Contacts);

            ContactsDto = _mapper.Map<ContactsDto>(Contacts);
            var response = new ApiResponse<ContactsDto>(ContactsDto);
            return Ok(response);
        }

        /// <summary>
        /// Actualizar contacto por Id
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> UpdateEntity(int id, ContactsDto ContactsDto)
        {
            var Contacts = _mapper.Map<Contacts>(ContactsDto);
            Contacts.Id = id;

            var result = await _ContactsService.UpdateContacts(Contacts);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        /// <summary>
        /// Eliminar contacto por Id
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await _ContactsService.DeleteContacts(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}

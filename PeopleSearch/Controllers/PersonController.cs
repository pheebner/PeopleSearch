using Microsoft.AspNetCore.Mvc;
using PeopleSearch.Business.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using PeopleSearch.Domain.Dto;

namespace PeopleSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Person>> SearchByName(string searchText) => await _personService.SearchByNameAsync(searchText);
    }
}
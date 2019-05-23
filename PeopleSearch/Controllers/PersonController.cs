using Microsoft.AspNetCore.Mvc;
using PeopleSearch.Business.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using PeopleSearch.Models;

namespace PeopleSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Person>> SearchByName(string searchText) =>
            (await _personService.SearchByNameAsync(searchText))
                .Select(p => _mapper.Map<Person>(p)).ToList();
    }
}
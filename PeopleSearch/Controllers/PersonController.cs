using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeopleSearch.Business.Interfaces;
using PeopleSearch.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpPost("[action]")]
        public async Task CreatePerson([FromBody] Person person) =>
            await _personService.CreatePersonAsync(_mapper.Map<Domain.Dto.Person>(person));
    }
}
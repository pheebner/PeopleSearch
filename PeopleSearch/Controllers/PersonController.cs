using Microsoft.AspNetCore.Mvc;
using PeopleSearch.Business.Interfaces;
using PeopleSearch.Business.Models;
using System.Collections.Generic;

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
        public IEnumerable<Person> Search(string searchText)
        {
            return _personService.Search(searchText);
        }
    }
}
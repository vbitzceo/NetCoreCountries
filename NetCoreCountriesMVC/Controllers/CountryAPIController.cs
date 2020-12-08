using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using voidBitz.NETCore.NetCoreCountries.Repository.Interfaces;

namespace NetCoreCountriesMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryAPIController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        public CountryAPIController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        [Produces("application/json")]
        [HttpGet("search")]
        public IActionResult Search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"];
                var search = _countryRepository.GetWhere(filter: a => a.Name.Contains(term), isTracking: false);
                var countryNames = search.Select(p => p.Name).ToList();

                return Ok(countryNames);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

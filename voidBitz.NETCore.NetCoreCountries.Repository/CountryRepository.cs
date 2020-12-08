using Microsoft.EntityFrameworkCore;
using System.Linq;
using voidBitz.NETCore.NetCoreCountries.DataAccess;
using voidBitz.NETCore.NetCoreCountries.Models;
using voidBitz.NETCore.NetCoreCountries.Repository.Interfaces;

namespace voidBitz.NETCore.NetCoreCountries.Repository
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        private readonly ApplicationDbContext _db = null;
        public CountryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public Country GetById(int id, bool includeNavigationProperties = false)
        {
            Country country;

            country = _db.Country.AsNoTracking().FirstOrDefault(c => c.Id == id);
           
            return country;
        }

        public bool Upsert(Country entity)
        {
            if (entity.Id == 0)
            {
                return base.AddWithSave(entity);
            }
            else
            {
                return base.UpdateWithSave(entity);
            }
        }
    }
}

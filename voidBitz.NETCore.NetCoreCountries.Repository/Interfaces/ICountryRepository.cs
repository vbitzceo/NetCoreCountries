using voidBitz.NETCore.Repository.Basees.Interfaces;
using voidBitz.NETCore.NetCoreCountries.Models;

namespace voidBitz.NETCore.NetCoreCountries.Repository.Interfaces
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        bool Upsert(Country entity);
        Country GetById(int id, bool includeNavigationProperties = false);
    }
}

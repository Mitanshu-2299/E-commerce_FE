
using ECommerce.Data.Model;


namespace ECommerce.Service.CountryService
{
    public interface ICountryService
    {
        Task<List<LocationModel>> GetCountriesAsync();
    }
}

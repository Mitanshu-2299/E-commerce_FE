using ECommerce.Config;
using ECommerce.Service.API;
using ECommerce.Data.Model;


namespace ECommerce.Service.CountryService
{
    public class CountryService : ICountryService
    {

        private readonly HttpClient _http;

        public CountryService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<LocationModel>> GetCountriesAsync()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ApiResponse<List<LocationModel>>>("listOfCountry");
                return response?.Data ?? new List<LocationModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching countries: {ex.Message}");
                return new List<LocationModel>();
            }
        }
    }
}
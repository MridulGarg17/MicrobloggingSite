using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
namespace GlitterDll
{
    public class GetCountry
    {
        private GlitterdbEntities glitterDb = new GlitterdbEntities();
        IList<CountryDto> countryList = new List<CountryDto>();

        public IList<CountryDto> GetAllCountry() {

            var countries = glitterDb.Countries.ToList();
            CountryDto countryObject;

            foreach (var x in countries) {
                countryObject = new CountryDto();
                countryObject.id = x.id;
                countryObject.name = x.name;

                countryList.Add(countryObject);

            }

            return countryList;
        }
    }
}

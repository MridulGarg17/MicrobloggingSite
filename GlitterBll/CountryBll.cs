using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlitterDll;
namespace GlitterBll
{
    public class CountryBll
    {

        public IList<CountryDto> getCountryList() {

            GetCountry xyz = new GetCountry();
            return xyz.GetAllCountry();
        }

    }
}

using System.Data;
using DVLD_Data;

namespace DVLD_Business
{
    public class clsCountry
    {
        public static DataTable GetAllCountries()
        {
            return clsCountry_DAL.GetAllCountries();
        }

        public static string GetCountryName(int CountryID)
        {
            return clsCountry_DAL.GetCountryNameBy(CountryID);
        }

        public static int GetCountryID(string CountryName)
        {
            return clsCountry_DAL.GetCountryIDBy(CountryName);
        }
    }
}

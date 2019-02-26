using LuckyForm.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LuckyForm.DAL
{
    
    public class CountryDB
    {
        DataTable dt;
        SqlHelper sqlHelper;
        public CountryDB()
        {
            this.sqlHelper = new SqlHelper();
        }

        public CountryDB(string path)
        {
            this.sqlHelper = new SqlHelper(path);
        }
        public List<Country> GetAllCountries()
        {
            string sql = @"SELECT * FROM Countries";
            this.dt = this.sqlHelper.GetData(sql);
            if (this.dt != null && this.dt.Rows.Count > 0)
            {
                List<Country> allCountries = new List<Country>();
                foreach (DataRow dr in this.dt.Rows)
                {
                    Country country = new Country();
                    country.ID = dr["CountriesID"].ToString();
                    country.Name = dr["CountriesName"].ToString();
                    country.Tel = dr["CountriesTel"].ToString();
                    country.Fax = dr["CountriesFax"].ToString();
                    country.Img = dr["CountriesImg"].ToString();

                    allCountries.Add(country);
                }
                return allCountries;
            }
            return null;
        }
    }
}
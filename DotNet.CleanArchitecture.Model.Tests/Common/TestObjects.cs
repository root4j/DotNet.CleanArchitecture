using DotNet.CleanArchitecture.Model.Entity.General;
using System;

namespace DotNet.CleanArchitecture.Model.Tests.Common
{
    public class TestObjects
    {
        public static string CityCode { get { return "COL-88001"; } }
        public static string CityName { get { return "San Andres Island"; } }
        public static string CountryCode { get { return "COL"; } }
        public static string CountryName { get { return "Colombia"; } }
        public static string StateCode { get { return "COL-88"; } }
        public static string StateName { get { return "San Andres Island"; } }
        public static string ValueListCode { get { return "Gen-Document-Id"; } }
        public static string ValueListCategory { get { return "Gen-Documents"; } }

        public static City GetCity()
        {
            var city = new City
            {
                CityCode = CityCode,
                StateCode = StateCode,
                CityName = "San Andres",
                Latitude = "12.58301369",
                Longitude = "-81.69606298",
                State = GetState(),
                CreatedBy = "Test",
                CreationDate = DateTime.Now,
                ModifiedBy = "Test",
                ModificationDate = DateTime.Now,
                RowStatus = "A"
            };
            return city;
        }

        public static Country GetCountry()
        {
            var country = new Country
            {
                CountryCode = CountryCode,
                CountryName = "Republic of Colombia",
                Alfa2Code = "CO",
                NumberCode = "170",
                InternetCode = ".co",
                CreatedBy = "Test",
                CreationDate = DateTime.Now,
                ModifiedBy = "Test",
                ModificationDate = DateTime.Now,
                RowStatus = "A"
            };
            return country;
        }

        public static State GetState()
        {
            var state = new State
            {
                StateCode = StateCode,
                CountryCode = CountryCode,
                StateName = "Archipielago De San Andres, Providencia Y Santa Catalina",
                Latitude = "12.58301369",
                Longitude = "-81.69606298",
                Country = GetCountry(),
                CreatedBy = "Test",
                CreationDate = DateTime.Now,
                ModifiedBy = "Test",
                ModificationDate = DateTime.Now,
                RowStatus = "A"
            };
            return state;
        }

        public static ValueList GetValueList()
        {
            var valueList = new ValueList
            {
                ValueListCode = ValueListCode,
                ValueListCategory = "Gen-Document",
                ListOrder = 1,
                ShortDescription = "Id",
                LongDescription = "Document Id",
                CreatedBy = "Test",
                CreationDate = DateTime.Now,
                ModifiedBy = "Test",
                ModificationDate = DateTime.Now,
                RowStatus = "A"
            };
            return valueList;
        }
    }
}
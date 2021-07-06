using DotNet.CleanArchitecture.Model.Business.General;
using DotNet.CleanArchitecture.Model.Tests.Common;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DotNet.CleanArchitecture.Model.Tests.General
{
    public class CountryBusinessTests
    {
        private const string Entity = "Country";

        [Fact]
        public async Task CreateCountry_Returns_Ok_If_Was_Created()
        {
            #region Arrange
            string database = string.Format("{0}_create_{1}", Entity, Guid.NewGuid());
            var business = new CountryBusiness(TestDbContext.GetDatabase(database));
            #endregion

            #region Act
            var country = TestObjects.GetCountry();
            string countryCode = country.CountryCode;
            await business.CreateAsync(countryCode, country);
            var actionResult = await business.ReadAsync(countryCode);
            #endregion

            #region Assert
            var result = actionResult;
            Assert.Equal(countryCode, result?.CountryCode);
            #endregion
        }

        [Fact]
        public async Task UpdateCountry_Returns_Ok_If_Was_Updated()
        {
            #region Arrange
            string database = string.Format("{0}_update_{1}", Entity, Guid.NewGuid());
            var business = new CountryBusiness(TestDbContext.GetDatabase(database));
            #endregion

            #region Act
            string countryCode = TestObjects.CountryCode;
            string countryName = TestObjects.CountryName;
            var country = TestObjects.GetCountry();
            await business.CreateAsync(countryCode, country);
            country = await business.ReadAsync(countryCode);
            country.CountryName = countryName;
            await business.UpdateAsync(countryCode, country);
            var actionResult = await business.ReadAsync(countryCode);
            #endregion

            #region Assert
            var result = actionResult;
            Assert.Equal(countryName, result?.CountryName);
            #endregion
        }

        [Fact]
        public async Task ReadCountry_Returns_Ok_If_Wasnt_Read()
        {
            #region Arrange
            string database = string.Format("{0}_read_{1}", Entity, Guid.NewGuid());
            var business = new CountryBusiness(TestDbContext.GetDatabase(database));
            #endregion

            #region Act
            string countryCode = TestObjects.CountryCode;
            var actionResult = await business.ReadAsync(countryCode);
            #endregion

            #region Assert
            var result = actionResult;
            Assert.Null(result);
            #endregion
        }

        [Fact]
        public async Task DeleteCountry_Returns_Ok_If_Was_Deleted()
        {
            #region Arrange
            string database = string.Format("{0}_delete_{1}", Entity, Guid.NewGuid());
            var business = new CountryBusiness(TestDbContext.GetDatabase(database));
            #endregion

            #region Act
            var country = TestObjects.GetCountry();
            string countryCode = country.CountryCode;
            await business.CreateAsync(countryCode, country);
            await business.DeleteAsync(countryCode);
            var actionResult = await business.ReadAsync(countryCode);
            #endregion

            #region Assert
            var result = actionResult;
            Assert.Null(result);
            #endregion
        }
    }
}
using DotNet.CleanArchitecture.Model.Business.General;
using DotNet.CleanArchitecture.Model.Tests.Common;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DotNet.CleanArchitecture.Model.Tests.General
{
    public class CityBusinessTests
    {
        private const string Entity = "City";

        [Fact]
        public async Task CreateCity_Returns_Ok_If_Was_Created()
        {
            #region Arrange
            string database = string.Format("{0}_create_{1}", Entity, Guid.NewGuid());
            var business = new CityBusiness(TestDbContext.GetDatabase(database));
            #endregion

            #region Act
            var city = TestObjects.GetCity();
            string cityCode = city.CityCode;
            await business.CreateAsync(cityCode, city);
            var actionResult = await business.ReadAsync(cityCode);
            #endregion

            #region Assert
            var result = actionResult;
            Assert.Equal(cityCode, result?.CityCode);
            #endregion
        }

        [Fact]
        public async Task UpdateCity_Returns_Ok_If_Was_Updated()
        {
            #region Arrange
            string database = string.Format("{0}_update_{1}", Entity, Guid.NewGuid());
            var business = new CityBusiness(TestDbContext.GetDatabase(database));
            #endregion

            #region Act
            string cityCode = TestObjects.CityCode;
            string cityName = TestObjects.CityName;
            var city = TestObjects.GetCity();
            await business.CreateAsync(cityCode, city);
            city = await business.ReadAsync(cityCode);
            city.CityName = cityName;
            await business.UpdateAsync(cityCode, city);
            var actionResult = await business.ReadAsync(cityCode);
            #endregion

            #region Assert
            var result = actionResult;
            Assert.Equal(cityName, result?.CityName);
            #endregion
        }

        [Fact]
        public async Task ReadCity_Returns_Ok_If_Wasnt_Read()
        {
            #region Arrange
            string database = string.Format("{0}_read_{1}", Entity, Guid.NewGuid());
            var business = new CityBusiness(TestDbContext.GetDatabase(database));
            #endregion

            #region Act
            string cityCode = TestObjects.CityCode;
            var actionResult = await business.ReadAsync(cityCode);
            #endregion

            #region Assert
            var result = actionResult;
            Assert.Null(result);
            #endregion
        }

        [Fact]
        public async Task DeleteCity_Returns_Ok_If_Was_Deleted()
        {
            #region Arrange
            string database = string.Format("{0}_delete_{1}", Entity, Guid.NewGuid());
            var business = new CityBusiness(TestDbContext.GetDatabase(database));
            #endregion

            #region Act
            var city = TestObjects.GetCity();
            string cityCode = city.CityCode;
            await business.CreateAsync(cityCode, city);
            await business.DeleteAsync(cityCode);
            var actionResult = await business.ReadAsync(cityCode);
            #endregion

            #region Assert
            var result = actionResult;
            Assert.Null(result);
            #endregion
        }
    }
}
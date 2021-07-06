using DotNet.CleanArchitecture.Model.Business.General;
using DotNet.CleanArchitecture.Model.Tests.Common;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DotNet.CleanArchitecture.Model.Tests.General
{
    public class ValueListBusinessTests
    {
        private const string Entity = "ValueList";

        [Fact]
        public async Task CreateValueList_Returns_Ok_If_Was_Created()
        {
            #region Arrange
            string database = string.Format("{0}_create_{1}", Entity, Guid.NewGuid());
            var business = new ValueListBusiness(TestDbContext.GetDatabase(database));
            #endregion

            #region Act
            var valueList = TestObjects.GetValueList();
            string valueListCode = valueList.ValueListCode;
            await business.CreateAsync(valueListCode, valueList);
            var actionResult = await business.ReadAsync(valueListCode);
            #endregion

            #region Assert
            var result = actionResult;
            Assert.Equal(valueListCode, result?.ValueListCode);
            #endregion
        }

        [Fact]
        public async Task UpdateValueList_Returns_Ok_If_Was_Updated()
        {
            #region Arrange
            string database = string.Format("{0}_update_{1}", Entity, Guid.NewGuid());
            var business = new ValueListBusiness(TestDbContext.GetDatabase(database));
            #endregion

            #region Act
            string valueListCode = TestObjects.ValueListCode;
            string valueListCategory = TestObjects.ValueListCategory;
            var valueList = TestObjects.GetValueList();
            await business.CreateAsync(valueListCode, valueList);
            valueList = await business.ReadAsync(valueListCode);
            valueList.ValueListCategory = valueListCategory;
            await business.UpdateAsync(valueListCode, valueList);
            var actionResult = await business.ReadAsync(valueListCode);
            #endregion

            #region Assert
            var result = actionResult;
            Assert.Equal(valueListCategory, result?.ValueListCategory);
            #endregion
        }

        [Fact]
        public async Task ReadValueList_Returns_Ok_If_Wasnt_Read()
        {
            #region Arrange
            string database = string.Format("{0}_read_{1}", Entity, Guid.NewGuid());
            var business = new ValueListBusiness(TestDbContext.GetDatabase(database));
            #endregion

            #region Act
            string valueListCode = TestObjects.ValueListCode;
            var actionResult = await business.ReadAsync(valueListCode);
            #endregion

            #region Assert
            var result = actionResult;
            Assert.Null(result);
            #endregion
        }

        [Fact]
        public async Task DeleteValueList_Returns_Ok_If_Was_Deleted()
        {
            #region Arrange
            string database = string.Format("{0}_delete_{1}", Entity, Guid.NewGuid());
            var business = new ValueListBusiness(TestDbContext.GetDatabase(database));
            #endregion

            #region Act
            var valueList = TestObjects.GetValueList();
            string valueListCode = valueList.ValueListCode;
            await business.CreateAsync(valueListCode, valueList);
            await business.DeleteAsync(valueListCode);
            var actionResult = await business.ReadAsync(valueListCode);
            #endregion

            #region Assert
            var result = actionResult;
            Assert.Null(result);
            #endregion
        }
    }
}
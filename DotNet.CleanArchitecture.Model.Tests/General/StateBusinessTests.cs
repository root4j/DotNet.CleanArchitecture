using DotNet.CleanArchitecture.Model.Business.General;
using DotNet.CleanArchitecture.Model.Tests.Common;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DotNet.CleanArchitecture.Model.Tests.General
{
    public class StateBusinessTests
    {
        private const string Entity = "State";

        [Fact]
        public async Task CreateState_Returns_Ok_If_Was_Created()
        {
            #region Arrange
            string database = string.Format("{0}_create_{1}", Entity, Guid.NewGuid());
            var business = new StateBusiness(TestDbContext.GetDatabase(database));
            #endregion

            #region Act
            var state = TestObjects.GetState();
            string stateCode = state.StateCode;
            await business.CreateAsync(stateCode, state);
            var actionResult = await business.ReadAsync(stateCode);
            #endregion

            #region Assert
            var result = actionResult;
            Assert.Equal(stateCode, result?.StateCode);
            #endregion
        }

        [Fact]
        public async Task UpdateState_Returns_Ok_If_Was_Updated()
        {
            #region Arrange
            string database = string.Format("{0}_update_{1}", Entity, Guid.NewGuid());
            var business = new StateBusiness(TestDbContext.GetDatabase(database));
            #endregion

            #region Act
            string stateCode = TestObjects.StateCode;
            string stateName = TestObjects.StateName;
            var state = TestObjects.GetState();
            await business.CreateAsync(stateCode, state);
            state = await business.ReadAsync(stateCode);
            state.StateName = stateName;
            await business.UpdateAsync(stateCode, state);
            var actionResult = await business.ReadAsync(stateCode);
            #endregion

            #region Assert
            var result = actionResult;
            Assert.Equal(stateName, result?.StateName);
            #endregion
        }

        [Fact]
        public async Task ReadState_Returns_Ok_If_Wasnt_Read()
        {
            #region Arrange
            string database = string.Format("{0}_read_{1}", Entity, Guid.NewGuid());
            var business = new StateBusiness(TestDbContext.GetDatabase(database));
            #endregion

            #region Act
            string stateCode = TestObjects.StateCode;
            var actionResult = await business.ReadAsync(stateCode);
            #endregion

            #region Assert
            var result = actionResult;
            Assert.Null(result);
            #endregion
        }

        [Fact]
        public async Task DeleteState_Returns_Ok_If_Was_Deleted()
        {
            #region Arrange
            string database = string.Format("{0}_delete_{1}", Entity, Guid.NewGuid());
            var business = new StateBusiness(TestDbContext.GetDatabase(database));
            #endregion

            #region Act
            var state = TestObjects.GetState();
            string stateCode = state.StateCode;
            await business.CreateAsync(stateCode, state);
            await business.DeleteAsync(stateCode);
            var actionResult = await business.ReadAsync(stateCode);
            #endregion

            #region Assert
            var result = actionResult;
            Assert.Null(result);
            #endregion
        }
    }
}
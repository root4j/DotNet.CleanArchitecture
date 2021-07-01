using DotNet.CleanArchitecture.Model.Common;
using System;

namespace DotNet.CleanArchitecture.Model.Exceptions
{
    [Serializable]
    public class NonObjectFoundException : SystemException
    {
        public NonObjectFoundException() : base(Constants.EXCEPTION_MESSAGEKEY_NONOBJECTFOUND)
        {
        }
    }
}
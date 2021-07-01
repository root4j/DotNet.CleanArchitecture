using DotNet.CleanArchitecture.Model.Common;
using System;

namespace DotNet.CleanArchitecture.Model.Exceptions
{
    [Serializable]
    public class NonEqualObjectException : SystemException
    {
        public NonEqualObjectException() : base(Constants.EXCEPTION_MESSAGEKEY_NONEQUALOBJECT)
        {
        }
    }
}
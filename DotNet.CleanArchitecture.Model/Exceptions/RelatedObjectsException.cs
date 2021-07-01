using DotNet.CleanArchitecture.Model.Common;
using System;

namespace DotNet.CleanArchitecture.Model.Exceptions
{
    [Serializable]
    public class RelatedObjectsException : SystemException
    {
        public RelatedObjectsException() : base(Constants.EXCEPTION_MESSAGEKEY_RELATEDOBJECTS)
        {
        }
    }
}
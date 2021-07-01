using DotNet.CleanArchitecture.Model.Common;
using System;

namespace DotNet.CleanArchitecture.Model.Exceptions
{
    [Serializable]
    public class EqualUniqueRowException : SystemException
    {
        public EqualUniqueRowException() : base(Constants.EXCEPTION_MESSAGEKEY_EQUALUNIQUEROW)
        {
        }
    }
}
// Type: Common.BusinessRulesException
// Assembly: Common, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Xavier\Documents\Visual Studio 2010\Projects\MDSManager\Common.dll

using System;

namespace Common.Exceptions
{
    public class BusinessRulesException : Exception
    {
        public BusinessRulesException(string message)
            : base(message)
        {
        }

        public BusinessRulesException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

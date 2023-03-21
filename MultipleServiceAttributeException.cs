using System;

namespace Contool
{
    public class MultipleServiceAttributeException : Exception
    {
        public MultipleServiceAttributeException(Type classType) 
            : base($"Multiple service attributes are declared at class '{classType.FullName}'.")
        {
        }
    }
}
